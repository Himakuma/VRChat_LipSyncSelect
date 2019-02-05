using ExpansionTools.LipSyncSelect.tmp;
using BearUnityLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using UnityEditor;
using UnityEngine;
using VRCSDK2;
using System.IO;

[CustomEditor(typeof(VRC_AvatarDescriptor))]
public class LipSyncSelect : AvatarDescriptorEditor
{

    private static string[] copyVisemeBlendShapes;

    /// <summary>
    /// 対応する値保持
    /// </summary>
    public class LipSyncMapping
    {
        string toVisemeName = string.Empty;
        string blendShapeName = string.Empty;

        public LipSyncMapping(string toVisemeName, string blendShapeName)
        {
            this.toVisemeName = toVisemeName;
            this.blendShapeName = blendShapeName;
        }
    }

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        RightMenu(GUILayoutUtility.GetLastRect());

    }


    private void LoadFileMenu(GenericMenu menu)
    {
        menu.AddSeparator("");
        menu.AddItem(new GUIContent("Lip Sync Auto Select(.*[^A-Za-z]sil$)"), false, () => {
            LipSyncAutoSelect();
        });

        // 配置済みクラスから、リップシンクのリストを作成
        var lipTmps = new Dictionary<string, ITmpInterface>();
        foreach (var assemblie in AppDomain.CurrentDomain.GetAssemblies())
        {
            foreach (var classInfo in assemblie.GetTypes().Where(t => t.IsClass && t.Namespace == @"ExpansionTools.LipSyncSelect.tmp").ToList())
            {
                lipTmps.Add(classInfo.Name.Substring(0, classInfo.Name.Length - 3), (ITmpInterface)Activator.CreateInstance(classInfo));
            }
        }

        // 文字列ソート
        var keys = lipTmps.Keys.ToArray();
        Array.Sort(keys);

        foreach(string lipSyncName in keys)
        {
            menu.AddItem(new GUIContent(lipSyncName), false, () => {
                LipSyncAutoSelect(lipTmps[lipSyncName]);
            });
        }
    }


    private void RightMenu(Rect rect)
    {
        GUI.enabled = true;
        if (Event.current.type == EventType.MouseDown && Event.current.button == 1)
        {
            GenericMenu menu = new GenericMenu();
            menu.AddItem(new GUIContent("Copy"), false, () => {
                LipSyncCopy();
            });

            menu.AddItem(new GUIContent("Paste"), false, () => {
                LipSyncPaste();
            });

            menu.AddItem(new GUIContent("Export"), false, () => {
                LipSyncExport();
            });


            LoadFileMenu(menu);
            menu.ShowAsContext();
        }
    }

    private VRC_AvatarDescriptor GetVRCAvatarDescriptor()
    {
        Type baseType = GetType().BaseType;
        return (VRC_AvatarDescriptor)baseType.GetField("avatarDescriptor", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(this);
    }

    private List<string> GetBlendShapeNames()
    {
        Type baseType = GetType().BaseType;
        return (List<string>)baseType.GetField("blendShapeNames", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(this);
    }

    /// <summary>
    /// アクティブの情報をコピー
    /// </summary>
    private void LipSyncCopy()
    {
        VRC_AvatarDescriptor avatarDescriptor = GetVRCAvatarDescriptor();
        if (avatarDescriptor.lipSync == VRC_AvatarDescriptor.LipSyncStyle.VisemeBlendShape)
        {
            copyVisemeBlendShapes = avatarDescriptor.VisemeBlendShapes;
        }
    }

    /// <summary>
    /// コピー情報の内容を設定
    /// </summary>
    private void LipSyncPaste()
    {
        VRC_AvatarDescriptor avatarDescriptor = GetVRCAvatarDescriptor();
        if (avatarDescriptor.lipSync == VRC_AvatarDescriptor.LipSyncStyle.VisemeBlendShape && copyVisemeBlendShapes != null)
        {
            List<string> blendShapeNames = GetBlendShapeNames();
            for (int i = 0; i < copyVisemeBlendShapes.Length; i++)
            {
                string[] matchNames = blendShapeNames.Where(t => t == copyVisemeBlendShapes[i]).ToArray();
                if (0 < matchNames.Length)
                {
                    avatarDescriptor.VisemeBlendShapes[i] = matchNames[0];
                }
            }
        }
    }

    /// <summary>
    /// アクティブの情報出力
    /// </summary>
    private void LipSyncExport()
    {
        string tmpPath = Path.Combine(Application.dataPath, "ExpansionTools/LipSyncSelect/tmp/ClassTemplate.cs.template");
        string exportText = BearFileUtil.GetAllText(tmpPath);


        VRC_AvatarDescriptor avatarDescriptor = GetVRCAvatarDescriptor();
        if (avatarDescriptor.lipSync == VRC_AvatarDescriptor.LipSyncStyle.VisemeBlendShape)
        {
            var visemeBlendShapes = avatarDescriptor.VisemeBlendShapes;

            List<string> blendShapeNames = GetBlendShapeNames();
            for (int i = 0; i < visemeBlendShapes.Length; i++)
            {
                string[] matchNames = blendShapeNames.Where(t => t == visemeBlendShapes[i]).ToArray();
                if (0 < matchNames.Length)
                {
                    string replaceKey = "@" + ((VRC_AvatarDescriptor.Viseme)i).ToString() + "@";
                    exportText = exportText.Replace(replaceKey, matchNames[0]);
                }
            }
        }
        var exportWindow = EditorWindow.GetWindow<LipSyncExport>(true);
        exportWindow.exportText = exportText;
        exportWindow.position = new Rect(200f, 200f, 300f, 100f);
    }

    /// <summary>
    /// 設定処理
    /// </summary>
    /// <param name="tmpData">設定値情報</param>
    private void LipSyncAutoSelect(ITmpInterface tmpData = null)
    {
        VRC_AvatarDescriptor avatarDescriptor = GetVRCAvatarDescriptor();
        Dictionary<VRC_AvatarDescriptor.Viseme, string> matchData = tmpData == null ? null : tmpData.GetDataSet() ;

        if (avatarDescriptor.lipSync == VRC_AvatarDescriptor.LipSyncStyle.VisemeBlendShape)
        {
            List<string> blendShapeNames = GetBlendShapeNames();
            foreach (string name in Enum.GetNames(typeof(VRC_AvatarDescriptor.Viseme)))
            {
                if ("Count" == name) continue;


                VRC_AvatarDescriptor.Viseme selectVisem = (VRC_AvatarDescriptor.Viseme)Enum.Parse(typeof(VRC_AvatarDescriptor.Viseme), name);
                if (matchData == null)
                {
                    string pattern = ".*[^A-Za-z]" + name.ToLower() + "$";
                    string[] matchNames = blendShapeNames.Where(t => t.ToLower() == name.ToLower() || Regex.IsMatch(t.ToLower(), pattern)).ToArray();
                    if (0 < matchNames.Length)
                    {
                        avatarDescriptor.VisemeBlendShapes[(int)selectVisem] = matchNames[0];
                    }
                }
                else
                {
                    avatarDescriptor.VisemeBlendShapes[(int)selectVisem] = matchData[selectVisem];
                }
            }
        }
    }
}

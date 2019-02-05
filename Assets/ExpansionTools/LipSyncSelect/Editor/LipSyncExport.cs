using BearUnityLib;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using UnityEditor;
using UnityEngine;

public class LipSyncExport : EditorWindow
{
    public string exportText = "";
    private string fileName = "";

    void OnGUI()
    {
        EditorGUILayout.BeginVertical();
        GUILayout.FlexibleSpace();
        {
            EditorGUILayout.BeginHorizontal();
            GUILayout.FlexibleSpace();
            {
                GUILayout.Label("ファイル名を半角英数字で入力してください。");
            }
            GUILayout.FlexibleSpace();
            EditorGUILayout.EndHorizontal();



            EditorGUILayout.BeginHorizontal();
            GUILayout.FlexibleSpace();
            EditorGUILayout.BeginVertical();
            GUILayout.FlexibleSpace();
            {

                EditorGUILayout.BeginHorizontal();
                GUILayout.FlexibleSpace();
                EditorGUILayout.BeginVertical();
                GUILayout.FlexibleSpace();
                {
                    fileName = GUILayout.TextField(fileName, GUILayout.Width(150f));
                }
                GUILayout.FlexibleSpace();
                EditorGUILayout.EndVertical();
                GUILayout.FlexibleSpace();
                EditorGUILayout.EndHorizontal();

                EditorGUILayout.BeginHorizontal();
                GUILayout.FlexibleSpace();
                EditorGUILayout.BeginVertical();
                GUILayout.FlexibleSpace();
                {
                    if (GUILayout.Button("OK", GUILayout.Height(25f), GUILayout.Width(40f)))
                    {
                        if (Regex.IsMatch(fileName, @"[^a-zA-Z0-9]"))
                        {
                            EditorUtility.DisplayDialog("エラー", "ファイル名は半角英数字で入力してください。", "OK");
                        }
                        else
                        {
                            string className = char.ToUpper(fileName[0]) + fileName.Substring(1);
                            exportText = exportText.Replace("@CLASS_NAME@", className);

                            string tmpPath = Path.Combine(Application.dataPath, "ExpansionTools/LipSyncSelect/tmp/" + className + "Tmp.cs");
                            if (!BearFileUtil.WriteText(exportText, tmpPath, Encoding.GetEncoding("UTF-8"), true))
                            {
                                EditorUtility.DisplayDialog("エラー", "ファイルの保存に失敗しました。\nもう一度やり直いて下さい。", "OK");
                            }
                            Close();
                            AssetDatabase.Refresh();
                        }
                    }
                }
                GUILayout.FlexibleSpace();
                EditorGUILayout.EndVertical();
                GUILayout.FlexibleSpace();
                EditorGUILayout.EndHorizontal();

            }
            GUILayout.FlexibleSpace();
            EditorGUILayout.EndVertical();
            GUILayout.FlexibleSpace();
            EditorGUILayout.EndHorizontal();

        }
        GUILayout.FlexibleSpace();
        EditorGUILayout.EndVertical();
    }
}

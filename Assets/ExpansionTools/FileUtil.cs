using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;

public class FileUtil
{
    /// <summary>
    /// 同一ファイル名が存在する場合、インデックスを追加して返却
    /// </summary>
    /// <param name="filePath"></param>
    /// <returns></returns>
    public static string ExistsFilePathRename(string filePath)
    {
        string renameFilePath = filePath;
        string dirPath = Path.GetDirectoryName(filePath);
        string baseFileName = Path.GetFileNameWithoutExtension(filePath);
        string extension = Path.GetExtension(filePath);

        int fileIndex = 1;
        while (File.Exists(renameFilePath))
        {
            string fileName = baseFileName + "(" + fileIndex + ")." + extension;
            renameFilePath = Path.Combine(dirPath, fileName);
            fileIndex++;
        }
        return renameFilePath;
    }


    /// <summary>
    /// テキストファイル書き出し
    /// </summary>
    /// <param name="writeText"></param>
    /// <param name="savePath"></param>
    /// <param name="encoding"></param>
    /// <param name="orverWrite"></param>
    /// <returns></returns>
    public static bool WriteText(string writeText, string savePath, Encoding encoding, bool orverWrite = false)
    {
        CreateFilePathDir(savePath);
        FileMode fileMode = orverWrite ? FileMode.Append : FileMode.OpenOrCreate;
        for (int i = 0; i < 5; i++)
        {
            try
            {
                using (FileStream fileStream = new FileStream(savePath, fileMode, FileAccess.Write))
                using (StreamWriter writer = new StreamWriter(fileStream, encoding))
                {
                    writer.Write(writeText);
                }
                return true;
            }
            catch
            {
                Thread.Sleep(500);
                continue;
            }
        }
        return false;
    }

    /// <summary>
    /// ファイルパスからディレクトリを作成
    /// </summary>
    /// <param name="filePath"></param>
    public static void CreateFilePathDir(string filePath)
    {
        string dirPath = Path.GetDirectoryName(filePath);
        if (!Directory.Exists(dirPath))
        {
            Directory.CreateDirectory(dirPath);
        }
    }

    /// <summary>
    /// 特定拡張子のファイル一覧を取得
    /// </summary>
    /// <param name="dirPath"></param>
    /// <param name="extension"></param>
    /// <returns></returns>
    public static string[] GetFileType(string dirPath, string extension)
    {
        return Directory.GetFiles(dirPath, "*." + extension, SearchOption.TopDirectoryOnly);
    }
}

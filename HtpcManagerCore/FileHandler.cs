using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace HtpcManagerCore
{
    public static class FileHandler
    {
        private const string sourceDirPath = @"\\10.0.0.6\media\daten\downloads\complete";
        private static string destDirPath;

        internal static void MoveAllFiles()
        {
            var filePaths = new List<string>(Directory.EnumerateFiles(sourceDirPath, "*.mkv", SearchOption.AllDirectories));
            Console.WriteLine($"Files found: {filePaths.Count}");
            filePaths.ForEach(filePath => MoveFile(filePath));
        }

        private static void MoveFile(string filePath)
        {
            Console.WriteLine(filePath);
            FileInfo actualFile = new FileInfo(filePath);


            Console.WriteLine($"Successfully moved \"{actualFile.Name}\" to directory {destDirPath}");
        }


    }
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace HtpcManagerCore
{
    public class FileHandler
    {
        private const string _sourceDirPath = @"\\10.0.0.6\media\daten\downloads\complete";
        private string _destPath = @"\\10.0.0.6\media\daten\tv";
        private string _userDefinedCategory;
        private FileInfo _actualFile;

        public FileHandler(string[] args)
        {
            _userDefinedCategory = args[4];
        }

        internal void MoveAllFiles()
        {
            var filePaths = new List<string>(Directory.EnumerateFiles(_sourceDirPath, " *.mkv", SearchOption.AllDirectories));
            Console.WriteLine($"Files found: {filePaths.Count}");
            filePaths.ForEach(filePath => MoveFile(filePath));
        }

        private void MoveFile(string filePath)
        {
            Console.WriteLine(filePath);
            _actualFile = new FileInfo(filePath);

            if (!_actualFile.Name.Contains("sample") && _userDefinedCategory.Equals("movie"))
            {
                string destFileName = MoveMovie();
                Console.WriteLine($"Successfully moved \"{_actualFile.Name}\" to directory {destFileName}");
            }

        }

        /// <summary>
        /// Moves a File of the Category "Movie"
        /// </summary>
        private string MoveMovie()
        {
            string year = DateTime.Now.Year.ToString();
            string destFileName = _destPath + $@"\filme\{year}";
            _actualFile.MoveTo(destFileName);
            return destFileName;
        }
    }
}

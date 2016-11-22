using System;
using System.Linq;
using System.IO;

namespace FileManager
{
    class DirectoryReader
    {
        private static readonly Lazy<DirectoryReader> lazy = new Lazy<DirectoryReader>(() => new DirectoryReader());
        public static DirectoryReader directoryReader { get { return lazy.Value; } }
        private DirectoryReader()
        {
        }

        public bool IsInProccess { get; set; }

        public bool DirectoryWatcher(string directory)
        {
            return Directory.EnumerateFiles(directory).Any();
        }

        public void ReadAllFiles(string fileFullPath)
        {
            if (DirectoryWatcher(fileFullPath))
            {
                IsInProccess = true;
                string[] filePaths = Directory.GetFiles(fileFullPath, "*.*", SearchOption.AllDirectories);

                foreach (string filePath in filePaths)
                {
                    FileReader.fileReader.Read(filePath);
                }
                IsInProccess = false;
            }
        }
    }
}
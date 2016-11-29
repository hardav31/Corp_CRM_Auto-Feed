using System;
using System.IO;
using LogManager;

namespace FileManager
{
    class FolderMonitor
    {
       public FileSystemWatcher watcher = new FileSystemWatcher();


        public FolderMonitor(string path)
        {
            watcher.Path = path;
            watcher.IncludeSubdirectories = true;
            watcher.EnableRaisingEvents = true;
            watcher.Created += Watcher_Created;
            watcher.Filter = "*.*";
             
        }

        private static  void Watcher_Created(object sender, FileSystemEventArgs e)
        {
            while (DirectoryReader.directoryReader.IsInProccess) ;
            try
            {

                bool isloaded = false;
                while (!isloaded)
                {
                    isloaded = IsFileLoaded(e.FullPath);
                }

                FileReader.fileReader.Read(e.FullPath);
            }
            catch (Exception ex)
            {
                LoggerType.WriteToLog(Path.GetFileName(e.FullPath), ex);
            }


        }


        public static bool IsFileLoaded(string direction)
        {
            
            try
            {
                using (FileStream stream = File.Open(direction, FileMode.Open, FileAccess.Read, FileShare.None))
                {
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }
        
    }

}

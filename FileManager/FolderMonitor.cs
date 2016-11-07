using System;
using System.IO;
using Pbar;
using App_Configuration;

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
            watcher.Deleted += Watcher_Deleted;
            watcher.Created += Watcher_Created;
            watcher.Filter = "*.*";
        }
        //TODO : Checking Path exeption

        private static void Watcher_Created(object sender, FileSystemEventArgs e)
        {
            try
            {
                if (new FileInfo(e.FullPath).Length / (1024 * 1024) > 1000)//if(size>1gb)
                {
                    //log: File is very big;
                    MoveFile(e.FullPath, AppConfigManager.Instance.JsonFolder_forCsv + e.Name);
                    return;
                }
                bool isloaded = false;
                while (!isloaded)
                {
                    isloaded = IsFileLoaded(e.FullPath);
                }

                if (Path.GetExtension(e.FullPath) == ".xml")
                {
                    Console.WriteLine("File {0} was Created at {1}", e.Name, DateTime.Now.ToLocalTime());
                    XMLParser ob = new XMLParser();

                    //ProgressBar.StartProgressBar();
                    ob.XMLFileReader(e.FullPath);
                    //ProgressBar.EndProgressBar();
                }

                else if (Path.GetExtension(e.FullPath) == ".csv")
                {
                    Console.WriteLine("File {0} was Created at {1}", e.Name, DateTime.Now.ToLocalTime());
                    CsvParser cscParser = new CsvParser();

                    //ProgressBar.StartProgressBar();
                    cscParser.CSVFileReader(e.FullPath);
                    //ProgressBar.EndProgressBar();
                }
                else
                {
                    Console.WriteLine("File {0} has uexpected file extention", e.Name);
                }
            }
            catch (IOException) { }
            catch (Exception) { }


        }

        private static void Watcher_Deleted(object sender, FileSystemEventArgs e)
        {
            Console.WriteLine("File {0} was Deleted at {1}", e.Name, DateTime.Now.ToLocalTime());
        }


        //Dear Armen is this a right solution?
        public static bool IsFileLoaded(string direction)
        {
            
            try
            {
                using (FileStream stream = File.Open(direction, FileMode.Open, FileAccess.Read, FileShare.None))
                {
                    return stream.Length > 0;
                }
            }
            catch //(Exception)
            {
                return false;
            }
        }
        public static void MoveFile(string path1, string path2)
        {
                File.Move(path1, path2);
        }
    }

}

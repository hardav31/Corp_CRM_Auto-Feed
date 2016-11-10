using System;
using System.IO;
using Pbar;
using App_Configuration;
using System.Threading.Tasks;
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
            watcher.Deleted += Watcher_Deleted;
            watcher.Created += Watcher_Created;
            watcher.Filter = "*.*";
        }

        private static  void Watcher_Created(object sender, FileSystemEventArgs e)
        {
            try
            {
                
                bool isloaded = false;
                while (!isloaded)
                {
                    isloaded = IsFileLoaded(e.FullPath);
                }

                if (Path.GetExtension(e.FullPath) == ".xml")
                {
                   
                    ProgressBar.Print("File "+ e.Name+ "is in processing " + DateTime.Now.ToLocalTime());

                    ProgressBar.StartProgressBar();
                    XMLParser.xmlParserObj.XMLFileReader(e.FullPath);
                    ProgressBar.EndProgressBar();
                }

                else if (Path.GetExtension(e.FullPath) == ".csv")
                {
                   
                    ProgressBar.Print("File " + e.Name + "is in processing  " + DateTime.Now.ToLocalTime());

                    ProgressBar.StartProgressBar();
                    CsvParser.csvParserObj.CSVFileReader(e.FullPath);
                    ProgressBar.EndProgressBar();
                }
                else
                {
                    ProgressBar.Print($"File { e.Name} has uexpected file extention");
                }
            }
            catch (Exception ex)
            {
                LoggerType.Exceptin(Path.GetFileName(e.FullPath), ex);
            }


        }

        private static void Watcher_Deleted(object sender, FileSystemEventArgs e)
        {
            ProgressBar.Print($"File {e.Name} was deleted");
        }


        public static bool IsFileLoaded(string direction)
        {
            
            try
            {
                using (FileStream stream = File.Open(direction, FileMode.Open, FileAccess.Read, FileShare.None))
                {
                    return stream.Length > 0;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }
        
    }

}

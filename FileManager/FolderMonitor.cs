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
            watcher.Created += Watcher_Created;
            //watcher.Filter = "*.*";
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
                    File.Move(e.FullPath, AppConfigManager.appSettings.WrongFilePath + Path.GetFileName(e.FullPath));
                    LoggerType.WriteToLog(LogType.Warning, Path.GetFileName(e.FullPath), "has uexpected file extention and moved to Wrong Files folder");
                }
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
                    //if (stream.Length == 0)
                    //{
                    //    File.Move(direction, AppConfigManager.appSettings.WrongFilePath + Path.GetFileName(direction));
                    //    LoggerType.WriteToLog(LogType.Warning, Path.GetFileName(direction), " file was empty and moved to wrong files folder");
                    //}
                    return stream.Length >= 0;
                }
            }
            catch
            {
                return false;
            }
        }
        
    }

}

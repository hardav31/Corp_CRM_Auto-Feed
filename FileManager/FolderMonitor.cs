using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

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
                    MoveFile(e.FullPath, @"C:\Users\ldavtyan\Desktop\PR Project\CreatingCSV" + e.Name);
                    return;
                }
                bool isloaded = false;
                while (!isloaded)
                {
                    isloaded = IsFileLoaded(e.FullPath);
                }

                if (Path.GetExtension(e.FullPath) == ".xml")
                {
                    XMLParser ob = new XMLParser();
                    Task.Run(() => ob.XMLFileReader(e.FullPath));
                }

                else if (Path.GetExtension(e.FullPath) == ".csv")
                {
                    Console.WriteLine("File {0} was Created at {1}", e.Name, DateTime.Now.ToLocalTime());
                    CsvParser cscParser = new CsvParser();
                    cscParser.CSVFileReader(e.FullPath);
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

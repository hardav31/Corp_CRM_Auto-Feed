using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PraemiumProject
{
    class Check_Folder
    {
        FileSystemWatcher watcher = new FileSystemWatcher();


        public Check_Folder(string path)
        {
            watcher.Path = path;
            watcher.IncludeSubdirectories = true;
            watcher.EnableRaisingEvents = true;
            watcher.Deleted += Watcher_Deleted;
            watcher.Created += Watcher_Created;
            watcher.Filter = "*.*";
        }

        private static void Watcher_Created(object sender, FileSystemEventArgs e)
        {

            bool isloaded = false;
            while (!isloaded)
            {
                isloaded = IsFileLoaded(e.FullPath);
            }

            if (Path.GetExtension(e.FullPath) == ".xml")
            {
                XMLParser ob = new XMLParser();
                Task.Run(() => ob.XMLStartReadingAsync(e.FullPath));
            }

            else if (Path.GetExtension(e.FullPath) == ".csv")
            {
                Console.WriteLine("File {0} was Created at {1}", e.Name, DateTime.Now.ToLocalTime());
                CsvParser.StartReadingAsync(e.FullPath);
            }
            else
            {
                Console.WriteLine("File {0} has uexpected file extention", e.Name);
            }


        }

        private static void Watcher_Deleted(object sender, FileSystemEventArgs e)
        {
            Console.WriteLine("File {0} was Deleted at {1}", e.Name, DateTime.Now.ToLocalTime());
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
            catch //(Exception)
            {
                return false;
            }
        }
    }

}

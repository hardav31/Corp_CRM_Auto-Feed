using LogManager;
using System;
using System.IO;

namespace FileManager
{
    class Program
    {
        static void Main(string[] args)
        {
            //TODO: Configuring via APPConfig
            Log log = new Log();
            FolderMonitor check = new FolderMonitor(@"C:\Users\Home\Desktop\New folder");
            check.watcher.WaitForChanged(WatcherChangeTypes.All);//Test
            Console.WriteLine(DateTime.Now.ToLocalTime());
            Console.ReadKey();
        }

    }

}






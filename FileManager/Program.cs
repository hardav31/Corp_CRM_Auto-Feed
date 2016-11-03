using System;
using System.IO;

namespace FileManager
{
    class Program
    {
        static void Main(string[] args)
        {
            //TODO: Configuring via APPConfig
            FolderMonitor check = new FolderMonitor(@"C:\Users\ldavtyan\Desktop\PR Project\CreatingCSV");
            check.watcher.WaitForChanged(WatcherChangeTypes.All);//Test
            Console.WriteLine(DateTime.Now.ToLocalTime());
            Console.ReadKey();
        }

    }

}






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
            
            Log.InIt();
            FolderMonitor check = new FolderMonitor(@"C:\Users\Galust\Desktop\New folder");
            check.watcher.WaitForChanged(WatcherChangeTypes.All);//Test
            Console.WriteLine(DateTime.Now.ToLocalTime());
            Console.ReadKey();
        }

    }

}






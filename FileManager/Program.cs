using System;

namespace FileManager
{
    class Program
    {
        static void Main(string[] args)
        {
            //TODO: Configuring via APPConfig
            FolderMonitor check = new FolderMonitor(@"C:\Users\Home\Desktop\New folder");
            
            Console.WriteLine(DateTime.Now.ToLocalTime());

            Console.ReadKey();
        }

    }

}






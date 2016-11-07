using App_Configuration;
using LogManager;
using System;
using System.IO;

namespace FileManager
{
    class Program
    {
        static void Main(string[] args)
        {
            ReadAppConfig.Instance.AppReader();
            LoggerType.CreateLogger(ReadAppConfig.Instance);
            FolderMonitor check = new FolderMonitor($@"{ReadAppConfig.Instance.FolderMonitorPath}");
            Console.ReadKey();
        }

    }

}






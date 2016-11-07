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
            AppConfigManager.Instance.AppReader();
            LoggerType.CreateLogger(AppConfigManager.Instance);
            FolderMonitor check = new FolderMonitor($@"{AppConfigManager.Instance.FolderMonitorPath}");
            Console.ReadKey();
        }

    }

}






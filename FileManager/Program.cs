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
            AppConfigManager.appSettings.AppReader();
            LoggerType.CreateLogger(AppConfigManager.appSettings);
            FolderMonitor check = new FolderMonitor($@"{AppConfigManager.appSettings.FolderMonitorPath}");
            Console.ReadKey();
        }

    }

}






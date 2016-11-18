using App_Configuration;
using LogManager;
using System;

namespace FileManager
{
    class Program
    {
        static void Main(string[] args)
        {
            AppConfigManager.appSettings.AppReader();
            LoggerType.CreateLogger(AppConfigManager.appSettings.LogToConsole, AppConfigManager.appSettings.LogToEventLog, AppConfigManager.appSettings.LogToFile);
            FolderMonitor check = new FolderMonitor(AppConfigManager.appSettings.FolderMonitorPath);
            DirectoryReader.directoryReader.ReadAllFiles(AppConfigManager.appSettings.FolderMonitorPath);

            Console.ReadKey();
        }

    }

}






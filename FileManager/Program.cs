using App_Configuration;
using LogManager;
using System;
using System.Diagnostics;
using System.IO;

namespace FileManager
{
    class Program
    {
        static void Main(string[] args)
        {
            AppConfigManager.appSettings.AppReader();
            //LoggerType.CreateLogger(AppConfigManager.appSettings.LogToConsole, AppConfigManager.appSettings.LogToEventLog, AppConfigManager.appSettings.LogToFile);
            LoggerType.CreateLogger(AppConfigManager.appSettings);
            FolderMonitor check = new FolderMonitor(AppConfigManager.appSettings.FolderMonitorPath);
            DirectoryReader.directoryReader.ReadAllFiles(AppConfigManager.appSettings.FolderMonitorPath);


            //FOR TESTING JSON SERIALIZER/DESERIALIZER
            //JsonParser jp = new JsonParser();
            //jp.JsonDeserializ();

            // DirectoryReader.directoryReader.ReadAllFiles(AppConfigManager.appSettings.FolderMonitorPath);
            Console.ReadKey();
        }

    }

}






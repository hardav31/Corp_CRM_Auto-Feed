using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using Pbar;

namespace App_Configuration
{
    public class AppConfigManager
    {
        private static readonly Lazy<AppConfigManager> lazy = new Lazy<AppConfigManager>(() => new AppConfigManager());
        public static AppConfigManager appSettings { get { return lazy.Value; } }
        private AppConfigManager()
        {
        }
        public string ConString { get; set; }
        public string JsonFolderPath { get; set; }
        public bool SaveInDB { get; set; }
        public bool SaveInJson { get; set; }
        public bool LogToFile { get; set; }
        public bool LogToEventLog { get; set; }
        public string FolderMonitorPath { get; set; }
        public string EventLogAppName { get; set; }
        public string EventLogFileName { get; set; }
        public string WrongFilePath { get; set; }
        public bool LogToConsole { get; set; }


        public void AppReader()
        {
            Dictionary<string, string> AppDictionary = ConfigurationManager.AppSettings.AllKeys.ToDictionary(
                                                                            k => k, v => ConfigurationManager.AppSettings[v]);

            string filePath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

            bool value;
            ConString = AppDictionary["conString"];
            JsonFolderPath = AppDictionary["JsonFolderPath"];
            FolderMonitorPath = AppDictionary["FolderMonitorPath"];
            WrongFilePath = AppDictionary["WrongFilePath"];
            EventLogFileName = AppDictionary["EventLogFileName"];
            EventLogAppName = AppDictionary["EventLogSource"];

            if (bool.TryParse(AppDictionary["saveInDB"], out value))
            {
                SaveInDB = value;
            }
            if (bool.TryParse(AppDictionary["saveInJSON"], out value))
            {
                SaveInJson = value;
            }
            if (bool.TryParse(AppDictionary["LogToFile"], out value))
            {
                LogToFile = value;
            }
            if (bool.TryParse(AppDictionary["LogToWinEventLog"], out value))
            {
                LogToEventLog = value;
            }
            if (bool.TryParse(AppDictionary["LogToConsole"], out value))
            {
                LogToConsole = value;
            }

            if (!Directory.Exists(FolderMonitorPath))
            {                
                string directoryForFolderMonitor = filePath + @"\FolderMonitorPath";
                Directory.CreateDirectory(directoryForFolderMonitor);
                FolderMonitorPath = directoryForFolderMonitor;               
            }

            if (SaveInDB)
            {
                try
                {
                    using (SqlConnection conn = new SqlConnection(ConString))
                    {
                        conn.Open();
                    }
                }
                catch (Exception ex)
                {
                    ProgressBar.Print($"Connection string is not valud,  {ex.Message}");
                    Console.ReadKey();
                    Environment.Exit(0);
                }
            }

            if (SaveInJson)
            {
                if (!Directory.Exists(JsonFolderPath))
                {
                    string directoruForJson = filePath + @"\JsonFolderPath\";
                    Directory.CreateDirectory(directoruForJson);
                    JsonFolderPath = directoruForJson;
                }
            }

            if (!Directory.Exists(WrongFilePath))
            {
                string directoryForWrongFiles = filePath + @"\WrongFilePath\";
                Directory.CreateDirectory(directoryForWrongFiles);
                WrongFilePath = directoryForWrongFiles;
            }


        }
    }
}


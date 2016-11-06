using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_Configuration
{
    public class ReadAppConfig
    {
        private static readonly Lazy<ReadAppConfig> lazy = new Lazy<ReadAppConfig>(() => new ReadAppConfig());
        public static ReadAppConfig Instance { get { return lazy.Value; } }
        private ReadAppConfig()
        {
        }
        public string ConString { get; set; }
        public string JsonFolder_forXmml { get; set; }
        public string JsonFolder_forCsv { get; set; }
        public bool SaveInDB { get; set; }
        public bool SaveInJson { get; set; }
        public bool LogToFile { get; set; }
        public bool LogToEventLog { get; set; }
        public bool LogToConsole { get; set; }
        public string FolderMonitorPath { get; set; }
        public string EventLogAppName { get; set; }
        public string EventLogFileName { get; set; }
        public void AppReader()
        {
            bool value;
            string[] array = ConfigurationManager.AppSettings.AllKeys.Select(v => ConfigurationManager.AppSettings[v]).ToArray();
            ConString = array[0];
            JsonFolder_forXmml = array[1];
            JsonFolder_forCsv = array[2];
            FolderMonitorPath = array[8];
            EventLogAppName = array[9];
            EventLogFileName = array[10];
            if (bool.TryParse(array[3], out value))
            {
                SaveInDB = value;
            }
            if (bool.TryParse(array[4], out value))
            {
                SaveInJson = value;
            }
            if (bool.TryParse(array[5], out value))
            {
                LogToFile = value;
            }
            if (bool.TryParse(array[6], out value))
            {
                LogToEventLog = value;
            }
            if (bool.TryParse(array[7], out value))
            {
                LogToConsole = value;
            }

        }
    }
}


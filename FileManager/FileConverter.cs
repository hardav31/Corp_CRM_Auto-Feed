using App_Configuration;
using DataManager;
using Models;
using Pbar;
using System;
using System.Collections.Generic;
using System.Text;

namespace FileManager
{
    class FileConverter
    {
        private static readonly Lazy<FileConverter> lazy = new Lazy<FileConverter>(() => new FileConverter());
        public static FileConverter fileConverter { get { return lazy.Value; } }
        private FileConverter()
        {
        }

        public void ConverToJson(Dictionary<int, Team> TeamsD, Dictionary<int, Project> ProjectsD, string direction)
        {
            ProgressBar.Print("Starting to convert data to Json format");
            StringBuilder sb = new StringBuilder();
          
            JsonParser.JsonParserObject.FilePath = sb.Append(String.Concat(AppConfigManager.appSettings.JsonFolderPath + direction.AppendTimeStamp()+".txt")).ToString();
            JsonParser.JsonParserObject.JsonSerializer(TeamsD, ProjectsD);
            ProgressBar.Print(" Data was successfully converted to Json format ");
        }

        public void StoreInDB(Dictionary<int, Team> TeamsD)
        {
            ProgressBar.Print("Starting to store data in DataBase");
            DataUpdater dUpdater = new DataUpdater();
            dUpdater.UpdateData(TeamsD);
            ProgressBar.Print(" Data was successfully stored in DataBase");
        }
    }
}

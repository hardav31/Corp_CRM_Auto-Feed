﻿using App_Configuration;
using DataManager;
using Models;
using Pbar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            ProgressBar.Print("Starting converting data to Json format");
            StringBuilder sb = new StringBuilder();
            JsonParser jsParser = new JsonParser();
            jsParser.FilePath = sb.Append(AppConfigManager.appSettings.JsonFolderPath + jsParser.jsonFoldername(direction)).ToString();
            jsParser.JsonWrite(TeamsD, ProjectsD);
            ProgressBar.Print(" Data was converted to Json format ");
        }

        public void StoreInDB(Dictionary<int, Team> TeamsD)
        {
            ProgressBar.Print("Starting storing data in DataBase");
            DataUpdater dUpdater = new DataUpdater();
            dUpdater.UpdateData(TeamsD);
            ProgressBar.Print(" Data was stored in DataBase");
        }
    }
}

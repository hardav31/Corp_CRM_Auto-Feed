using App_Configuration;
using LogManager;
using Pbar;
using System;
using System.IO;


namespace FileManager
{
    class FileReader
    {
        private static readonly Lazy<FileReader> lazy = new Lazy<FileReader>(() => new FileReader());
        public static FileReader fileReader { get { return lazy.Value; } }
        private FileReader()
        {
        }

        public void Read(string directory)
        {
            try
            {
                if (!(new FileInfo(directory).Length == 0))
                {

                    if (Path.GetExtension(directory) == ".xml")
                    {

                        ProgressBar.Print("File " + Path.GetFileName(directory) + " is in processing " + DateTime.Now.ToLocalTime());

                        ProgressBar.StartProgressBar();
                        XMLParser.xmlParserObj.XMLFileReader(directory);
                        ProgressBar.EndProgressBar();
                    }

                    else if (Path.GetExtension(directory) == ".csv")
                    {

                        ProgressBar.Print("File " + Path.GetFileName(directory) + " is in processing  " + DateTime.Now.ToLocalTime());

                        ProgressBar.StartProgressBar();
                        CsvParser.csvParserObj.CSVFileReader(directory);
                        ProgressBar.EndProgressBar();
                    }
                    else
                    {
                        File.Move(directory, AppConfigManager.appSettings.WrongFilePath + directory.AppendTimeStamp());
                        LoggerType.WriteToLog(LogType.Warning, Path.GetFileName(directory), " has unexpected file extention and moved to Wrong Files folder");
                    }
                }
                else
                {
                    File.Move(directory, AppConfigManager.appSettings.WrongFilePath + directory.AppendTimeStamp());
                    LoggerType.WriteToLog(LogType.Warning, Path.GetFileName(directory), " file was empty and has moved to Wrong File's folder");
                }
            }
            catch(IOException e)
            {
                LoggerType.WriteToLog(Path.GetFileName(directory), e);
            }
            catch (Exception e)
            {
                LoggerType.WriteToLog(Path.GetFileName(directory), e);
            }
        }
    }
}

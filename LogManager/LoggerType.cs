using App_Configuration;
using System;

namespace LogManager
{
    public class LoggerType
    {

        protected LoggerType() { }
        private static ILogger logger;
        public static void CreateLogger(AppConfigManager reader)
        {
            if (reader.LogToConsole && reader.LogToEventLog && reader.LogToFile)
            {
                CreateLogger(new FileWinEventConsoleLogger());
            }
            else if (reader.LogToConsole && reader.LogToEventLog && !reader.LogToFile)
            {
                CreateLogger(new WinEventConsoleLogger());
            }
            else if (reader.LogToConsole && !reader.LogToEventLog && reader.LogToFile)
            {
                CreateLogger(new FileConsoleLogger());
            }
            else if(!reader.LogToConsole && reader.LogToEventLog && reader.LogToFile)
            {
                CreateLogger(new FileWinEventLogger());
            }
            else if(!reader.LogToConsole && !reader.LogToEventLog && reader.LogToFile)
            {
                CreateLogger(new FileLogger());
            }
            else if(!reader.LogToConsole && reader.LogToEventLog && !reader.LogToFile)
            {
                CreateLogger(new WinEventLogger());
            }
            else if(reader.LogToConsole && !reader.LogToEventLog && !reader.LogToFile)
            {
                CreateLogger(new ConsoleLogger());
            }
            else
            {
                Console.WriteLine("Log does'n set");
            }
        }
        private static void CreateLogger(ILogger ilogger)
        {
            logger = ilogger;
        }
        public static void Error(string fileName, string line)
        {
            logger.Error(fileName, line);
        }
        public static void Exceptin(string fileName, Exception ex)
        {
            logger.Exceptin(fileName, ex);
        }
        public static void Info(string fileName, string massage)
        {
            logger.Info(fileName, massage);
        }
        public static void Warning(string fileName, string line)
        {
            logger.Warning(fileName, line);
        }
    }
}



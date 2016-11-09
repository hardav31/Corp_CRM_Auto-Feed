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
        public static void Error(string info, string message)
        {
            logger.Error(info, message);
        }
        public static void Exceptin(string info, Exception ex)
        {
            logger.Exceptin(info, ex);
        }
        public static void Info(string info, string message)
        {
            logger.Info(info, message);
        }
        public static void Warning(string info, string message)
        {
            logger.Warning(info, message);
        }
    }
}



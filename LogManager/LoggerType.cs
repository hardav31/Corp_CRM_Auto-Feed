using App_Configuration;
using LogManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogManager
{
    public class LoggerType
    {

        protected LoggerType() { }
        private static ILogger logger;
        public static void CreateLogger(AppConfigManager reader)
        {
            if (reader.LogToEventLog && reader.LogToFile)
            {
                CreateLogger(new FileWinEventConsoleLogger());
            }

            else if (reader.LogToEventLog && !reader.LogToFile)
            {
                CreateLogger(new WinEventConsoleLogger());
            }
            else if (!reader.LogToEventLog && reader.LogToFile)
            {
                CreateLogger(new FileConsoleLogger());
            }
            else
            {
                CreateLogger(new ConsoleLogger());
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



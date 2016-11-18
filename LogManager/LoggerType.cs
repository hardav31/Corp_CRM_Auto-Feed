using App_Configuration;
using System;

namespace LogManager
{
    public class LoggerType
    {

        protected LoggerType() { }
        private static ILogger logger;
        //public static void CreateLogger(bool logToConsole, bool logToEventLog, bool logToFile)
        //{
         public static void CreateLogger(AppConfigManager reader)


        //    if (logToConsole && logToEventLog && logToFile)
        //    {
        //        CreateLogger(new FileWinEventConsoleLogger());
        //    }
        //    else if (logToConsole && logToEventLog && !logToFile)
        //    {
        //        CreateLogger(new WinEventConsoleLogger());
        //    }
        //    else if (logToConsole && !logToEventLog && logToFile)
        //    {
        //        CreateLogger(new FileConsoleLogger());
        //    }
        //    else if(!logToConsole && logToEventLog && logToFile)
        //    {
        //        CreateLogger(new FileWinEventLogger());
        //    }
        //    else if(!logToConsole && !logToEventLog && logToFile)
        //    {
        //        CreateLogger(new FileLogger());
        //    }
        //    else if(!logToConsole && logToEventLog && !logToFile)
        //    {
        //        CreateLogger(new WinEventLogger());
        //    }
        //    else if(logToConsole && !logToEventLog && !logToFile)
        //    {
        //        CreateLogger(new ConsoleLogger());
        //    }

        //}

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
            else if (!reader.LogToConsole && reader.LogToEventLog && reader.LogToFile)
            {
                CreateLogger(new FileWinEventLogger());
            }
            else if (!reader.LogToConsole && !reader.LogToEventLog && reader.LogToFile)
            {
                CreateLogger(new FileLogger());
            }
            else if (!reader.LogToConsole && reader.LogToEventLog && !reader.LogToFile)
            {
                CreateLogger(new WinEventLogger());
            }
            else if (reader.LogToConsole && !reader.LogToEventLog && !reader.LogToFile)
            {
                CreateLogger(new ConsoleLogger());
            }

        }
        private static void CreateLogger(ILogger ilogger)
        {
            logger = ilogger;
        }

        public static void WriteToLog(LogType logeType, string info, string message)
        {
            logger.WriteToLog(logeType, info, message);
        }

        public static void WriteToLog(string info, Exception ex)
        {
            logger.WriteToLog(info, ex);
        }
    }
}



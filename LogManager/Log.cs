using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogManager
{
   public class Log
    {
        static LogToEventLog logtoEventLog;
        static LogToFile logToTextFile;
        static bool logToFile;
        static bool logToEventLog;
        public static void InIt()
        {
            bool.TryParse(ConfigurationManager.AppSettings["WriteToFile"], out logToFile);
            bool.TryParse(ConfigurationManager.AppSettings["WriteToWinEventLog"], out logToEventLog);
            if (logToFile)
            {
                logToTextFile = new LogToFile();
            }
            if (logToEventLog)
            {
                logtoEventLog = new LogToEventLog();
                if (!EventLog.SourceExists("Skype"))
                {
                    EventLog.CreateEventSource("Skype", "MyLogName");
                }
                logtoEventLog.myLog = new EventLog("MyLogName");
                logtoEventLog.myLog.Source = "Skype";
            }
        }
        public static void DoLog(Chois chois, string fileName, string line)
        {
            switch (chois)
            {
                case Chois.Info:
                    if (logToFile)
                        logToTextFile.Info(fileName, line);
                    if (logToEventLog)
                        logtoEventLog.Info(fileName, line);
                    break;
                case Chois.Warning:
                    if (logToFile)
                        logToTextFile.Warning(fileName, line);
                    if (logToEventLog)
                        logtoEventLog.Warning(fileName, line);
                    break;
                case Chois.Error:
                    if (logToFile)
                        logToTextFile.Error(fileName, line);
                    if (logToEventLog)
                        logtoEventLog.Error(fileName, line);
                    break;
            }
        }
        public static void DoLog(string fileName, Exception ex)
        {
            if (logToTextFile != null)
                logToTextFile.Exceptin(fileName, ex);
            if (logtoEventLog != null)
                logtoEventLog.Exceptin(fileName, ex);
        }
    }

    public enum Chois
    {
        Info,
        Warning,
        Error,
        Exception
    }
}

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
        static EventLog myLog;
        static bool logToFile;
        static bool logToEventLog;
        public Log()
        {
            if (!EventLog.SourceExists("Skype"))
            {
                EventLog.CreateEventSource("Skype", "MyLogName");
            }
            myLog = new EventLog("MyLogName");
            myLog.Source = "Skype";
            bool.TryParse(ConfigurationManager.AppSettings["WriteToFile"], out logToFile);
            bool.TryParse(ConfigurationManager.AppSettings["WriteToWinEventLog"], out logToEventLog);
        }
        public static void Info(string fileName, string massage)
        {
            if (logToFile)
            {
                WriteToFile(fileName, "info", massage);
            }
            if (logToEventLog)
            {
                myLog.WriteEntry(FileInformation(fileName, massage), EventLogEntryType.Information);
            }
        }
        public static void Warning(string fileName, string line)
        {
            if (logToFile)
            {
                WriteToFile(fileName, "Warning", line);
            }
            if (logToEventLog)
            {
                myLog.WriteEntry(FileInformation(fileName, line), EventLogEntryType.Warning);
            }
        }
        public static void Error(string fileName, string line)
        {
            if (logToFile)
            {
                WriteToFile(fileName, "Error", line);
            }
            if (logToEventLog)
            {
                myLog.WriteEntry(FileInformation(fileName, line), EventLogEntryType.Error);
            }
        }
        public static void Exception(string fileName, Exception ex)
        {
            if (logToFile)
            {
                WriteExceptionToFile(fileName, ex);
            }
            if (logToEventLog)
            {
                WriteExceptionToEventLog(fileName, ex);
            }
        }
        private static void WriteToFile(string fileName, string type, string line)
        {
            Trace.WriteLine(string.Format("DateTime = {0}, Type = {1}, Line =  {2}, FileName = {3}",
                                   DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                                   type,
                                   line,
                                   fileName));
        }
        private static void WriteExceptionToFile(string fileName, Exception ex)
        {
            StringBuilder str = new StringBuilder();
            str.Append(Environment.NewLine + fileName + Environment.NewLine);
            str.Append("Exception Type" + Environment.NewLine);
            str.Append(ex.GetType().Name);
            str.Append(Environment.NewLine + Environment.NewLine);
            str.Append("Massage" + Environment.NewLine);
            str.Append(ex.Message + Environment.NewLine + Environment.NewLine);
            str.Append("Stack Trace" + Environment.NewLine);
            str.Append(ex.StackTrace + Environment.NewLine + Environment.NewLine);
            Exception innerException = ex.InnerException;
            while (innerException != null)
            {
                str.Append("Exception Type" + Environment.NewLine);
                str.Append(innerException.GetType().Name);
                str.Append(Environment.NewLine + Environment.NewLine);
                str.Append("Massage" + Environment.NewLine);
                str.Append(innerException.Message + Environment.NewLine + Environment.NewLine);
                str.Append("Stack Trace" + Environment.NewLine);
                str.Append(innerException.StackTrace + Environment.NewLine + Environment.NewLine);
            }
            Trace.WriteLine(string.Format("DateTime = {0}, {1}",
                                                            DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                                                            str.ToString()));
        }
        private static string FileInformation(string fileName, string line)
        {
            StringBuilder str = new StringBuilder();
            str.Append(fileName + Environment.NewLine);
            str.Append(line + Environment.NewLine);
            return str.ToString();
        }
        private static void WriteExceptionToEventLog(string fileName, Exception ex)
        {
            StringBuilder str = new StringBuilder();
            str.Append(Environment.NewLine + fileName + Environment.NewLine);
            str.Append("Exception Type" + Environment.NewLine);
            str.Append(ex.GetType().Name);
            str.Append(Environment.NewLine + Environment.NewLine);
            str.Append("Massage" + Environment.NewLine);
            str.Append(ex.Message + Environment.NewLine + Environment.NewLine);
            str.Append("Stack Trace" + Environment.NewLine);
            str.Append(ex.StackTrace + Environment.NewLine + Environment.NewLine);
            Exception innerException = ex.InnerException;
            while (innerException != null)
            {
                str.Append("Exception Type" + Environment.NewLine);
                str.Append(innerException.GetType().Name);
                str.Append(Environment.NewLine + Environment.NewLine);
                str.Append("Massage" + Environment.NewLine);
                str.Append(innerException.Message + Environment.NewLine + Environment.NewLine);
                str.Append("Stack Trace" + Environment.NewLine);
                str.Append(innerException.StackTrace + Environment.NewLine + Environment.NewLine);
            }
            myLog.WriteEntry(str.ToString(), EventLogEntryType.Error);
        }
    }
}

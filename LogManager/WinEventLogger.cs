using App_Configuration;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogManager
{
    class WinEventLogger : ILogger
    {
        public EventLog myLog;
        public WinEventLogger()
        {
            if (!EventLog.SourceExists(AppConfigManager.Instance.EventLogAppName))
            {
                EventLog.CreateEventSource(AppConfigManager.Instance.EventLogAppName, AppConfigManager.Instance.EventLogFileName);
            }
            myLog = new EventLog(AppConfigManager.Instance.EventLogFileName);
            myLog.Source = AppConfigManager.Instance.EventLogAppName;
        }
        public void Error(string fileName, string line)
        {
            myLog.WriteEntry(FileInformation(fileName, line), EventLogEntryType.Error);
        }
        public void Exceptin(string fileName, Exception ex)
        {
            WriteExceptionToEventLog(fileName, ex);
        }
        public void Info(string fileName, string massage)
        {
            myLog.WriteEntry(FileInformation(fileName, massage), EventLogEntryType.Information);
        }
        public void Warning(string fileName, string line)
        {
            myLog.WriteEntry(FileInformation(fileName, line), EventLogEntryType.Warning);
        }
        private static string FileInformation(string fileName, string line)
        {
            StringBuilder str = new StringBuilder();
            str.Append(fileName + Environment.NewLine);
            str.Append(line + Environment.NewLine);
            return str.ToString();
        }
        private void WriteExceptionToEventLog(string fileName, Exception ex)
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

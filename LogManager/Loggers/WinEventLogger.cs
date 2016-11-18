﻿using App_Configuration;
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
            if (!EventLog.SourceExists(AppConfigManager.appSettings.EventLogAppName))
            {
                EventLog.CreateEventSource(AppConfigManager.appSettings.EventLogAppName, AppConfigManager.appSettings.EventLogFileName);
            }
            myLog = new EventLog(AppConfigManager.appSettings.EventLogFileName);
            myLog.Source = AppConfigManager.appSettings.EventLogAppName;
        }
        
        public void WriteToLog(string info, Exception ex)
        {
            WriteExceptionToEventLog(info, ex);
        }

        public void WriteToLog(LogType logeType, string info, string message)
        {
            switch (logeType)
            {
                case LogType.Info:
                    myLog.WriteEntry(FileInformation(info, message), EventLogEntryType.Information);
                    break;
                case LogType.Warning:
                    myLog.WriteEntry(FileInformation(info, message), EventLogEntryType.Warning);
                    break;
                case LogType.Error:
                    myLog.WriteEntry(FileInformation(info, message), EventLogEntryType.Error);
                    break;
                default:
                    break;
            }
        }
        private static string FileInformation(string info, string message)
        {
            StringBuilder str = new StringBuilder();
            str.Append(info + Environment.NewLine);
            str.Append(message + Environment.NewLine);
            return str.ToString();
        }


        private void WriteExceptionToEventLog(string info, Exception ex)
        {
            StringBuilder str = new StringBuilder();
            str.Append(Environment.NewLine + info + Environment.NewLine);
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
                innerException = innerException.InnerException;
            }
            myLog.WriteEntry(str.ToString(), EventLogEntryType.Error);
        }
    }

}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogManager
{
    class FileWinEventLogger : ILogger
    {
        public FileWinEventLogger()
        {
            fileLogger = new FileLogger();
            eventLogLogger = new WinEventLogger();
        }
        private FileLogger fileLogger;
        private WinEventLogger eventLogLogger;
     
        public void WriteToLog(LogType logeType, string info, string message)
        {
            switch (logeType)
            {
                case LogType.Info:
                    fileLogger.WriteToLog(LogType.Info, info, message);
                    eventLogLogger.WriteToLog(LogType.Info, info, message);
                    break;
                case LogType.Warning:
                    fileLogger.WriteToLog(LogType.Warning, info, message);
                    eventLogLogger.WriteToLog(LogType.Warning, info, message);
                    break;
                case LogType.Error:
                    fileLogger.WriteToLog(LogType.Error, info, message);
                    eventLogLogger.WriteToLog(LogType.Error, info, message);
                    break;
                default:
                    break;
            }
        }

        public void WriteToLog(string info, Exception ex)
        {
            fileLogger.WriteToLog(info, ex);
            eventLogLogger.WriteToLog(info, ex);
        }
    }
}

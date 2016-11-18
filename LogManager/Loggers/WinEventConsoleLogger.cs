using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogManager
{
    class WinEventConsoleLogger : ILogger
    {
        public WinEventConsoleLogger()
        {
            eventLogLogger = new WinEventLogger();
            consoleLogger = new ConsoleLogger();
        }
        private WinEventLogger eventLogLogger;
        private ConsoleLogger consoleLogger;

        public void WriteToLog(LogType logeType, string info, string message)
        {
            switch (logeType)
            {
                case LogType.Info:
                    consoleLogger.WriteToLog(LogType.Info, info, message);
                    eventLogLogger.WriteToLog(LogType.Info, info, message);
                    break;
                case LogType.Warning:
                    consoleLogger.WriteToLog(LogType.Warning, info, message);
                    eventLogLogger.WriteToLog(LogType.Warning, info, message);
                    break;
                case LogType.Error:
                    consoleLogger.WriteToLog(LogType.Error, info, message);
                    eventLogLogger.WriteToLog(LogType.Error, info, message);
                    break;
                default:
                    break;
            }
        }

        public void WriteToLog(string info, Exception ex)
        {
            eventLogLogger.WriteToLog(info, ex);
            consoleLogger.WriteToLog(info, ex);
        }       
    }
}

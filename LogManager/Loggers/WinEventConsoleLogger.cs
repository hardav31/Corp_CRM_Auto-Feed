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
        public void Error(string info, string message)
        {
            eventLogLogger.Error(info, message);
            consoleLogger.Error(info, message);
        }
        public void Exceptin(string info, Exception ex)
        {
            eventLogLogger.Exceptin(info, ex);
            consoleLogger.Exceptin(info, ex);
        }
        public void Info(string info, string message)
        {
            eventLogLogger.Info(info, message);
            consoleLogger.Info(info, message);
        }
        public void Warning(string info, string message)
        {
            eventLogLogger.Warning(info, message);
            consoleLogger.Warning(info, message);
        }
    }
}

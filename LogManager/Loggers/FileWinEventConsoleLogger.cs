using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogManager
{
    class FileWinEventConsoleLogger : ILogger
    {
        public FileWinEventConsoleLogger()
        {
            fileLogger = new FileLogger();
            eventLogLogger = new WinEventLogger();
            consoleLogger = new ConsoleLogger();
        }
        private FileLogger fileLogger;
        private WinEventLogger eventLogLogger;
        private ConsoleLogger consoleLogger;
        public void Error(string info, string message)
        {
            fileLogger.Error(info, message);
            eventLogLogger.Error(info, message);
            consoleLogger.Error(info, message);
        }
        public void Exceptin(string info, Exception ex)
        {
            fileLogger.Exceptin(info, ex);
            eventLogLogger.Exceptin(info, ex);
            consoleLogger.Exceptin(info, ex);
        }
        public void Info(string info, string message)
        {
            fileLogger.Info(info, message);
            eventLogLogger.Info(info, message);
            consoleLogger.Info(info, message);
        }
        public void Warning(string info, string message)
        {
            fileLogger.Warning(info, message);
            eventLogLogger.Warning(info, message);
            consoleLogger.Warning(info, message);
        }
    }
}

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
        public void Error(string fileName, string line)
        {
            eventLogLogger.Error(fileName, line);
            consoleLogger.Error(fileName, line);
        }
        public void Exceptin(string fileName, Exception ex)
        {
            eventLogLogger.Exceptin(fileName, ex);
            consoleLogger.Exceptin(fileName, ex);
        }
        public void Info(string fileName, string massage)
        {
            eventLogLogger.Info(fileName, massage);
            consoleLogger.Info(fileName, massage);
        }
        public void Warning(string fileName, string line)
        {
            eventLogLogger.Warning(fileName, line);
            consoleLogger.Warning(fileName, line);
        }
    }
}

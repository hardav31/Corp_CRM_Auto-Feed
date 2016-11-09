using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogManager
{
    class FileConsoleLogger : ILogger
    {
        public FileConsoleLogger()
        {
            fileLogger = new FileLogger();
            consoleLogger = new ConsoleLogger();
        }
        private FileLogger fileLogger;
        private ConsoleLogger consoleLogger;
        public void Error(string info, string message)
        {
            fileLogger.Error(info, message);
            consoleLogger.Error(info, message);
        }
        public void Exceptin(string info, Exception ex)
        {
            fileLogger.Exceptin(info, ex);
            consoleLogger.Exceptin(info, ex);
        }
        public void Info(string info, string massage)
        {
            fileLogger.Info(info, massage);
            consoleLogger.Info(info, massage);
        }
        public void Warning(string info, string message)
        {
            fileLogger.Warning(info, message);
            consoleLogger.Warning(info, message);
        }
    }
}

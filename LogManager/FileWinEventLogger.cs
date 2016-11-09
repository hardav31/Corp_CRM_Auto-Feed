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
        public void Error(string fileName, string line)
        {
            fileLogger.Error(fileName, line);
            eventLogLogger.Error(fileName, line);
        }
        public void Exceptin(string fileName, Exception ex)
        {
            fileLogger.Exceptin(fileName, ex);
            eventLogLogger.Exceptin(fileName, ex);
        }
        public void Info(string fileName, string massage)
        {
            fileLogger.Info(fileName, massage);
            eventLogLogger.Info(fileName, massage);
        }
        public void Warning(string fileName, string line)
        {
            fileLogger.Warning(fileName, line);
            eventLogLogger.Warning(fileName, line);
        }
    }
}

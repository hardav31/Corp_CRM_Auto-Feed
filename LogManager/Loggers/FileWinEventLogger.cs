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
        public void Error(string info, string message)
        {
            fileLogger.Error(info, message);
            eventLogLogger.Error(info, message);
        }
        public void Exceptin(string info, Exception ex)
        {
            fileLogger.Exceptin(info, ex);
            eventLogLogger.Exceptin(info, ex);
        }
        public void Info(string info, string message)
        {
            fileLogger.Info(info, message);
            eventLogLogger.Info(info, message);
        }
        public void Warning(string info, string message)
        {
            fileLogger.Warning(info, message);
            eventLogLogger.Warning(info, message);
        }
    }
}

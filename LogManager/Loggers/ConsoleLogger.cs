using Pbar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogManager
{
    class ConsoleLogger : ILogger
    {
        
        public void WriteToLog(string info, Exception ex)
        {
            ProgressBar.Print(info, ex);
        }

        public void WriteToLog(LogType logeType, string info, string message)
        {
            switch (logeType)
            {
                case LogType.Info:
                    ProgressBar.Print(LogType.Info.ToString(), info, message);
                    break;
                case LogType.Warning:
                    ProgressBar.Print(LogType.Warning.ToString(), info, message);
                    break;
                case LogType.Error:
                    ProgressBar.Print(LogType.Error.ToString(), info, message);
                    break;
                default:
                    break;
            }
        }
    }
}

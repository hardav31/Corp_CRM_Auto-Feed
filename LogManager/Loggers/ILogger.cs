using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogManager
{
    interface ILogger
    {
        void WriteToLog(LogType logeType, string info, string message);
        void WriteToLog(string info, Exception ex);
    }

}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogManager
{
    interface ILogger
    {
        void Info(string info, string message);
        void Warning(string info, string message);
        void Error(string info, string message);
        void Exceptin(string info, Exception ex);
    }

}

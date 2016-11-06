using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogManager
{
    interface ILogger
    {
        void Info(string fileName, string massage);
        void Warning(string fileName, string line);
        void Error(string fileName, string line);
        void Exceptin(string fileName, Exception ex);
    }

}

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
        public void Error(string fileName, string line)
        {
           ProgressBar.Print(fileName, line, "Error");         
        }

        public void Exceptin(string fileName, Exception ex)
        {
           ProgressBar.Print(fileName, ex);
        }

        public void Info(string fileName, string message)
        {
            ProgressBar.Print(fileName, message, "Info");
        }

        public void Warning(string fileName, string line)
        {
            ProgressBar.Print(fileName, line, "Warning");
        }
       
    }
}

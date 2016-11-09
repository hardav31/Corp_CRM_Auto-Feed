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
        public void Error(string info, string message)
        {
           ProgressBar.Print(info, message, "Error");         
        }

        public void Exceptin(string info, Exception ex)
        {
           ProgressBar.Print(info, ex);
        }

        public void Info(string info, string message)
        {
            ProgressBar.Print(info, message, "Info");
        }

        public void Warning(string info, string message)
        {
            ProgressBar.Print(info, message, "Warning");
        }
       
    }
}

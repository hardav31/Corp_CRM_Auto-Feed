using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogManager
{
    class FileLogger : ILogger
    {
       

        public void Error(string info, string message)
        {
            WriteToFile(info, "Error", message);
        }
        public void Exceptin(string info, Exception ex)
        {
            WriteExceptionToFile(info, ex);
        }
        public void Info(string info, string massage)
        {
            WriteToFile(info, "info", massage);
        }
        public void Warning(string info, string message)
        {
            WriteToFile(info, "Warning", message);
        }
        private static void WriteToFile(string info, string type, string message)
        {
            Trace.WriteLine(string.Format(" {0},  {1},  {2},  {3}",
                                   type,
                                   message,
                                   info,
                                   DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")));
        }
        private static void WriteExceptionToFile(string info, Exception ex)
        {
            StringBuilder str = new StringBuilder();
            str.Append(Environment.NewLine + info + Environment.NewLine);
            str.Append("Exception Type" + Environment.NewLine);
            str.Append(ex.GetType().Name);
            str.Append(Environment.NewLine + Environment.NewLine);
            str.Append("Massage" + Environment.NewLine);
            str.Append(ex.Message + Environment.NewLine + Environment.NewLine);
            str.Append("Stack Trace" + Environment.NewLine);
            str.Append(ex.StackTrace + Environment.NewLine + Environment.NewLine);
            Exception innerException = ex.InnerException;
            while (innerException != null)
            {
                str.Append("Exception Type" + Environment.NewLine);
                str.Append(innerException.GetType().Name);
                str.Append(Environment.NewLine + Environment.NewLine);
                str.Append("Massage" + Environment.NewLine);
                str.Append(innerException.Message + Environment.NewLine + Environment.NewLine);
                str.Append("Stack Trace" + Environment.NewLine);
                str.Append(innerException.StackTrace + Environment.NewLine + Environment.NewLine);
            }
            Trace.WriteLine(string.Format(" {0}, {1}",
                                                      str.ToString(),
                                                      DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")));
        }
    }
}

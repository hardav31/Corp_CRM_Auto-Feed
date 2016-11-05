using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogManager
{
    class LogToFile : ILoger
    {
        public void Error(string fileName, string line)
        {
            WriteToFile(fileName, "Error", line);
        }
        public void Exceptin(string fileName, Exception ex)
        {
            WriteExceptionToFile(fileName, ex);
        }
        public void Info(string fileName, string massage)
        {
            WriteToFile(fileName, "info", massage);
        }
        public void Warning(string fileName, string line)
        {
            WriteToFile(fileName, "Warning", line);
        }
        private static void WriteToFile(string fileName, string type, string line)
        {
            Trace.WriteLine(string.Format("DateTime = {0}, Type = {1}, Line =  {2}, FileName = {3}",
                                   DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                                   type,
                                   line,
                                   fileName));
        }
        private static void WriteExceptionToFile(string fileName, Exception ex)
        {
            StringBuilder str = new StringBuilder();
            str.Append(Environment.NewLine + fileName + Environment.NewLine);
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
            Trace.WriteLine(string.Format("DateTime = {0}, {1}",
                                                            DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                                                            str.ToString()));
        }
    }
}

using System;
using System.IO;


namespace FileManager
{
    static class ChangeFileName
    {
        public static string AppendTimeStamp(this string fileName)
        {
            return Path.Combine(
                Path.GetFileNameWithoutExtension(fileName) + "_",
                DateTime.Now.ToString("yyyyMMddHHmmssfff"),
                Path.GetExtension(fileName)
                );
        }
    }
}

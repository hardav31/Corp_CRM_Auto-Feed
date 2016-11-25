using System;
using System.IO;


namespace FileManager
{
    static class ChangeFileName
    {
        public static string AppendTimeStamp(this string fileName)
        {
            return String.Concat(
                Path.GetFileNameWithoutExtension(fileName) + "_",
                DateTime.Now.ToString("yyyyMMddHHmmssfff"),
                Path.GetExtension(fileName)
                );
        }
    }
}

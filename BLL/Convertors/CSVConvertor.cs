using BLL.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Convertors
{
    class CSVConvertor : IConvertor
    {
        public string Filepath { get; set; }
        public CSVConvertor(string filepath)
        {
            Filepath = filepath;
        }
        public T DeSerialize<T>(string data)
        {
            throw new NotImplementedException();
        }

        public string Serialize<T>(IEnumerable<T> objectlist)
        {
            Type t = typeof(T);
            PropertyInfo[] properties = t.GetProperties();

            string header = String.Join(",", properties.Select(f => f.Name).ToArray());

            StringBuilder csvData = new StringBuilder();
            csvData.AppendLine(header);

            foreach (var o in objectlist)
                csvData.AppendLine(ToCsvFields(",", properties, o));

            return csvData.ToString();

        }

        private string ToCsvFields(string separator, PropertyInfo[] properties, object obj)
        {

            StringBuilder line = new StringBuilder();
            if (obj is string)
            {
                line.Append(obj as string);
                return line.ToString();
            }

            foreach (var prop in properties)
            {
                var value = prop.GetValue(obj);
                var proptype = prop.GetValue(obj).GetType();

                if (line.Length > 0)
                {
                    line.Append(separator);
                }
                if (value == null || value == "")
                {
                    line.Append("NULL");
                }
                if (value is string)
                {
                    line.Append(value as string);
                }

            }

            return line.ToString();

        }
        public void WriteInCSV<T>(IEnumerable<T> modellist)
        {
            using (StreamWriter sw = new StreamWriter(new FileStream(Filepath, FileMode.Create)))
            {
                sw.WriteLine(this.Serialize(modellist));
            }
        }

        //private string ToCsv(string separator, IEnumerable<object> objectList)
        //{
        //    StringBuilder csvData = new StringBuilder();
        //    foreach (var obj in objectList)
        //    {
        //        csvData.AppendLine(ToCsvFields(separator, obj));
        //    }
        //    return csvData.ToString();
        //}

        //private string ToCsvFields(string separator, object obj)
        //{
        //    var fields = obj.GetType().GetProperties();
        //    StringBuilder line = new StringBuilder();

        //    if (obj is string)
        //    {
        //        line.Append(obj as string);
        //        return line.ToString();
        //    }

        //    foreach (var field in fields)
        //    {
        //        var value = field.GetValue(obj);
        //        var fieldType = field.GetValue(obj).GetType();

        //        if (line.Length > 0)
        //        {
        //            line.Append(separator);
        //        }
        //        if (value == null)
        //        {
        //            line.Append("NULL");
        //        }
        //        if (value is string)
        //        {
        //            line.Append(value as string);
        //        }
        //        if (typeof(IEnumerable).IsAssignableFrom(fieldType))
        //        {
        //            var objectList = value as IEnumerable;
        //            StringBuilder row = new StringBuilder();

        //            foreach (var item in objectList)
        //            {
        //                if (row.Length > 0)
        //                {
        //                    row.Append(separator);
        //                }
        //                row.Append(ToCsvFields(separator, item));
        //            }
        //            line.Append(row.ToString());
        //        }
        //        else
        //        {
        //            line.Append(value.ToString());
        //        }
        //    }
        //    return line.ToString();



        //}
    }
}

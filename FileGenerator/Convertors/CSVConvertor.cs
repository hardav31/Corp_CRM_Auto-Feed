using FileGenerator.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

namespace FileGenerator.Convertors
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
               
        public  void WriteInCSV<T>(IEnumerable<T> modellist)
        {
            string[] k = Filepath.Split('\\');
            string path=string.Join("\\",k);
            try
            {
                using (StreamWriter sw = new StreamWriter(new FileStream(path, FileMode.Create)))
                {
                    sw.WriteLine(this.Serialize(modellist));
                   
                }
            }
            catch (System.UnauthorizedAccessException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch
            {
                MessageBox.Show("Please enter valid folder path");
            }
        }

        //public List<Entities> CreateObject(int count)
        //{
        //    Entities model;
        //    List<Entities> modellist = new List<Entities>();
        //    for (int i = 0; i < count; i++)
        //    {
        //        model = new Entities();
        //        model.MemberId = i.ToString();
        //        model.MemberName = "Member" + (10 + i).ToString();
        //        model.MemberSurname = "Surname" + (10 * i).ToString();
        //        model.ProjectId = (i * 10).ToString();
        //        model.ProjectDescription = "Test01";
        //        model.ProjectDueDate = "";
        //        model.TeamId = (100 + i).ToString();
        //        model.TeamName = "team" + (100 + i).ToString();
        //        model.ProjectName = "Project" + i.ToString();
        //        model.ProjectCreatedDate = DateTime.Now.ToString();
        //        modellist.Add(model);
        //    }
        //    return modellist;
        //}
    }
}

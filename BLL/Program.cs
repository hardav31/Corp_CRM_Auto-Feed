using BLL.Convertors;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class Program
    {
        static void Main(string[] args)
        {
           
            Entities model;
            List<Entities> modellist = new List<Entities>();
            for (int i = 0; i < 100; i++)
            {
                model = new Entities();
                model.MemberId = i.ToString();
                model.MemberName = "Member"+(10+ i).ToString();
                model.MemberSurname = "Surname"+(10*i).ToString();
                model.ProjectId = (i * 10).ToString();
                model.ProjectDescription = "Test01";
                model.ProjectDueDate = "";
                model.TeamId = (100 + i).ToString();
                model.TeamName = "team" + (100 + i).ToString();
                model.ProjectName = "Project" + i.ToString();
                model.ProjectCreatedDate = DateTime.Now.ToString();

                modellist.Add(model);
            }

            CSVConvertor csvConvertor = new CSVConvertor(@"C:\Users\ldavtyan\Desktop\PR Project\CreatingCSV\test.csv");
            csvConvertor.WriteInCSV(modellist);
           
        


        Console.ReadLine();

        }
    }
}

using FileGenerator.Models;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace FileGenerator
{
    class Save
    {
        public static void ToXml(List<Team> teams)
        {
            using (FileStream fs = new FileStream(@"D:\Teams.xml", FileMode.OpenOrCreate))
            {
                XmlSerializer s = new XmlSerializer(teams.GetType());
                s.Serialize(fs, teams);
            }
        }

        public static void ToCsv()
        {

        }
    }
}

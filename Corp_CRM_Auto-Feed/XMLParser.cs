using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;
using System.Xml;
using System.Collections.Specialized;
using FileGenerator.Models;

namespace PraemiumProject
{
    class XMLParser
    {
       //In Progress
        private void XMLFileReader(string direction)
        {
            //TODO: if (file.Length > 1000000)
            List<Team> list = new List<Team>();

            using (FileStream fs = new FileStream(direction, FileMode.Open))
            {
                XmlSerializer s = new XmlSerializer(list.GetType());
                XmlReader reader = XmlReader.Create(fs);
                list = (List<Team>)s.Deserialize(reader);
                Console.WriteLine("XML file was deserializen correct in list!!!");
            }
            
        }
        //TODO: Invoke Json or Saving Data in DB methods
    }
}

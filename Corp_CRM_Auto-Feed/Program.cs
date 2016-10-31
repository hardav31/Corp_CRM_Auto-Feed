using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace PraemiumProject
{
    class Program
    {
        static void Main(string[] args)
        {
            //TODO: Configuring via APPConfig
            FolderMonitor check = new FolderMonitor(@"C:\Users\ldavtyan\Desktop\PR Project\CreatingCSV");
            
            Console.WriteLine(DateTime.Now.ToLocalTime());

            Console.ReadKey();
        }

    }

}






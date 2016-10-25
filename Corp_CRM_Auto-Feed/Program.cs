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

            Check_Folder check = new Check_Folder(@"C:\Users\Galust\Desktop\New folder");
            
            Console.WriteLine(DateTime.Now.ToLocalTime());

            Console.ReadKey();
        }

    }

}






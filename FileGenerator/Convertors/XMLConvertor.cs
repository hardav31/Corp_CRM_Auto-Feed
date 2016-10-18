using FileGenerator.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileGenerator.Convertors
{
    class XMLConvertor : IConvertor
    {
        public T DeSerialize<T>(string data)
        {
            throw new NotImplementedException();
        }

        public string Serialize<T>(IEnumerable<T> item)
        {
            throw new NotImplementedException();
        }
      
    }
}

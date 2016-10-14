using BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Convertors
{
    class XMLConvertor : IConvertor
    {
        public T DeSerialize<T>(string data)
        {
            throw new NotImplementedException();
        }

        public string Serialize<Entities>(Entities item)
        {
            throw new NotImplementedException();
        }
    }
}

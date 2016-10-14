using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    interface IConvertor
    {

        string Serialize<T>(T item);
        T DeSerialize<T>(string data);

    }
}

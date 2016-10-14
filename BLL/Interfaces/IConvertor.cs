﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    interface IConvertor
    {

        string Serialize<T>(IEnumerable<T> item);
        T DeSerialize<T>(string data);

    }
}

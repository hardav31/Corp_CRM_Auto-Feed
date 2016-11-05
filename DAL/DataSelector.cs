using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
   public class DataSelector
    {
        DBConnection dbc = new DBConnection();
       public void select()
        {
            SqlCommand cmd = dbc.getCommand("dbo.getAllRecords", "@condition", "", CommandType.StoredProcedure);
          var x = cmd.ExecuteReader();
        }
    }
}

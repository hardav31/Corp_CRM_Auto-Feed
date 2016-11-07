using System;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{ 
   public class SQLHelper
    {
        public void ExecuteNonQuery(SqlConnection con, string cmdTxt, CommandType cmdType)
        {
            ExecuteNonQuery(con, cmdTxt, cmdType, null);
        }

        public void ExecuteNonQuery(SqlConnection con, string cmdTxt, CommandType cmdType, params SqlParameter[] cmdparameters)
        {
            if (con == null) throw new Exception("connection");
            SqlCommand cmd = new SqlCommand(cmdTxt, con);
            cmd.CommandType = cmdType;
            if (cmdparameters.Length != 0)
            {
                Attach(cmd, cmdparameters);
            }
            cmd.ExecuteNonQuery();
        }

        private void Attach(SqlCommand cmd, params SqlParameter[] cmdparameters)
        {
            foreach (var param in cmdparameters)
            {
                cmd.Parameters.Add(param);
            }
        }

    }
}

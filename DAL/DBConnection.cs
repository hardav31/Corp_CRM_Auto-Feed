using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    class DBConnection : IDisposable
    {
        string conString = ConfigurationManager.AppSettings["conString"];
        SqlConnection con = null;
        public SqlCommand getCommand(string cmdTxt, string parametrName, object value,CommandType cmdType)
        {
            con = new SqlConnection(conString);

            SqlCommand cmd = new SqlCommand(cmdTxt, con);
            cmd.CommandType = cmdType;
            SqlParameter param = new SqlParameter();
            param.ParameterName = parametrName;
            param.Value = value;
            cmd.Parameters.Add(param);
            cmd.CommandTimeout = 0;
            con.Open();
            return cmd;
        }

        public void Dispose()
        {
            con.Close();
        }
    }
}

using System.Collections.Generic;
using System.Data.SqlClient;

namespace DAL
{
    public class SQLCommandParameter
    {
        List<SqlParameter> parameters = new List<SqlParameter>();
        /// <summary>
        /// 
        /// </summary>
        /// <param name="pName">The command parameter name</param>
        /// <param name="pValue">The command parameter name</param>
        public void AddParameter(string pName, object pValue)
        {
            SqlParameter param = new SqlParameter();
            param.ParameterName = pName;
            param.Value = pValue;
            parameters.Add(param);
        }

        public SqlParameter[] GetSqlParameters()
        {
            return parameters.ToArray();
        }

       
    }
}

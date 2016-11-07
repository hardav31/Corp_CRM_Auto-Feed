using System.Collections.Generic;
using System.Data.SqlClient;

namespace DataManager
{
    public class CommandParameter
    {
       
        List<SqlParameter> parameters = new List<SqlParameter>();
        public SqlParameter[] CreateParametersArray(List<ParamNameValuePair> pNamesValues)
        {
            foreach (var pNameValue in pNamesValues)
            {
                SqlParameter param = new SqlParameter();
                param.ParameterName = pNameValue.ParameterName;
                param.Value = pNameValue.parameterValue;
                parameters.Add(param);
            }
            return  parameters.ToArray();
        }
    }
}

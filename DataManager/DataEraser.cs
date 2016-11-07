using DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataManager
{
    public class DataEraser
    {

        public void DeleteData()
        {
            List<ParamNameValuePair> pNamesValues = new List<ParamNameValuePair>();
            pNamesValues.Add(new ParamNameValuePair("@teamID", 1));
            pNamesValues.Add(new ParamNameValuePair("@memberID", 2));

            CommandParameter cmdParam = new CommandParameter();
            var parameteres = cmdParam.CreateParametersArray(pNamesValues);
            try
            {
                using (DBConnection dbc = new DBConnection())
                {
                    SQLHelper sqlHelper = new SQLHelper();
                    sqlHelper.ExecuteNonQuery(dbc.Connection, "dbo.deleteRecords", CommandType.StoredProcedure, parameteres);
                }
            }
            catch (Exception e)
            {

                Console.WriteLine(e);
            }



        }
    }
}

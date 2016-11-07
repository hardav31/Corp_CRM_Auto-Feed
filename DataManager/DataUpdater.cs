using DAL;
using Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataManager
{
    public class DataUpdater
    {
        public void UpdateData(Dictionary<int, Team> teamsD)
        {
            DTable dTable = new DTable();
            DataTable dt = dTable.Create();
            var filledDT = dTable.Fill(dt, teamsD);

            List<ParamNameValuePair> pNamesValues = new List<ParamNameValuePair>();
            pNamesValues.Add(new ParamNameValuePair("@sourcetable", filledDT));

            CommandParameter cmdParam = new CommandParameter();
            var parameters = cmdParam.CreateParametersArray(pNamesValues);
            try
            {
                using (DBConnection dbcon = new DBConnection())
                {
                    SQLHelper sqlHelper = new SQLHelper();
                    sqlHelper.ExecuteNonQuery(dbcon.Connection, "dbo.insertData", CommandType.StoredProcedure, parameters);
                    Console.WriteLine("sucses");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);

            }


        }
    }
}

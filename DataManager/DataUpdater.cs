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
            try
            {
                using (DTable dTable = new DTable())
                {
                    DataTable dt = dTable.Create();

                    var filledDT = dTable.Fill(dt, teamsD);

                    CommandParameter cmdParam = new CommandParameter();
                    cmdParam.AddParameter("@sourcetable", filledDT);
                    var parameters=cmdParam.GetSqlParameters();

                    using (DBConnection dbcon = new DBConnection())
                    {
                        SQLHelper sqlHelper = new SQLHelper();
                        sqlHelper.ExecuteNonQuery(dbcon.Connection, "dbo.insertData", CommandType.StoredProcedure, parameters);
                        //TODO: LOG
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);

            }


        }
    }
}

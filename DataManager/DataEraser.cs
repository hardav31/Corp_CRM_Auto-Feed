using DAL;
using System;
using System.Collections.Generic;
using System.Data;

namespace DataManager
{
    public class DataEraser
    {

        public void DeleteData()
        {

            CommandParameter cmdParam = new CommandParameter();
            cmdParam.AddParameter("@teamID", 121);
            cmdParam.AddParameter("@memberID", 2);
            var parameters = cmdParam.GetSqlParameters();

            try
            {
                using (DBConnection dbc = new DBConnection())
                {
                    SQLHelper sqlHelper = new SQLHelper();
                    sqlHelper.ExecuteNonQuery(dbc.Connection, "dbo.deleteRecords", CommandType.StoredProcedure, parameters);
                    //TODO: log
                }
            }

            catch (Exception e)
            {
                throw e;
            }



        }
    }
}
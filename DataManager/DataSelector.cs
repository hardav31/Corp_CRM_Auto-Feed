using DAL;
using System;
using System.Collections.Generic;
using System.Data;

namespace DataManager
{
    public class DataSelector
    {
        public void SelectData()
        {
            try
            {
                using (DTable dtc = new DTable())
                {
                    DataTable dt = dtc.Create();

                    using (DBConnection dbc = new DBConnection())
                    {
                        SQLHelper helper = new SQLHelper();
                        CommandParameter cmdParam = new CommandParameter();
                        cmdParam.AddParameter("@condition", "Team.TeamId=1");
                        var parameters = cmdParam.GetSqlParameters();
                        var a = helper.ExecuteDataTable(dbc.Connection, "dbo.getAllRecords", CommandType.StoredProcedure, dt, parameters);
                    }
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}


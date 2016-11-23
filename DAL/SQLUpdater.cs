using System;
using System.Data;

namespace DAL
{
    public class SQLUpdater
    {
        public void Update(DataTable dt)
        {
            try
            {
                SQLCommandParameter cmdParam = new SQLCommandParameter();
                cmdParam.AddParameter("@sourcetable", dt);
                var parameters = cmdParam.GetSqlParameters();

                using (SQLDBConnection sqlcon = new SQLDBConnection())
                {
                    SQLHelper sqlHelper = new SQLHelper();
                    sqlHelper.ExecuteNonQuery(sqlcon.Connection, "dbo.insertData", CommandType.StoredProcedure, parameters);
                }
            }
            catch (Exception e)
            {
                throw e;

            }

        }
    }
}

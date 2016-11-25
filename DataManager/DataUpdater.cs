using DAL;
using Models;
using System;
using System.Collections.Generic;
using System.Data;

namespace DataManager
{
    public class DataUpdater
    {
        public void UpdateData(object data, DBType type)
        {
            switch (type)
            {
                case DBType.SQL:
                    {
                        try
                        {
                            using (DTable dTable = new DTable())
                            {
                                DataTable dt = dTable.Create();

                                var filledDT = dTable.Fill(dt, data as Dictionary<int, Team>);

                                SQLUpdater sqlUpdater = new SQLUpdater();
                                sqlUpdater.Update(filledDT);
                                break;
                            }
                        }

                        catch (Exception e)
                        {
                            throw e;
                        }
                    }
            }
        }
    }
}


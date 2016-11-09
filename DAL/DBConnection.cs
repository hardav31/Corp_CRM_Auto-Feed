using App_Configuration;
using LogManager;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
namespace DAL
{
    public sealed class DBConnection : IDisposable
    {
        readonly string conString = AppConfigManager.appSettings.ConString;
        private SqlConnection connection;
        public DBConnection()
        {
            InitSqlConnection();
        }
        private void InitSqlConnection()
        {
            try
            {
                if (connection == null)
                {
                    connection = new SqlConnection();
                    connection.ConnectionString = conString;
                    connection.Open();
                }
                else
                {
                    if (connection.State != ConnectionState.Closed)
                    {
                        connection.Close();

                    }
                    connection.ConnectionString = conString;
                    connection.Open();
                }
            }
            catch (Exception ex)
            {
                LoggerType.Exceptin("Problems with connection",ex);
            }
            
        }
        public void Dispose()
        {
            if (connection != null)
                connection.Close();
        }

        public SqlConnection Connection { get { return connection; } }
    }
}

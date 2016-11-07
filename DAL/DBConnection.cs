using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
namespace DAL
{
    public sealed class DBConnection : IDisposable
    {
        readonly string conString = ConfigurationManager.AppSettings["conString"];
        private SqlConnection connection;
        public DBConnection()
        {
            InitSqlConnection();
        }
        private void InitSqlConnection()
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
                    try
                    {
                        connection.Close();

                    }
                    catch (Exception)
                    {

                        throw;
                    }
                }
                connection.ConnectionString = conString;
                connection.Open();
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

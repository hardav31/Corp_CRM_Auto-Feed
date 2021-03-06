﻿using System;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class SQLHelper
    {
        #region ExecuteNonQuery
        /// <summary>
        /// 
        /// </summary>
        /// <param name="con"> A valid SqlConnection</param>
        /// <param name="cmdTxt">The stored procedure name</param>
        /// <param name="cmdType">The CommandType </param>
        public void ExecuteNonQuery(SqlConnection con, string cmdTxt, CommandType cmdType)
        {
            ExecuteNonQuery(con, cmdTxt, cmdType, null);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="con"> A valid SqlConnection</param>
        /// <param name="cmdTxt">The stored procedure name</param>
        /// <param name="cmdType">The CommandType </param>
        /// <param name="cmdparameters">An array of SqlParamters used to execute the command</param>
        public void ExecuteNonQuery(SqlConnection con, string cmdTxt, CommandType cmdType, params SqlParameter[] cmdparameters)
        {
            if (con == null) throw new Exception("connection");
            SqlCommand cmd = new SqlCommand(cmdTxt, con);
            cmd.CommandType = cmdType;
            cmd.CommandTimeout = 0;
            if (cmdparameters.Length != 0)
            {
                Attach(cmd, cmdparameters);
            }
            cmd.ExecuteNonQuery();
        }
        #endregion ExecuteNonQuery

        #region ExecuteDataTable
        /// <summary>
        /// 
        /// </summary>
        /// <param name="con"> A valid SqlConnection</param>
        /// <param name="cmdTxt">The stored procedure name</param>
        /// <param name="cmdType">The CommandType </param>
        /// <param name="dt">A DataTable object</param>
        /// <returns></returns>
        public DataTable ExecuteDataTable(SqlConnection con, string cmdTxt, CommandType cmdType, DataTable dt)
        {
            return ExecuteDataTable(con, cmdTxt, cmdType, dt, null);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="con"> A valid SqlConnection</param>
        /// <param name="cmdTxt">The stored procedure name</param>
        /// <param name="cmdType">The CommandType </param>
        /// <param name="dt">A DataTable object</param>
        /// <param name="cmdparameters">An array of SqlParamters used to execute the command</param>
        /// <returns>A datatable containing the results generated by the command</returns>
        public DataTable ExecuteDataTable(SqlConnection con, string cmdTxt, CommandType cmdType, DataTable dt, params SqlParameter[] cmdparameters)
        {
            if (con == null) throw new Exception("connection");
            SqlCommand cmd = new SqlCommand(cmdTxt, con);
            cmd.CommandType = cmdType;
            cmd.CommandTimeout = 0;
            if (cmdparameters.Length != 0)
            {
                Attach(cmd, cmdparameters);
            }
            using (SqlDataAdapter dAdapter = new SqlDataAdapter(cmd))
            {
                dAdapter.Fill(dt);
            }
            return dt;
        }


        #endregion ExecuteDataTable

        private void Attach(SqlCommand cmd, params SqlParameter[] cmdparameters)
        {
            foreach (var param in cmdparameters)
            {
                cmd.Parameters.Add(param);
            }
        }

    }
}

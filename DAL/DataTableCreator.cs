using System;
using System.Data;

namespace DAL
{
    class DataTableCreator
    {
        public DataTable Create()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("MemberID", typeof(int));
            dt.Columns.Add("MemberName", typeof(string));
            dt.Columns.Add("MemberSurname", typeof(string));
            dt.Columns.Add("TeamID", typeof(int));
            dt.Columns.Add("TeamName", typeof(string));
            dt.Columns.Add("ProjectID", typeof(int));
            dt.Columns.Add("ProjectName", typeof(string));
            dt.Columns.Add("ProjectCreatedDate", typeof(DateTime));
            dt.Columns.Add("ProjectDueDate", typeof(DateTime));
            dt.Columns.Add("ProjecDescription", typeof(string));
            return dt;
        }
    }
}

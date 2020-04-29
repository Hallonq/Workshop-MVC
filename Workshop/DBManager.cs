using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Workshop
{
    public class DBManager
    {
        private string ConnectionString { get; set; }
        private SqlConnection conn = null;
        private SqlCommand cmd = null;
        private string SQL;

        public DBManager(string sql)
        {
            ConnectionString = @"Server=DESKTOP-S6HEJ6V\SQLEXPRESS01; Database = Workshop; Integrated Security = True";
            SQL = sql;
        }

        public DataTable ExecuteSQL()
        {
            var tbl = new DataTable();

            using (conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                cmd = new SqlCommand(SQL, conn);
                var adapter = new SqlDataAdapter(cmd);
                adapter.Fill(tbl);
            }
            return tbl;
        }

        public void ExecuteSQLNoReturn()
        {
            using (conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                cmd = new SqlCommand(SQL, conn);
                cmd.ExecuteNonQuery();
            }
        }
    }
}

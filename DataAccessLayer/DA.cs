using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace F1News.DataAccessLayer
{
    public class DA
    {
        public string _ConnectionStrVC { get; set; }

        public DA(string ConnectionStrVC)
        {
            _ConnectionStrVC = ConnectionStrVC;
        }
        private SqlConnection GetConnection()
        {
            SqlConnection conn = new SqlConnection(_ConnectionStrVC);
            conn.Open();
            return conn;
        }
        private void CloseConnection(SqlConnection conn)
        {
            conn.Close();

        }

    }
}

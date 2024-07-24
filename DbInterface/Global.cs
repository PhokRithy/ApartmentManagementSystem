using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APARTMENT_MANAGEMENT_SYSTEM.DbInterface
{
    public class Global
    {
        public static SqlConnection Connection()
        {
            SqlConnection conn = new SqlConnection("Data Source=localhost,2222;Initial Catalog=APARTMENT_db;User Id=sa;Password=BBU@2021;Encrypt=True;TrustServerCertificate=True;");
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }

            return conn;
        }
    }
}

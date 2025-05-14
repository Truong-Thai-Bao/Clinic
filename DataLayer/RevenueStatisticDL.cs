using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class RevenueStatisticDL
    {
        public DataTable GetRevenue()
        {
            using (SqlConnection conn = new SqlConnection(DBCommon.connString))
            {
                string query = "SELECT * FROM View_RevenueStatistics";
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }
    }
}

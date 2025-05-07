using DataLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace BusinessLayer
{
    public class RevenueStatisticsBUS
    {
        public DataTable GetRevenueStatistics()
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

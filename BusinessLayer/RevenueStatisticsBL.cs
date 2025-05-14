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
    public class RevenueStatisticsBL
    {
        private RevenueStatisticDL RevenueStatisticDL;
        public RevenueStatisticsBL() { 
            RevenueStatisticDL = new RevenueStatisticDL();
        }
        public DataTable GetRevenueStatistics()
        {
            return RevenueStatisticDL.GetRevenue();
        }

    }
}

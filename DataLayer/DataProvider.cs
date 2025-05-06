using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace DataLayer
{
    public class DataProvider
    {
        private SqlConnection cn;
        public DataProvider()
        {
            cn = new SqlConnection(DBCommon.connString);
        }

        public void Connect()
        {
            if(cn.State == ConnectionState.Closed)
            {
                cn.Open();
            }
        }
        public void Disconnect()
        {
            if (cn.State == ConnectionState.Open)
            {
                cn.Close();
            }
        }

        public object MyExcuteScalar(string sql,CommandType type)
        {
            try
            {
                Connect();
                SqlCommand cmd = new SqlCommand(sql, cn);
                cmd.CommandType = type;
                return (cmd.ExecuteScalar());
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                Disconnect();
            }
        }
    }
}

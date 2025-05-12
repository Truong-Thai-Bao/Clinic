using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace DataLayer
{
    public class DBCommon
    {
        //public static string connString = @"Data Source=OZLADE\SQLEXPRESS;Initial Catalog=CMSystem;
        //                Integrated Security=True;Encrypt=True;TrustServerCertificate=True";
        public static string connString = @"Data Source=THAI-BAO\SQLEXPRESS;Initial Catalog=CMSystem;
                          Integrated Security=True;Encrypt=True;TrustServerCertificate=True";
        //public static string connString = @"Data Source=.\SQLEXPRESS;Initial Catalog=CMSystem;
        //                Integrated Security=True;Encrypt=True;TrustServerCertificate=True";
        public SqlConnection cn;
        public DBCommon()
        {
            cn = new SqlConnection(connString);
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
            if(cn.State == ConnectionState.Open) 
            { 
                cn.Close();
            }
        }

        public object MyExecutaScalar(string sql, CommandType type,List<SqlParameter> parameters = null)
        {
            try
            {
                Connect();

                SqlCommand cmd = new SqlCommand(sql, cn);
                cmd.CommandType = type;
                if (parameters != null)
                    foreach (var param in parameters)
                        cmd.Parameters.Add(param);

                return cmd.ExecuteScalar();
            }
            catch (SqlException ex)
            {

                throw ex;
            }
            finally
            {
                Disconnect();
            }
        }

        public SqlDataReader MyExcuteSqlDataReader(string sql, CommandType type,List<SqlParameter> parameters)
        {
            try
            {
                Connect();
                SqlCommand cmd = new SqlCommand(sql, cn);
                cmd.CommandType = type;
                foreach(var param in parameters)
                {
                    cmd.Parameters.Add(param);
                }
                return cmd.ExecuteReader();
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }
    }

}

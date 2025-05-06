using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataTransferLayer;

namespace DataLayer
{
    public class GetUserInfoDL : DBCommon
    {
        public UserInfo GetUserInfo(Account account)
        {
            string sql = "Select * From UserInfo Where UserName = @UserName and UserPassword = @UserPassword";
            try
            {
                Connect();
                SqlCommand cmd = new SqlCommand(sql, cn);
                cmd.Parameters.AddWithValue("@UserName", account.username);
                cmd.Parameters.AddWithValue("@UserPassword", account.password);
                using (SqlDataReader reader = cmd.ExecuteReader())
                if(reader.Read()) 
                {
                    return new UserInfo(
                        name: reader["UserName"].ToString(),
                        pass: reader["UserPassword"].ToString(),
                        type: Convert.ToInt32(reader["UserType"]));

                }
                else
                {
                    return null;
                }
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
    }
}

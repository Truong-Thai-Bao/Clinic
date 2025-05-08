using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataTransferLayer;
using System.Data;

namespace DataLayer
{
    public class GetUserInfoDL : DBCommon
    {
        public UserInfo GetUserInfo(Account account)
        {
            string sql = "Select * From View_UserInfo Where Username = @UserName and UserPassword = @UserPassword";
            try
            {
                Connect();
                List<SqlParameter> parameters = new List<SqlParameter>();
                parameters.Add(new SqlParameter("@UserName", account.username));
                parameters.Add(new SqlParameter("@UserPassword", account.password));
                SqlDataReader reader = MyExcuteSqlDataReader(sql, CommandType.Text,parameters);
                if (reader.Read())
                {
                    return new UserInfo(Convert.ToInt32(reader[0]),
                                            reader[1].ToString(),
                                            reader[2].ToString(),
                                           Convert.ToInt32(reader[3]),
                                            Convert.ToInt32(reader[8]));
                }
                return null;
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

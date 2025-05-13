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
    public class UserInfoDL : DBCommon
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

        public void InsertInfo(Account account) 
        {
            string query = @"INSERT INTO UserInfo (Username, UserPassword, UserType, AddedDate) VALUES (@Username, @UserPassword, @UserType, @AddedDate)";

            using (SqlConnection sqlCon = new SqlConnection(connString))
            {
                sqlCon.Open();
                SqlCommand command = new SqlCommand(query, sqlCon);
                command.Parameters.AddWithValue("@Username",account.username);
                command.Parameters.AddWithValue("@UserPassword", account.password);
                command.Parameters.AddWithValue("@UserType", 1); //1 means Admin
                command.Parameters.AddWithValue("@AddedDate", DateTime.Now);
                command.ExecuteNonQuery();
            }
        }
    }
}

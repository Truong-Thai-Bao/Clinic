using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataTransferLayer;
namespace DataLayer
{
    public class LoginDL : DBCommon
    {
        public bool Login(Account account)
        {
			string sql = "select Count(UserName) from UserInfo where UserName=@username and UserPassword=@password";
			try
			{
				SqlParameter sqlParameter = new SqlParameter();

				return (int)MyExecutaScalar(sql, CommandType.Text) > 0;
			}
			catch (SqlException ex)
			{

				throw ex;
			}
        }
    }
}

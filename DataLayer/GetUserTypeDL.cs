using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DataTransferLayer;
namespace DataLayer
{
    public class GetUserTypeDL : DBCommon
    {
        public int GetUserType(Account account)
        {
            string sql = "uspGetUserType";
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@Username", account.username));
            parameters.Add(new SqlParameter("@UserPassword", account.password));
            try
            {
                return (int)MyExecutaScalar(sql, CommandType.StoredProcedure, parameters);                
			}
			catch (SqlException ex)
			{

				throw ex;
			}
        }
    }
}

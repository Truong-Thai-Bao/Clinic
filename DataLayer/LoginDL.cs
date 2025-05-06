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
            string sql = $"Select Count(UserName) from UserInfo where UserName= '{account.username}'  and UserPassword = '{account.password}'";
            try
            {
                return (int)MyExecutaScalar(sql, CommandType.Text) > 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

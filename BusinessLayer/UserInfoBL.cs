using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using DataLayer;
using DataTransferLayer;
namespace BusinessLayer
{
    public class UserInfoBL
    {
        private UserInfoDL getUserInfoDL;
        public UserInfoBL() { 
            getUserInfoDL = new UserInfoDL();
        }

        public UserInfo GetUserInfo(Account account)
        {
            try
            {
                return getUserInfoDL.GetUserInfo(account);
            }
            catch (SqlException ex)
            {

                throw ex;
            }
        }

        public void InsertInfo(Account account) 
        {
            try
            {
                getUserInfoDL.InsertInfo(account);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

    }
}

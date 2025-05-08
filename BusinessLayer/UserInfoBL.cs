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

        public DataTransferLayer.UserInfo GetUserInfo(Account account)
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
    }
}

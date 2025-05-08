using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer;
using DataTransferLayer;
namespace BusinessLayer
{
    public class GetUserTypeBL
    {
        private GetUserTypeDL getUserTypeDL;
        public GetUserTypeBL()
        {
            getUserTypeDL = new GetUserTypeDL();
        }

        public int GetUserType(Account account)
        {
            try
            {
                return getUserTypeDL.GetUserType(account);
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }
    }
}

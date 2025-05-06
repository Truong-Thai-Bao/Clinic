using System;
﻿using DataLayer;
using System;
using System.Data.SqlClient;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer;
using DataTransferLayer;
namespace BusinessLayer
{
    public class LoginBL
    {
        private LoginDL loginDL;
        public LoginBL() { 
           loginDL = new LoginDL();
        }

        public bool Login(Account account)
        {
            try
            {
                return loginDL.Login(account);
            }
            catch (SqlException ex)
            {

                throw ex;
            }
        }
    }
}

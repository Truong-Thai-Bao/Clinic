using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTransferLayer
{
    public class Account
    {
        public string username { get; set; }
        public string password { get; set; }
        public Account(string user, string pass)
        {
            this.username = user;
            this.password = pass;
        }
    }
}

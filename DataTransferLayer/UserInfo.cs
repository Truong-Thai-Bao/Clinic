using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTransferLayer
{
    public class UserInfo : CommonProps
    {
        public int UserId { get; set; } = 0;

        public string UserName { get; set; } = "";

        public string UserPassword { get; set; } = string.Empty;

        public int UserType { get; set; } = 0;

        public UserInfo(string name,string pass,int type)
        {
           this.UserName = name;
            this.UserPassword = pass;
             this.UserType = type;
        }
    }
}

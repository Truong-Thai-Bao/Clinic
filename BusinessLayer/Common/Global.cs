using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataTransferLayer;
namespace BusinessLayer
{
    public static class Global
    {
        public static DataTransferLayer.UserInfo UserInfo { get; set; } = new DataTransferLayer.UserInfo();
    }
}

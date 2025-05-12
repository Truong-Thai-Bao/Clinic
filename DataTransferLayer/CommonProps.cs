using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTransferLayer
{
    public  class CommonProps
    {
        public DateTime? AddedDate { get; set; } = null;

        public int AddedBy { get; set; } = 0;

        public DateTime? UpdateDate { get; set; } = null;

        public int UpdatedBy { get; set; } = 0;
    }
}

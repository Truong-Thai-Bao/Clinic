using System;

namespace BusinessLayer
{
    public class CommonProps
    {
        public DateTime? AddDate { get; set; } = null;

        public int AddedBy { get; set; } = 0;

        public DateTime? UpdateDate { get; set; } = null;

        public int UpdatedBy { get; set; } = 0;
    }
}

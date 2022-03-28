using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RestaurantDTO
{
    public class BillEntity
    {
        public int MenuId { get; set; }
        public string FromDate { get; set; }
        public string ToDate { get; set; }
        public int StaffId { get; set; }
        public int Status { get; set; }
        public int FromMonth { get; set; }
        public int FromYear { get; set; }
        public int ToMonth { get; set; }
        public int ToYear { get; set; }
        public bool isWeek { get; set; }
        public string BillCode { get; set; }
        public int ShiftId { get; set; }
        public int MeterialId { get; set; }
    }
}

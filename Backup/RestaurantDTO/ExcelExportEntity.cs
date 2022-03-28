using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RestaurantDTO
{
    public class ExcelExportEntity
    {
        public string SheetName { get; set; }
        public string FilePath { get; set; }
        public string Caption { get; set; }
        public string Title { get; set; }
        public string FullName { get; set; }
        public string FromDate { get; set; }
        public string ToDate { get; set; }
        public string ExcelFormat { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RestaurantCommon
{
    public class UserFunctionList
    {
        public List<Function> Services = new List<Function>();
        public List<Function> Menus = new List<Function>();
        public List<Function> Stocks = new List<Function>();
        public List<Function> Bills = new List<Function>();
        public List<Function> Reports = new List<Function>();
        public List<Function> Customers = new List<Function>();
        public List<Function> Staffs = new List<Function>();
        public List<Function> SystemConfig = new List<Function>();
        public List<Function> Histories = new List<Function>();
        public int StaffId { get; set; }
        public string UserName { get; set; }
        public string FullName { get; set; }
        public int RoleId { get; set; }
    }

    public class Function
    {
        public int View { get; set; }
        public int Add { get; set; }
        public int Edit { get; set; }
        public int Delete { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RestaurantDTO
{
    /// <summary>
    /// Thao tác với chuỗi kết nối với cơ sở dữ liệu.
    /// </summary>
    public class DataBaseConnection
    {
        /// <summary>
        /// lấy chuỗi kết nối
        /// </summary>
        /// <returns></returns>
        public static string GetConnectString()
        {
            return Properties.Settings.Default.RestaurantManagementConnectionString;
        }
    }
}

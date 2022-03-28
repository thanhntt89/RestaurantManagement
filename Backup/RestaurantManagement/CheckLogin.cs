using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RestaurantDTO;
using System.Data.SqlClient;
using System.Configuration;

namespace RestaurantManagement
{
    public class CheckLogin
    {
        public static bool CheckConnectionString()
        {
            string ConnecString = string.Empty;
           // ConnecString = RestaurantManagement.Properties.Settings.Default["RestaurantManagementConnectionString"].ToString();
            ConnecString = ConfigurationManager.ConnectionStrings["RestaurantManagement.Properties.Settings.RestaurantManagementConnectionString"].ConnectionString.ToString();
            try
            {
                SettingConnectionApplication(ConnecString);
                SqlConnection sqlConnection = new SqlConnection(ConnecString);
                sqlConnection.Open();
                return true;
            }
            catch
            {
                ConnectionManagement ConnectionManagement = new ConnectionManagement();
                ConnectionManagement.ShowDialog();
                return ConnectionManagement.isOK;
            }
        }
        /// <summary>
        /// Cài đặt kết nối cho DataSet
        /// </summary>
        public static void SettingConnectionApplication(string sqlConnectString)
        {
            System.Configuration.Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            RestaurantDTO.Properties.Settings.Default["RestaurantManagementConnectionString"] = sqlConnectString;
            config.Save(ConfigurationSaveMode.Full);
            ConfigurationManager.RefreshSection("RestaurantManagementConnectionString");
        }

        /// <summary>
        /// Lưu thông tin đường dẫn database vào file xml
        /// </summary>
        /// <param name="sqlConnectString"></param>
        public static void SaveConnectionString(string sqlConnectString)
        {
            var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            var connectionStringsSection = (ConnectionStringsSection)config.GetSection("connectionStrings");
            connectionStringsSection.ConnectionStrings["RestaurantManagement.Properties.Settings.RestaurantManagementConnectionString"].ConnectionString = sqlConnectString;
            config.Save();
            ConfigurationManager.RefreshSection("connectionStrings");
        }
    }
}

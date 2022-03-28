using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using RestaurantCommon;

namespace RestaurantManagement
{
    public partial class UserControlDesktop : UserControl
    {
        #region Khai báo các phương thức điều khiển từ giao diện desktop

        /// <summary>
        /// Mở menu services
        /// </summary>
        public delegate void OpenServices(object sender, EventArgs e);
        public event OpenServices onpenServices;

        /// <summary>
        /// Mở menu thực đơn
        /// </summary>
        public delegate void OpenMenus(object sender, EventArgs e);
        public event OpenMenus openMenus;

        /// <summary>
        /// Mở kho hàng
        /// </summary>
        public delegate void OpenStocks(object sender, EventArgs e);
        public event OpenStocks openStocks;

        /// <summary>
        /// Mở menu hóa đơn
        /// </summary>
        public delegate void OpenBills(object sender, EventArgs e);
        public event OpenBills openBills;

        public delegate void OpenReports(object sender, EventArgs e);
        public event OpenReports openReports;

        /// <summary>
        /// Mở menu khách hàng
        /// </summary>
        public delegate void OpenCustomers(object sender, EventArgs e);
        public event OpenCustomers openCustomers;

        /// <summary>
        /// Mở menu nhân viên
        /// </summary>
        public delegate void OpenStaffs(object sender, EventArgs e);
        public event OpenStaffs openStaffs;

        /// <summary>
        /// Mở cấu hình hệ thống
        /// </summary>
        public delegate void OpenSystemConfigs(object sender, EventArgs e);
        public event OpenSystemConfigs openSystemConfigs;

        #endregion

        private UserFunctionList userFunctionList;

        private bool Services, Menus, Stocks, Bills, Reports, Customers, Staffs, Systems;

        private void CheckUserFunctions(UserFunctionList userFunctionList)
        {
            if (userFunctionList.Services.Count > 0 && userFunctionList.Services[0].View == 1)
                Services = true;
            else
                Services = false;

            if (userFunctionList.Menus.Count > 0 && userFunctionList.Menus[0].View == 1)
                Menus = true;
            else
                Menus = false;

            if (userFunctionList.Stocks.Count > 0 && userFunctionList.Stocks[0].View == 1)
                Stocks = true;
            else
                Stocks = false;

            if (userFunctionList.Bills.Count > 0 && userFunctionList.Bills[0].View == 1)
                Bills = true;
            else
                Bills = false;

            if (userFunctionList.Reports.Count > 0 && userFunctionList.Reports[0].View == 1)
                Reports = true;
            else
                Reports = false;

            if (userFunctionList.Customers.Count > 0 && userFunctionList.Customers[0].View == 1)
                Customers = true;
            else
                Customers = false;
            if (userFunctionList.SystemConfig.Count > 0 && userFunctionList.SystemConfig[0].View == 1)
                Systems = true;
            else
                Systems = false;

            Staffs = false;
            if (userFunctionList.RoleId == 2)
            {
                Staffs = true;
                Systems = true;
            }
        }

        public UserControlDesktop(UserFunctionList userFunctionList, string restaurantInfor)
        {
            InitializeComponent();
            lbRestaurantInfor.Text = restaurantInfor;
            this.userFunctionList = userFunctionList;
            lbUserName.Text = userFunctionList.UserName;
            CheckUserFunctions(userFunctionList);
        }

        private void UserControlDesktop_SizeChanged(object sender, EventArgs e)
        {
            panel1.CenterHorizontally();
            panel1.CenterVertically();
        }

        private void UserControlDesktop_Load(object sender, EventArgs e)
        {
            panel1.CenterHorizontally();
            panel1.CenterVertically();
        }

        private void btnBills_Click(object sender, EventArgs e)
        {
            if (!Bills)
            {
                MessageBox.Show("Bạn không có quyền vào chức năng này", Constants.CaptionInformationMessage, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return;
            }
            if (openBills != null)
                openBills(null, null);
        }

        private void btnReportManagement_Click(object sender, EventArgs e)
        {
            if (!Reports)
            {
                MessageBox.Show("Bạn không có quyền vào chức năng này", Constants.CaptionInformationMessage, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return;
            }
            if (openReports != null)
                openReports(null, null);
        }

        private void btnUtilities_Click(object sender, EventArgs e)
        {
            if (!Systems)
            {
                MessageBox.Show("Bạn không có quyền vào chức năng này", Constants.CaptionInformationMessage, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return;
            }
            if (openSystemConfigs != null)
                openSystemConfigs(null, null);
        }

        private void btnMenuManagement_Click(object sender, EventArgs e)
        {
            if (!Menus)
            {
                MessageBox.Show("Bạn không có quyền vào chức năng này", Constants.CaptionInformationMessage, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return;
            }
            if (openMenus != null)
                openMenus(null, null);
        }

        private void btnStockManagement_Click(object sender, EventArgs e)
        {
            if (!Stocks)
            {
                MessageBox.Show("Bạn không có quyền vào chức năng này", Constants.CaptionInformationMessage, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return;
            }
            if (openStocks != null)
                openStocks(null, null);
        }

        private void btnStaffManagement_Click(object sender, EventArgs e)
        {
            if (!Staffs)
            {
                MessageBox.Show("Bạn không có quyền vào chức năng này", Constants.CaptionInformationMessage, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return;
            }
            if (openStaffs != null)
                openStaffs(null, null);
        }

        private void btnCustomerManagement_Click(object sender, EventArgs e)
        {
            if (!Customers)
            {
                MessageBox.Show("Bạn không có quyền vào chức năng này", Constants.CaptionInformationMessage, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return;
            }
            if (openCustomers != null)
                openCustomers(null, null);
        }

        private void btnCustomerServices_Click(object sender, EventArgs e)
        {
            if (!Services)
            {
                MessageBox.Show("Bạn không có quyền vào chức năng này", Constants.CaptionInformationMessage, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return;
            }
            if (onpenServices != null)
                onpenServices(null, null);
        }
    }
}

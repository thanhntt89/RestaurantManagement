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
    public partial class UserControlReportMainUI : UserControl
    {
        private UserFunctionList userFunctionList;

        public UserControlReportMainUI(UserFunctionList userFunctionList)
        {
            InitializeComponent();
            this.userFunctionList = userFunctionList;
        }

        private void UserControlReportMainUI_Load(object sender, EventArgs e)
        {
        }

        private void UserControlReportMainUI_SizeChanged(object sender, EventArgs e)
        {
            panelMain.CenterVertically();
            panelMain.CenterHorizontally();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="type">0 thống kê theo ngày, 1 theo tuần, 2 theo tháng,  3 theo năm</param>
        private void ShowReportFormByType(string billType)
        {
            panelMain.Visible = false;
            if (this.Controls.IndexOfKey("UserControlBillSales") == 0)
                return;
            UserControlBillSales UserControlBillSales = new UserControlBillSales(billType,userFunctionList);
            UserControlBillSales.removedUserControler += new UserControlBillSales.RemovedUserControler(CleanControlByName);
            UserControlBillSales.Dock = DockStyle.Fill;
            this.Controls.Add(UserControlBillSales);
        }

        private void CleanControlByName(string controlName)
        {
            panelMain.Visible = true;
            this.Controls.RemoveByKey(controlName);
            this.Refresh();
        }

        private void btnDailyCost_Click(object sender, EventArgs e)
        {
            LogHistories.InsertLogHistories("Xem báo cáo bán hàng theo ngày ", DateTime.Now, userFunctionList.UserName, "Thành công");
            ShowReportFormByType(Constants.Day);
        }

        private void btnMonthCost_Click(object sender, EventArgs e)
        {
            LogHistories.InsertLogHistories("Xem báo cáo bán hàng theo tháng ", DateTime.Now, userFunctionList.UserName, "Thành công");
            ShowReportFormByType(Constants.Month);
        }

        private void btnYearsCost_Click(object sender, EventArgs e)
        {
            LogHistories.InsertLogHistories("Xem báo cáo bán hàng theo năm ", DateTime.Now, userFunctionList.UserName, "Thành công");
            ShowReportFormByType(Constants.Year);
        }

        private void btnDailyRevenue_Click(object sender, EventArgs e)
        {
            LogHistories.InsertLogHistories("Xem báo cáo chi phí theo ngày ", DateTime.Now, userFunctionList.UserName, "Thành công");
            ShowBillByType(Constants.Day);
        }

        private void ShowBillByType(string billType)
        {
            panelMain.Visible = false;
            if (this.Controls.IndexOfKey("UserControlReportBill") == 0)
                return;
            UserControlBillsManagement UserControlBillsManagement = new UserControlBillsManagement(billType,userFunctionList);
            UserControlBillsManagement.removedUserControler += new UserControlBillsManagement.RemovedUserControler(CleanControlByName);
            UserControlBillsManagement.Dock = DockStyle.Fill;
            this.Controls.Add(UserControlBillsManagement);
        }

        private void btnMonthRevenue_Click(object sender, EventArgs e)
        {
            LogHistories.InsertLogHistories("Xem báo cáo chi phí theo tháng ", DateTime.Now, userFunctionList.UserName, "Thành công");
            ShowBillByType(Constants.Month);
        }

        private void btnYearsRevenue_Click(object sender, EventArgs e)
        {
            LogHistories.InsertLogHistories("Xem báo cáo chi phí theo năm ", DateTime.Now, userFunctionList.UserName, "Thành công");
            ShowBillByType(Constants.Year);
        }

        private void btnMenuTotal_Click(object sender, EventArgs e)
        {
            LogHistories.InsertLogHistories("Xem báo cáo thực đơn ", DateTime.Now, userFunctionList.UserName, "Thành công");
            ShowMenuReport(Constants.Day);
        }

        private void ShowMenuReport(string MenuType)
        {
            panelMain.Visible = false;
            if (this.Controls.IndexOfKey("UserControlMenuReport") == 0)
                return;
            UserControlMenuReport UserControlMenuReport = new UserControlMenuReport(MenuType,userFunctionList);
            UserControlMenuReport.removedUserControler += new UserControlMenuReport.RemovedUserControler(CleanControlByName);
            UserControlMenuReport.Dock = DockStyle.Fill;
            this.Controls.Add(UserControlMenuReport);
        }

        private void btnMeterial_Click(object sender, EventArgs e)
        {
            panelMain.Visible = false;
            if (this.Controls.IndexOfKey("UserControlMeterialImport") == 0)
                return;
            LogHistories.InsertLogHistories("Xem báo cáo thống kê theo mặt hàng ", DateTime.Now, userFunctionList.UserName, "Thành công");
            UserControlMeterialImport UserControlMeterialImport = new UserControlMeterialImport(userFunctionList);
            UserControlMeterialImport.removedUserControler += new UserControlMeterialImport.RemovedUserControler(CleanControlByName);
            UserControlMeterialImport.Dock = DockStyle.Fill;
            this.Controls.Add(UserControlMeterialImport);
        }
    }
}

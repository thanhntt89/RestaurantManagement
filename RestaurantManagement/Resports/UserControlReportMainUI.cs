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
        public UserControlReportMainUI()
        {
            InitializeComponent();
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
        private void ShowReportFormByType(int type)
        {
            panelMain.Visible = false;
            if (this.Controls.IndexOfKey("UserControlReportBill") == 0)
                return;
            UserControlReportBill UserControlReportBill = new UserControlReportBill(type);
            UserControlReportBill.removedUserControler += new UserControlReportBill.RemovedUserControler(CleanControlByName);
            UserControlReportBill.Dock = DockStyle.Fill;
            this.Controls.Add(UserControlReportBill);
        }

        private void VisiblePanelMain()
        {
            panelMain.Visible = true;
        }

        private void CleanControlByName(string controlName)
        {
            VisiblePanelMain();
            this.Controls.RemoveByKey(controlName);
            this.Refresh();
        }
        private void btnDailyCost_Click(object sender, EventArgs e)
        {
            ShowReportFormByType(0);
        }

        private void btnMonthCost_Click(object sender, EventArgs e)
        {
            ShowReportFormByType(1);
        }

        private void btnYearsCost_Click(object sender, EventArgs e)
        {
            ShowReportFormByType(2);
        }
    }
}

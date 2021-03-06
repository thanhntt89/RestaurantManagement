using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using RestaurantCommon;
using RestaurantDTO;
using RestaurantController;
using System.Linq;

namespace RestaurantManagement
{
    public partial class FormMainUI : DevComponents.DotNetBar.Metro.MetroAppForm
    {
        private bool isTrial = false;
        private UserFunctionList userFunctionList = null;
        private RestaurantInforController restaurantInforController = new RestaurantInforController();
        private RestaurantInforDataSet.RestaurantInforDataTable restaurantInforDataTable = null;
        private string restaurantInfor = string.Empty;
        private ProcessingEntity processingEntity = null;
        public FormMainUI(bool istrial)
        {
            InitializeComponent();
            this.isTrial = istrial;
            DisableMenuTop();
        }

        public FormMainUI()
        {
            InitializeComponent();
        }

        private void mnMenus_Click(object sender, EventArgs e)
        {
            if (panelExMainUI.Controls.IndexOfKey("UserControlMenuList") == 0)
                return;
            panelExMainUI.Controls.Clear();
            mnMenus.Checked = true;
            UserControlMenuList UserControlMenuList = new UserControlMenuList(isTrial, userFunctionList);
            UserControlMenuList.Dock = DockStyle.Fill;
            panelExMainUI.Controls.Add(UserControlMenuList);
        }

        private void mnServices_Click(object sender, EventArgs e)
        {
            processingEntity = new ProcessingEntity();
            processingEntity.Completed = false;

            if (backgroundWorkerLoadService == null)
            {
                backgroundWorkerLoadService = new BackgroundWorker();
                backgroundWorkerLoadService.DoWork += new DoWorkEventHandler(backgroundWorkerLoadService_DoWork);
                backgroundWorkerLoadService.RunWorkerCompleted += new RunWorkerCompletedEventHandler(backgroundWorkerLoadService_RunWorkerCompleted);
            }
            backgroundWorkerLoadService.RunWorkerAsync();
            Processing processing = new Processing(processingEntity);
            processing.ShowDialog();
        }

        private void OpenServicesMenu()
        {
            MethodInvoker invoke = delegate
            {
                if (panelExMainUI.Controls.IndexOfKey("UserControlMainServices") == 0)
                    return;
                panelExMainUI.Controls.Clear();
                mnServices.Checked = true;
                LogHistories.InsertLogHistories("Vào chức năng phục vụ bán hàng ", DateTime.Now, userFunctionList.UserName, "Thành công");
                UserControlMainServices UserControlMainServices = new UserControlMainServices(isTrial, userFunctionList);
                UserControlMainServices.Dock = DockStyle.Fill;
                panelExMainUI.Controls.Add(UserControlMainServices);

            };
            if (InvokeRequired)
            {
                BeginInvoke(invoke);
            }
            else
            {
                invoke.Invoke();
            }
        }

        private void mnStock_Click(object sender, EventArgs e)
        {
            if (panelExMainUI.Controls.IndexOfKey("UserControlStockManagement") == 0)
                return;
            panelExMainUI.Controls.Clear();
            mnStock.Checked = true;
            UserControlStockManagement UserControlStockManagement = new UserControlStockManagement(userFunctionList);
            UserControlStockManagement.Dock = DockStyle.Fill;
            panelExMainUI.Controls.Add(UserControlStockManagement);
        }

        private void mnCustomer_Click(object sender, EventArgs e)
        {
            if (panelExMainUI.Controls.IndexOfKey("UserControlCustomerManagement") == 0)
                return;
            panelExMainUI.Controls.Clear();
            mnCustomer.Checked = true;
            LogHistories.InsertLogHistories("Vào chức năng quản lý khách hàng ", DateTime.Now, userFunctionList.UserName, "Thành công");
            UserControlCustomerManagement UserControlCustomerManagement = new UserControlCustomerManagement(userFunctionList);
            UserControlCustomerManagement.Dock = DockStyle.Fill;
            panelExMainUI.Controls.Add(UserControlCustomerManagement);
        }

        private void mnStaff_Click(object sender, EventArgs e)
        {
            if (panelExMainUI.Controls.IndexOfKey("UserControlStaffManagement") == 0)
                return;
            panelExMainUI.Controls.Clear();
            mnStaff.Checked = true;
            LogHistories.InsertLogHistories("Vào chức năng quản lý nhân viên ", DateTime.Now, userFunctionList.UserName, "Thành công");
            UserControlStaffManagement UserControlStaffManagement = new UserControlStaffManagement(isTrial,userFunctionList);
            UserControlStaffManagement.Dock = DockStyle.Fill;
            panelExMainUI.Controls.Add(UserControlStaffManagement);
        }

        private void FormMainUI_Load(object sender, EventArgs e)
        {
            if (backgroundWorkerRestaurantInfor == null)
            {
                backgroundWorkerRestaurantInfor = new BackgroundWorker();
                backgroundWorkerRestaurantInfor.DoWork += new DoWorkEventHandler(backgroundWorkerRestaurantInfor_DoWork);
                backgroundWorkerRestaurantInfor.RunWorkerCompleted += new RunWorkerCompletedEventHandler(backgroundWorkerRestaurantInfor_RunWorkerCompleted);
            }
            backgroundWorkerRestaurantInfor.RunWorkerAsync();
            LoginShowDiaLog();

            //// Hiện thị cấu hình hệ thống
            //metroAppButtonSystem.BackstageTab.Show();
        }

        private void mnReport_Click(object sender, EventArgs e)
        {
            if (panelExMainUI.Controls.IndexOfKey("UserControlReportMainUI") == 0)
                return;
            panelExMainUI.Controls.Clear();
            LogHistories.InsertLogHistories("Vào chức năng thống kê báo cáo hóa đơn ", DateTime.Now, userFunctionList.UserName, "Thành công");
            mnReport.Checked = true;
            UserControlReportMainUI UserControlReportMainUI = new UserControlReportMainUI(userFunctionList);
            UserControlReportMainUI.Dock = DockStyle.Fill;
            panelExMainUI.Controls.Add(UserControlReportMainUI);

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonItem6_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            LogoutSystem();
            LoginShowDiaLog();
        }

        private void LogoutSystem()
        {
            lbFullName.Text = string.Empty;
            lbUserName.Text = string.Empty;
            panelExMainUI.Controls.Clear();

            // Disable button Hệ thống
            metroAppButtonSystem.Enabled = false;
            DisableMenuTop();
            LogHistories.InsertLogHistories("Thoát khỏi hệ thống", DateTime.Now, userFunctionList.UserName, "Thành công");
        }

        private void LoginSystem(UserFunctionList userFunctionList)
        {
            this.userFunctionList = userFunctionList;
            if (userFunctionList.RoleId == 2)
                lbRole.Text = Constants.SupperAdmin;
            else
                if (userFunctionList.RoleId == 1)
                    lbRole.Text = Constants.Manager;
                else
                    lbRole.Text = Constants.Staffs;

            CheckUserFunctions(userFunctionList);
            lbUserName.Text = userFunctionList.UserName;
            lbFullName.Text = userFunctionList.FullName;
            ShowDeskTop();
        }

        private void CheckUserFunctions(UserFunctionList userFunctionList)
        {
            if (userFunctionList.Services.Count > 0 && userFunctionList.Services[0].View == 1)
                mnServices.Visible = true;
            else
                mnServices.Visible = false;

            if (userFunctionList.Menus.Count > 0 && userFunctionList.Menus[0].View == 1)
                mnMenus.Visible = true;
            else
                mnMenus.Visible = false;

            if (userFunctionList.Stocks.Count > 0 && userFunctionList.Stocks[0].View == 1)
                mnStock.Visible = true;
            else
                mnStock.Visible = false;

            if (userFunctionList.Bills.Count > 0 && userFunctionList.Bills[0].View == 1)
                mnBills.Visible = true;
            else
                mnBills.Visible = false;

            if (userFunctionList.Reports.Count > 0 && userFunctionList.Reports[0].View == 1)
                mnReport.Visible = true;
            else
                mnReport.Visible = false;

            if (userFunctionList.Customers.Count > 0 && userFunctionList.Customers[0].View == 1)
                mnCustomer.Visible = true;
            else
                mnCustomer.Visible = false;

            if (userFunctionList.SystemConfig.Count > 0 && userFunctionList.SystemConfig[0].View == 1)
            {
                btnSystemConfig.Visible = true;
            }
            else
                btnSystemConfig.Visible = false;

            btnChangePassword.Enabled = true;
            btnLogOut.Enabled = true;
            metroAppButtonSystem.Enabled = true;

            if (userFunctionList.RoleId == 2)
            {
                mnStaff.Visible = true;
                btnSystemConfig.Visible = true;
            }

        }

        private void DisableMenuTop()
        {
            btnChangePassword.Enabled = false;
            btnSystemConfig.Visible = false;
            btnLogOut.Enabled = false;
            mnServices.Visible = false;
            mnMenus.Visible = false;
            mnStock.Visible = false;
            mnBills.Visible = false;
            mnReport.Visible = false;
            mnStaff.Visible = false;
            mnCustomer.Visible = false;
        }

        /// <summary>
        /// Xoá bỏ các controller khi thay đổi lại database
        /// </summary>
        private void CleanController()
        {
            panelExMainUI.Controls.Clear();
        }

        private void backgroundWorkerLoadService_DoWork(object sender, DoWorkEventArgs e)
        {
            OpenServicesMenu();
        }

        private void LoadRestaurantInfor()
        {
            restaurantInforDataTable = new RestaurantInforDataSet.RestaurantInforDataTable();
            restaurantInforController.GetAllRestaurantInforByRestaurantInforId(restaurantInforDataTable, 1);
            restaurantInfor = restaurantInforDataTable.First().RestaurantName;
        }

        private void backgroundWorkerLoadService_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            processingEntity.Completed = true;
            backgroundWorkerLoadService.Dispose();
            backgroundWorkerLoadService = null;
            GC.Collect();
        }

        private void btnChangedConnection_Click(object sender, EventArgs e)
        {
            ConnectionManagement ConnectionManagement = new ConnectionManagement();
            ConnectionManagement.changedDatabase += new ConnectionManagement.ChangedDataBase(CleanController);
            ConnectionManagement.ShowDialog();
        }

        private void mnBills_Click(object sender, EventArgs e)
        {
            if (panelExMainUI.Controls.IndexOfKey("UserControlBillManagement") == 0)
                return;
            panelExMainUI.Controls.Clear();
            mnBills.Checked = true;
            UserControlBillManagement UserControlBillManagement = new UserControlBillManagement(userFunctionList);
            UserControlBillManagement.Dock = DockStyle.Fill;
            panelExMainUI.Controls.Add(UserControlBillManagement);

        }

        private void ShowDeskTop()
        {
            if (panelExMainUI.Controls.IndexOfKey("UserControlDesktop") == 0)
                return;

            panelExMainUI.Controls.Clear();
            LogHistories.InsertLogHistories("Xem chức năng phân quyền sử dụng", DateTime.Now, userFunctionList.UserName, "Thành công");
            UserControlDesktop UserControlDesktop = new UserControlDesktop(userFunctionList, restaurantInfor);
            UserControlDesktop.openCustomers += new UserControlDesktop.OpenCustomers(mnCustomer_Click);
            UserControlDesktop.openBills += new UserControlDesktop.OpenBills(mnBills_Click);
            UserControlDesktop.onpenServices += new UserControlDesktop.OpenServices(mnServices_Click);
            UserControlDesktop.openMenus += new UserControlDesktop.OpenMenus(mnMenus_Click);
            UserControlDesktop.openReports += new UserControlDesktop.OpenReports(mnReport_Click);
            UserControlDesktop.openStaffs += new UserControlDesktop.OpenStaffs(mnStaff_Click);
            UserControlDesktop.openStocks += new UserControlDesktop.OpenStocks(mnStock_Click);
            UserControlDesktop.openSystemConfigs += new UserControlDesktop.OpenSystemConfigs(btnSystemConfig_Click);
            UserControlDesktop.Dock = DockStyle.Fill;
            panelExMainUI.Controls.Add(UserControlDesktop);
        }

        private void metroAppButtonSystem_Click(object sender, EventArgs e)
        {
            ShowDeskTop();
        }

        private void LoginShowDiaLog()
        {
            Login Login = new Login();
            Login.loginSystem += new Login.LoginSystem(LoginSystem);
            Login.ShowDialog();
        }

        private void metroShell1_SettingsButtonClick(object sender, EventArgs e)
        {
            ConnectionManagement ConnectionManagement = new ConnectionManagement();
            ConnectionManagement.changedDatabase += new ConnectionManagement.ChangedDataBase(CleanController);
            ConnectionManagement.ShowDialog();
        }

        private void metroShell1_HelpButtonClick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnChangePassword_Click(object sender, EventArgs e)
        {
            ChangedPassoword ChangedPassoword = new ChangedPassoword(userFunctionList);
            ChangedPassoword.ShowDialog();
        }

        private void btnSystemConfig_Click(object sender, EventArgs e)
        {
            if (panelExMainUI.Controls.IndexOfKey("UserControlSystemConfig") == 0)
                return;
            panelExMainUI.Controls.Clear();

            UserControlSystemConfig UserControlSystemConfig = new UserControlSystemConfig(userFunctionList);
            UserControlSystemConfig.Dock = DockStyle.Fill;
            panelExMainUI.Controls.Add(UserControlSystemConfig);
        }

        private void btnHelp_Click(object sender, EventArgs e)
        {

        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            AboutUs aboutUs = new AboutUs(isTrial);
            aboutUs.ShowDialog();
        }

        private void backgroundWorkerRestaurantInfor_DoWork(object sender, DoWorkEventArgs e)
        {
            LoadRestaurantInfor();
        }

        private void backgroundWorkerRestaurantInfor_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            backgroundWorkerRestaurantInfor.Dispose();
            backgroundWorkerRestaurantInfor = null;
            GC.Collect();
        }
    }
}
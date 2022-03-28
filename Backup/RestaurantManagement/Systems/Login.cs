using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using RestaurantDTO;
using RestaurantController;
using RestaurantCommon;

namespace RestaurantManagement
{
    public partial class Login : DevComponents.DotNetBar.Metro.MetroForm
    {
        public delegate void LoginSystem(UserFunctionList userFunctions);
        public event LoginSystem loginSystem;

        private StaffDataSet.StaffsDataTable staffsDataTable = null;
        private StaffController staffController = new StaffController();
        private string fullName = string.Empty;
        private int roleId;
        private int staffId;
        private UserFunctionList userFunctionList = new UserFunctionList();
        private Function function = null;
        private FunctionsDetailDataSet.FunctionDetailDataTable functionDetailDataTable = null;
        private FunctionDetailController functionDetailController = new FunctionDetailController();

        private List<Function> Services = new List<Function>();
        private List<Function> Menus = new List<Function>();
        private List<Function> Stocks = new List<Function>();
        private List<Function> Bills = new List<Function>();
        private List<Function> Reports = new List<Function>();
        private List<Function> Customers = new List<Function>();
        private List<Function> Staffs = new List<Function>();
        private List<Function> SystemConfig = new List<Function>();
        private List<Function> Histories = new List<Function>();

        public Login()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (!CheckLogin())
            {
                return;
            }
            LogHistories.InsertLogHistories("Đăng nhập hệ thống thành công", DateTime.Now, txtUserName.Text, "Thành công");
            loginSystem(userFunctionList);
            Clean();
            this.Close();
        }

        private bool CheckLogin()
        {
            if (string.IsNullOrEmpty(txtUserName.Text))
            {
                txtUserName.Focus();
                MessageBox.Show("Bạn hãy nhập vào tên đăng nhập.", Constants.CaptionInformationMessage, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            if (string.IsNullOrEmpty(txtPassword.Text))
            {
                txtPassword.Focus();
                MessageBox.Show("Bạn hãy nhập vào mật khẩu.", Constants.CaptionInformationMessage, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            staffsDataTable = new StaffDataSet.StaffsDataTable();
            staffController.GetStaffByUserName(staffsDataTable, txtUserName.Text);

            if (staffsDataTable.Rows.Count == 0)
            {
                txtUserName.Focus();
                MessageBox.Show("Tên đăng nhập không đúng bạn hãy kiểm tra lại.", Constants.CaptionErrorMessage, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            string newPass = Utilities.EnCryptMD5(txtPassword.Text, Utilities.CKEY, true);
            if (!staffsDataTable.First().PassWord.Trim().Equals(newPass))
            {
                txtPassword.Focus();
                MessageBox.Show("Mật khẩu đăng nhập không chính xác.", Constants.CaptionErrorMessage, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            userFunctionList.UserName = txtUserName.Text;

            userFunctionList.FullName = staffsDataTable.First().FullName;
            staffId = staffsDataTable.First().StaffId;
            userFunctionList.StaffId = staffId;
            userFunctionList.RoleId = staffsDataTable.First().RoleId;
            if (roleId == 2)
            {
                CheckSuperUser();
            }
            else
            {
                GetAllFunctionsByStaffId();
            }
            return true;
        }

        private void Clean()
        {
            txtUserName.Text = string.Empty;
            txtPassword.Text = string.Empty;
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Enter)
            {
                btnLogin_Click(null, null);
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void GetAllFunctionsByStaffId()
        {
            functionDetailDataTable = new FunctionsDetailDataSet.FunctionDetailDataTable();
            functionDetailController.GetFunctionDetailByStaffId(functionDetailDataTable, staffId);

            foreach (FunctionsDetailDataSet.FunctionDetailRow item in functionDetailDataTable.Rows)
            {
                if (item.FunctionId.Trim().Equals(Constants.Services))
                {
                    function = new Function();
                    function.Add = item.AddRole;
                    function.Edit = item.EditRole;
                    function.Delete = item.DeleteRole;
                    function.View = item.Status;
                    Services.Add(function);
                    userFunctionList.Services = Services;
                    continue;
                }

                if (item.FunctionId.Trim().Equals(Constants.Menus))
                {
                    function = new Function();
                    function.Add = item.AddRole;
                    function.Edit = item.EditRole;
                    function.Delete = item.DeleteRole;
                    function.View = item.Status;
                    Menus.Add(function);
                    userFunctionList.Menus = Menus;
                    continue;
                }

                if (item.FunctionId.Trim().Equals(Constants.Stocks))
                {
                    function = new Function();
                    function.Add = item.AddRole;
                    function.Edit = item.EditRole;
                    function.Delete = item.DeleteRole;
                    function.View = item.Status;
                    Stocks.Add(function);
                    userFunctionList.Stocks = Stocks;
                    continue;
                }
                if (item.FunctionId.Trim().Equals(Constants.Bills))
                {
                    function = new Function();
                    function.Add = item.AddRole;
                    function.Edit = item.EditRole;
                    function.Delete = item.DeleteRole;
                    function.View = item.Status;
                    Bills.Add(function);
                    userFunctionList.Bills = Bills;
                    continue;
                }

                if (item.FunctionId.Trim().Equals(Constants.Reports))
                {
                    function = new Function();
                    function.Add = item.AddRole;
                    function.Edit = item.EditRole;
                    function.Delete = item.DeleteRole;
                    function.View = item.Status;
                    Reports.Add(function);
                    userFunctionList.Reports = Reports;
                    continue;
                }

                if (item.FunctionId.Trim().Equals(Constants.Customers))
                {
                    function = new Function();
                    function.Add = item.AddRole;
                    function.Edit = item.EditRole;
                    function.Delete = item.DeleteRole;
                    function.View = item.Status;
                    Customers.Add(function);
                    userFunctionList.Customers = Customers;
                    continue;
                }

                if (item.FunctionId.Trim().Equals(Constants.SystemConfig))
                {
                    function = new Function();
                    function.Add = item.AddRole;
                    function.Edit = item.EditRole;
                    function.Delete = item.DeleteRole;
                    function.View = item.Status;
                    SystemConfig.Add(function);
                    userFunctionList.SystemConfig = SystemConfig;
                    continue;
                }

                if (item.FunctionId.Trim().Equals(Constants.Histories))
                {
                    function = new Function();
                    function.Add = item.AddRole;
                    function.Edit = item.EditRole;
                    function.Delete = item.DeleteRole;
                    function.View = item.Status;
                    Histories.Add(function);
                    userFunctionList.Histories = Histories;
                    continue;
                }

                if (item.FunctionId.Trim().Equals(Constants.Staffs))
                {
                    function = new Function();
                    function.Add = item.AddRole;
                    function.Edit = item.EditRole;
                    function.Delete = item.DeleteRole;
                    function.View = item.Status;
                    Staffs.Add(function);
                    userFunctionList.Staffs = Staffs;
                    continue;
                }

            }
        }

        private void CheckSuperUser()
        {
            function = new Function();
            function.Add = 1;
            function.Edit = 1;
            function.Delete = 1;
            function.View = 1;

            Services.Add(function);
            userFunctionList.Services = Services;

            Menus.Add(function);
            userFunctionList.Menus = Menus;

            Stocks.Add(function);
            userFunctionList.Stocks = Stocks;

            Reports.Add(function);
            userFunctionList.Reports = Reports;

            Bills.Add(function);
            userFunctionList.Bills = Bills;

            Reports.Add(function);
            userFunctionList.Reports = Reports;

            Customers.Add(function);
            userFunctionList.Customers = Customers;

            SystemConfig.Add(function);
            userFunctionList.SystemConfig = SystemConfig;

            Histories.Add(function);
            userFunctionList.Histories = Histories;

            Staffs.Add(function);
            userFunctionList.Staffs = Staffs;

            Histories.Add(function);
            userFunctionList.Histories = Histories;
        }
    }
}

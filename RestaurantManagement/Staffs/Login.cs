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
        public delegate void LoginSystem();
        public event LoginSystem loginSystem;

        private StaffDataSet.StaffsDataTable staffsDataTable = null;
        private StaffController staffController = new StaffController();

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
            Clean();
            loginSystem();
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
    }
}

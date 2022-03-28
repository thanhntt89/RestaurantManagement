using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using RestaurantCommon;
using RestaurantDTO;
using RestaurantController;

namespace RestaurantManagement
{
    public partial class UserControlChangedPassword : UserControl
    {
        private StaffDataSet.StaffsDataTable staffsDataTable = null;
        private StaffController staffController = new StaffController();
        public UserFunctionList userFunctionList;

        private string userName = string.Empty;

        public UserControlChangedPassword(UserFunctionList userFunctionList)
        {
            InitializeComponent();
            this.userFunctionList = userFunctionList;
            lbUserName.Text = userFunctionList.UserName;
        }

        public UserControlChangedPassword()
        {
            InitializeComponent();
        }

        private void UserControlChangedPassword_Load(object sender, EventArgs e)
        {
            panel1.CenterHorizontally();
            panel1.CenterVertically();
        }

        private void UserControlChangedPassword_SizeChanged(object sender, EventArgs e)
        {
            panel1.CenterHorizontally();
            panel1.CenterVertically();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveInfor();
        }

        private bool CheckItem()
        {
            if (string.IsNullOrEmpty(txtOldPassword.Text))
            {
                txtOldPassword.Focus();
                MessageBox.Show("Mật khẩu cũ không được để trống.", Constants.CaptionInformationMessage, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            if (string.IsNullOrEmpty(txtNewPassword.Text))
            {
                txtNewPassword.Focus();
                MessageBox.Show("Mật khẩu mới không được để trống.", Constants.CaptionInformationMessage, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            if (!txtNewPassword.Text.Equals(txtNewPasswordConfirm.Text))
            {
                txtNewPasswordConfirm.Focus();
                MessageBox.Show("Xác nhận mật khẩu mới không đúng.", Constants.CaptionInformationMessage, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            return true;
        }

        private void SaveInfor()
        {
            if (!CheckItem())
            {
                return;
            }
            staffsDataTable = new StaffDataSet.StaffsDataTable();
            staffController.GetStaffByUserName(staffsDataTable, lbUserName.Text);

            if (staffsDataTable.Rows.Count == 0)
                return;

            if (!Utilities.DeCryptMD5(staffsDataTable.First().PassWord, Utilities.CKEY, true).Equals(txtOldPassword.Text))
            {
                MessageBox.Show("Mật khẩu cũ nhập không đúng.", Constants.CaptionErrorMessage, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            staffsDataTable.First().PassWord = Utilities.EnCryptMD5(txtNewPassword.Text, Utilities.CKEY, true);
            try
            {
                staffController.UpdateStaff(staffsDataTable);
                LogHistories.InsertLogHistories("Đổi mật khẩu người dùng ", DateTime.Now, userFunctionList.UserName, "Thành công");

                MessageBox.Show("Thay đổi mật khẩu thành công.", Constants.CaptionInformationMessage, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch
            {
                LogHistories.InsertLogHistories("Đổi mật khẩu người dùng ", DateTime.Now, userFunctionList.UserName, "Lỗi");
                MessageBox.Show("Lỗi đổi mật khẩu không thành công.", Constants.CaptionErrorMessage, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

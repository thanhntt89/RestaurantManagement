using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using RestaurantController;
using RestaurantDTO;
using RestaurantCommon;

namespace RestaurantManagement
{
    public partial class RegisterStaff : DevComponents.DotNetBar.Metro.MetroForm
    {
        public delegate void ReLoadData();
        public event ReLoadData reLoadData;

        private StaffController staffController = new StaffController();
        private StaffDataSet.StaffsDataTable staffDataTable = null;

        private UserFunctionList userFunctionList;

        private int RoleId = -1;

        public RegisterStaff(UserFunctionList userFunctionList)
        {
            InitializeComponent();
            this.userFunctionList = userFunctionList;
        }

        private void btnImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog openfileDialog = new OpenFileDialog();
            Utilities.ConvertImgeToByte(openfileDialog, ptbImage);
        }

        private void btnAddNewStaff_Click(object sender, EventArgs e)
        {
            AddStaff();
        }

        private void AddStaff()
        {
            if (!CheckItem())
                return;
            if (!CheckUserName())
                return;

            staffDataTable = new StaffDataSet.StaffsDataTable();
            var newRow = staffDataTable.NewStaffsRow();
            newRow.StaffCode = txtStaffCode.Text;
            newRow.FullName = txtFullName.Text;
            newRow.UserName = txtUserName.Text;
            newRow.PassWord = Utilities.EnCryptMD5(txtPassword.Text, Utilities.CKEY, true);
            newRow.RoleId = RoleId;
            newRow.Email = txtEmail.Text;
            newRow.Mobile = txtMobile.Text;
            newRow.Address = txtAddress.Text;
            newRow.Image = ptbImage.Image == null ? null : Utilities.ConvertImageToByte(ptbImage.Image);
            newRow.Status = 0;
            staffDataTable.AddStaffsRow(newRow);

            try
            {
                staffController.UpdateStaff(staffDataTable);
                LogHistories.InsertLogHistories("Thêm nhân viên: " + txtFullName.Text + " tên đăng nhập: " + txtUserName.Text, DateTime.Now, userFunctionList.UserName, "Thành công");
                reLoadData();
                MessageBox.Show("Tạo mới nhân viên thành công.", Constants.CaptionInformationMessage, MessageBoxButtons.OK, MessageBoxIcon.Information);
                Clean();
            }
            catch
            {
                LogHistories.InsertLogHistories("Thêm nhân viên: " + txtFullName.Text + " tên đăng nhập: " + txtUserName.Text, DateTime.Now, userFunctionList.UserName, "Lỗi");
                MessageBox.Show("Tạo mới nhân viên không thành công.", Constants.CaptionErrorMessage, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool CheckItem()
        {
            if (rdManager.Checked)
                RoleId = 1;
            else
                RoleId = 0;

            if (string.IsNullOrEmpty(txtFullName.Text))
            {
                MessageBox.Show("Tên người dùng không được để trống", Constants.CaptionErrorMessage, MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtFullName.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtUserName.Text))
            {
                MessageBox.Show("Tên đăng nhập không được để trống", Constants.CaptionErrorMessage, MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtUserName.Focus();
                return false;
            }
            if (RoleId == -1)
            {
                MessageBox.Show("Bạn phải chọn quyền cho người dùng!", Constants.CaptionErrorMessage, MessageBoxButtons.OK, MessageBoxIcon.Information);
                rdManager.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtPassword.Text))
            {
                MessageBox.Show("Mật khẩu không được để trống", Constants.CaptionErrorMessage, MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtPassword.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtComfirmPassword.Text))
            {
                MessageBox.Show("Mật khẩu xác nhận không được để trống", Constants.CaptionErrorMessage, MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtComfirmPassword.Focus();
                return false;
            }
            if (!txtComfirmPassword.Text.Equals(txtPassword.Text))
            {
                MessageBox.Show("Mật khẩu xác nhận không đúng với mật khẩu đã nhập.", Constants.CaptionErrorMessage, MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtComfirmPassword.Focus();
                return false;
            }
            return true;
        }

        private bool CheckUserName()
        {
            staffDataTable = new StaffDataSet.StaffsDataTable();
            staffController.GetStaffByUserName(staffDataTable, txtUserName.Text);
            if (staffDataTable.Rows.Count > 0)
            {
                MessageBox.Show("Tên đăng nhập này đã tồn tại bạn hãy nhập vào tên khác", Constants.CaptionErrorMessage, MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtUserName.Focus();
                return false;
            }
            staffDataTable = new StaffDataSet.StaffsDataTable();
            staffController.GetStaffByStaffCode(staffDataTable, txtStaffCode.Text);
            if (staffDataTable.Rows.Count > 0)
            {
                MessageBox.Show("Mã nhân viên này đã tồn tại bạn hãy nhập vào mã nhân viên khác", Constants.CaptionErrorMessage, MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtStaffCode.Focus();
                return false;
            }
            return true;
        }

        private void Clean()
        {
            txtStaffCode.Focus();
            txtStaffCode.Text = string.Empty;
            txtUserName.Text = string.Empty;
            txtFullName.Text = string.Empty;
            txtPassword.Text = string.Empty;
            txtComfirmPassword.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtMobile.Text = string.Empty;
            txtAddress.Text = string.Empty;
            ptbImage.Image = null;
        }

        private void txtExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Enter)
            {
                btnAddNewStaff_Click(null, null);
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using RestaurantController;
using RestaurantDTO;
using System.Linq;
using RestaurantCommon;
namespace RestaurantManagement
{
    public partial class UpdateStaff : DevComponents.DotNetBar.Metro.MetroForm
    {
        public delegate void ReLoadData();
        public event ReLoadData reLoadData;

        private StaffController staffController = new StaffController();
        private StaffDataSet.StaffsDataTable staffDataTable = null;

        private int RoleId = -1;
        private int StaffId = -1;

        private UserFunctionList userFunctionList;

        public UpdateStaff(int staffId, UserFunctionList userFunctionList)
        {
            InitializeComponent();
            this.StaffId = staffId;
            this.userFunctionList = userFunctionList;
        }


        public UpdateStaff()
        {
            InitializeComponent();
        }

        private void txtExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void LoadUpdate()
        {
            staffDataTable = new StaffDataSet.StaffsDataTable();
            staffController.GetStaffByStaffId(staffDataTable, StaffId);
            if (staffDataTable.Rows.Count == 0)
                return;
            txtStaffCode.Text = staffDataTable.First().Field<string>("StaffCode");
            txtFullName.Text = staffDataTable.First().FullName;
            txtUserName.Text = staffDataTable.First().UserName;
            RoleId = staffDataTable.First().RoleId;

            if (RoleId == 2)
            {
                rdManager.Checked = true;
                rdManager.Text = "Supper Admin";
                rdManager.Enabled = false;
                rdUser.Enabled = false;
            }
            else
                if (RoleId == 1)
                {
                    rdManager.Checked = true;
                }
                else
                {
                    rdUser.Checked = true;
                }

            txtPassword.Text = Utilities.DeCryptMD5(staffDataTable.First().PassWord, Utilities.CKEY, true);
            txtComfirmPassword.Text = txtPassword.Text;
            txtEmail.Text = staffDataTable.First().Field<string>("Email");
            txtMobile.Text = staffDataTable.First().Field<string>("Mobile");
            txtAddress.Text = staffDataTable.First().Field<string>("Address");
            ptbImage.Image = staffDataTable.First().IsImageNull() ? null : Utilities.ConvertByteToImage(staffDataTable.First().Image);
        }

        private void btnAddNewStaff_Click(object sender, EventArgs e)
        {
            AddStaff();
        }

        private void AddStaff()
        {
            if (!CheckItem())
                return;

            staffDataTable = new StaffDataSet.StaffsDataTable();
            staffController.GetStaffByStaffId(staffDataTable, StaffId);
            if (staffDataTable.Rows.Count == 0)
            {
                return;
            }

            staffDataTable.First().PassWord = Utilities.EnCryptMD5(txtPassword.Text, Utilities.CKEY, true);
            staffDataTable.First().FullName = txtFullName.Text.Trim();
            staffDataTable.First().RoleId = RoleId;
            staffDataTable.First().Email = txtEmail.Text.Trim();
            staffDataTable.First().Mobile = txtMobile.Text.Trim();
            staffDataTable.First().Address = txtAddress.Text.Trim();
            staffDataTable.First().Image = ptbImage.Image == null ? null : Utilities.ConvertImageToByte(ptbImage.Image);

            try
            {
                staffController.UpdateStaff(staffDataTable);
                LogHistories.InsertLogHistories("Cập nhật nhân viên: " + txtFullName.Text + " tên đăng nhập: " + txtUserName.Text, DateTime.Now, userFunctionList.UserName, "Thành công");
                reLoadData();
                MessageBox.Show("Cập nhật nhân viên thành công.", Constants.CaptionInformationMessage, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch
            {
                LogHistories.InsertLogHistories("Cập nhật nhân viên: " + txtFullName.Text + " tên đăng nhập: " + txtUserName.Text, DateTime.Now, userFunctionList.UserName, "Lỗi");
                MessageBox.Show("Cập nhật nhân viên không thành công.", Constants.CaptionErrorMessage, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            this.Close();
        }

        private bool CheckStaffCode()
        {
            staffDataTable = new StaffDataSet.StaffsDataTable();
            staffController.GetStaffByStaffCode(staffDataTable, txtStaffCode.Text);
            if (staffDataTable.Rows.Count > 1)
            {
                MessageBox.Show("Mã nhân viên này đã tồn tại bạn hãy nhập vào mã nhân viên khác", Constants.CaptionErrorMessage, MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtStaffCode.Focus();
                return false;
            }
            return true;
        }

        private bool CheckItem()
        {
            if (rdManager.Checked)
            {
                if (RoleId == 2)
                {
                    RoleId = 2;
                }
                else
                    RoleId = 1;
            }
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

        private void btnImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog openfileDialog = new OpenFileDialog();
            Utilities.ConvertImgeToByte(openfileDialog, ptbImage);
        }

        private void UpdateStaff_Load(object sender, EventArgs e)
        {
            LoadUpdate();
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
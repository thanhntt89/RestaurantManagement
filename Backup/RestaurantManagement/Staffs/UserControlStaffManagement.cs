using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using RestaurantController;
using RestaurantDTO;
using RestaurantCommon;

namespace RestaurantManagement
{
    public partial class UserControlStaffManagement : UserControl
    {
        private StaffController staffController = new StaffController();
        private StaffDataSet.StaffsDataTable staffsDataTable = null;

        // private int roleIdLogin;
        private UserFunctionList userFunctionList;
        private bool isTrail = true;
        public UserControlStaffManagement(bool isTrail, UserFunctionList userFunctionList)
        {
            InitializeComponent();
            this.isTrail = isTrail;
            this.userFunctionList = userFunctionList;
            // this.roleIdLogin = userFunctionList.RoleId;
        }

        private void btnAddNewStaff_Click(object sender, EventArgs e)
        {
            if (isTrail)
            {
                MessageBox.Show("Đây là phiên bản dùng thử bạn không có quyền sử dụng tính năng này.\n Để sử dụng được bạn vui lòng đăng ký sử dụng!\n Liên hệ: Nguyễn Tất Thành Mobile: 098 664 8910", "Phiên bản dùng thử", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            RegisterStaff RegisterStaff = new RegisterStaff(userFunctionList);
            RegisterStaff.reLoadData += new RegisterStaff.ReLoadData(LoadAllStaff);
            RegisterStaff.ShowDialog();
        }

        private void btnEditCustomer_Click(object sender, EventArgs e)
        {
            UpdateStaffForm();
        }

        private void UpdateStaffForm()
        {
            int StaffId = -1;

            StaffId = (int)dgvStaffList.CurrentRow.Cells["StaffId"].Value;
            UpdateStaff UpdateStaff = new UpdateStaff(StaffId, userFunctionList);
            UpdateStaff.reLoadData += new UpdateStaff.ReLoadData(LoadAllStaff);
            UpdateStaff.ShowDialog();
        }

        private void UserControlStaffManagement_Load(object sender, EventArgs e)
        {
            LoadAllStaff();
        }

        private void LoadAllStaff()
        {
            dgvStaffList.Rows.Clear();

            staffsDataTable = new StaffDataSet.StaffsDataTable();
            staffController.GetAllStaff(staffsDataTable);
            LogHistories.InsertLogHistories("Tìm kiếm nhân viên từ danhg sách ", DateTime.Now, userFunctionList.UserName, "Thành công");
            if (staffsDataTable.Rows.Count == 0)
                return;
            var querry = from row in staffsDataTable
                         select row;
            if (!string.IsNullOrEmpty(txtFullName.Text))
            {
                querry = querry.Where(r => r.FullName.IndexOf(txtFullName.Text, StringComparison.OrdinalIgnoreCase) >= 0);
            }
            if (!string.IsNullOrEmpty(txtStaffCode.Text))
            {
                querry = querry.Where(r => r.StaffCode.IndexOf(txtStaffCode.Text, StringComparison.OrdinalIgnoreCase) >= 0);
            }
            if (!string.IsNullOrEmpty(txtMobile.Text))
            {
                querry = querry.Where(r => r.Mobile.IndexOf(txtMobile.Text, StringComparison.OrdinalIgnoreCase) >= 0);
            }
            if (!string.IsNullOrEmpty(txtUserName.Text))
            {
                querry = querry.Where(r => r.UserName.IndexOf(txtUserName.Text, StringComparison.OrdinalIgnoreCase) >= 0);
            }

            int indexrow = 0;
            dgvStaffList.AllowUserToAddRows = true;
            foreach (var item in querry)
            {
                dgvStaffList.Rows.Add();
                DataGridViewRow row = dgvStaffList.Rows[indexrow];
                row.Cells["STT"].Value = indexrow + 1;
                row.Cells["StaffCode"].Value = item.StaffCode;
                row.Cells["FullName"].Value = item.FullName;
                row.Cells["UserName"].Value = item.UserName;
                row.Cells["Mobile"].Value = item.Mobile;
                row.Cells["Address"].Value = item.Address;
                row.Cells["Email"].Value = item.Email;
                row.Cells["StaffId"].Value = item.StaffId;
                row.Cells["RoleId"].Value = item.RoleId;
                if (item.RoleId == 2)
                    row.Cells["Role"].Value = "Supper Admin";
                else
                    if (item.RoleId == 1)
                        row.Cells["Role"].Value = "Quản lý";
                    else
                        row.Cells["Role"].Value = "Nhân viên";

                indexrow++;
            }
            dgvStaffList.AllowUserToAddRows = false;
        }

        private void dgvStaffList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            UpdateStaffForm();
        }

        private void btnDeleteCustomer_Click(object sender, EventArgs e)
        {
            DeleteUser();
        }

        private void DeleteUser()
        {
            int StaffId = -1;
            int roleId = -1;
            roleId = (int)dgvStaffList.CurrentRow.Cells["RoleId"].Value;

            if (roleId == 2)
            {
                MessageBox.Show("Tài khoản quản trị hệ thống bạn không thể xóa.", Constants.CaptionInformationMessage, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            StaffId = (int)dgvStaffList.CurrentRow.Cells["StaffId"].Value;

            staffsDataTable = new StaffDataSet.StaffsDataTable();
            staffController.GetStaffByStaffId(staffsDataTable, StaffId);
            if (staffsDataTable.Rows.Count == 0)
                return;

            string userName = dgvStaffList.CurrentRow.Cells["UserName"].Value.ToString();
            DialogResult rst = MessageBox.Show("Bạn có muốn xoá người dùng " + userName + " này không?", Constants.CaptionInformationMessage, MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (rst != DialogResult.Yes)
                return;
            staffsDataTable.First().Delete();
            try
            {
                staffController.UpdateStaff(staffsDataTable);
                LogHistories.InsertLogHistories("Xóa nhân viên: " + userName, DateTime.Now, userFunctionList.UserName, "Thành công");
                MessageBox.Show("Xoá thông tin thành công!", Constants.CaptionInformationMessage, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch
            {
                LogHistories.InsertLogHistories("Xóa nhân viên: " + userName, DateTime.Now, userFunctionList.UserName, "Lỗi");
                MessageBox.Show("Không thể xoá được: Nhân viên đang được sử dụng trong hoá đơn!", Constants.CaptionErrorMessage, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            LoadAllStaff();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            LoadAllStaff();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Enter)
            {
                btnSearch_Click(null, null);
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
}

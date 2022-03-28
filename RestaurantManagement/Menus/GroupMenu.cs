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
    public partial class GroupMenu : DevComponents.DotNetBar.Metro.MetroForm
    {
        private MenuGroupDataSet.MenuGroupDataTable menuGroupDataTable = null;
        private MenuGroupController menuGroupController = new MenuGroupController();

        public delegate void ReLoadData();
        public event ReLoadData reLoadData;
        private UserFunctionList userFunctionList;
        public GroupMenu(UserFunctionList userFunctionList)
        {
            InitializeComponent();
            this.userFunctionList = userFunctionList;
            CheckRole();
        }

        private void CheckRole()
        {
            dgvGroupName.Columns["Delete"].Visible = false;
            dgvGroupName.AllowUserToAddRows = false;
            btnSave.Enabled = false;

            if (userFunctionList.Menus[0].Add == 1)
            {
                btnSave.Enabled = true;
                dgvGroupName.AllowUserToAddRows = true;
            }
            if (userFunctionList.Menus[0].Edit == 1)
            {
                btnSave.Enabled = true;
            }
            if (userFunctionList.Menus[0].Delete == 1)
            {
                dgvGroupName.Columns["Delete"].Visible = true;
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            MenuGroupSave();
            reLoadData();
        }

        private void LoadGroupMenu()
        {
            menuGroupDataTable = new MenuGroupDataSet.MenuGroupDataTable();
            menuGroupController.GetAllMenuGroup(menuGroupDataTable);
            if (menuGroupDataTable.Rows.Count == 0)
                return;

            DataGridViewTextBoxCell sTT, groupName, note, delete, menuGroupId;

            int index = 0;

            foreach (MenuGroupDataSet.MenuGroupRow row in menuGroupDataTable.Rows)
            {
                index++;

                sTT = new DataGridViewTextBoxCell();
                sTT.Value = index;

                groupName = new DataGridViewTextBoxCell();
                groupName.Value = row.GroupName;

                note = new DataGridViewTextBoxCell();
                note.Value = row.IsGroupNoteNull() ? string.Empty : row.GroupNote;

                delete = new DataGridViewTextBoxCell();
                delete.Value = "Xoá";

                menuGroupId = new DataGridViewTextBoxCell();
                menuGroupId.Value = row.GroupId;

                dgvGroupName.Rows.Add(sTT.Value, groupName.Value, note.Value, delete.Value, menuGroupId.Value);
            }
        }

        private void GroupMenu_Load(object sender, EventArgs e)
        {
            LoadGroupMenu();
        }

        private bool CheckItem()
        {
            for (int i = 0; i < dgvGroupName.Rows.Count - 1; i++)
            {
                if (dgvGroupName.Rows[i].Cells["GroupName"].Value == null)
                {
                    MessageBox.Show("Tên nhóm thực đơn không để trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }

            return true;
        }

        private void MenuGroupSave()
        {
            if (!CheckItem())
            {
                return;
            }

            string menuGroupId = string.Empty;
            menuGroupDataTable = new MenuGroupDataSet.MenuGroupDataTable();

            for (int i = 0; i < dgvGroupName.Rows.Count - 1; i++)
            {
                // Cập nhật
                if (dgvGroupName.Rows[i].Cells["MenuGroupId"].Value != null)
                {
                    menuGroupId = dgvGroupName.Rows[i].Cells["MenuGroupId"].Value.ToString();
                    menuGroupController.GetMenuGroupByMenuGroupId(menuGroupDataTable, int.Parse(menuGroupId));
                    if (menuGroupDataTable.Rows.Count == 0)
                        continue;
                    menuGroupDataTable.First().GroupName = dgvGroupName.Rows[i].Cells["GroupName"].Value.ToString();
                    menuGroupDataTable.First().GroupNote = dgvGroupName.Rows[i].Cells["Note"].Value == null ? string.Empty : dgvGroupName.Rows[i].Cells["Note"].Value.ToString();

                    try
                    {
                        menuGroupController.UpdateMenuGroup(menuGroupDataTable);
                        LogHistories.InsertLogHistories("Thêm danh mục mới " + dgvGroupName.Rows[i].Cells["GroupName"].Value.ToString(), DateTime.Now, userFunctionList.UserName, "Thành công");
                    }
                    catch
                    {
                        LogHistories.InsertLogHistories("Thêm danh mục mới " + dgvGroupName.Rows[i].Cells["GroupName"].Value.ToString(), DateTime.Now, userFunctionList.UserName, "Lỗi");
                        MessageBox.Show("Thêm mới nhóm " + dgvGroupName.Rows[i].Cells["GroupName"].Value.ToString() + " không thành công!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                // Thêm mới
                else
                {
                    var newRow = menuGroupDataTable.NewMenuGroupRow();
                    newRow.GroupName = dgvGroupName.Rows[i].Cells["GroupName"].Value.ToString();
                    newRow.GroupNote = dgvGroupName.Rows[i].Cells["Note"].Value == null ? string.Empty : dgvGroupName.Rows[i].Cells["Note"].Value.ToString();

                    menuGroupDataTable.AddMenuGroupRow(newRow);

                    try
                    {
                        menuGroupController.UpdateMenuGroup(menuGroupDataTable);
                        LogHistories.InsertLogHistories("Cập nhật danh mục " + dgvGroupName.Rows[i].Cells["GroupName"].Value.ToString(), DateTime.Now, userFunctionList.UserName, "Thành công");
                    }
                    catch
                    {
                        LogHistories.InsertLogHistories("Cập nhật danh mục " + dgvGroupName.Rows[i].Cells["GroupName"].Value.ToString(), DateTime.Now, userFunctionList.UserName, "Lỗi");
                        MessageBox.Show("Thêm mới nhóm " + dgvGroupName.Rows[i].Cells["GroupName"].Value.ToString() + " không thành công!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
            }
            reLoadData();

            MessageBox.Show("Lưu thông tin thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void dgvGroupName_UserAddedRow(object sender, DataGridViewRowEventArgs e)
        {
            dgvGroupName.CurrentRow.Cells["STT"].Value = e.Row.Index;

        }

        private void DeleteMenuGroupByGroupId(int indexRow)
        {
            int menuGroupId = 0;
            menuGroupDataTable = new MenuGroupDataSet.MenuGroupDataTable();
            string GroupName = string.Empty;
            int rowCount = dgvGroupName.Rows.Count - 1;
            if (dgvGroupName.CurrentRow.Cells["GroupName"].Value == null)
                return;
            GroupName = dgvGroupName.CurrentRow.Cells["GroupName"].Value.ToString();
            DialogResult rst = MessageBox.Show("Bạn có muốn xoá vùng " + GroupName + " này không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (rst != DialogResult.Yes)
                return;

            // Xoá trong database nếu có
            if (dgvGroupName.Rows[indexRow].Cells["MenuGroupId"].Value != null)
            {
                menuGroupId = int.Parse(dgvGroupName.CurrentRow.Cells["MenuGroupId"].Value.ToString());

                menuGroupController.GetMenuGroupByMenuGroupId(menuGroupDataTable, menuGroupId);
                menuGroupDataTable.First().Delete();
                try
                {
                    menuGroupController.UpdateMenuGroup(menuGroupDataTable);
                    LogHistories.InsertLogHistories("Xóa danh mục thực đơn " + GroupName, DateTime.Now, userFunctionList.UserName, "Thành công");

                    MessageBox.Show("Xoá thông tin thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch
                {
                    LogHistories.InsertLogHistories("Xóa danh mục thực đơn " + GroupName, DateTime.Now, userFunctionList.UserName, "Lỗi");
                    MessageBox.Show("Nhóm danh mục đang có thực đơn không thể xoá được!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            dgvGroupName.Rows.RemoveAt(indexRow);
            reLoadData();
        }

        private void dgvGroupName_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 3)
            {
                DeleteMenuGroupByGroupId(e.RowIndex);
            }
        }
    }
}

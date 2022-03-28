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
using DevComponents.DotNetBar.Controls;
using RestaurantCommon;

namespace RestaurantManagement
{
    public partial class UserControlMenuList : UserControl
    {
        private int menuGroupId = 0;
        private string menuGroupName = string.Empty;
        private int subGroupId = 0;
        private string subGroupName = string.Empty;

        private MenuGroupDataSet.MenuGroupDataTable menuGroupDataTable = null;
        private MenuGroupController menuGroupController = new MenuGroupController();
        private MenuDataSet.MenuDataTable menuDataTable = null;
        private MenuDataSet.MenuAndSubGroupMenuDataTable menuAndSubGroupMenuDataTable = null;
        private MenuController menuController = new MenuController();
        private SubGroupMenuDataSet.SubGroupMenuDataTable subGroupMenuDataTable = null;
        private SubGroupMenuController subGroupMenuController = new SubGroupMenuController();

        private UserFunctionList userFunctionList = null;
        private bool isTrail = true;

        public UserControlMenuList(bool isTrail, UserFunctionList userFunctionList)
        {
            InitializeComponent();
            this.isTrail = isTrail;
            this.userFunctionList = userFunctionList;
            CheckRole();
        }

        private void CheckRole()
        {
            btnAddFood.Enabled = false;
            btnDeleteFood.Enabled = false;
            dgvMenuList.Columns["Delete"].Visible = false;
            btnEditFood.Enabled = false;
            btnGroupMenu.Enabled = false;
            mnAddFoodGroupName.Enabled = false;
            mnDeleteFoodGroup.Enabled = false;
            mnEditFoodGroupName.Enabled = false;

            if (userFunctionList.Menus[0].Add == 1)
            {
                btnAddFood.Enabled = true;
                btnGroupMenu.Enabled = true;
                mnAddFoodGroupName.Enabled = true;
            }
            if (userFunctionList.Menus[0].Edit == 1)
            {
                btnGroupMenu.Enabled = true;
                mnEditFoodGroupName.Enabled = true;
                btnEditFood.Enabled = true;
            }
            if (userFunctionList.Menus[0].Delete == 1)
            {
                btnDeleteFood.Enabled = true;
                dgvMenuList.Columns["Delete"].Visible = true;
                mnDeleteFoodGroup.Enabled = true;
            }
        }

        private void btnAddFood_Click(object sender, EventArgs e)
        {
            if (isTrail)
            {
                MessageBox.Show("Đây là phiên bản dùng thử bạn không có quyền sử dụng tính năng này.\n Để sử dụng được bạn vui lòng đăng ký sử dụng!\n Liên hệ: Nguyễn Tất Thành Mobile: 098 664 8910", "Phiên bản dùng thử", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            AddMenu AddFood = new AddMenu(subGroupId, subGroupName, menuGroupName, userFunctionList);
            AddFood.reLoadData += new AddMenu.ReLoadData(LoadFoodMenuBySubMenuGroup);
            AddFood.ShowDialog();
        }

        private void btnEditFood_Click(object sender, EventArgs e)
        {
            ShowFormUpdateMenu();
        }

        private void mnAddFoodGroupName_Click(object sender, EventArgs e)
        {
            try
            {
                string groupId = listViewMenus.SelectedItems[0].Group.Name;
                AddSubGroupMenu AddFoodGroup = new AddSubGroupMenu(groupId, userFunctionList);
                AddFoodGroup.reLoadData += new AddSubGroupMenu.ReLoadData(LoadMenuListView);
                AddFoodGroup.ShowDialog();
            }
            catch
            {
                MessageBox.Show("Bạn chưa chọn danh mục thực đơn nào để thao tác.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void mnEditFoodGroupName_Click(object sender, EventArgs e)
        {
            try
            {
                string subgroupId = listViewMenus.SelectedItems[0].Name;
                string groupId = listViewMenus.SelectedItems[0].Group.Name;
                EditFoodGroup EditFoodGroup = new EditFoodGroup(groupId, subgroupId, userFunctionList);
                EditFoodGroup.reLoadData += new EditFoodGroup.ReLoadData(LoadMenuListView);
                EditFoodGroup.ShowDialog();
            }
            catch
            {
                MessageBox.Show("Bạn chưa chọn danh mục thực đơn nào để thao tác.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadAllMenuGroup()
        {
            menuGroupDataTable = new MenuGroupDataSet.MenuGroupDataTable();
            menuGroupController.GetAllMenuGroup(menuGroupDataTable);

            var newRow = menuGroupDataTable.NewMenuGroupRow();
            newRow.GroupId = -1;
            newRow.GroupName = string.Empty;
            newRow.GroupNote = string.Empty;
            menuGroupDataTable.Rows.InsertAt(newRow, 0);

            cboMenuGroup.DataSource = menuGroupDataTable;
            cboMenuGroup.DisplayMembers = menuGroupDataTable.GroupNameColumn.ColumnName;
            cboMenuGroup.ValueMember = menuGroupDataTable.GroupIdColumn.ColumnName;
        }

        private void LoadSubGroupMenu()
        {
            subGroupMenuDataTable = new SubGroupMenuDataSet.SubGroupMenuDataTable();
            subGroupMenuController.GetAllSubGroupMenu(subGroupMenuDataTable);
        }

        private void LoadMenuListView()
        {
            LoadSubGroupMenu();
            if (menuGroupDataTable == null | subGroupMenuDataTable == null)
                return;
            var querry = from row in menuGroupDataTable
                         select row;
            if (cboMenuGroup.SelectedIndex > 0)
                querry = querry.Where(r => r.GroupId == int.Parse(cboMenuGroup.SelectedValue.ToString()));

            listViewMenus.Items.Clear();

            listViewMenus.View = View.Tile;
            // Load danh mục MenuGroup
            ListViewGroup listViewGroup = null;
            ListViewItem listViewSubGroup = null;
            foreach (var row in querry)
            {
                listViewGroup = new ListViewGroup();
                listViewGroup.Name = row.GroupId.ToString();
                listViewGroup.Header = row.GroupName;
                listViewMenus.Groups.Add(listViewGroup);

                var querrySubGroup = from item in subGroupMenuDataTable
                                     where item.GroupId == row.GroupId
                                     select item;
                foreach (var item in querrySubGroup)
                {
                    listViewSubGroup = new ListViewItem();
                    listViewSubGroup.Name = item.SubGroupId.ToString();
                    listViewSubGroup.Text = item.SubGroupName;
                    listViewSubGroup.Group = listViewGroup;
                    listViewSubGroup.ImageIndex = 1;
                    listViewMenus.Items.Add(listViewSubGroup);
                }
            }
        }

        private void UserControlMenuList_Load(object sender, EventArgs e)
        {
            LoadAllMenuGroup();
            LoadSubGroupMenu();
            LoadMenuListView();
        }

        private void btnGroupMenu_Click(object sender, EventArgs e)
        {
            GroupMenu GroupMenu = new GroupMenu(userFunctionList);
            GroupMenu.reLoadData += new GroupMenu.ReLoadData(LoadAllMenuGroup);
            GroupMenu.ShowDialog();
        }

        private void mnDeleteFoodGroup_Click(object sender, EventArgs e)
        {
            try
            {
                subGroupId = int.Parse(listViewMenus.SelectedItems[0].Name);
                subGroupName = listViewMenus.SelectedItems[0].Text;
                DeleteSubGroup(subGroupId, subGroupName);
            }
            catch
            {
                MessageBox.Show("Bạn chưa chọn danh mục thực đơn nào để thao tác.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DeleteSubGroup(int subgroupId, string subGroupName)
        {
            DialogResult rst = MessageBox.Show("Bạn có muốn xoá danh mục thực đơn " + subGroupName + " này không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (rst != DialogResult.Yes)
                return;

            subGroupMenuDataTable = new SubGroupMenuDataSet.SubGroupMenuDataTable();
            subGroupMenuController.GetSubGroupMenuBySubGroupMenuId(subGroupMenuDataTable, subgroupId);

            if (subGroupMenuDataTable.Rows.Count == 0)
                return;

            subGroupMenuDataTable.First().Delete();
            try
            {
                subGroupMenuController.UpdateSubGroupMenu(subGroupMenuDataTable);
                LogHistories.InsertLogHistories("Xóa danh mục thực đơn " + subGroupName, DateTime.Now, userFunctionList.UserName, "Thành công");
                LoadMenuListView();
                MessageBox.Show("Xoá thông tin danh mục thực đơn thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch
            {
                LogHistories.InsertLogHistories("Xóa danh mục thực đơn " + subGroupName, DateTime.Now, userFunctionList.UserName, "Lỗi");
                MessageBox.Show("Danh mục này đang có thông tin thực đơn.\n Không xoá được thông tin danh mục thực đơn", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void LoadFoodMenuBySubMenuGroup()
        {
            subGroupId = 0;
            try
            {
                menuGroupId = int.Parse(listViewMenus.SelectedItems[0].Group.Name);
                menuGroupName = listViewMenus.SelectedItems[0].Group.Header;
                subGroupId = int.Parse(listViewMenus.SelectedItems[0].Name);
                subGroupName = listViewMenus.SelectedItems[0].Text;
            }
            catch
            {
                //dgvMenuList.Columns["ItemName"].HeaderText = "Tên món ăn nhóm";
                //dgvMenuList.Rows.Clear();
                //MessageBox.Show("Bạn chưa chọn mục nào để thao tác", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //return;
            }

            menuAndSubGroupMenuDataTable = new MenuDataSet.MenuAndSubGroupMenuDataTable();
         
            if (subGroupId > 0 | cboMenuGroup.SelectedIndex != 0)
            {
                 menuController.GetMenuBySubGroupId(menuAndSubGroupMenuDataTable, subGroupId);
            }
            else
            {
                menuController.GetAllMenuAndSubGroupMenu(menuAndSubGroupMenuDataTable);
            }

            dgvMenuList.Rows.Clear();
           // dgvMenuList.Columns["ItemName"].HeaderText = "Tên món ăn nhóm: " + subGroupName;

            var querry = from row in menuAndSubGroupMenuDataTable
                         select row;


            if (!string.IsNullOrEmpty(txtMenuName.Text))
            {
                querry = querry.Where(r => r.ItemName.IndexOf(txtMenuName.Text, StringComparison.OrdinalIgnoreCase) >= 0);
            }

            DataGridViewTextBoxCell sTT, subMenuGroup, itemMenu, unitName, menuId;
            DataGridViewButtonCell meterial, delete;
            DataGridViewImageCell image;
            DataGridViewDoubleInputCell cost;

            int index = 0;


            foreach (var item in querry)
            {
                index++;
                sTT = new DataGridViewTextBoxCell();
                sTT.Value = index;

                subMenuGroup = new DataGridViewTextBoxCell();
                subMenuGroup.Value = item.SubGroupName;

                itemMenu = new DataGridViewTextBoxCell();
                itemMenu.Value = item.ItemName;

                unitName = new DataGridViewTextBoxCell();
                unitName.Value = item.UnitName;

                cost = new DataGridViewDoubleInputCell();
                cost.Value = item.Cost;

                image = new DataGridViewImageCell();
                image.Value = item.IsImageMenuNull() ? null : Utilities.ConvertByteToImage(item.ImageMenu);

                meterial = new DataGridViewButtonCell();
                meterial.Value = "Chế biến";

                delete = new DataGridViewButtonCell();
                delete.Value = "Xoá";

                menuId = new DataGridViewTextBoxCell();
                menuId.Value = item.MenuId;

                dgvMenuList.Rows.Add(sTT.Value, subMenuGroup.Value, itemMenu.Value, unitName.Value, cost.Value, image.Value, meterial.Value, delete.Value, menuId.Value);
            }
        }

        private void listViewMenus_DoubleClick(object sender, EventArgs e)
        {
            LoadFoodMenuBySubMenuGroup();
        }

        private void dgvMenuList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Nếu click chuột vào cột xoá
            if (e.ColumnIndex == 7)
            {
                DeleteMenuGroupByGroupId(e.RowIndex);
            }
        }

        private void DeleteMenuGroupByGroupId(int indexRow)
        {
            int menuId = 0;
            menuDataTable = new MenuDataSet.MenuDataTable();
            string ItemName = string.Empty;

            if (dgvMenuList.Rows[indexRow].Cells["MenuId"].Value == null)
                return;

            menuId = (int)dgvMenuList.Rows[indexRow].Cells["MenuId"].Value;

            ItemName = dgvMenuList.Rows[indexRow].Cells["ItemName"].Value.ToString();
            DialogResult rst = MessageBox.Show("Bạn có muốn xoá món ăn " + ItemName + " này không?", Constants.CaptionInformationMessage, MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (rst != DialogResult.Yes)
                return;

            menuController.GetMenuByMenuId(menuDataTable, menuId);
            menuDataTable.First().Delete();
            try
            {
                menuController.UpdateMenu(menuDataTable);
                LogHistories.InsertLogHistories("Xóa thực đơn " + ItemName, DateTime.Now, userFunctionList.UserName, "Thành công");
                MessageBox.Show("Xoá thông tin thành công!", Constants.CaptionInformationMessage, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch
            {
                LogHistories.InsertLogHistories("Xóa thực đơn " + ItemName, DateTime.Now, userFunctionList.UserName, "Lỗi");
                MessageBox.Show("Không thể xoá được: Thực đơn đang được sử dụng trong hoá đơn.!", Constants.CaptionErrorMessage, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            dgvMenuList.Rows.RemoveAt(indexRow);
        }

        private void btnDeleteFood_Click(object sender, EventArgs e)
        {
            if (dgvMenuList.Rows.Count > 0)
                DeleteMenuGroupByGroupId(dgvMenuList.CurrentRow.Index);
        }

        private void dgvMenuList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (userFunctionList.Menus[0].Edit == 1)
            {
                ShowFormUpdateMenu();
            }
        }

        private void ShowFormUpdateMenu()
        {
            if (dgvMenuList.Rows.Count == 0)
                return;

            int menuId = int.Parse(dgvMenuList.CurrentRow.Cells["MenuId"].Value.ToString());
            LogHistories.InsertLogHistories("Xem cập thực đơn " + dgvMenuList.CurrentRow.Cells["ItemName"].Value.ToString(), DateTime.Now, userFunctionList.UserName, "Thành công");
            UpdateMenu UpdateMenu = new UpdateMenu(menuId, subGroupId, menuGroupId, subGroupName, menuGroupName, userFunctionList);
            UpdateMenu.reLoadData += new UpdateMenu.ReLoadData(LoadFoodMenuBySubMenuGroup);
            UpdateMenu.ShowDialog();
        }

        private void listViewMenus_Click(object sender, EventArgs e)
        {
          //  LoadAllMenuBySubGroupMenu();
           // cboMenuGroup.SelectedIndex = -1;
            LoadFoodMenuBySubMenuGroup();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            LoadFoodMenuBySubMenuGroup();
        }

        private void cboMenuGroup_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadMenuListView();
            LoadFoodMenuBySubMenuGroup();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Enter)
                listViewMenus_Click(null, null);
            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
}
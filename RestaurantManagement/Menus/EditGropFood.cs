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
    public partial class EditFoodGroup : DevComponents.DotNetBar.Metro.MetroForm
    {
        public delegate void ReLoadData();
        public event ReLoadData reLoadData;

        private SubGroupMenuDataSet.SubGroupMenuDataTable subGroupMenuDataTable = null;
        private SubGroupMenuController subGroupMenuController = new SubGroupMenuController();
        private MenuGroupDataSet.MenuGroupDataTable menuGroupDataTable = null;
        private MenuGroupController menuGroupController = new MenuGroupController();

        private int subgroupId = 0;
        private int groupId = 0;
        private UserFunctionList userFunctionList;

        public EditFoodGroup(string groupId, string subgroupId, UserFunctionList userFunctionList)
        {
            InitializeComponent();
            this.subgroupId = int.Parse(subgroupId);
            this.groupId = int.Parse(groupId);
            this.userFunctionList = userFunctionList;
        }

        public EditFoodGroup()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void EditFoodGroup_Load(object sender, EventArgs e)
        {
            LoadAllGroup();
        }

        private void LoadAllGroup()
        {
            menuGroupDataTable = new MenuGroupDataSet.MenuGroupDataTable();
            menuGroupController.GetAllMenuGroup(menuGroupDataTable);
            if (menuGroupDataTable.Rows.Count == 0)
                return;

            cboParentGroup.DataSource = menuGroupDataTable;
            cboParentGroup.DisplayMembers = menuGroupDataTable.GroupNameColumn.ColumnName;
            cboParentGroup.ValueMember = menuGroupDataTable.GroupIdColumn.ColumnName;

            cboParentGroup.SelectedValue = groupId;

            subGroupMenuDataTable = new SubGroupMenuDataSet.SubGroupMenuDataTable();
            subGroupMenuController.GetSubGroupMenuBySubGroupMenuId(subGroupMenuDataTable, subgroupId);

            txtNote.Text = subGroupMenuDataTable.First().Field<string>("Note");
            txtSubGroup.Text = subGroupMenuDataTable.First().SubGroupName;
        }

        private void UpdateSubGroupMenu()
        {
            if (!CheckItem())
                return; 

            subGroupMenuDataTable = new SubGroupMenuDataSet.SubGroupMenuDataTable();
            subGroupMenuController.GetSubGroupMenuBySubGroupMenuId(subGroupMenuDataTable, subgroupId);
            
            if (subGroupMenuDataTable.Rows.Count == 0)
                return;
            subGroupMenuDataTable.First().SubGroupName = txtSubGroup.Text;
            subGroupMenuDataTable.First().Note = txtNote.Text;
            subGroupMenuDataTable.First().GroupId = int.Parse(cboParentGroup.SelectedValue.ToString());
            try
            {
                subGroupMenuController.UpdateSubGroupMenu(subGroupMenuDataTable);
                LogHistories.InsertLogHistories("Cập nhật nhóm danh mục thực đơn " + txtSubGroup.Text, DateTime.Now, userFunctionList.UserName, "Thành công");
                reLoadData();
                MessageBox.Show("Cập nhật nhóm danh mục thực đơn mới thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch
            {
                LogHistories.InsertLogHistories("Cập nhật nhóm danh mục thực đơn " + txtSubGroup.Text, DateTime.Now, userFunctionList.UserName, "Lỗi");
                MessageBox.Show("Không cập được nhật nhóm danh mục thực đơn.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool CheckItem()
        {
            if (cboParentGroup.SelectedValue == null)
            {
                cboParentGroup.Focus();
                MessageBox.Show("Tên nhóm danh mục thực đơn không được để trống.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (string.IsNullOrEmpty(txtSubGroup.Text))
            {
                txtSubGroup.Focus();
                MessageBox.Show("Tên danh mục thực đơn không được để trống.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            UpdateSubGroupMenu();
            this.Close();
        }

        private void btnExit_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Enter)
                btnSave_Click(null, null);
            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
}

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
    public partial class AddSubGroupMenu : DevComponents.DotNetBar.Metro.MetroForm
    {
        public delegate void ReLoadData();
        public event ReLoadData reLoadData;

        private SubGroupMenuDataSet.SubGroupMenuDataTable subGroupMenuDataTable = null;
        private SubGroupMenuController subGroupMenuController = new SubGroupMenuController();
        private MenuGroupDataSet.MenuGroupDataTable menuGroupDataTable = null;
        private MenuGroupController menuGroupController = new MenuGroupController();
        private UserFunctionList userFunctionList = null;
        private int GroupId = 0;

        public AddSubGroupMenu(string groupId, UserFunctionList userFunctionList)
        {
            InitializeComponent();
            this.GroupId = int.Parse(groupId);
            this.userFunctionList = userFunctionList;
        }
        public AddSubGroupMenu()
        {
            InitializeComponent();
        }


        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
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

            cboParentGroup.SelectedValue = GroupId;
        }

        private void AddFoodGroup_Load(object sender, EventArgs e)
        {
            LoadAllGroup();
        }

        private void RegistSubGroupMenu()
        {
            if (!CheckItem())
                return;

            subGroupMenuDataTable = new SubGroupMenuDataSet.SubGroupMenuDataTable();
            var newRow = subGroupMenuDataTable.NewSubGroupMenuRow();
            newRow.SubGroupName = txtSubGroup.Text;
            newRow.Note = txtNote.Text;
            newRow.GroupId = int.Parse(cboParentGroup.SelectedValue.ToString());

            subGroupMenuDataTable.AddSubGroupMenuRow(newRow);
            try 
            {
                subGroupMenuController.UpdateSubGroupMenu(subGroupMenuDataTable);
                LogHistories.InsertLogHistories("Thếm nhóm danh mục thực đơn mới " + txtSubGroup.Text, DateTime.Now, userFunctionList.UserName, "Thành công");
                CleanUp();
                reLoadData();
                MessageBox.Show("Thếm nhóm danh mục thực đơn mới thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch 
            {
                LogHistories.InsertLogHistories("Thếm nhóm danh mục thực đơn mới " + txtSubGroup.Text, DateTime.Now, userFunctionList.UserName, "Lỗi");
                MessageBox.Show("Không thêm được nhật nhóm danh mục thực đơn.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool CheckItem()
        {
            if(cboParentGroup.SelectedValue==null)
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

        private void CleanUp()
        {
            txtSubGroup.Focus();
            txtSubGroup.Text = string.Empty;
            txtNote.Text = string.Empty;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            RegistSubGroupMenu();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Enter)
                btnSave_Click(null, null);
            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
}

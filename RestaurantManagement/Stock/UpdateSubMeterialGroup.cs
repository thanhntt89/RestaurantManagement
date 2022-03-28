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
    public partial class UpdateSubMeterialGroup : DevComponents.DotNetBar.Metro.MetroForm
    {
        public delegate void ReLoadData();
        public event ReLoadData reLoadData;

        private MeterialGroupController meterialGroupController = new MeterialGroupController();
        private MeterialGroupDataSet.MeterialGroupDataTable meterialGroupDataTable = null;
        private SubMeterialGroupDataSet.SubMeterialGroupDataTable subMeterialGroupDataTable = null;
        private SubMeterialGroupController subMeterialGroupController = new SubMeterialGroupController();

        private int subMeterialGroupId = 0;
        private string SubMterialGroupName = string.Empty;
        private int MeterialGroupId = 0;
        private UserFunctionList userFunctionList = null;
        public UpdateSubMeterialGroup(int MeterialGroupId, int subMeterialGroupId, string SubMterialGroupName, UserFunctionList userFunctionList)
        {
            InitializeComponent();
            this.MeterialGroupId = MeterialGroupId;
            this.subMeterialGroupId = subMeterialGroupId;
            this.txtSubGroup.Text = SubMterialGroupName;
            this.userFunctionList = userFunctionList;
        }

        public UpdateSubMeterialGroup()
        {
            InitializeComponent();
        }

        private void LoadMeterialGroupAll()
        {
            meterialGroupDataTable = new MeterialGroupDataSet.MeterialGroupDataTable();
            meterialGroupController.GetMeterialGroupByAll(meterialGroupDataTable);
            if (meterialGroupDataTable.Rows.Count == 0)
                return;
            cboParentGroup.DataSource = meterialGroupDataTable;
            cboParentGroup.DisplayMembers = meterialGroupDataTable.MeterialGroupNameColumn.ColumnName;
            cboParentGroup.ValueMember = meterialGroupDataTable.MeterialGroupIdColumn.ColumnName;
            cboParentGroup.SelectedValue = MeterialGroupId;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveSubMeterialGroup();
        }

        private void UpdateSubMeterialGroup_Load(object sender, EventArgs e)
        {
            LoadMeterialGroupAll();
        }

        private void SaveSubMeterialGroup()
        {
            if (!CheckItem())
                return;

            subMeterialGroupDataTable = new SubMeterialGroupDataSet.SubMeterialGroupDataTable();
            subMeterialGroupController.GetBySubMerterialGroupId(subMeterialGroupDataTable, subMeterialGroupId);
            if (subMeterialGroupDataTable.Rows.Count == 0)
                return;

            subMeterialGroupDataTable.First().SubMeterialGroupName = txtSubGroup.Text;
            subMeterialGroupDataTable.First().MeterialGroupId = int.Parse(cboParentGroup.SelectedValue.ToString());
            subMeterialGroupDataTable.First().Note = txtNote.Text;
            try
            {
                subMeterialGroupController.UpdateSubMeterialGroup(subMeterialGroupDataTable);
                LogHistories.InsertLogHistories("Chức năng cập nhật nhóm nguyên liệu", DateTime.Now, userFunctionList.UserName, "Thành công");
                reLoadData();
                MessageBox.Show("Cập nhật nhóm nguyên liệu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch(Exception ex)
            {
                LogHistories.InsertLogHistories("Chức năng cập nhật nhóm nguyên liệu", DateTime.Now, userFunctionList.UserName, ex.Message);
                MessageBox.Show("Không cập nhật được nhóm mới!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private bool CheckItem()
        {
            if (cboParentGroup.SelectedValue == null)
            {
                cboParentGroup.Focus();
                MessageBox.Show("Tên nhóm danh mục nguyên liệu không được để trống", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (string.IsNullOrEmpty(txtSubGroup.Text))
            {
                txtSubGroup.Focus();
                MessageBox.Show("Tên nhóm nguyên liệu không được để trống", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }
    }
}

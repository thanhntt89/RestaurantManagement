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

namespace RestaurantManagement
{
    public partial class SubMeterialGroup : DevComponents.DotNetBar.Metro.MetroForm
    {
        public delegate void ReLoadData();
        public event ReLoadData reLoadData;

        private MeterialGroupController meterialGroupController = new MeterialGroupController();
        private MeterialGroupDataSet.MeterialGroupDataTable meterialGroupDataTable = null;
        private SubMeterialGroupDataSet.SubMeterialGroupDataTable subMeterialGroupDataTable = null;
        private SubMeterialGroupController subMeterialGroupController = new SubMeterialGroupController();

        public SubMeterialGroup()
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
        }

        private void SaveSubMeterialGroup()
        {
            if (!CheckItem())
                return;

            subMeterialGroupDataTable = new SubMeterialGroupDataSet.SubMeterialGroupDataTable();
            var row = subMeterialGroupDataTable.NewSubMeterialGroupRow();
            row.SubMeterialGroupName = txtSubGroup.Text;
            row.MeterialGroupId = int.Parse(cboParentGroup.SelectedValue.ToString());
            row.Note = txtNote.Text;

            subMeterialGroupDataTable.AddSubMeterialGroupRow(row);
            try
            {
                subMeterialGroupController.UpdateSubMeterialGroup(subMeterialGroupDataTable);
                reLoadData();
                MessageBox.Show("Tạo mới nhóm nguyên liệu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch
            {
                MessageBox.Show("Không tạo được nhóm mới!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            Clean();
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

        private void Clean()
        {
            txtSubGroup.Text = string.Empty;
            txtNote.Text = string.Empty;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveSubMeterialGroup();
        }

        private void SubMeterialGroup_Load(object sender, EventArgs e)
        {
            LoadMeterialGroupAll();
        }
    }
}

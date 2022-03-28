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
    public partial class UpdateMeterial : DevComponents.DotNetBar.Metro.MetroForm
    {
        public delegate void ReLoadData();
        public event ReLoadData reLoadData;

        private MeterialController meterialController = new MeterialController();
        private MeterialDataSet.MeterialsDataTable meterialsDataTable = null;

        private UnitController unitController = new UnitController();
        private UnitDataSet.UnitDataTable unitDataTable = null;

        private SubMeterialGroupController subMeterialGroupController = new SubMeterialGroupController();
        private SubMeterialGroupDataSet.SubMeterialGroupDataTable subMeterialGroupDataTable = null;
        private int subMeterialGroupId = 0;
        private int meterialId = 0;
        private string subMeterialGroupName = string.Empty;

        public UpdateMeterial(int meterialId, int subMeterialGroupId, string subMeterialGroupName)
        {
            InitializeComponent();
            this.meterialId = meterialId;
            this.subMeterialGroupId = subMeterialGroupId;
        }

        public UpdateMeterial()
        {
            InitializeComponent();

        }

        private void LoadUpdate()
        {
            meterialsDataTable = new MeterialDataSet.MeterialsDataTable();
            meterialController.GetByMerterialId(meterialsDataTable, meterialId);
            if (meterialsDataTable.Rows.Count == 0)
                return;

            txtMeterialCode.Text = meterialsDataTable.First().Field<string>("MeterialCode");
            txtMeterialName.Text = meterialsDataTable.First().MeterialName;
            cboUnit.SelectedValue = meterialsDataTable.First().UnitId;
            txtNote.Text = meterialsDataTable.First().Field<string>("Note");
        }

        private void LoadAllUnit()
        {
            unitDataTable = new UnitDataSet.UnitDataTable();
            unitController.GetAllUnit(unitDataTable);
            if (unitDataTable.Rows.Count == 0)
                return;

            cboUnit.DataSource = unitDataTable;
            cboUnit.DisplayMembers = unitDataTable.UnitNameColumn.ColumnName;
            cboUnit.ValueMember = unitDataTable.UnitIdColumn.ColumnName;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAddMeterial_Click(object sender, EventArgs e)
        {
            SaveMeterial();
        }
        private void SaveMeterial()
        {
            if (!CheckItem())
                return;
            meterialsDataTable = new MeterialDataSet.MeterialsDataTable();
            meterialController.GetByMerterialId(meterialsDataTable, meterialId);
            if (meterialsDataTable.Rows.Count == 0)
                return;

            meterialsDataTable.First().SubMeterialGroupId = subMeterialGroupId;
            meterialsDataTable.First().MeterialCode = txtMeterialCode.Text;
            meterialsDataTable.First().MeterialName = txtMeterialName.Text;
            meterialsDataTable.First().UnitId = int.Parse(cboUnit.SelectedValue.ToString());
            meterialsDataTable.First().Note = txtNote.Text;

            try
            {
                meterialController.UpdateMeterial(meterialsDataTable);
                reLoadData();
                MessageBox.Show("Cập nhật thông tin mặt hàng thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch
            {
                MessageBox.Show("Cập nhật mặt hàng mới không thành công", "Lỗi thêm mặt hàng", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
        private bool CheckItem()
        {
            if (cboSubMeterialGroup.SelectedValue == null)
            {
                cboSubMeterialGroup.Focus();
                MessageBox.Show("Bạn phải chọn nhóm cho mặt hàng", "Lỗi thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (string.IsNullOrEmpty(txtMeterialName.Text))
            {
                txtMeterialName.Focus();
                MessageBox.Show("Thông tin tên mặt hàng không để trống", "Lỗi thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (cboUnit.SelectedValue == null)
            {
                cboUnit.Focus();
                MessageBox.Show("Chọn đơn vị tính cho mặt hàng", "Lỗi thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        private void UpdateMeterial_Load(object sender, EventArgs e)
        {
            LoadAllUnit();
            LoadUpdate();
            LoadSubMeterialGroupAll();
        }
        private void LoadSubMeterialGroupAll()
        {
            subMeterialGroupDataTable = new SubMeterialGroupDataSet.SubMeterialGroupDataTable();
            subMeterialGroupController.GetBySunMeterialGroupAll(subMeterialGroupDataTable);
            if (subMeterialGroupDataTable.Rows.Count == 0)
                return;
            cboSubMeterialGroup.DataSource = subMeterialGroupDataTable;
            cboSubMeterialGroup.DisplayMembers = subMeterialGroupDataTable.SubMeterialGroupNameColumn.ColumnName;
            cboSubMeterialGroup.ValueMember = subMeterialGroupDataTable.SubMeterialGroupIdColumn.ColumnName;
            cboSubMeterialGroup.SelectedValue = subMeterialGroupId;
        }
    }
}

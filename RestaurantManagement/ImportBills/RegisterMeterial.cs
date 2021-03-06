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

namespace RestaurantManagement
{
    public partial class RegisterMeterial : DevComponents.DotNetBar.Metro.MetroForm
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
        private string subMeterialGroupName = string.Empty;
        public RegisterMeterial(int subMeterialGroupId, string subMeterialGroupName)
        {
            InitializeComponent();
            this.subMeterialGroupId = subMeterialGroupId;
            this.subMeterialGroupName = subMeterialGroupName;
        }

        public RegisterMeterial()
        {
            InitializeComponent();
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
            var row = meterialsDataTable.NewMeterialsRow();
            row.SubMeterialGroupId = subMeterialGroupId;
            row.MeterialCode = txtMeterialCode.Text;
            row.MeterialName = txtMeterialName.Text;
            row.UnitId = int.Parse(cboUnit.SelectedValue.ToString());
            row.Note = txtNote.Text;

            meterialsDataTable.AddMeterialsRow(row);
            try
            {
                meterialController.UpdateMeterial(meterialsDataTable);
                reLoadData();
                MessageBox.Show("Thêm thông tin mặt hàng thành công.\n Nhấn Yes để tiếp tục thêm mặc hàng mới", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            }
            catch
            {
                MessageBox.Show("Thêm mặt hàng mới không thành công", Constants.CaptionErrorMessage, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            Clean();
        }

        private void RegisterMeterial_Load(object sender, EventArgs e)
        {
            LoadSubMeterialGroupAll();
            LoadAllUnit();
        }

        private void Clean()
        {
            txtMeterialCode.Text = string.Empty;
            txtMeterialName.Text = string.Empty;
            txtNote.Text = string.Empty;
        }
    }
}
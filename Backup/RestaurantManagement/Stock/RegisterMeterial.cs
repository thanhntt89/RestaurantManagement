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
using RestaurantCommon;

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
        private UserFunctionList userFunctionList = null;

        public RegisterMeterial(int subMeterialGroupId, string subMeterialGroupName, UserFunctionList userFunctionList)
        {
            InitializeComponent();
            this.subMeterialGroupId = subMeterialGroupId;
            this.subMeterialGroupName = subMeterialGroupName;
            this.userFunctionList = userFunctionList;
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
            if (string.IsNullOrEmpty(txtMeterialCode.Text))
            {
                txtMeterialCode.Focus();
                MessageBox.Show("Thông tin mã mặt hàng không để trống", "Lỗi thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            meterialController.GetMeterialByMeterialCode(meterialsDataTable, txtMeterialCode.Text);
            if (meterialsDataTable.Rows.Count > 0)
            {
                MessageBox.Show("Mã mặt hàng này đã tồn tại bạn hãy nhập vào mã khác.", Constants.CaptionErrorMessage, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            var row = meterialsDataTable.NewMeterialsRow();
            row.SubMeterialGroupId = (int)cboSubMeterialGroup.SelectedValue;
            row.MeterialCode = txtMeterialCode.Text;
            row.MeterialName = txtMeterialName.Text;
            row.Quantity = 0;
            row.UnitId = int.Parse(cboUnit.SelectedValue.ToString());
            row.Note = txtNote.Text;

            meterialsDataTable.AddMeterialsRow(row);
            try
            {
                meterialController.UpdateMeterial(meterialsDataTable);
                LogHistories.InsertLogHistories("Thêm mới mặt hàng", DateTime.Now, userFunctionList.UserName, "Thành công");
                reLoadData();
                MessageBox.Show("Thêm thông tin mặt hàng thành công.\n Nhấn Yes để tiếp tục thêm mặc hàng mới", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            }
            catch(Exception ex)
            {
                LogHistories.InsertLogHistories("Thêm mới mặt hàng", DateTime.Now, userFunctionList.UserName, ex.Message);
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
            txtMeterialCode.Focus();
            txtMeterialCode.Text = string.Empty;
            txtMeterialName.Text = string.Empty;
            txtNote.Text = string.Empty;
        }

        private void btnUnit_Click(object sender, EventArgs e)
        {
            MeterialManagement MeterialManagement = new MeterialManagement(userFunctionList);
            MeterialManagement.reLoadData += new MeterialManagement.ReLoadData(LoadAllUnit);
            MeterialManagement.ShowDialog();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Enter)
            {
                btnAddMeterial_Click(null, null);
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
}
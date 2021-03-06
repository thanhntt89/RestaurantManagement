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
    public partial class ImportBillsOld : DevComponents.DotNetBar.Metro.MetroForm
    {
        private SubMeterialGroupDataSet.SubMeterialGroupDataTable subMeterialGroupDataTable = null;
        private SubMeterialGroupController subMeterialGroupController = new SubMeterialGroupController();
        private MeterialController meterialController = new MeterialController();
        private MeterialDataSet.MeterialUnitAndSubGroupMeterialDataTable meterialUnitAndSubGroupMeterialDataTable = null;
        private UnitDataSet.UnitDataTable unitDataTable = null;
        private UnitController unitController = new UnitController();
        private string unitName = string.Empty;


        public ImportBillsOld()
        {
            InitializeComponent();
        }

        private void LoadAllUnit()
        {
            unitDataTable = new UnitDataSet.UnitDataTable();
            unitController.GetAllUnit(unitDataTable);
        }

        private void LoadAllSubGroupMeterial()
        {
            subMeterialGroupDataTable = new SubMeterialGroupDataSet.SubMeterialGroupDataTable();
            subMeterialGroupController.GetBySunMeterialGroupAll(subMeterialGroupDataTable);

            cboSubGroupMeterial.DisplayMember = subMeterialGroupDataTable.SubMeterialGroupNameColumn.ColumnName;
            cboSubGroupMeterial.ValueMember = subMeterialGroupDataTable.SubMeterialGroupIdColumn.ColumnName;
            cboSubGroupMeterial.DataSource = subMeterialGroupDataTable;
        }

        private void LoadStart()
        {
            LoadAllUnit();
            LoadAllSubGroupMeterial();
        }

        private void ImportBills_Load(object sender, EventArgs e)
        {
            LoadStart();
        }

        private void LoadMeterialBySubGroupMeterialId()
        {
            cboMeterial.Text = string.Empty;
            if (cboSubGroupMeterial.SelectedValue == null)
                return;
            int subGroupMeterial = int.Parse(cboSubGroupMeterial.SelectedValue.ToString());
            meterialUnitAndSubGroupMeterialDataTable = new MeterialDataSet.MeterialUnitAndSubGroupMeterialDataTable();
            meterialController.GetBySubMeterialGroupId(meterialUnitAndSubGroupMeterialDataTable, subGroupMeterial);

            cboMeterial.DataSource = meterialUnitAndSubGroupMeterialDataTable;
            cboMeterial.DisplayMember = meterialUnitAndSubGroupMeterialDataTable.MeterialNameColumn.ColumnName;
            cboMeterial.ValueMember = meterialUnitAndSubGroupMeterialDataTable.MeterialIdColumn.ColumnName;
        }

        private void cboSubGroupMeterial_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadMeterialBySubGroupMeterialId();
        }

        private void AddNewMenuRow(int IndexMax, string meterialName, double quantity, string unitName, double cost, Int64 meterialId)
        {
            // Bật tính năng cho phép thêm dòng
            dgvImportBill.AllowUserToAddRows = true;

            // Thực hiện thêm một dòng mới
            dgvImportBill.Rows.Add();

            // Khai báo biến hàng mới cho bảng
            DataGridViewRow Rows = dgvImportBill.Rows[IndexMax];

            // Gán các giá trị vào từng cột tương ứng của hàng vừa thêm
            Rows.Cells["STT"].Value = IndexMax + 1;
            Rows.Cells["MeterialName"].Value = meterialName;
            Rows.Cells["Quantity"].Value = quantity;
            Rows.Cells["UnitName"].Value = unitName;
            Rows.Cells["Cost"].Value = cost;
            Rows.Cells["TotalMoney"].Value = quantity * cost;
            Rows.Cells["MeterialId"].Value = meterialId;

            // Khoá tính năng cho phép thêm dòng
            dgvImportBill.AllowUserToAddRows = false;
            dgvImportBill.Rows[IndexMax].Selected = true;
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            int indexMax = dgvImportBill.Rows.Count;
            int meterialId = int.Parse(cboMeterial.SelectedValue.ToString());
            var querry = from row in meterialUnitAndSubGroupMeterialDataTable
                         where row.MeterialId == meterialId
                         select row;
            foreach (var item in querry)
            {
                unitName = item.UnitName;
            }
            bool isExist = false;
            double quantity = 0;

            // Kiểm tra xem MenuId đã tồn tại hay chưa, nếu chưa có thì tiến hành thêm mới, ngược lại thì update thêm số lượng
            for (int i = 0; i < dgvImportBill.Rows.Count; i++)
            {
                // Nếu tồn tại thực đơn trong danh sách rồi thì cập nhật
                if (dgvImportBill.Rows[i].Cells["MenuId"].Value.ToString().Equals(menuId))
                {
                    dgvImportBill.Rows[i].Selected = true;
                    indexMax = i;
                    isExist = true;
                    quantity = (double)dgvImportBill.Rows[i].Cells["Quantity"].Value;
                    quantity++;
                    dgvImportBill.Rows[i].Cells["Quantity"].Value = quantity;

                    break;
                }
            }
            //Trường hợp đây là thực đơn mới
            if (!isExist)
            {
                AddNewMenuRow(indexMax, cboMeterial.Text, txtQuantity.Value, unitName, txtCost.Value, meterialId);
            }
        }

        private void labelX1_Click(object sender, EventArgs e)
        {

        }

        private void dtpBillDate_ValueChanged(object sender, EventArgs e)
        {

        }

        private void labelX2_Click(object sender, EventArgs e)
        {

        }

        private void txtNote_TextChanged(object sender, EventArgs e)
        {

        }

        private void labelX3_Click(object sender, EventArgs e)
        {

        }

        private void txtTotalMoney_ValueChanged(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {

        }

        private void labelX4_Click(object sender, EventArgs e)
        {

        }

        private void cboMeterial_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void labelX5_Click(object sender, EventArgs e)
        {

        }

        private void txtQuantity_ValueChanged(object sender, EventArgs e)
        {

        }

        private void labelX6_Click(object sender, EventArgs e)
        {

        }

        private void txtCost_ValueChanged(object sender, EventArgs e)
        {

        }

        private void labelX7_Click(object sender, EventArgs e)
        {

        }

        private void labelX8_Click(object sender, EventArgs e)
        {

        }

        private void dgvImportBill_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
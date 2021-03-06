using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using RestaurantDTO;
using RestaurantController;
using System.Linq;

namespace RestaurantManagement
{
    public partial class ImportBills : DevComponents.DotNetBar.Metro.MetroForm
    {
        private SubMeterialGroupDataSet.SubMeterialGroupDataTable subMeterialGroupDataTable = null;
        private SubMeterialGroupController subMeterialGroupController = new SubMeterialGroupController();
        private MeterialController meterialController = new MeterialController();
        private MeterialDataSet.MeterialUnitAndSubGroupMeterialDataTable meterialUnitAndSubGroupMeterialDataTable = null;
        private UnitDataSet.UnitDataTable unitDataTable = null;
        private UnitController unitController = new UnitController();
        private string unitName = string.Empty;

        private ImportBillController importBillController = new ImportBillController();
        private ImportBillDataSet.ImportBillDataTable importBillDataTable = null;

        private ImportBillDetailController importBillDetailController = new ImportBillDetailController();
        private ImportBillDetailDataSet.ImportBillDetailDataTable importBillDetailDataTable = null;

        private MeterialDataSet.MeterialsDataTable meterialsDataTable = null;

        public ImportBills()
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
            CreateBillImportId();
            LoadAllUnit();
            LoadAllSubGroupMeterial();
        }

        private void UpdateMeterialQuantityByMeterialId(int meterialId, double quantity)
        {
            meterialsDataTable = new MeterialDataSet.MeterialsDataTable();
            meterialController.GetByMerterialId(meterialsDataTable, meterialId);
            if (meterialsDataTable.Rows.Count == 0)
                return;
            double inventory = 0;

            inventory = meterialsDataTable.First().IsQuantityNull() ? 0 : meterialsDataTable.First().Quantity;
            inventory += quantity;
            meterialsDataTable.First().Quantity = inventory;

            try
            {
                meterialController.UpdateMeterial(meterialsDataTable);
            }
            catch
            {
            }
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

        private void SaveImportBill()
        {
            importBillDataTable = new ImportBillDataSet.ImportBillDataTable();
            var newRow = importBillDataTable.NewImportBillRow();
            newRow.ImpportId = txtBillCode.Text;
            newRow.ImportBillCode = txtBillCode.Text;
            newRow.DateTime = dtpBillDate.Value;
            newRow.Note = txtNote.Text;
            newRow.TotalMoney = txtTotalMoney.Value;

            importBillDataTable.AddImportBillRow(newRow);
            try
            {
                importBillController.UpdateImportBill(importBillDataTable);
            }
            catch
            {
                MessageBox.Show("Lỗi: Thêm mới hoá đơn không thành công!", Constants.CaptionErrorMessage, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            SaveImportBillDetail();
        }

        private void SaveImportBillDetail()
        {
            importBillDetailDataTable = new ImportBillDetailDataSet.ImportBillDetailDataTable();
            int meterialId = 0;
            double quantity = 0;
            for (int i = 0; i < dgvImportBill.Rows.Count; i++)
            {
                meterialId = int.Parse(dgvImportBill.Rows[i].Cells["MeterialId"].Value.ToString());
                quantity = (double)dgvImportBill.Rows[i].Cells["Quantity"].Value;
                UpdateMeterialQuantityByMeterialId(meterialId, quantity);

                var newRow = importBillDetailDataTable.NewImportBillDetailRow();

                newRow.ImportBillId = txtBillCode.Text;
                newRow.MeterialId = meterialId;
                newRow.Quantity = quantity;
                newRow.Cost = (double)dgvImportBill.Rows[i].Cells["Cost"].Value;

                importBillDetailDataTable.AddImportBillDetailRow(newRow);
            }
            try
            {
                importBillDetailController.UpdateImportBillDetail(importBillDetailDataTable);
                MessageBox.Show("Thêm mới hoá đơn thành công!", Constants.CaptionInformationMessage, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch
            {
                importBillDataTable = new ImportBillDataSet.ImportBillDataTable();
                importBillController.GetByImportId(importBillDataTable, txtBillCode.Text);
                if (importBillDataTable.Rows.Count == 0)
                    return;
                importBillDataTable.First().Delete();
                try
                {
                    importBillController.UpdateImportBill(importBillDataTable);
                }
                catch
                {
                    //MessageBox.Show("Lỗi: Thêm mới hoá đơn không thành công!", Constants.CaptionErrorMessage, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //return;
                }
                MessageBox.Show("Lỗi: Thêm mới hoá đơn không thành công!", Constants.CaptionErrorMessage, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
            Rows.Cells["UnitNames"].Value = unitName;
            Rows.Cells["Cost"].Value = cost;
            Rows.Cells["TotalCost"].Value = quantity * cost;
            Rows.Cells["MeterialId"].Value = meterialId;

            // Khoá tính năng cho phép thêm dòng
            dgvImportBill.AllowUserToAddRows = false;
            dgvImportBill.Rows[IndexMax].Selected = true;
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            Import();
        }

        private void Clear()
        {
            txtCost.Value = 0;
            txtQuantity.Value = 0;
        }

        private bool CheckImtem()
        {
            if (cboMeterial.SelectedValue == null)
            {
                cboMeterial.Focus();
                MessageBox.Show("Bạn hãy chọn mặt hàng để nhập", Constants.CaptionInformationMessage, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (txtQuantity.Value <= 0)
            {
                txtQuantity.Focus();
                MessageBox.Show("Bạn hãy nhập vào số lượng của mặt hàng", Constants.CaptionInformationMessage, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (txtCost.Value <= 0)
            {
                txtCost.Focus();
                MessageBox.Show("Bạn hãy nhập vào đơn giá của mặt hàng", Constants.CaptionInformationMessage, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private void Import()
        {
            if (!CheckImtem())
            {
                return;
            }
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
                if (dgvImportBill.Rows[i].Cells["MeterialId"].Value.ToString().Equals(meterialId.ToString()))
                {
                    MessageBox.Show("Mặt hàng đã được nhập bạn hãy điều chỉnh lại số lượng trên bảng", Constants.CaptionInformationMessage, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }
            //Trường hợp đây là thực đơn mới
            if (!isExist)
            {
                AddNewMenuRow(indexMax, cboMeterial.Text, txtQuantity.Value, unitName, txtCost.Value, meterialId);
            }
            quantity = 0;
            for (int j = 0; j < dgvImportBill.Rows.Count; j++)
            {
                quantity += (double)dgvImportBill.Rows[j].Cells["TotalCost"].Value;
            }
            txtTotalMoney.Value = quantity;
            Clear();
        }

        private void cboSubGroupMeterial_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadMeterialBySubGroupMeterialId();
        }

        private void ImportBills_Load(object sender, EventArgs e)
        {
            LoadStart();
        }

        private void CreateBillImportId()
        {
            txtBillCode.Text = Utilities.CreatedFirstBillId("IB", DateTime.Now);
        }

        private void TotalMoneyCellEndEdit()
        {
            double moneyTotal = 0;
            double quantity = 0;
            double cost = 0;
            for (int i = 0; i < dgvImportBill.Rows.Count; i++)
            {
                dgvImportBill.Rows[i].Cells["STT"].Value = i + 1;

                if (dgvImportBill.Rows[i].Cells["Quantity"].Value != null)
                    quantity = double.Parse(dgvImportBill.Rows[i].Cells["Quantity"].Value.ToString());
                if (dgvImportBill.Rows[i].Cells["Cost"].Value != null)
                    cost = double.Parse(dgvImportBill.Rows[i].Cells["Cost"].Value.ToString());

                dgvImportBill.Rows[i].Cells["TotalCost"].Value = cost * quantity;

                if (dgvImportBill.Rows[i].Cells["TotalCost"].Value != null)
                    moneyTotal += double.Parse(dgvImportBill.Rows[i].Cells["TotalCost"].Value.ToString());
            }
            txtTotalMoney.Value = moneyTotal;
        }

        private void dgvImportBill_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            TotalMoneyCellEndEdit();
        }

        private void DeleteMenuButtonDataGridView(DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex != 6)
            {
                return;
            }
            dgvImportBill.Rows.RemoveAt(e.RowIndex);
            TotalMoneyCellEndEdit();
        }

        private void dgvImportBill_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DeleteMenuButtonDataGridView(e);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveImportBill();
            CreateNewImportBill();
        }

        private void CreateNewImportBill()
        {
            CreateBillImportId();
            dgvImportBill.Rows.Clear();
            txtNote.Text = string.Empty;
            Clear();
        }
    }
}
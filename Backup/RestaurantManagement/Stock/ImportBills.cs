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
using RestaurantCommon;

namespace RestaurantManagement
{
    public partial class ImportBills : DevComponents.DotNetBar.Metro.MetroForm
    {
        // Sự kiện load lại dữ liệu
        public delegate void ReLoadData();
        public event ReLoadData reLoadData;

        private SubMeterialGroupDataSet.SubMeterialGroupDataTable subMeterialGroupDataTable = null;
        private SubMeterialGroupController subMeterialGroupController = new SubMeterialGroupController();
        private MeterialController meterialController = new MeterialController();
        private MeterialDataSet.MeterialUnitAndSubGroupMeterialDataTable meterialUnitAndSubGroupMeterialDataTable = null;
        private string unitName = string.Empty;

        private ImportBillController importBillController = new ImportBillController();
        private ImportBillDataSet.ImportBillDataTable importBillDataTable = null;

        private ImportBillDetailController importBillDetailController = new ImportBillDetailController();
        private ImportBillDetailDataSet.ImportBillDetailDataTable importBillDetailDataTable = null;

        private MeterialDataSet.MeterialsDataTable meterialsDataTable = null;
        private string importBillId = string.Empty;
        private UserFunctionList userFunctionList;

        public ImportBills(UserFunctionList userFunctionList)
        {
            InitializeComponent();
            this.userFunctionList = userFunctionList;
        }

        private void LoadAllSubGroupMeterial()
        {
            subMeterialGroupDataTable = new SubMeterialGroupDataSet.SubMeterialGroupDataTable();
            subMeterialGroupController.GetBySunMeterialGroupAll(subMeterialGroupDataTable);
            var newRow = subMeterialGroupDataTable.NewSubMeterialGroupRow();
            newRow.SubMeterialGroupId = 0;
            newRow.SubMeterialGroupName = "Tất cả nhóm mặt hàng";
            newRow.Note = string.Empty;
            newRow.MeterialGroupId = 0;
            subMeterialGroupDataTable.Rows.InsertAt(newRow, 0);

            cboSubGroupMeterial.DisplayMember = subMeterialGroupDataTable.SubMeterialGroupNameColumn.ColumnName;
            cboSubGroupMeterial.ValueMember = subMeterialGroupDataTable.SubMeterialGroupIdColumn.ColumnName;
            cboSubGroupMeterial.DataSource = subMeterialGroupDataTable;
        }

        private void LoadInitialize()
        {
            LoadAllSubGroupMeterial();
            importBillId = Utilities.CreatedFirstBillId("IB", DateTime.Now);
            txtBillCode.Text = importBillId;
        }

        private void LoadAllMeterial()
        {
            meterialUnitAndSubGroupMeterialDataTable = new MeterialDataSet.MeterialUnitAndSubGroupMeterialDataTable();
            meterialController.GetMeterialByAll(meterialUnitAndSubGroupMeterialDataTable);
            var querry = from row in meterialUnitAndSubGroupMeterialDataTable
                         select row;
            if ((int)cboSubGroupMeterial.SelectedValue > 0)
            {
                querry = querry.Where(r => r.SubMeterialGroupId == (int)cboSubGroupMeterial.SelectedValue);
            }

            cboMeterial.DisplayMember = "MeterialName";
            cboMeterial.ValueMember = "MeterialId";
            cboMeterial.AutoCompleteSource = AutoCompleteSource.ListItems;
            cboMeterial.DataSource = querry.ToList();
            txtMeterialCode.Text = string.Empty;
            cboMeterial.SelectedIndex = -1;
            txtQuantity.Value = 0;
            txtInventories.Value = 0;
            lbUnitName.Text = string.Empty;
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
            if (!Utilities.CheckNullOrMinMaxLength("Mã hóa đơn", txtBillCode.Text, 3, 20))
            {
                return;
            }

            if (dgvImportBill.Rows.Count == 0)
                return;

            DialogResult rst = MessageBox.Show("Bạn có muốn lưu lại những thông tin này không?", Constants.CaptionInformationMessage, MessageBoxButtons.YesNo, MessageBoxIcon.Information);
           
            if (rst == DialogResult.No)
                return;

            importBillDataTable = new ImportBillDataSet.ImportBillDataTable();
            var newRow = importBillDataTable.NewImportBillRow();
            newRow.ImportId = importBillId;
            newRow.ImportBillCode = txtBillCode.Text;
            newRow.DateTime = dtpBillDate.Value;
            newRow.Note = txtNote.Text;
            newRow.TotalMoney = txtTotalMoney.Value;
            newRow.StaffId = userFunctionList.StaffId;
            
            importBillDataTable.AddImportBillRow(newRow);
            try
            {
                importBillController.UpdateImportBill(importBillDataTable);
                LogHistories.InsertLogHistories("Thêm hóa đơn nhập hàng " + txtBillCode.Text, DateTime.Now, userFunctionList.UserName, "Thành công");
            }
            catch
            {
                LogHistories.InsertLogHistories("Thêm hóa đơn nhập hàng " + txtBillCode.Text, DateTime.Now, userFunctionList.UserName, "Lỗi");
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
                quantity = double.Parse(dgvImportBill.Rows[i].Cells["Quantity"].Value.ToString());
                UpdateMeterialQuantityByMeterialId(meterialId, quantity);

                var newRow = importBillDetailDataTable.NewImportBillDetailRow();
                newRow.ImportBillId = txtBillCode.Text;
                newRow.MeterialId = meterialId;
                newRow.Quantity = quantity;
                newRow.Cost = double.Parse(dgvImportBill.Rows[i].Cells["Cost"].Value.ToString());

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
            LoadInitialize();
            CleanUp();
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
            cboMeterial.SelectedIndex = -1;
            txtMeterialCode.Text = string.Empty;
            txtQuantity.Value = 0;
            txtMeterialCode.Focus();
            txtCost.Value = 0;
            txtInventories.Value = 0;
        }

        private void CleanUp()
        {
            dgvImportBill.Rows.Clear();
            txtNote.Text = string.Empty;
            txtQuantity.Value = 0;
            txtCost.Value = 0;
            cboMeterial.SelectedIndex = -1;
            txtMeterialCode.Text = string.Empty;
            txtTotalMoney.Value = 0;
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
            LoadInitialize();
        }

        private void CreateBillImportId()
        {
            importBillId = Utilities.CreatedFirstBillId("IB", DateTime.Now);
            txtBillCode.Text = importBillId;
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
            if (reLoadData != null)
                reLoadData();
        }

        private void txtMeterialCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                SearchByMeterialCode();
            }
        }

        private void txtMeterialCode_TextChanged(object sender, EventArgs e)
        {
            SearchByMeterialCode();
        }

        private void SearchByMeterialCode()
        {
            if (!string.IsNullOrEmpty(txtMeterialCode.Text))
            {
                panelSearch.Visible = true;
                panelSearch.Top = cboMeterial.Top - 3;
                panelSearch.Left = cboMeterial.Left;
            }
            else
            {
                panelSearch.Visible = false;
                return;
            }
            dgvMeterialSearch.Rows.Clear();
            var querry = from row in meterialUnitAndSubGroupMeterialDataTable
                         select row;

            if (!string.IsNullOrEmpty(txtMeterialCode.Text))
            {
                querry = querry.Where(r => r.MeterialCode.IndexOf(txtMeterialCode.Text, StringComparison.OrdinalIgnoreCase) >= 0);
            }
            if ((int)cboSubGroupMeterial.SelectedValue > 0)
            {
                querry = querry.Where(r => r.SubMeterialGroupId == (int)cboSubGroupMeterial.SelectedValue);
            }
            dgvMeterialSearch.AllowUserToAddRows = true;
            int index = 0;

            foreach (var item in querry)
            {
                dgvMeterialSearch.Rows.Add();
                DataGridViewRow row = dgvMeterialSearch.Rows[index];
                row.Cells["MeterialCode"].Value = item.IsMeterialCodeNull() ? string.Empty : item.MeterialCode;
                row.Cells["MeterialNameSearch"].Value = item.MeterialName;
                row.Cells["UnitNameSearch"].Value = item.UnitName;
                row.Cells["QuantitySearch"].Value = item.IsQuantityNull() ? 0 : item.Quantity;
                row.Cells["MeterialIdSearch"].Value = item.MeterialId;
                index++;
            }
            dgvMeterialSearch.AllowUserToAddRows = false;
        }


        private void btnClose_Click(object sender, EventArgs e)
        {
            panelSearch.Visible = false;
        }

        private void dgvMeterialSearch_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e != null)
                SelectMeterial(e.RowIndex);
        }

        private void SelectMeterial(int RowIndex)
        {
            if (RowIndex < 0)
                return;
            DataGridViewRow row = dgvMeterialSearch.Rows[RowIndex];
            cboMeterial.SelectedValue = (int)row.Cells["MeterialIdSearch"].Value;
            panelSearch.Visible = false;
            txtQuantity.Focus();
        }

        private void cboMeterial_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboMeterial.SelectedItem != null)
            {
                MeterialDataSet.MeterialUnitAndSubGroupMeterialRow row = (MeterialDataSet.MeterialUnitAndSubGroupMeterialRow)cboMeterial.SelectedItem;
                txtInventories.Value = row.IsQuantityNull() ? 0 : row.Quantity;
                txtMeterialCode.Text = row.MeterialCode;
                unitName = row.UnitName;
                lbUnitName.Text = unitName;
                panelSearch.Visible = false;
                txtQuantity.Value = 0;
                txtQuantity.Focus();
            }
        }

        private void cboSubGroupMeterial_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            LoadAllMeterial();
        }

        private void ImportBills_SizeChanged(object sender, EventArgs e)
        {
            panelSearch.Top = cboMeterial.Top - 3;
            panelSearch.Left = cboMeterial.Left;
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Enter && txtCost.Value > 0)
                Import();
            if (keyData == Keys.Enter && cboMeterial.Text != string.Empty && txtQuantity.Value > 0)
            {
                txtQuantity.Focus();
            }
            if (keyData == Keys.Enter && txtQuantity.Value > 0)
            {
                txtCost.Value = 0;
                txtCost.Focus();
            }
            if (keyData == Keys.F2)
            {
                SaveImportBill();
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void ImportBills_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (reLoadData != null)
                reLoadData();
        }
    }
}
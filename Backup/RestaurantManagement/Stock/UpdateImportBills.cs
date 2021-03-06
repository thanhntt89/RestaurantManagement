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
    public partial class UpdateImportBills : DevComponents.DotNetBar.Metro.MetroForm
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
        private ImportBillDetailDataSet.SearchImportBillDetailDataTable searchImportBillDetailDataTable = null;

        private MeterialDataSet.MeterialsDataTable meterialsDataTable = null;
        private int staffId = 0;

        private string ImportBillId = string.Empty;
        private UserFunctionList userFunctionList = null;

        public UpdateImportBills(string importBillId, UserFunctionList userFunctionList)
        {
            InitializeComponent();
            this.ImportBillId = importBillId;
            this.userFunctionList = userFunctionList;
            CheckRole();
        }

        private void CheckRole()
        {
            dgvImportBill.Columns["Delete"].Visible = false;
            btnSave.Enabled = false;
            btnImport.Enabled = false;

            if (userFunctionList.Bills[0].Add == 1)
            {
                btnSave.Enabled = true;
                btnImport.Enabled = true;
            }
            if (userFunctionList.Bills[0].Edit == 1)
            {
                btnSave.Enabled = true;
            }
            if (userFunctionList.Bills[0].Delete == 1)
            {
                dgvImportBill.Columns["Delete"].Visible = true;
            }
        }

        public UpdateImportBills()
        {
            InitializeComponent();
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
            txtBillCode.Text = Utilities.CreatedFirstBillId("IB", DateTime.Now);
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

        private void UpdateMeterialQuantityByMeterialId(int meterialId, double quantity, double reQuantity)
        {
            meterialsDataTable = new MeterialDataSet.MeterialsDataTable();
            meterialController.GetByMerterialId(meterialsDataTable, meterialId);
            if (meterialsDataTable.Rows.Count == 0)
                return;
            double inventory = 0;
            inventory += (quantity - reQuantity);
            meterialsDataTable.First().Quantity += inventory;

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
            //DialogResult rst = MessageBox.Show("Bạn có muốn lưu lại những thông tin này không?", Constants.CaptionInformationMessage, MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            //if (rst == DialogResult.No)
            //    return;

            importBillDataTable = new ImportBillDataSet.ImportBillDataTable();
            importBillController.GetByImportId(importBillDataTable, ImportBillId);
            if (importBillDataTable.Rows.Count == 0)
                return;

            importBillDataTable.First().Note = txtNote.Text;
            importBillDataTable.First().TotalMoney = txtTotalMoney.Value;
            if (staffId > 0)
                importBillDataTable.First().StaffId = staffId;
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
            Int64 importBillDetailId = 0;
            int meterialId = 0;
            double quantity = 0;
            double reQuantity = 0;
            bool isSuccess = false;
            if (dgvImportBill.Rows.Count == 0)
                return;

            for (int i = 0; i < dgvImportBill.Rows.Count; i++)
            {
                importBillDetailId = (Int64)dgvImportBill.Rows[i].Cells["ImportBillDetailId"].Value;
                meterialId = int.Parse(dgvImportBill.Rows[i].Cells["MeterialId"].Value.ToString());
                quantity = double.Parse(dgvImportBill.Rows[i].Cells["Quantity"].Value.ToString());
                reQuantity = double.Parse(dgvImportBill.Rows[i].Cells["ReQuantity"].Value.ToString());
                UpdateMeterialQuantityByMeterialId(meterialId, quantity, reQuantity);
                if (importBillDetailId == -1)
                {
                    var newRow = importBillDetailDataTable.NewImportBillDetailRow();

                    newRow.ImportBillId = ImportBillId;
                    newRow.MeterialId = meterialId;
                    newRow.Quantity = quantity;
                    newRow.Cost = double.Parse(dgvImportBill.Rows[i].Cells["Cost"].Value.ToString());

                    importBillDetailDataTable.AddImportBillDetailRow(newRow);
                    try
                    {
                        importBillDetailController.UpdateImportBillDetail(importBillDetailDataTable);
                        isSuccess = true;
                    }
                    catch
                    {
                        isSuccess = false;
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
                        }
                    }
                }
                else
                {
                    importBillDetailController.GetByImportBillDetailId(importBillDetailDataTable, importBillDetailId);
                    if (importBillDetailDataTable.Rows.Count == 0)
                        return;
                    importBillDetailDataTable.First().MeterialId = meterialId;
                    importBillDetailDataTable.First().Quantity = quantity;
                    importBillDetailDataTable.First().Cost = double.Parse(dgvImportBill.Rows[i].Cells["Cost"].Value.ToString());
                    try
                    {
                        importBillDetailController.UpdateImportBillDetail(importBillDetailDataTable);
                        isSuccess = true;
                    }
                    catch
                    {
                        isSuccess = false;
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
                        }

                    }
                }
            }

            if (isSuccess)
                MessageBox.Show("Thêm mới hoá đơn thành công!", Constants.CaptionInformationMessage, MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("Lỗi: Cập nhật hoá đơn không thành công!", Constants.CaptionErrorMessage, MessageBoxButtons.OK, MessageBoxIcon.Error);

            LoadInitialize();
            CleanUp();
        }

        private void AddNewMenuRow(int IndexMax, string meterialName, double quantity, string unitName, double cost, Int64 meterialId, Int64 importBillDetailId, double reQuantity)
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
            Rows.Cells["ImportBillDetailId"].Value = importBillDetailId;
            Rows.Cells["ReQuantity"].Value = reQuantity;
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
                AddNewMenuRow(indexMax, cboMeterial.Text, txtQuantity.Value, unitName, txtCost.Value, meterialId, -1, 0);
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
            LoadImportBill();
            LoadImportBillDetail();
            TotalMoneyCellEndEdit();
        }

        private void LoadImportBill()
        {
            importBillDataTable = new ImportBillDataSet.ImportBillDataTable();
            importBillController.GetByImportId(importBillDataTable, ImportBillId);
            txtBillCode.Text = importBillDataTable.First().Field<string>("ImportBillCode");
            txtTotalMoney.Value = importBillDataTable.First().TotalMoney;
            txtNote.Text = importBillDataTable.First().Field<string>("Note");
        }

        private void LoadImportBillDetail()
        {
            searchImportBillDetailDataTable = new ImportBillDetailDataSet.SearchImportBillDetailDataTable();
            importBillDetailController.GetByImportBillId(searchImportBillDetailDataTable, ImportBillId);
            int indexMax = 0;
            foreach (ImportBillDetailDataSet.SearchImportBillDetailRow item in searchImportBillDetailDataTable.Rows)
            {
                AddNewMenuRow(indexMax, item.MeterialName, item.Quantity, item.UnitName, item.Cost, item.MeterialId, item.ImportBillDetailId, item.Quantity);
                indexMax++;
            }
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
            if (e.ColumnIndex != 6 | e.RowIndex == -1)
            {
                return;
            }
            Int64 importBillDetailId;
            double reQuantity;
            int meterialId;
            reQuantity = double.Parse(dgvImportBill.Rows[e.RowIndex].Cells["ReQuantity"].Value.ToString());

            meterialId = int.Parse(dgvImportBill.Rows[e.RowIndex].Cells["MeterialId"].Value.ToString());
            if (dgvImportBill.Rows[e.RowIndex].Cells["ImportBillDetailId"].Value == null)
                return;
            DialogResult rst = MessageBox.Show("Bạn có muốn xoá nguyên liệu " + dgvImportBill.Rows[e.RowIndex].Cells["MeterialName"].Value.ToString() + " này không?", Constants.CaptionInformationMessage, MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (rst == DialogResult.No)
                return;

            importBillDetailId = Int64.Parse(dgvImportBill.Rows[e.RowIndex].Cells["ImportBillDetailId"].Value.ToString());

            importBillDetailDataTable = new ImportBillDetailDataSet.ImportBillDetailDataTable();
            importBillDetailController.GetByImportBillDetailId(importBillDetailDataTable, importBillDetailId);

            if (importBillDetailDataTable.Rows.Count == 0)
            {
                dgvImportBill.Rows.RemoveAt(e.RowIndex);
                return;
            }
            importBillDetailDataTable.First().Delete();
            try
            {
                importBillDetailController.UpdateImportBillDetail(importBillDetailDataTable);
                dgvImportBill.Rows.RemoveAt(e.RowIndex);
                TotalMoneyCellEndEdit();
                UpdateMeterialQuantityByMeterialId(meterialId, 0, reQuantity);
                SaveImportBill();
                ImportBills_Load(null, null);
                MessageBox.Show("Xoá nguyên liệu thành công", Constants.CaptionInformationMessage, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch
            {
                MessageBox.Show("Lỗi: Xoá nguyên liệu không thành công", Constants.CaptionErrorMessage, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (reLoadData != null)
                reLoadData();
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
            this.Close();
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
            if (userFunctionList.Bills[0].Add == 1)
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
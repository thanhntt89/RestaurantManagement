using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using RestaurantController;
using RestaurantDTO;
using RestaurantCommon;

namespace RestaurantManagement
{
    public partial class ExportBills : DevComponents.DotNetBar.Metro.MetroForm
    {
        // Sự kiện load lại dữ liệu
        public delegate void ReLoadData();
        public event ReLoadData reLoadData;

        private SubMeterialGroupDataSet.SubMeterialGroupDataTable subMeterialGroupDataTable = null;
        private SubMeterialGroupController subMeterialGroupController = new SubMeterialGroupController();
        private MeterialController meterialController = new MeterialController();
        private MeterialDataSet.MeterialUnitAndSubGroupMeterialDataTable meterialUnitAndSubGroupMeterialDataTable = null;
        private MeterialDataSet.MeterialsDataTable meterialsDataTable = null;
        private ExportBillController exportBillController = new ExportBillController();
        private ExportBillsDataSet.ExportBillDataTable exportBillDataTable = null;
        private ExportBillDetailController exportBillDetailController = new ExportBillDetailController();
        private ExportBillDetailDataSet.ExportBillDetailDataTable exportBillDetailDataTable = null;
        private string unitName = string.Empty;
        private int staffId = 0;
        private UserFunctionList userFunctionList;
        private string exportBillId = string.Empty;

        public ExportBills(UserFunctionList userFunctionList)
        {
            InitializeComponent();
            this.userFunctionList = userFunctionList;
        }

        private void ExportBills_Load(object sender, EventArgs e)
        {
            this.cboMeterial.SelectedIndexChanged += new System.EventHandler(this.cboMeterial_SelectedIndexChanged);
            LoadInitialize();
        }

        private void LoadInitialize()
        {
            LoadAllSubGroupMeterial();
            exportBillId = Utilities.CreatedFirstBillId("EB", DateTime.Now);
            txtBillCode.Text = exportBillId;
        }

        private void LoadAllSubGroupMeterial()
        {
            subMeterialGroupDataTable = new SubMeterialGroupDataSet.SubMeterialGroupDataTable();
            subMeterialGroupController.GetBySunMeterialGroupAll(subMeterialGroupDataTable);
            var newRow = subMeterialGroupDataTable.NewSubMeterialGroupRow();
            newRow.SubMeterialGroupId = 0;
            newRow.SubMeterialGroupName = "Tất cả";
            newRow.Note = string.Empty;
            newRow.MeterialGroupId = 0;
            subMeterialGroupDataTable.Rows.InsertAt(newRow, 0);

            cboSubGroupMeterial.DisplayMember = subMeterialGroupDataTable.SubMeterialGroupNameColumn.ColumnName;
            cboSubGroupMeterial.ValueMember = subMeterialGroupDataTable.SubMeterialGroupIdColumn.ColumnName;
            cboSubGroupMeterial.DataSource = subMeterialGroupDataTable;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            panelSearch.Visible = false;
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
            txtInventories.Value = 0;
            lbUnitName.Text = string.Empty;
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

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Enter && txtQuantity.Value > 0)
                ExportMeterial();
            if (keyData == Keys.F2)
                SaveExportBill();
            return base.ProcessCmdKey(ref msg, keyData);
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

        //private string Meterial
        private void btnImport_Click(object sender, EventArgs e)
        {
            ExportMeterial();
        }

        private void cboMeterial_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboMeterial.SelectedValue == null)
            {
                return;
            }
            MeterialDataSet.MeterialUnitAndSubGroupMeterialRow row = (MeterialDataSet.MeterialUnitAndSubGroupMeterialRow)cboMeterial.SelectedItem;

            txtInventories.Value = row.IsQuantityNull() ? 0 : row.Quantity;
            txtMeterialCode.Text = row.MeterialCode;//(string)meterialCode;
            unitName = row.UnitName;
            lbUnitName.Text = unitName;
            // }
            txtQuantity.Value = 0;
            panelSearch.Visible = false;
            txtQuantity.Focus();
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

            if (txtInventories.Value < txtQuantity.Value)
            {
                txtQuantity.Focus();
                MessageBox.Show("Số lượng xuất kho vượt quá số lượng tồn kho", Constants.CaptionInformationMessage, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private void ExportMeterial()
        {
            if (!CheckImtem())
            {
                return;
            }
            int indexMax = dgvExportBill.Rows.Count;
            int meterialId = int.Parse(cboMeterial.SelectedValue.ToString());
            bool isExist = false;

            // Kiểm tra xem MenuId đã tồn tại hay chưa, nếu chưa có thì tiến hành thêm mới, ngược lại thì update thêm số lượng
            for (int i = 0; i < dgvExportBill.Rows.Count; i++)
            {
                // Nếu tồn tại thực đơn trong danh sách rồi thì cập nhật
                if (dgvExportBill.Rows[i].Cells["MeterialId"].Value.ToString().Equals(meterialId.ToString()))
                {
                    dgvExportBill.Rows[i].Selected = true;
                    MessageBox.Show("Mặt hàng đã được nhập bạn hãy điều chỉnh lại số lượng trên bảng", Constants.CaptionInformationMessage, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }
            //Trường hợp đây là thực đơn mới
            if (!isExist)
            {
                AddNewMenuRow(indexMax, cboMeterial.Text, txtInventories.Value, txtQuantity.Value, unitName, meterialId);
            }
            Clear();
        }

        private void Clear()
        {
            cboMeterial.SelectedIndex = -1;
            txtMeterialCode.Text = string.Empty;
            txtInventories.Value = 0;
            txtQuantity.Value = 0;
            txtMeterialCode.Focus();
        }

        private void AddNewMenuRow(int IndexMax, string meterialName, double inventories, double quantity, string unitName, Int64 meterialId)
        {
            // Bật tính năng cho phép thêm dòng
            dgvExportBill.AllowUserToAddRows = true;

            // Thực hiện thêm một dòng mới
            dgvExportBill.Rows.Add();

            // Khai báo biến hàng mới cho bảng
            DataGridViewRow Rows = dgvExportBill.Rows[IndexMax];

            // Gán các giá trị vào từng cột tương ứng của hàng vừa thêm
            Rows.Cells["STT"].Value = IndexMax + 1;
            Rows.Cells["MeterialName"].Value = meterialName;
            Rows.Cells["Quantity"].Value = quantity;
            Rows.Cells["UnitNames"].Value = unitName;
            Rows.Cells["Inventories"].Value = inventories;
            Rows.Cells["MeterialId"].Value = meterialId;

            // Khoá tính năng cho phép thêm dòng
            dgvExportBill.AllowUserToAddRows = false;
            dgvExportBill.Rows[IndexMax].Selected = true;
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

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveExportBill();
            if (reLoadData != null)
                reLoadData();
        }

        private void SaveExportBill()
        {
            DialogResult rst = MessageBox.Show("Bạn có muốn lưu lại những thông tin này không?", Constants.CaptionInformationMessage, MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (rst == DialogResult.No)
                return;

            if (!CheckInventories())
                return;
            exportBillDataTable = new ExportBillsDataSet.ExportBillDataTable();

            var newRow = exportBillDataTable.NewExportBillRow();
            newRow.ExportId = exportBillId;
            newRow.Date = dtpBillDate.Value;
            newRow.Note = txtNote.Text;
            if (staffId > 0)
                newRow.StaffId = staffId;

            exportBillDataTable.AddExportBillRow(newRow);
            try
            {
                exportBillController.UpdateExportBill(exportBillDataTable);
                LogHistories.InsertLogHistories("Thêm hóa đơn xuất kho " + txtBillCode.Text, DateTime.Now, userFunctionList.UserName, "Thành công");
            }
            catch
            {
                LogHistories.InsertLogHistories("Thêm hóa đơn xuất kho " + txtBillCode.Text, DateTime.Now, userFunctionList.UserName, "Lỗ");
                MessageBox.Show("Lỗi: Thêm mới hoá đơn không thành công!", Constants.CaptionErrorMessage, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            SaveBillDetail(txtBillCode.Text);
        }

        private void SaveBillDetail(string exportId)
        {
            exportBillDetailDataTable = new ExportBillDetailDataSet.ExportBillDetailDataTable();

            int meterialId = 0;
            double Inventory = 0;
            double quantity = 0;

            for (int i = 0; i < dgvExportBill.Rows.Count; i++)
            {
                quantity = double.Parse(dgvExportBill.Rows[i].Cells["Quantity"].Value.ToString());
                meterialId = int.Parse(dgvExportBill.Rows[i].Cells["MeterialId"].Value.ToString());
                UpdateMeterial(meterialId, quantity);

                var newRow = exportBillDetailDataTable.NewExportBillDetailRow();
                newRow.ExportId = exportId;
                newRow.MeterialId = meterialId;
                newRow.Quantity = quantity;

                exportBillDetailDataTable.AddExportBillDetailRow(newRow);
            }
            try
            {
                exportBillDetailController.UpdateExportBillDetail(exportBillDetailDataTable);
                MessageBox.Show("Xuất kho thành công!", Constants.CaptionInformationMessage, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch
            {
                MessageBox.Show("Xuất kho thành công!", Constants.CaptionErrorMessage, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Sau khi xuất kho thành công cập nhật lại thông tin của danh sách nguyên liệu
            LoadInitialize();
            CleanUp();
        }

        private void UpdateMeterial(int meterialId, double quantity)
        {
            meterialsDataTable = new MeterialDataSet.MeterialsDataTable();
            meterialController.GetByMerterialId(meterialsDataTable, meterialId);
            meterialsDataTable.First().Quantity = meterialsDataTable.First().Quantity - quantity;
            try
            {
                meterialController.UpdateMeterial(meterialsDataTable);
            }
            catch
            {
            }
        }

        private bool CheckInventories()
        {
            if (dgvExportBill.Rows.Count == 0)
            {
                MessageBox.Show("Chưa có mặt hàng nào để xuất kho.", Constants.CaptionErrorMessage, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            meterialsDataTable = new MeterialDataSet.MeterialsDataTable();
            int meterialId = 0;
            double Inventory = 0;
            double quantity = 0;
            bool isQuantityLarge = false;
            for (int i = 0; i < dgvExportBill.Rows.Count; i++)
            {
                quantity = double.Parse(dgvExportBill.Rows[i].Cells["Quantity"].Value.ToString());
                meterialId = int.Parse(dgvExportBill.Rows[i].Cells["MeterialId"].Value.ToString());
                meterialController.GetByMerterialId(meterialsDataTable, meterialId);
                Inventory = meterialsDataTable.First().Quantity;
                if (quantity > Inventory || quantity == 0)
                {
                    dgvExportBill.Rows[i].Cells["Inventories"].Value = Inventory;
                    dgvExportBill.Rows[i].Cells["Quantity"].Style.BackColor = Color.Red;
                    isQuantityLarge = true;
                }
            }
            if (isQuantityLarge)
            {
                MessageBox.Show("Số lượng xuất kho phải lớn hơn 0 và không vượt quá số lượng tồn kho, bạn hãy điều chỉnh lại", Constants.CaptionErrorMessage, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        private void CleanUp()
        {
            dgvExportBill.Rows.Clear();
            txtNote.Text = string.Empty;
            txtQuantity.Value = 0;
            txtInventories.Value = 0;
            cboMeterial.SelectedIndex = -1;
            txtMeterialCode.Text = string.Empty;
        }

        private void dgvExportBill_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (double.Parse(dgvExportBill.Rows[e.RowIndex].Cells["Inventories"].Value.ToString()) >= double.Parse(dgvExportBill.Rows[e.RowIndex].Cells["Quantity"].Value.ToString()))
                dgvExportBill.Rows[e.RowIndex].Cells["Quantity"].Style.BackColor = Color.White;
            else
            {
                dgvExportBill.Rows[e.RowIndex].Cells["Quantity"].Style.BackColor = Color.Red;
                MessageBox.Show("Số lượng xuất kho vượt quá số lượng tồn kho, bạn hãy điều chỉnh lại", Constants.CaptionErrorMessage, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void dgvExportBill_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e != null && e.ColumnIndex == 5)
                DeleteMeterial(e.RowIndex);
        }

        private void DeleteMeterial(int index)
        {
            dgvExportBill.Rows.RemoveAt(index);
        }

        private void cboSubGroupMeterial_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadAllMeterial();
        }

        private void ExportBills_SizeChanged(object sender, EventArgs e)
        {
            panelSearch.Top = cboMeterial.Top - 3;
            panelSearch.Left = cboMeterial.Left;
        }

        private void ExportBills_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (reLoadData != null)
                reLoadData();
        }
    }
}

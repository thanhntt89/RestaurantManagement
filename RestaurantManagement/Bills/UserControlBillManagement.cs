using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using RestaurantDTO;
using RestaurantController;
using RestaurantCommon;
using System.IO;

namespace RestaurantManagement
{
    public partial class UserControlBillManagement : UserControl
    {
        private ShiftDataSet.ShiftsDataTable ShiftsDataTable = null;
        private BillEntity billEntity = null;
        private BillsDataSet.SearchBillDataTable searchBillDataTable = null;
        private BillController billController = new BillController();
        private BillsDataSet.BillDataTable billDataTable = null;

        private ImportBillDataSet.ImportBillDataTable importBillDataTable = null;
        private ImportBillController importBillController = new ImportBillController();
        private ImportBillDataSet.SearchImportBillsDataTable searchImportBillsDataTable = null;
        private UserFunctionList userFunctionList = null;
        private string billCode = string.Empty;
        private bool IsExportSuccess;

        private ExcelExportEntity excelEntity = null;
        private ProcessingEntity processingEntity = null;

        public UserControlBillManagement(UserFunctionList userFunctionList)
        {
            InitializeComponent();
            this.userFunctionList = userFunctionList;
            CheckRole();
        }

        private void CheckRole()
        {
            dgvImportBill.Columns["DeleteImport"].Visible = false;
            dgvReportBill.Columns["Delete"].Visible = false;

            if (userFunctionList.Bills[0].Delete == 1)
            {
                dgvImportBill.Columns["DeleteImport"].Visible = true;
                dgvReportBill.Columns["Delete"].Visible = true;
            }
        }

        private void UserControlBillManagement_Load(object sender, EventArgs e)
        {
            LoadInitialize();
        }

        private void LoadInitialize()
        {
            LoadAllShift();
            LoadStaffAll();
        }

        private void LoadAllShift()
        {
            ShiftsDataTable = new ShiftDataSet.ShiftsDataTable();
            ShiftsController ShiftsController = new ShiftsController();
            ShiftsController.GetAllShift(ShiftsDataTable);
            if (ShiftsDataTable.Rows.Count == 0)
                return;
            var newRow = ShiftsDataTable.NewShiftsRow();
            newRow.ShiftId = 0;
            newRow.ShiftCode = string.Empty;
            newRow.ShiftName = "Tất cả ";
            newRow.Note = string.Empty;
            ShiftsDataTable.Rows.InsertAt(newRow, 0);

            cboShift.DataSource = ShiftsDataTable;
            cboShift.DisplayMembers = ShiftsDataTable.ShiftNameColumn.ColumnName;
            cboShift.ValueMember = ShiftsDataTable.ShiftIdColumn.ColumnName;
            cboShift.Text = string.Empty;
        }

        /// <summary>
        /// Load danh sách nhân viên
        /// </summary>
        private void LoadStaffAll()
        {
            StaffController StaffController = new StaffController();
            StaffDataSet.StaffsDataTable StaffsDataTable = new StaffDataSet.StaffsDataTable();
            StaffDataSet.StaffsDataTable thuNganDataTable = new StaffDataSet.StaffsDataTable();

            StaffController.GetAllStaff(StaffsDataTable);

            if (StaffsDataTable.Rows.Count == 0)
                return;

            var newRow = StaffsDataTable.NewStaffsRow();
            newRow.StaffId = 0;
            newRow.StaffCode = string.Empty;
            newRow.Status = 1;
            newRow.UserName = string.Empty;
            newRow.FullName = "Tất cả ";
            newRow.Address = string.Empty;
            newRow.Email = string.Empty;
            newRow.Mobile = string.Empty;
            newRow.PassWord = string.Empty;
            newRow.RoleId = 0;
            newRow.Image = null;

            StaffsDataTable.Rows.InsertAt(newRow, 0);

            thuNganDataTable.Merge(StaffsDataTable);

            cboStaff.DataSource = StaffsDataTable;
            cboStaff.DisplayMembers = StaffsDataTable.FullNameColumn.ColumnName;
            cboStaff.ValueMember = StaffsDataTable.StaffIdColumn.ColumnName;

            cboImportBillStaff.DataSource = StaffsDataTable;
            cboImportBillStaff.DisplayMembers = StaffsDataTable.FullNameColumn.ColumnName;
            cboImportBillStaff.ValueMember = StaffsDataTable.StaffIdColumn.ColumnName;

            cboThuNgan.DataSource = thuNganDataTable;
            cboThuNgan.DisplayMembers = thuNganDataTable.FullNameColumn.ColumnName;
            cboThuNgan.ValueMember = thuNganDataTable.StaffIdColumn.ColumnName;
            // cboThuNgan.SelectedValue = userFunctionList.StaffId;
        }

        private void btnSearchReport_Click(object sender, EventArgs e)
        {
            SearchBillSale();
        }

        private void SearchBillSale()
        {
            dgvReportBill.Rows.Clear();
            billEntity = new BillEntity();
            LogHistories.InsertLogHistories("Tìm kiếm hóa đơn bán hàng ", DateTime.Now, userFunctionList.UserName, "Tìm kiếm");

            billEntity.ShiftId = (int)cboShift.SelectedValue;
            billEntity.StaffId = (int)cboStaff.SelectedValue;
            if (dtpFormDate.Checked)
                billEntity.FromDate = dtpFormDate.Value.ToString("yyyy-MM-dd 00:00:00");

            if (dtpToDate.Checked)
                billEntity.ToDate = dtpToDate.Value.ToString("yyyy-MM-dd 23:59:59");

            //billEntity.BillCode = txtBillCodes.Text;

            if (cboBillStatus.SelectedNode != null && cboBillStatus.SelectedNode.Name.Equals("Payed"))
                billEntity.Status = Constants.Payed;
            else if (cboBillStatus.SelectedNode != null && cboBillStatus.SelectedNode.Name.Equals("IsNotPay"))
                billEntity.Status = Constants.IsNotPay;
            else
                billEntity.Status = -1;

            searchBillDataTable = new BillsDataSet.SearchBillDataTable();
            billController.SearchBillByBillEntity(searchBillDataTable, billEntity);

            var querry = from row in searchBillDataTable
                         select row;
            if (!string.IsNullOrEmpty(txtBillCodes.Text))
                querry = querry.Where(r => r.BillCode.IndexOf(txtBillCodes.Text, StringComparison.OrdinalIgnoreCase) >= 0);
            if (cboThuNgan.SelectedIndex > 0)
                querry = querry.Where(r => r.Note == int.Parse(cboThuNgan.SelectedValue.ToString()));
            int index = 0;
            dgvReportBill.AllowUserToAddRows = true;

            foreach (var item in querry)
            {
                dgvReportBill.Rows.Add();
                DataGridViewRow row = dgvReportBill.Rows[index];
                row.Cells["STT"].Value = index + 1;
                row.Cells["StaffName"].Value = item.FullName;
                row.Cells["ShiftName"].Value = item.ShiftName;
                row.Cells["BillCode"].Value = item.IsBillCodeNull() ? string.Empty : item.BillCode;
                row.Cells["BillDate"].Value = item.BillDate.ToString("dd/MM/yyyy HH:mm:ss tt");
                row.Cells["TableName"].Value = item.TableName;
                row.Cells["TotalCost"].Value = item.TotalCost;
                if (item.Status == Constants.TableIsUsed)
                    row.Cells["Status"].Value = true;
                else
                    row.Cells["Status"].Value = false;
                row.Cells["BillId"].Value = item.BillId;

                index++;
            }
            dgvReportBill.AllowUserToAddRows = false;
        }

        private void ShowBillDetail()
        {
            if (dgvReportBill.Rows.Count == 0)
                return;
            string billId = string.Empty;
            bool isNotPayOut = false;

            if (dgvReportBill.CurrentRow.Cells["BillId"].Value == null)
                return;
            billId = dgvReportBill.CurrentRow.Cells["BillId"].Value.ToString();
            isNotPayOut = (bool)dgvReportBill.CurrentRow.Cells["Status"].Value;
            UpdateMainServices UpdateMainServices = new UpdateMainServices(billId, isNotPayOut, userFunctionList);
            UpdateMainServices.reLoadData += new UpdateMainServices.ReLoadData(SearchBillSale);
            UpdateMainServices.ShowDialog();
        }

        private void DeleteBill(int indexRow)
        {
            if (indexRow == -1)
                return;

            if (dgvReportBill.Rows[indexRow].Cells["BillId"].Value == null)
                return;

            string billId = dgvReportBill.CurrentRow.Cells["BillId"].Value.ToString();
            int tableId = -1;
            billDataTable = new BillsDataSet.BillDataTable();
            billController.GetBillByBillId(billDataTable, billId);
            DialogResult rst = MessageBox.Show("Xoá hoá đơn này sẽ ảnh hưởng tới kết quả báo cáo doanh thu của cửa hàng.\n Bạn có muốn tiếp tục không?", Constants.CaptionInformationMessage, MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (rst != DialogResult.Yes)
                return;

            if (billDataTable.Rows.Count == 0)
            {
                dgvReportBill.Rows.RemoveAt(dgvReportBill.CurrentRow.Index);
                MessageBox.Show("Xoá hoá đơn thành công!", Constants.CaptionInformationMessage, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            billCode = billDataTable.First().BillCode;
            tableId = billDataTable.First().TableId;
            billDataTable.First().Delete();

            try
            {
                billController.UpdateBill(billDataTable);
                LogHistories.InsertLogHistories("Xóa hóa đơn " + billCode, DateTime.Now, userFunctionList.UserName, "Thành công");
                UpdateTableByStatus(tableId, Constants.TableIsFree);
                dgvReportBill.Rows.RemoveAt(dgvReportBill.CurrentRow.Index);
                MessageBox.Show("Xoá hoá đơn thành công!", Constants.CaptionInformationMessage, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch
            {
                LogHistories.InsertLogHistories("Xóa hóa đơn " + billCode, DateTime.Now, userFunctionList.UserName, "Lỗi");
                MessageBox.Show("Không xoá được hoá đơn!", Constants.CaptionErrorMessage, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateTableByStatus(int tableId, int status)
        {
            TablesDataSet.TablesDataTable tablesDataTable = null;
            TablesController tablesController = new TablesController();

            // Cập nhật trạng thái vào database
            tablesDataTable = new TablesDataSet.TablesDataTable();
            tablesController.GetAllTableByTableId(tablesDataTable, tableId);
            if (tablesDataTable.Rows.Count == 0)
                return;
            tablesDataTable.First().Status = status;
            try
            {
                tablesController.UpdateTable(tablesDataTable);
            }
            catch
            {
                LogHistories.InsertLogHistories("Cập nhật trạng thái bàn tableId = " + tableId + " không thành công: Xóa hóa đơn " + billCode, DateTime.Now, userFunctionList.UserName, "Thành công");
            }
        }

        private void dgvReportBill_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 8)
                DeleteBill(e.RowIndex);
        }

        private void dgvReportBill_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            ShowBillDetail();
        }

        private void SearchImportBill()
        {
            dgvImportBill.Rows.Clear();
            billEntity = new BillEntity();
            LogHistories.InsertLogHistories("Tìm kiếm hóa đơn nhập hàng ", DateTime.Now, userFunctionList.UserName, "Tìm kiếm");
            billEntity.StaffId = (int)cboImportBillStaff.SelectedValue;

            billEntity.Status = -1;

            if (dtpImportBillFromDate.Checked)
                billEntity.FromDate = dtpImportBillFromDate.Value.ToString("yyyy-MM-dd 00:00:00");
            if (dtpImportToDate.Checked)
                billEntity.ToDate = dtpImportToDate.Value.ToString("yyyy-MM-dd 23:59:59");

            //  billEntity.BillCode = txtImportBillCode.Text;

            searchImportBillsDataTable = new ImportBillDataSet.SearchImportBillsDataTable();
            importBillController.SearchImportBillByBillEntity(searchImportBillsDataTable, billEntity);

            var querry = from row in searchImportBillsDataTable
                         select row;
            if (!string.IsNullOrEmpty(txtImportBillCode.Text))
                querry = querry.Where(r => r.ImportBillCode.IndexOf(txtImportBillCode.Text, StringComparison.OrdinalIgnoreCase) >= 0);

            int index = 0;
            dgvImportBill.AllowUserToAddRows = true;

            foreach (var item in querry)
            {
                dgvImportBill.Rows.Add();
                DataGridViewRow row = dgvImportBill.Rows[index];
                row.Cells["ImportIndex"].Value = index + 1;
                row.Cells["ImportStaffName"].Value = item.Field<string>("FullName");
                row.Cells["ImportBillCode"].Value = item.Field<string>("ImportBillCode");
                row.Cells["ImportBillDateTime"].Value = item.DateTime.ToString("dd/MM/yyyy HH:mm:ss tt");
                row.Cells["ImportTotalMoney"].Value = item.TotalMoney;
                row.Cells["ImportNote"].Value = item.Field<string>("Note");
                row.Cells["ImportBillId"].Value = item.ImportId;

                index++;
            }
            dgvImportBill.AllowUserToAddRows = false;
        }

        private void btnImportBillSearch_Click(object sender, EventArgs e)
        {
            SearchImportBill();
        }

        private void dgvImportBill_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            ShowUpdateImportBill();
        }

        private void ShowUpdateImportBill()
        {
            if (dgvImportBill.Rows.Count == 0)
                return;

            string ImportBillId = string.Empty;
            if (dgvImportBill.CurrentRow.Cells["ImportBillId"].Value == null)
                return;
            ImportBillId = dgvImportBill.CurrentRow.Cells["ImportBillId"].Value.ToString();
            UpdateImportBills UpdateImportBills = new UpdateImportBills(ImportBillId, userFunctionList);
            UpdateImportBills.reLoadData += new UpdateImportBills.ReLoadData(SearchImportBill);
            UpdateImportBills.ShowDialog();
        }

        private void DeleteImportBill(int indexRow)
        {
            if (dgvImportBill.Rows[indexRow].Cells["ImportBillId"].Value == null)
                return;

            string importBillId = dgvImportBill.CurrentRow.Cells["ImportBillId"].Value.ToString();
            string importBillCode = string.Empty;
            importBillDataTable = new ImportBillDataSet.ImportBillDataTable();
            importBillController.GetByImportId(importBillDataTable, importBillId);
            DialogResult rst = MessageBox.Show("Xoá hoá đơn này sẽ ảnh hưởng tới kết quả báo cáo chi phí của cửa hàng.\n Bạn có muốn tiếp tục không?", Constants.CaptionInformationMessage, MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (rst != DialogResult.Yes)
                return;

            if (importBillDataTable.Rows.Count == 0)
            {
                dgvImportBill.Rows.RemoveAt(indexRow);
                MessageBox.Show("Xoá hoá đơn thành công!", Constants.CaptionInformationMessage, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            importBillCode = importBillDataTable.First().ImportBillCode;
            importBillDataTable.First().Delete();
            try
            {
                importBillController.UpdateImportBill(importBillDataTable);
                LogHistories.InsertLogHistories("Xóa hóa đơn " + importBillCode, DateTime.Now, userFunctionList.UserName, "Thành công");
                dgvImportBill.Rows.RemoveAt(indexRow);
                MessageBox.Show("Xoá hoá đơn thành công!", Constants.CaptionInformationMessage, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch
            {
                LogHistories.InsertLogHistories("Xóa hóa đơn " + importBillCode, DateTime.Now, userFunctionList.UserName, "Lỗi");
                MessageBox.Show("Lỗi: Đang tồn tại chi tiết hoá đơn nhập không xoá được hoá đơn này.", Constants.CaptionErrorMessage, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvImportBill_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 6 && e.RowIndex > -1)
                DeleteImportBill(e.RowIndex);
        }

        private void btnExportToExcel_Click(object sender, EventArgs e)
        {
            SaveFileDialog save = new SaveFileDialog();
            save.Title = "Đặt tên file để lưu";
            save.Filter = "Excel XP/2003|*.xls|Excel 2007/2010|*.xlsx";
            if (save.ShowDialog() == DialogResult.Cancel)
                return;
            processingEntity = new ProcessingEntity();
            excelEntity = new ExcelExportEntity();

            if (Path.GetExtension(save.FileName).CompareTo(".xls") == 0)
                excelEntity.ExcelFormat = Constants.ExcelXP2003;
            else if (Path.GetExtension(save.FileName).CompareTo(".xlsx") == 0)
                excelEntity.ExcelFormat = Constants.Excel20072010;

            excelEntity.FilePath = save.FileName;
            excelEntity.Caption = "Báo cáo hoá đơn bán hàng ";
            excelEntity.Title = "Danh sách hoá đơn bán hàng ";
            excelEntity.FromDate = lbFormDate.Text + ": " + dtpFormDate.Text;
            excelEntity.ToDate = lbToDate.Text + ": " + dtpToDate.Text;
            excelEntity.SheetName = "BCTKT";

            if (backgroundWorkerExportBillSales == null)
            {
                backgroundWorkerExportBillSales = new BackgroundWorker();
                backgroundWorkerExportBillSales.DoWork += new DoWorkEventHandler(backgroundWorkerExportBillSales_DoWork);
                backgroundWorkerExportBillSales.RunWorkerCompleted += new RunWorkerCompletedEventHandler(backgroundWorkerExportBillSales_RunWorkerCompleted);
            }
            processingEntity.Completed = false;
            backgroundWorkerExportBillSales.RunWorkerAsync();

            Processing processing = new Processing(processingEntity);
            processing.ShowDialog();

            if (IsExportSuccess)
            {
                LogHistories.InsertLogHistories("Xuất hóa đơn bán hàng ra file " + save.FileName, DateTime.Now, userFunctionList.UserName, "Thành công");
                MessageBox.Show("Xuất thông tin thành công!", Constants.CaptionInformationMessage, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                LogHistories.InsertLogHistories("Xuất hóa đơn bán hàng ra file " + save.FileName, DateTime.Now, userFunctionList.UserName, "Lỗi");
                MessageBox.Show("Lỗi: Xuất thông tin không thành công!", Constants.CaptionErrorMessage, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnImportBillExcelExport_Click(object sender, EventArgs e)
        {
            SaveFileDialog save = new SaveFileDialog();
            save.Title = "Đặt tên file để lưu";
            save.Filter = "Excel XP/2003|*.xls|Excel 2007/2010|*.xlsx";
            if (save.ShowDialog() == DialogResult.Cancel)
                return;

            processingEntity = new ProcessingEntity();
            excelEntity = new ExcelExportEntity();

            if (Path.GetExtension(save.FileName).CompareTo(".xls") == 0)
                excelEntity.ExcelFormat = Constants.ExcelXP2003;
            else if (Path.GetExtension(save.FileName).CompareTo(".xlsx") == 0)
                excelEntity.ExcelFormat = Constants.Excel20072010;

            excelEntity.FilePath = save.FileName;
            excelEntity.Caption = "Báo cáo hoá đơn nhập hàng ";
            excelEntity.Title = "Danh sách hoá đơn nhập hàng ";
            excelEntity.FromDate = lbFormDate.Text + ": " + dtpFormDate.Text;
            excelEntity.ToDate = lbToDate.Text + ": " + dtpToDate.Text;
            excelEntity.SheetName = "BCTKT";
            excelEntity.FullName = cboImportBillStaff.Text;

            if (backgroundWorkerExportImportBills == null)
            {
                backgroundWorkerExportImportBills = new BackgroundWorker();
                backgroundWorkerExportImportBills.DoWork += new DoWorkEventHandler(backgroundWorkerExportImportBills_DoWork);
                backgroundWorkerExportImportBills.RunWorkerCompleted += new RunWorkerCompletedEventHandler(backgroundWorkerExportImportBills_RunWorkerCompleted);
            }

            processingEntity.Completed = false;
            backgroundWorkerExportImportBills.RunWorkerAsync();

            Processing processing = new Processing(processingEntity);
            processing.ShowDialog();

            if (IsExportSuccess)
            {
                LogHistories.InsertLogHistories("Xuất hóa đơn nhập hàng ra file " + save.FileName, DateTime.Now, userFunctionList.UserName, "Thành công");
                MessageBox.Show("Xuất thông tin thành công!", Constants.CaptionInformationMessage, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                LogHistories.InsertLogHistories("Xuất hóa đơn nhập hàng ra file " + save.FileName, DateTime.Now, userFunctionList.UserName, "Lỗi");
                MessageBox.Show("Lỗi: Xuất thông tin không thành công!", Constants.CaptionErrorMessage, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBillDetail_Click(object sender, EventArgs e)
        {
            ShowBillDetail();
        }

        private void btnImportDetail_Click(object sender, EventArgs e)
        {
            ShowUpdateImportBill();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Enter)
                if (superTabControl1.SelectedTabIndex == 0)
                    SearchBillSale();
                else if (superTabControl1.SelectedTabIndex == 1)
                    SearchImportBill();
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void backgroundWorkerExportBillSales_DoWork(object sender, DoWorkEventArgs e)
        {
            IsExportSuccess = ExcelExportController.ExportServicesBill(dgvReportBill, excelEntity);
        }

        private void backgroundWorkerExportBillSales_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            processingEntity.Completed = true;
            backgroundWorkerExportBillSales.Dispose();
            backgroundWorkerExportBillSales = null;
            GC.Collect();
        }

        private void backgroundWorkerExportImportBills_DoWork(object sender, DoWorkEventArgs e)
        {
            IsExportSuccess = ExcelExportController.ExportImportBillMeterial(dgvImportBill, excelEntity);
        }

        private void backgroundWorkerExportImportBills_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            processingEntity.Completed = true;
            backgroundWorkerExportImportBills.Dispose();
            backgroundWorkerExportImportBills = null;
            GC.Collect();
        }
    }
}

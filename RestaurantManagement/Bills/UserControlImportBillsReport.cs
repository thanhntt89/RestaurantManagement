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
using System.IO;

namespace RestaurantManagement
{
    public partial class UserControlBillsManagement : UserControl
    {
        private BillEntity billEntity = null;
        public delegate void RemovedUserControler(string controler);
        public event RemovedUserControler removedUserControler;

        private ImportBillController importBillController = new ImportBillController();
        private ImportBillDataSet.ImportBillReportDataTable importBillReportDataTable = null;
        private StaffController staffController = new StaffController();
        private StaffDataSet.StaffsDataTable staffsDataTable = null;
        private UserFunctionList userFunctionList;

        private ExcelExportEntity excelEntity = null;
        private ProcessingEntity processingEntity = null;
        private bool IsExportSuccess;

        public UserControlBillsManagement(string ImporBillType, UserFunctionList userFunctionList)
        {
            InitializeComponent();
            LoadDateTimeType(ImporBillType);
            this.userFunctionList = userFunctionList;
        }

        private void LoadDateTimeType(string ImporBillType)
        {
            cboReportType.Enabled = false;
            dtpFormDate.Value = dtpFormDate.Value.AddDays(-1);
            if (ImporBillType.Equals(Constants.Day))
            {
                cboReportType.SelectedIndex = (int)ReportViewByType.DairyImport;
            }
            if (ImporBillType.Equals(Constants.Month))
            {
                lbFormDate.Text = "Từ tháng năm";
                lbToDate.Text = "Đến tháng năm";
                dtpToDate.CustomFormat = "MM/yyyy";
                dtpFormDate.CustomFormat = "MM/yyyy";
                cboReportType.SelectedIndex = (int)ReportViewByType.MonthImport;
            }
            if (ImporBillType.Equals(Constants.Year))
            {
                lbFormDate.Text = "Từ năm";
                lbToDate.Text = "Đến năm";
                dtpToDate.CustomFormat = "yyyy";
                dtpFormDate.CustomFormat = "yyyy";

                cboReportType.SelectedIndex = (int)ReportViewByType.YearImport;
            }
        }

        public UserControlBillsManagement()
        {
            InitializeComponent();
        }

        private void LoadAllStaff()
        {
            staffsDataTable = new StaffDataSet.StaffsDataTable();
            staffController.GetAllStaff(staffsDataTable);

            if (staffsDataTable.Rows.Count == 0)
                return;
            var newRow = staffsDataTable.NewStaffsRow();
            newRow.StaffId = 0;
            newRow.StaffCode = string.Empty;
            newRow.FullName = string.Empty;
            newRow.Status = -1;
            newRow.UserName = string.Empty;
            newRow.PassWord = string.Empty;
            newRow.Mobile = string.Empty;
            newRow.Email = string.Empty;
            newRow.Address = string.Empty;
            newRow.Image = null;
            newRow.RoleId = -1;
            staffsDataTable.Rows.InsertAt(newRow, 0);
            cboStaff.DataSource = staffsDataTable;
            cboStaff.ValueMember = staffsDataTable.StaffIdColumn.ColumnName;
            cboStaff.DisplayMembers = staffsDataTable.UserNameColumn.ColumnName;
        }

        private bool CheckItem()
        {
            if (dtpFormDate.Checked && dtpToDate.Checked)
                if (dtpFormDate.Value > dtpToDate.Value)
                {
                    MessageBox.Show(lbFormDate.Text + " không được lớn hơn " + lbToDate.Text + "", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            return true;
        }

        private void SearchByDay()
        {
            if (!CheckItem())
                return;
            dgvReportBill.Rows.Clear();
            billEntity = new BillEntity();
            LogHistories.InsertLogHistories("Tìm báo cáo nhập kho từ ngày" + dtpFormDate.Text + " đến ngày " + dtpToDate.Text + " ", DateTime.Now, userFunctionList.UserName, "Tìm kiếm");

            if (cboStaff.SelectedValue != null)
                billEntity.StaffId = int.Parse(cboStaff.SelectedValue.ToString());
            billEntity.Status = 0;
            double totalday = Math.Round((dtpToDate.Value - dtpFormDate.Value).TotalDays, 0);

            int index = 0;
            double TotalMoney = 0;
            int billTotal = 0;

            for (int i = 0; i <= totalday; i++)
            {
                if (dtpFormDate.Checked)
                    billEntity.FromDate = dtpFormDate.Value.AddDays(i).ToString("yyyy-MM-dd 00:00:01");
                if (dtpToDate.Checked)
                    billEntity.ToDate = dtpFormDate.Value.AddDays(i).ToString("yyyy-MM-dd 23:59:59");

                importBillReportDataTable = new ImportBillDataSet.ImportBillReportDataTable();
                importBillController.SearchImportBillByBillEntity(importBillReportDataTable, billEntity);
                if (importBillReportDataTable.First().CountBill == 0)
                    continue;

                dgvReportBill.AllowUserToAddRows = true;
                dgvReportBill.Rows.Add();
                DataGridViewRow row = dgvReportBill.Rows[index];
                row.Cells["STT"].Value = index + 1;
                row.Cells["BillDate"].Value = "Hoá đơn nhập hàng theo ngày: " + dtpFormDate.Value.AddDays(i).ToString("dd/MM/yyyy");
                row.Cells["BillTotal"].Value = importBillReportDataTable.First().IsCountBillNull() ? 0 : importBillReportDataTable.First().CountBill;
                row.Cells["MoneyTotal"].Value = importBillReportDataTable.First().IsTotalMoneyNull() ? "0" : importBillReportDataTable.First().TotalMoney.ToString("###,#0");
                TotalMoney += importBillReportDataTable.First().IsTotalMoneyNull() ? 0 : importBillReportDataTable.First().TotalMoney;
                billTotal += importBillReportDataTable.First().CountBill;
                index++;
            }

            dgvReportBill.AllowUserToAddRows = false;
            txtBillTotal.Value = billTotal;
            txtTotalMoney.Value = TotalMoney;
        }

        private void SearchBillByMonth()
        {
            if (!CheckItem())
                return;
            billEntity = new BillEntity();
            LogHistories.InsertLogHistories("Tìm báo cáo nhập kho theo tháng từ: " + dtpFormDate.Text + " đến ngày " + dtpToDate.Text + " ", DateTime.Now, userFunctionList.UserName, "Tìm kiếm");

            if (cboStaff.SelectedValue != null)
                billEntity.StaffId = int.Parse(cboStaff.SelectedValue.ToString());

            billEntity.Status = -1;
            double totalMonth = Math.Round((dtpToDate.Value - dtpFormDate.Value).TotalDays / 30, 0);
            double totalday = Math.Round((dtpToDate.Value - dtpFormDate.Value).TotalDays, 0);
            int index = 0;
            double TotalMoney = 0;
            int billTotal = 0;
            string fromDate = string.Empty;
            string todate = string.Empty;
            int firtDay;
            int lastDay;
            for (int i = 0; i <= totalMonth; i++)
            {
                billEntity.ToYear = dtpFormDate.Value.AddMonths(i).Year;
                billEntity.ToMonth = dtpFormDate.Value.AddMonths(i).Month;
                billEntity.FromMonth = dtpFormDate.Value.AddMonths(i).Month;
                billEntity.FromYear = dtpFormDate.Value.AddMonths(i).Year;

                firtDay = 1;
                lastDay = Utilities.GetLastDayOfMonth(dtpFormDate.Value.AddMonths(i));
                fromDate = firtDay.ToString("0#") + "/" + dtpFormDate.Value.AddMonths(i).ToString("MM/yyyy");
                todate = lastDay + "/" + dtpFormDate.Value.AddMonths(i).ToString("MM/yyyy");


                importBillReportDataTable = new ImportBillDataSet.ImportBillReportDataTable();
                importBillController.SearchImportBillByBillEntity(importBillReportDataTable, billEntity);
                if (importBillReportDataTable.First().CountBill == 0)
                    continue;
                dgvReportBill.AllowUserToAddRows = true;
                dgvReportBill.Rows.Add();
                DataGridViewRow row = dgvReportBill.Rows[index];
                row.Cells["STT"].Value = index + 1;
                row.Cells["BillDate"].Value = "Hoá đơn nhập hàng theo tháng tính từ: " + fromDate + " đến " + todate;
                row.Cells["BillTotal"].Value = importBillReportDataTable.First().IsCountBillNull() ? 0 : importBillReportDataTable.First().CountBill;
                row.Cells["MoneyTotal"].Value = importBillReportDataTable.First().IsTotalMoneyNull() ? "0" : importBillReportDataTable.First().TotalMoney.ToString("###,#0");
                TotalMoney += importBillReportDataTable.First().IsTotalMoneyNull() ? 0 : importBillReportDataTable.First().TotalMoney;
                billTotal += importBillReportDataTable.First().CountBill;
                index++;
            }

            dgvReportBill.AllowUserToAddRows = false;
            txtBillTotal.Value = billTotal;
            txtTotalMoney.Value = TotalMoney;
        }

        private void SearchBillByYear()
        {
            if (!CheckItem())
                return;
            dgvReportBill.Rows.Clear();
            billEntity = new BillEntity();
            LogHistories.InsertLogHistories("Tìm báo cáo nhập kho theo năm từ: " + dtpFormDate.Text + " đến ngày " + dtpToDate.Text + " ", DateTime.Now, userFunctionList.UserName, "Tìm kiếm");

            if (cboStaff.SelectedValue != null)
                billEntity.StaffId = int.Parse(cboStaff.SelectedValue.ToString());

            billEntity.Status = 0;
            double totalMonth = dtpToDate.Value.Year - dtpFormDate.Value.Year;
            double totalday = Math.Round((dtpToDate.Value - dtpFormDate.Value).TotalDays, 0);
            int index = 0;
            double TotalMoney = 0;
            int billTotal = 0;

            for (int i = 0; i <= totalMonth; i++)
            {
                billEntity.ToYear = dtpFormDate.Value.AddYears(i).Year;
                billEntity.FromYear = dtpFormDate.Value.AddYears(i).Year;

                importBillReportDataTable = new ImportBillDataSet.ImportBillReportDataTable();
                importBillController.SearchImportBillByBillEntity(importBillReportDataTable, billEntity);
                if (importBillReportDataTable.First().CountBill == 0)
                    continue;

                dgvReportBill.AllowUserToAddRows = true;
                dgvReportBill.Rows.Add();
                DataGridViewRow row = dgvReportBill.Rows[index];
                row.Cells["STT"].Value = index + 1;
                row.Cells["BillDate"].Value = "Hoá đơn nhập hàng theo năm: " + dtpFormDate.Value.AddYears(i).Year;
                row.Cells["BillTotal"].Value = importBillReportDataTable.First().IsCountBillNull() ? 0 : importBillReportDataTable.First().CountBill;
                row.Cells["MoneyTotal"].Value = importBillReportDataTable.First().IsTotalMoneyNull() ? "0" : importBillReportDataTable.First().TotalMoney.ToString("###,#0");
                TotalMoney += importBillReportDataTable.First().IsTotalMoneyNull() ? 0 : importBillReportDataTable.First().TotalMoney;
                billTotal += importBillReportDataTable.First().CountBill;
                index++;
            }
            dgvReportBill.AllowUserToAddRows = false;
            txtBillTotal.Value = billTotal;
            txtTotalMoney.Value = TotalMoney;
        }

        private void btnSearchReport_Click(object sender, EventArgs e)
        {
            dgvReportBill.Rows.Clear();
            txtTotalMoney.Value = 0;
            txtBillTotal.Value = 0;

            if (cboReportType.SelectedNode.Name.Equals(Constants.Day))
                SearchByDay();
            if (cboReportType.SelectedNode.Name.Equals(Constants.Month))
                SearchBillByMonth();
            if (cboReportType.SelectedNode.Name.Equals(Constants.Year))
                SearchBillByYear();
        }

        private void UserControlBillsManagement_Load(object sender, EventArgs e)
        {
            LoadAllStaff();
        }

        private void DeleteBillByBillId(int indexRow)
        {
            string billId = string.Empty;
            BillsDataSet.BillDataTable billDataTable = new BillsDataSet.BillDataTable();
            string ItemName = string.Empty;

            if (dgvReportBill.Rows[indexRow].Cells["BillId"].Value == null)
                return;

            billId = (string)dgvReportBill.Rows[indexRow].Cells["BillId"].Value;

            ItemName = dgvReportBill.Rows[indexRow].Cells["CustomerName"].Value.ToString();
            DialogResult rst = MessageBox.Show("Bạn có muốn xoá hoá đơn " + ItemName + " này không?", Constants.CaptionInformationMessage, MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (rst != DialogResult.Yes)
                return;

            //  billController.GetBillByBillId(billDataTable, billId);
            if (billDataTable.Rows.Count == 1)
                billDataTable.First().Delete();
            else
            {
                MessageBox.Show("Không tồn tại hoá đơn này, hoặc hoá đơn đã bị xoá!", Constants.CaptionErrorMessage, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                //  billController.UpdateBill(billDataTable);
                MessageBox.Show("Xoá thông tin thành công!", Constants.CaptionInformationMessage, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch
            {
                MessageBox.Show("Không thể xoá được: Hoá đơn đang được sử dụng!", Constants.CaptionErrorMessage, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            dgvReportBill.Rows.RemoveAt(indexRow);
        }

        private void dgvReportBill_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 7)
                DeleteBillByBillId(e.RowIndex);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            if (removedUserControler != null)
                removedUserControler(this.Name);
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
            excelEntity.Caption = "Báo cáo nhập kho theo" + cboReportType.Text;
            excelEntity.Title = "Báo cáo nhập kho theo " + cboReportType.Text;
            excelEntity.FromDate = lbFormDate.Text + ": " + dtpFormDate.Text;
            excelEntity.ToDate = lbToDate.Text + ": " + dtpToDate.Text;
            excelEntity.SheetName = "BCTKT";

            if (backgroundWorkerExportExcel == null)
            {
                backgroundWorkerExportExcel = new BackgroundWorker();
                backgroundWorkerExportExcel.DoWork += new DoWorkEventHandler(backgroundWorkerExportExcel_DoWork);
                backgroundWorkerExportExcel.RunWorkerCompleted += new RunWorkerCompletedEventHandler(backgroundWorkerExportExcel_RunWorkerCompleted);
            }

            processingEntity.Completed = false;
            backgroundWorkerExportExcel.RunWorkerAsync();

            Processing processing = new Processing(processingEntity);
            processing.ShowDialog();

            if (IsExportSuccess)
            {
                LogHistories.InsertLogHistories("Xuất file báo cáo nhập kho theo: " + cboReportType.Text, DateTime.Now, userFunctionList.UserName, "Thành công");
                MessageBox.Show("Xuất thông tin thành công!", Constants.CaptionInformationMessage, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                LogHistories.InsertLogHistories("Xuất file báo cáo nhập kho theo: " + cboReportType.Text, DateTime.Now, userFunctionList.UserName, "Lỗi");
                MessageBox.Show("Lỗi: Xuất thông tin không thành công!", Constants.CaptionErrorMessage, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void backgroundWorkerExportExcel_DoWork(object sender, DoWorkEventArgs e)
        {
          IsExportSuccess=  ExcelExportController.ExportImportBill(dgvReportBill, excelEntity);
        }

        private void backgroundWorkerExportExcel_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            processingEntity.Completed = true;
            backgroundWorkerExportExcel.Dispose();
            backgroundWorkerExportExcel = null;
            GC.Collect();
        }
    }
}

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
    public partial class UserControlBillSales : UserControl
    {
        public delegate void RemovedUserControler(string controler);
        public event RemovedUserControler removedUserControler;

        private BillController billController = new BillController();
        private BillsDataSet.ReportBillDataTable reportBillDataTable = null;
        private BillEntity billEntity = null;
        private StaffController staffController = new StaffController();
        private StaffDataSet.StaffsDataTable staffsDataTable = null;
        private UserFunctionList userFunctionList;

        private ExcelExportEntity excelEntity = null;
        private ProcessingEntity processingEntity = null;
        private bool IsExportSuccess;

        public UserControlBillSales(string billType, UserFunctionList userFunctionList)
        {
            InitializeComponent();
            LoadDateTimeType(billType);
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


        public UserControlBillSales()
        {
            InitializeComponent();
            dtpFormDate.Value = dtpFormDate.Value.AddDays(-1);
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
            cboStaff.DisplayMembers = staffsDataTable.FullNameColumn.ColumnName;

        }

        private void UserControlReportBill_Load(object sender, EventArgs e)
        {
            LoadAllStaff();
            dtpToDate.Value = DateTime.Now;
        }

        private void btnSearchReport_Click(object sender, EventArgs e)
        {
            if (cboReportType.SelectedNode == null)
                return;
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

        private void SearchByDay()
        {
            if (!CheckItem())
                return;
            dgvReportBill.Rows.Clear();
            billEntity = new BillEntity();
            LogHistories.InsertLogHistories("Tìm kiếm báo cáo bán hàng theo ngày ", DateTime.Now, userFunctionList.UserName, "Tìm kiếm");
            if (cboStaff.SelectedValue != null)
                billEntity.StaffId = int.Parse(cboStaff.SelectedValue.ToString());
            billEntity.Status = 0;
            double totalday = Math.Round((dtpToDate.Value - dtpFormDate.Value).TotalDays, 0);

            int index = 0;
            double TotalMoney = 0;
            int billTotal = 0;

            for (int i = 0; i <= totalday; i++)
            {
                billEntity.FromDate = dtpFormDate.Value.AddDays(i).ToString("yyyy-MM-dd 00:00:01");
                billEntity.ToDate = dtpFormDate.Value.AddDays(i).ToString("yyyy-MM-dd 23:59:59");

                reportBillDataTable = new BillsDataSet.ReportBillDataTable();
                billController.SearchBillByBillEntity(reportBillDataTable, billEntity);

                if (reportBillDataTable.First().CountBill == 0)
                    continue;

                dgvReportBill.AllowUserToAddRows = true;
                dgvReportBill.Rows.Add();
                DataGridViewRow row = dgvReportBill.Rows[index];
                row.Cells["STT"].Value = index + 1;
                row.Cells["BillDate"].Value = "Hoá đơn bán hàng theo ngày: " + dtpFormDate.Value.AddDays(i).ToString("dd/MM/yyyy");
                row.Cells["BillTotal"].Value = reportBillDataTable.First().IsCountBillNull() ? 0 : reportBillDataTable.First().CountBill;
                row.Cells["MoneyTotal"].Value = reportBillDataTable.First().IsTotalMoneyNull() ? "0" : reportBillDataTable.First().TotalMoney.ToString("###,#0");
                TotalMoney += reportBillDataTable.First().IsTotalMoneyNull() ? 0 : reportBillDataTable.First().TotalMoney;
                billTotal += reportBillDataTable.First().CountBill;
                index++;
            }
            dgvReportBill.AllowUserToAddRows = false;
            txtBillTotal.Value = billTotal;
            txtTotalMoney.Value = TotalMoney;
        }
        public DateTime GoToEndOfMonth(DateTime date)
        {
            if (date.Month == 12)
            {
                // nếu là tháng 12 thì trả về ngày 31  
                return new DateTime(date.Year, date.Month, 31);
            }
            // chuyển tới ngày đầu tiên của tháng kế tiếp  
            DateTime tem = new DateTime(date.Year, date.Month + 1, 1);
            // lùi lại 1 ngày là về ngày cuối tháng của tháng hiện tại rồi.  
            return tem.AddDays(-1);
        }
        private void SearchBillByMonth()
        {
            if (!CheckItem())
                return;
            reportBillDataTable = new BillsDataSet.ReportBillDataTable();
            dgvReportBill.Rows.Clear();
            billEntity = new BillEntity();
            LogHistories.InsertLogHistories("Tìm kiếm báo cáo bán hàng theo tháng ", DateTime.Now, userFunctionList.UserName, "Tìm kiếm");

            if (cboStaff.SelectedValue != null)
                billEntity.StaffId = int.Parse(cboStaff.SelectedValue.ToString());

            billEntity.Status = 0;
            double totalMonth = Math.Round((dtpToDate.Value - dtpFormDate.Value).TotalDays / 30, 0);
            double totalday = Math.Round((dtpToDate.Value - dtpFormDate.Value).TotalDays, 0);
            int index = 0;
            double TotalMoney = 0;
            int billTotal = 0;
            int firtDay;
            int lastDay;
            string fromDate = string.Empty;
            string toDate = string.Empty;

            for (int i = 0; i <= totalMonth; i++)
            {
                billEntity.FromMonth = dtpFormDate.Value.AddMonths(i).Month;
                billEntity.FromYear = dtpFormDate.Value.AddMonths(i).Year;

                billEntity.ToMonth = dtpFormDate.Value.AddMonths(i).Month;
                billEntity.ToYear = dtpFormDate.Value.AddMonths(i).Year;

                firtDay = 1;
                lastDay = Utilities.GetLastDayOfMonth(dtpFormDate.Value.AddMonths(i));
                fromDate = firtDay.ToString("0#") + "/" + dtpFormDate.Value.AddMonths(i).ToString("MM/yyyy");
                toDate = lastDay + "/" + dtpFormDate.Value.AddMonths(i).ToString("MM/yyyy");

                reportBillDataTable = new BillsDataSet.ReportBillDataTable();
                billController.SearchBillByBillEntity(reportBillDataTable, billEntity);

                if (reportBillDataTable.First().CountBill == 0)
                    continue;

                dgvReportBill.AllowUserToAddRows = true;
                dgvReportBill.Rows.Add();
                DataGridViewRow row = dgvReportBill.Rows[index];
                row.Cells["STT"].Value = index + 1;
                row.Cells["BillDate"].Value = "Hoá đơn bán hàng theo tháng tính từ: " + fromDate + " đến " + toDate;
                row.Cells["BillTotal"].Value = reportBillDataTable.First().IsCountBillNull() ? 0 : reportBillDataTable.First().CountBill;
                row.Cells["MoneyTotal"].Value = reportBillDataTable.First().IsTotalMoneyNull() ? "0" : reportBillDataTable.First().TotalMoney.ToString("###,#0");
                TotalMoney += reportBillDataTable.First().IsTotalMoneyNull() ? 0 : reportBillDataTable.First().TotalMoney;
                billTotal += reportBillDataTable.First().CountBill;
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
            LogHistories.InsertLogHistories("Tìm kiếm báo cáo bán hàng theo năm ", DateTime.Now, userFunctionList.UserName, "Tìm kiếm");

            if (cboStaff.SelectedValue != null)
                billEntity.StaffId = int.Parse(cboStaff.SelectedValue.ToString());

            billEntity.Status = 0;
            double totalYears = 0;
          //  double totalday = 0;

            totalYears = dtpToDate.Value.Year - dtpFormDate.Value.Year;
          //  totalday = Math.Round((dtpToDate.Value - dtpFormDate.Value).TotalDays, 0);

            int index = 0;
            double TotalMoney = 0;
            int billTotal = 0;

            for (int i = 0; i <= totalYears; i++)
            {
                billEntity.ToYear = dtpFormDate.Value.AddYears(i).Year;
                billEntity.FromYear = dtpFormDate.Value.AddYears(i).Year;

                reportBillDataTable = new BillsDataSet.ReportBillDataTable();
                billController.SearchBillByBillEntity(reportBillDataTable, billEntity);

                if (reportBillDataTable.First().CountBill == 0)
                    continue;

                dgvReportBill.AllowUserToAddRows = true;
                dgvReportBill.Rows.Add();
                DataGridViewRow row = dgvReportBill.Rows[index];
                row.Cells["STT"].Value = index + 1;
                row.Cells["BillDate"].Value = "Hoá đơn bán hàng theo năm: " + dtpFormDate.Value.AddYears(i).Year;
                row.Cells["BillTotal"].Value = reportBillDataTable.First().IsCountBillNull() ? 0 : reportBillDataTable.First().CountBill;
                row.Cells["MoneyTotal"].Value = reportBillDataTable.First().IsTotalMoneyNull() ? "0" : reportBillDataTable.First().TotalMoney.ToString("###,#0");
                TotalMoney += reportBillDataTable.First().IsTotalMoneyNull() ? 0 : reportBillDataTable.First().TotalMoney;
                billTotal += reportBillDataTable.First().CountBill;
                index++;
            }
            dgvReportBill.AllowUserToAddRows = false;
            txtBillTotal.Value = billTotal;
            txtTotalMoney.Value = TotalMoney;
        }

        private bool CheckItem()
        {

            if (dtpToDate.Checked && dtpFormDate.Checked && dtpFormDate.Value > dtpToDate.Value)
            {
                MessageBox.Show("Từ ngày không được lớn hơn tới ngày", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
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
            excelEntity.Caption = "Báo cáo bán hàng theo" + cboReportType.Text;
            excelEntity.Title = "Báo cáo bán hàng theo " + cboReportType.Text;
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
                LogHistories.InsertLogHistories("Xuất file báo cáo theo " + cboReportType.Text, DateTime.Now, userFunctionList.UserName, "Thành công");
                MessageBox.Show("Xuất thông tin thành công!", Constants.CaptionInformationMessage, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                LogHistories.InsertLogHistories("Xuất file báo cáo theo " + cboReportType.Text, DateTime.Now, userFunctionList.UserName, "Lỗi");
                MessageBox.Show("Lỗi: Xuất thông tin không thành công!", Constants.CaptionErrorMessage, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            if (removedUserControler != null)
                removedUserControler(this.Name);
        }

        private void backgroundWorkerExportExcel_DoWork(object sender, DoWorkEventArgs e)
        {
           IsExportSuccess= ExcelExportController.ExportBillSale(dgvReportBill, excelEntity);
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

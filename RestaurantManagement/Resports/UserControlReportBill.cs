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

namespace RestaurantManagement
{
    public partial class UserControlReportBill : UserControl
    {
        public delegate void RemovedUserControler(string controler);
        public event RemovedUserControler removedUserControler;

        private BillController billController = new BillController();
        private BillsDataSet.ReportBillDataTable reportBillDataTable = null;
        private BillEntity billEntity = null;
        private StaffController staffController = new StaffController();
        private StaffDataSet.StaffsDataTable staffsDataTable = null;

        public UserControlReportBill(int selectNode)
        {
            InitializeComponent();

            cboReportType.SelectedIndex = selectNode;
        }


        public UserControlReportBill()
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

        private void UserControlReportBill_Load(object sender, EventArgs e)
        {
            LoadAllStaff();
            dtpToDate.Value = DateTime.Now;
        }

        private void btnSearchReport_Click(object sender, EventArgs e)
        {
            if (cboReportType.SelectedNode == null)
                return;

            if (cboReportType.SelectedNode.Name.Equals("nodeReportDay"))
                SearchByDay();
            if (cboReportType.SelectedNode.Name.Equals("nodeReportMonth"))
                SearchBillByMonth();
            if (cboReportType.SelectedNode.Name.Equals("nodeReportYear"))
                SearchBillByYear();
        }

        private void SearchByDay()
        {
            if (!CheckItem())
                return;
            dgvReportBill.Rows.Clear();
            billEntity = new BillEntity();
            if (cboStaff.SelectedValue != null)
                billEntity.StaffId = int.Parse(cboStaff.SelectedValue.ToString());
            billEntity.Status = 0;
            double totalday = Math.Round((dtpToDate.Value - dtpFormDate.Value).TotalDays, 0);

            int index = 0;
            double TotalMoney = 0;
            int billTotal = 0;

            for (int i = 0; i <= totalday; i++)
            {
                billEntity.ToDate = dtpFormDate.Value.AddDays(i).ToString("dd/MM/yyyy");
                billEntity.FromDate = dtpFormDate.Value.AddDays(i).ToString("dd/MM/yyyy");

                reportBillDataTable = new BillsDataSet.ReportBillDataTable();
                billController.SearchBillByBillEntity(reportBillDataTable, billEntity);

                dgvReportBill.AllowUserToAddRows = true;
                dgvReportBill.Rows.Add();
                DataGridViewRow row = dgvReportBill.Rows[index];
                row.Cells["STT"].Value = index + 1;
                row.Cells["BillDate"].Value = "Hoá đơn ngày: " + dtpFormDate.Value.AddDays(i).ToString("dd/MM/yyyy");
                row.Cells["BillTotal"].Value = reportBillDataTable.First().IsCountBillNull() ? 0 : reportBillDataTable.First().CountBill;
                row.Cells["MoneyTotal"].Value = reportBillDataTable.First().IsTotalMoneyNull() ? "0" : reportBillDataTable.First().TotalMoney.ToString("###,#0");
                TotalMoney += reportBillDataTable.First().IsTotalMoneyNull() ? 0 : reportBillDataTable.First().TotalMoney;
                billTotal += reportBillDataTable.First().CountBill;
                index++;
            }

            if (reportBillDataTable.Rows.Count == 0)
            {
                return;
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
            dgvReportBill.Rows.Clear();
            billEntity = new BillEntity();

            if (cboStaff.SelectedValue != null)
                billEntity.StaffId = int.Parse(cboStaff.SelectedValue.ToString());

            billEntity.Status = 0;
            double totalMonth = Math.Round((dtpToDate.Value - dtpFormDate.Value).TotalDays / 30, 0);
            double totalday = Math.Round((dtpToDate.Value - dtpFormDate.Value).TotalDays, 0);
            int index = 0;
            double TotalMoney = 0;
            int billTotal = 0;

            for (int i = 0; i <= totalMonth; i++)
            {

                billEntity.FromMonth = dtpFormDate.Value.AddMonths(i).Month;
                billEntity.FromYear = dtpFormDate.Value.AddMonths(i).Year;

                billEntity.ToMonth = dtpFormDate.Value.AddMonths(i).Month;
                billEntity.ToYear = dtpFormDate.Value.AddMonths(i).Year;

                reportBillDataTable = new BillsDataSet.ReportBillDataTable();
                billController.SearchBillByBillEntity(reportBillDataTable, billEntity);

                dgvReportBill.AllowUserToAddRows = true;
                dgvReportBill.Rows.Add();
                DataGridViewRow row = dgvReportBill.Rows[index];
                row.Cells["STT"].Value = index + 1;
                row.Cells["BillDate"].Value = "Hoá đơn tháng: " + dtpFormDate.Value.AddMonths(i).ToString("dd/MM/yyyy") + " đến " + dtpFormDate.Value.AddMonths(i + 1).ToString("dd/MM/yyyy");
                row.Cells["BillTotal"].Value = reportBillDataTable.First().IsCountBillNull() ? 0 : reportBillDataTable.First().CountBill;
                row.Cells["MoneyTotal"].Value = reportBillDataTable.First().IsTotalMoneyNull() ? "0" : reportBillDataTable.First().TotalMoney.ToString("###,#0");
                TotalMoney += reportBillDataTable.First().IsTotalMoneyNull() ? 0 : reportBillDataTable.First().TotalMoney;
                billTotal += reportBillDataTable.First().CountBill;
                index++;
            }

            if (reportBillDataTable.Rows.Count == 0)
            {
                return;
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

                reportBillDataTable = new BillsDataSet.ReportBillDataTable();
                billController.SearchBillByBillEntity(reportBillDataTable, billEntity);

                dgvReportBill.AllowUserToAddRows = true;
                dgvReportBill.Rows.Add();
                DataGridViewRow row = dgvReportBill.Rows[index];
                row.Cells["STT"].Value = index + 1;
                row.Cells["BillDate"].Value = "Hoá đơn năm: " + dtpFormDate.Value.AddYears(i).Year;
                row.Cells["BillTotal"].Value = reportBillDataTable.First().IsCountBillNull() ? 0 : reportBillDataTable.First().CountBill;
                row.Cells["MoneyTotal"].Value = reportBillDataTable.First().IsTotalMoneyNull() ? "0" : reportBillDataTable.First().TotalMoney.ToString("###,#0");
                TotalMoney += reportBillDataTable.First().IsTotalMoneyNull() ? 0 : reportBillDataTable.First().TotalMoney;
                billTotal += reportBillDataTable.First().CountBill;
                index++;
            }

            if (reportBillDataTable.Rows.Count == 0)
            {
                return;
            }

            dgvReportBill.AllowUserToAddRows = false;
            txtBillTotal.Value = billTotal;
            txtTotalMoney.Value = TotalMoney;
        }

        private bool CheckItem()
        {
            if (dtpFormDate.Value > dtpToDate.Value)
            {
                MessageBox.Show("Từ ngày không được lớn hơn tới ngày", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        private void btnExportToExcel_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Chức năng này đang được xây dựng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            if (removedUserControler != null)
                removedUserControler(this.Name);
        }
    }
}

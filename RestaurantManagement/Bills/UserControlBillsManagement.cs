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
    public partial class UserControlBillsManagement : UserControl
    {
        private BillController billController = new BillController();
        private BillsDataSet.SearchBillDataTable searchBillDataTable = null;
        private StaffController staffController = new StaffController();
        private StaffDataSet.StaffsDataTable staffsDataTable = null;

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

        private void SearchByDay()
        {
            BillEntity billEntity = new BillEntity();
            billEntity.FromDate = dtpFormDate.Text;
            billEntity.ToDate = dtpToDate.Text;
            billEntity.Status = 0;
            billEntity.StaffId = cboStaff.SelectedValue == null ? 0 : int.Parse(cboStaff.SelectedValue.ToString());
            searchBillDataTable = new BillsDataSet.SearchBillDataTable();
            billController.SearchBillByBillEntity(searchBillDataTable, billEntity);
            dgvReportBill.Rows.Clear();
            int index = 0;
            double moneyTotal = 0;
            dgvReportBill.AllowUserToAddRows = true;
            foreach (BillsDataSet.SearchBillRow item in searchBillDataTable.Rows)
            {
                dgvReportBill.Rows.Add();
                DataGridViewRow row = dgvReportBill.Rows[index];
                row.Cells["STT"].Value = index + 1;
                row.Cells["BillCode"].Value = item.IsBillCodeNull() ? string.Empty : item.BillCode;
                row.Cells["ShiftName"].Value = item.ShiftName;
                row.Cells["BillDate"].Value = dtpFormDate.Value.AddDays(index).ToString("dd/MM/yyyy");
                row.Cells["CustomerName"].Value = item.IsCustomerNameNull() ? string.Empty : item.CustomerName;
                row.Cells["StaffName"].Value = item.UserName;
                row.Cells["MoneyTotal"].Value = item.TotalCost;
                row.Cells["BillId"].Value = item.BillId;
                row.Cells["Delete"].Value = "Xoá";
                moneyTotal += item.TotalCost;
                index++;
            }
            dgvReportBill.AllowUserToAddRows = false;
            txtTotalMoney.Value = moneyTotal;
            txtBillTotal.Text = index.ToString();
        }

        private void btnSearchReport_Click(object sender, EventArgs e)
        {
            if (cboReportType.SelectedNode.Name.Equals("Sale"))
                SearchByDay();
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

            billController.GetBillByBillId(billDataTable, billId);
            if (billDataTable.Rows.Count == 1)
                billDataTable.First().Delete();
            else 
            {
                MessageBox.Show("Không tồn tại hoá đơn này, hoặc hoá đơn đã bị xoá!", Constants.CaptionErrorMessage, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                billController.UpdateBill(billDataTable);
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
    }
}

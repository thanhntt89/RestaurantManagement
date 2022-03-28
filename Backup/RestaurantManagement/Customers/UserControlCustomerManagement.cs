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
    public partial class UserControlCustomerManagement : UserControl
    {
        private CustomerController customerController = new CustomerController();
        private CustomerDataSet.CustomersDataTable customersDataTable = null;
        private UserFunctionList userFunctionList;
        public UserControlCustomerManagement(UserFunctionList userFunctionList)
        {
            InitializeComponent();
            this.userFunctionList = userFunctionList;
            CheckRole();
        }

        private void CheckRole()
        {
            btnAddNewCustomer.Enabled = false;
            btnDeleteCustomer.Enabled = false;
            btnEditCustomer.Enabled = false;

            if (userFunctionList.Customers[0].Add == 1)
            {
                btnAddNewCustomer.Enabled = true;
            }
            if (userFunctionList.Customers[0].Edit == 1)
            {
                btnEditCustomer.Enabled = true;
            }
            if (userFunctionList.Customers[0].Delete == 1)
            {
                btnDeleteCustomer.Enabled = true;
            }
        }

        private void btnAddNewCustomer_Click(object sender, EventArgs e)
        {
            RegisterCustomer RegisterCustomer = new RegisterCustomer();
            RegisterCustomer.reLoadData += new RegisterCustomer.ReLoadData(LoadInitilize);
            RegisterCustomer.ShowDialog();
        }

        private void btnEditCustomer_Click(object sender, EventArgs e)
        {
            UpdateCustomer();
        }

        private void UpdateCustomer()
        {
            if (dgvCustomerList.CurrentRow.Index == -1)
                return;
            int customerId = int.Parse(dgvCustomerList.CurrentRow.Cells["CustomerId"].Value.ToString());
            UpdateCustomer UpdateCustomer = new UpdateCustomer(customerId,userFunctionList);
            UpdateCustomer.reLoadData += new UpdateCustomer.ReLoadData(LoadInitilize);
            UpdateCustomer.ShowDialog();
        }

        private void LoadAllCustomer()
        {
            customersDataTable = new CustomerDataSet.CustomersDataTable();
            customerController.GetAllCustomer(customersDataTable);
        }

        private void SearchCustomer()
        {
            dgvCustomerList.Rows.Clear();
            LogHistories.InsertLogHistories("Tìm kiếm thông tin khách hàng ", DateTime.Now, userFunctionList.UserName, "Thành công");

            if (customersDataTable.Rows.Count == 0)
                return;

            var querry = from row in customersDataTable
                         select row;
            if (!string.IsNullOrEmpty(txtCustomerCode.Text))
            {
                querry = querry.Where(r => r.CustomerCode.IndexOf(txtCustomerCode.Text, StringComparison.OrdinalIgnoreCase) >= 0);
            }
            if (!string.IsNullOrEmpty(txtCustomerName.Text))
            {
                querry = querry.Where(r => r.CustomerName.IndexOf(txtCustomerName.Text, StringComparison.OrdinalIgnoreCase) >= 0);
            }
            if (!string.IsNullOrEmpty(txtMobile.Text))
            {
                querry = querry.Where(r => r.CustomerMobile.IndexOf(txtMobile.Text, StringComparison.OrdinalIgnoreCase) >= 0);
            }
            if (!string.IsNullOrEmpty(txtTaxes.Text))
            {
                querry = querry.Where(r => r.CustomerTaxeCode.IndexOf(txtTaxes.Text, StringComparison.OrdinalIgnoreCase) >= 0);
            }
            int index = 0;
            dgvCustomerList.AllowUserToAddRows = true;
            foreach (var item in querry)
            {
                dgvCustomerList.Rows.Add();
                DataGridViewRow row = dgvCustomerList.Rows[index];

                row.Cells["STT"].Value = index + 1;
                row.Cells["CustomerCode"].Value = item.Field<string>("CustomerCode");
                row.Cells["CustomerName"].Value = item.Field<string>("CustomerName");
                row.Cells["CustomerAddress"].Value = item.Field<string>("CustomerAddress");
                row.Cells["CustomerMobile"].Value = item.Field<string>("CustomerMobile");
                row.Cells["CustomerTaxeCode"].Value = item.Field<string>("CustomerTaxeCode");
                row.Cells["CustomerEmail"].Value = item.Field<string>("CustomerEmail");
                row.Cells["CustomerNote"].Value = item.Field<string>("CustomerNote");
                row.Cells["CustomerId"].Value = item.CustomerId;
                index++;
            }
            dgvCustomerList.AllowUserToAddRows = false;
        }

        private void UserControlCustomerManagement_Load(object sender, EventArgs e)
        {
            LoadInitilize();
        }

        private void LoadInitilize()
        {
            LoadAllCustomer();
            SearchCustomer();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            LoadInitilize();
        }

        private void dgvCustomerList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (userFunctionList.Customers[0].Edit == 1)
                UpdateCustomer();
        }

        private void btnDeleteCustomer_Click(object sender, EventArgs e)
        {
            DeleteCustomer();
        }

        private void DeleteCustomer()
        {
            int rowIndex = -1;
            int customerId = 0;
            customersDataTable = new CustomerDataSet.CustomersDataTable();
            string customerName = string.Empty;

            if (dgvCustomerList.CurrentRow.Cells["CustomerId"].Value == null)
                return;
            rowIndex = dgvCustomerList.CurrentRow.Index;

            customerId = int.Parse(dgvCustomerList.Rows[rowIndex].Cells["CustomerId"].Value.ToString());

            customerName = dgvCustomerList.Rows[rowIndex].Cells["CustomerName"].Value.ToString();
            DialogResult rst = MessageBox.Show("Bạn có muốn xoá khách hàng " + customerName + " này không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (rst != DialogResult.Yes)
                return;

            customerController.GetCustomerByCustomerId(customersDataTable, customerId);
            customersDataTable.First().Delete();
            try
            {
                customerController.UpdateCustomer(customersDataTable);
                LogHistories.InsertLogHistories("Xóa thông tin khách hàng " + customerName, DateTime.Now, userFunctionList.UserName, "Thành công");
                MessageBox.Show("Xoá thông tin thành công!", Constants.CaptionInformationMessage, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch
            {
                LogHistories.InsertLogHistories("Xóa thông tin khách hàng " + customerName, DateTime.Now, userFunctionList.UserName, "Lỗi");
                MessageBox.Show("Không thể xoá được: Khách hàng đang được sử dụng trong hoá đơn.!", Constants.CaptionErrorMessage, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            dgvCustomerList.Rows.RemoveAt(rowIndex);
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Enter)
                btnSearch_Click(null, null);
            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using RestaurantController;
using RestaurantDTO;
using RestaurantCommon;

namespace RestaurantManagement
{
    public partial class CustomerSearchForBill : DevComponents.DotNetBar.Metro.MetroForm
    {
        public delegate void GetCustomerInfor(int customerId);
        public event GetCustomerInfor getCustomerInfor;

        private CustomerController customerController = new CustomerController();
        private CustomerDataSet.CustomersDataTable customersDataTable = null;

        private UserFunctionList userFunctionList;

        public CustomerSearchForBill(UserFunctionList userFunctionList)
        {
            InitializeComponent();
            this.userFunctionList = userFunctionList;
        }

        private void CustomerSearchForBill_Load(object sender, EventArgs e)
        {
            LoadInitilize();
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
            UpdateCustomer();
        }

        private void dgvCustomerList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 9)
            {
                GetCusTomerInfor(e.RowIndex);
            }
        }

        public void GetCusTomerInfor(int indexRow)
        {
            if(indexRow==-1)
                return;
            int customerId = int.Parse(dgvCustomerList.Rows[indexRow].Cells["CustomerId"].Value.ToString());
            if (getCustomerInfor != null)
                getCustomerInfor(customerId);
            this.Close();
        }

        private void dgvCustomerList_CellDoubleClick_1(object sender, DataGridViewCellEventArgs e)
        {
            GetCusTomerInfor(e.RowIndex);
        }
    }
}

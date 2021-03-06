using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using RestaurantController;
using RestaurantDTO;
using RestaurantCommon;

namespace RestaurantManagement
{
    public partial class RegisterCustomer : DevComponents.DotNetBar.Metro.MetroForm
    {
        public delegate void ReLoadData();
        public event ReLoadData reLoadData;

        private CustomerController customerController = new CustomerController();
        private CustomerDataSet.CustomersDataTable customersDataTable = null;

        public RegisterCustomer()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnRegisterCustomer_Click(object sender, EventArgs e)
        {
            SaveCustomer();
        }

        private bool CheckItem()
        {
            if (!Utilities.CheckNullOrMinMaxLength("Tên khách hàng", txtCustomerName.Text, 0, 200))
            {
                txtCustomerName.Focus();
                return false;
            }
            if (!Utilities.CheckNullOrMinMaxLength("Mã khách hàng", txtCustormerCode.Text,0, 20))
            {
                txtCustormerCode.Focus();
                return false;
            }
            if (!Utilities.CheckMaxLength("Địa chỉ", txtCustomerAddress.Text, 100))
            {
                txtCustomerAddress.Focus();
                return false;
            }
            if (!Utilities.CheckMaxLength("Email", txtCustomerEmail.Text, 100))
            {
                txtCustomerEmail.Focus();
                return false;
            }
            if (!Utilities.CheckMaxLength("Điện thoại", txtCustomerMobile.Text, 15))
            {
                txtCustomerMobile.Focus();
                return false;
            }
            if (!Utilities.CheckMaxLength("Mã số thuế", txtCustomerTaxes.Text, 20))
            {
                txtCustomerTaxes.Focus();
                return false;
            }
            if (!Utilities.CheckMaxLength("Ghi chú", txtNote.Text, 200))
            {
                txtNote.Focus();
                return false;
            }
            return true;
        }

        private void SaveCustomer()
        {
            if (!CheckItem())
            {
                return;
            }
            customersDataTable = new CustomerDataSet.CustomersDataTable();
            customerController.GetCustomerByCustomerCode(customersDataTable, txtCustormerCode.Text);

            if (customersDataTable.Rows.Count > 0)
            {
                txtCustormerCode.Focus();
                MessageBox.Show("Mã khách hàng này đã tồn tại bạn phải nhập vào một mã khác", Constants.CaptionInformationMessage, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var newRow = customersDataTable.NewCustomersRow();
            newRow.CustomerTaxeCode = txtCustomerTaxes.Text;
            newRow.CustomerNote = txtNote.Text;
            newRow.CustomerName = txtCustomerName.Text;
            newRow.CustomerMobile = txtCustomerMobile.Text;
            newRow.CustomerCode = txtCustormerCode.Text;
            newRow.CustomerAddress = txtCustomerAddress.Text;
            newRow.CustomerEmail = txtCustomerEmail.Text;

            customersDataTable.AddCustomersRow(newRow);

            try
            {
                customerController.UpdateCustomer(customersDataTable);
                MessageBox.Show("Thêm thông tin khách hàng thành công", Constants.CaptionInformationMessage, MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (reLoadData != null)
                    reLoadData();
            }
            catch
            {
                MessageBox.Show("Lỗi thêm thông tin khách hàng thành không công", Constants.CaptionErrorMessage, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            Clean();
        }

        private void Clean()
        {
            txtCustormerCode.Focus();
            txtCustomerEmail.Text = string.Empty;
            txtCustomerAddress.Text = string.Empty;
            txtCustomerMobile.Text = string.Empty;
            txtCustomerName.Text = string.Empty;
            txtCustomerTaxes.Text = string.Empty;
            txtCustormerCode.Text = string.Empty;
            txtNote.Text = string.Empty;
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Enter)
                SaveCustomer();
            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
}
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
using System.Linq;
using RestaurantCommon;

namespace RestaurantManagement
{
    public partial class UpdateCustomer : DevComponents.DotNetBar.Metro.MetroForm
    {
        public delegate void ReLoadData();
        public event ReLoadData reLoadData;

        private CustomerController customerController = new CustomerController();
        private CustomerDataSet.CustomersDataTable customersDataTable = null;

        private int customerId = -1;
        private UserFunctionList userFunctionList;

        public UpdateCustomer(int customerId, UserFunctionList userFunctionList)
        {
            InitializeComponent();
            this.customerId = customerId;
            this.userFunctionList = userFunctionList;
        }

        public UpdateCustomer()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void LoadUpdate()
        {
            customersDataTable = new CustomerDataSet.CustomersDataTable();
            customerController.GetCustomerByCustomerId(customersDataTable, customerId);

            if (customersDataTable.Rows.Count <= 0)
            {
                MessageBox.Show("Mã khách hàng này không còn tồn tại trong cơ sở dữ liệu", Constants.CaptionInformationMessage, MessageBoxButtons.OK, MessageBoxIcon.Error);
                if (reLoadData != null)
                    reLoadData();
                return;
            }
            txtCustomerTaxes.Text = customersDataTable.First().CustomerTaxeCode;
            txtNote.Text = customersDataTable.First().CustomerNote;
            txtCustomerName.Text = customersDataTable.First().CustomerName;
            txtCustomerMobile.Text = customersDataTable.First().CustomerMobile;
            txtCustormerCode.Text = customersDataTable.First().CustomerCode;
            txtCustomerAddress.Text = customersDataTable.First().CustomerAddress;
            txtCustomerEmail.Text = customersDataTable.First().CustomerEmail;
        }

        private void SaveCustomer()
        {
            if (!CheckItem())
            {
                return;
            }
            //customersDataTable.First().CustomerTaxeCode = txtCustomerTaxes.Text;
            customersDataTable.First().CustomerNote = txtNote.Text;
            customersDataTable.First().CustomerName = txtCustomerName.Text;
            customersDataTable.First().CustomerMobile = txtCustomerMobile.Text;
            customersDataTable.First().CustomerCode = txtCustormerCode.Text;
            customersDataTable.First().CustomerAddress = txtCustomerAddress.Text;
            customersDataTable.First().CustomerEmail = txtCustomerEmail.Text;

            try
            {
                customerController.UpdateCustomer(customersDataTable);
                LogHistories.InsertLogHistories("Cập nhật thông tin khách hàng " + txtCustomerName.Text, DateTime.Now, userFunctionList.UserName, "Thành công");
                MessageBox.Show("Cập nhật thông tin khách hàng thành công", Constants.CaptionInformationMessage, MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (reLoadData != null)
                    reLoadData();
            }
            catch
            {
                LogHistories.InsertLogHistories("Cập nhật thông tin khách hàng " + txtCustomerName.Text, DateTime.Now, userFunctionList.UserName, "Lỗi");
                MessageBox.Show("Lỗi: Cập nhật thông tin khách hàng thành không công", Constants.CaptionErrorMessage, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            this.Close();
        }

        private bool CheckItem()
        {
            if (!Utilities.CheckNullOrMinMaxLength("Tên khách hàng", txtCustomerName.Text, 0, 200))
            {
                txtCustomerName.Focus();
                return false;
            }
            if (!Utilities.CheckNullOrMinMaxLength("Mã khách hàng", txtCustormerCode.Text, 0, 20))
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

        private void UpdateCustomer_Load(object sender, EventArgs e)
        {
            LoadUpdate();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Enter)
                SaveCustomer();
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void btnRegisterCustomer_Click(object sender, EventArgs e)
        {
            SaveCustomer();
        }
    }
}
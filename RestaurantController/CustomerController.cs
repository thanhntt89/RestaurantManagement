using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RestaurantDTO;
using RestaurantDTO.CustomerDataSetTableAdapters;
namespace RestaurantController
{
    public class CustomerController
    {
        public void UpdateCustomer(CustomerDataSet.CustomersDataTable customerDataTable)
        {
            try
            {
                CustomersTableAdapter CustomersTableAdapter = new CustomersTableAdapter();
                CustomersTableAdapter.Update(customerDataTable);
            }
            catch
            {
                throw;
            }
        }

        public void GetCustomerByCustomerId(CustomerDataSet.CustomersDataTable customerDataTable, int customerId)
        {
            using (var CustomersTableAdapter = new CustomersTableAdapter())
            {
                CustomersTableAdapter.FillByCustomerId(customerDataTable, customerId);
            }
        }

        public void GetCustomerByCustomerCode(CustomerDataSet.CustomersDataTable customerDataTable, string customerCode)
        {
            using (var CustomersTableAdapter = new CustomersTableAdapter())
            {
                CustomersTableAdapter.FillByCustomerCode(customerDataTable, customerCode);
            }
        }

        public void GetAllCustomer(CustomerDataSet.CustomersDataTable customerDataTable)
        {
            using (var CustomersTableAdapter = new CustomersTableAdapter())
            {
                CustomersTableAdapter.FillByAll(customerDataTable);
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RestaurantDTO;
using RestaurantDTO.BillDetailDataSetTableAdapters;

namespace RestaurantController
{
    public class BillDetailController
    {
        public void UpdateBillDetail(BillDetailDataSet.BillDetailDataTable BillDetailDataTable)
        {
            try
            {
                BillDetailTableAdapter BillDetailTableAdapter = new BillDetailTableAdapter();
                BillDetailTableAdapter.Update(BillDetailDataTable);
            }
            catch
            {
                throw;
            }
        }

        public void GetBillDetailByBillId(BillDetailDataSet.BillDetailDataTable BillDetailDataTable, string billId)
        {
            using (var billDetailAdapter = new BillDetailTableAdapter())
            {
                billDetailAdapter.FillByBillId(BillDetailDataTable, billId);
            }
        }

        public void GetBillDetailByBillDetailId(BillDetailDataSet.BillDetailDataTable BillDetailDataTable, Int64 billDetailId)
        {
            using (var billDetailAdapter = new BillDetailTableAdapter())
            {
                billDetailAdapter.FillByBillDetailId(BillDetailDataTable, billDetailId);
            }
        }

        public void GetBillDetailAndMenuByBillId(BillDetailDataSet.BillDetailAndMenuDataTable billDetailAndMenuDataTable, string billId)
        {
            using (var billDetailAdapter = new BillDetailAndMenuTableAdapter())
            {
                billDetailAdapter.FillBillDetailByBillId(billDetailAndMenuDataTable, billId);
            }
        }
    }
}

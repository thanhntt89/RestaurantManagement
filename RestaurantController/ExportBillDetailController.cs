using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RestaurantDTO;
using RestaurantDTO.ExportBillDetailDataSetTableAdapters;

namespace RestaurantController
{
    public class ExportBillDetailController
    {
        public void UpdateExportBillDetail(ExportBillDetailDataSet.ExportBillDetailDataTable exportBillDetailDataTable)
        {
            try
            {
                var exportBillDetailTableAdapter = new ExportBillDetailTableAdapter();
                exportBillDetailTableAdapter.Update(exportBillDetailDataTable);

            }
            catch
            {
                throw;
            }
        }

        public void GetAllExportBillDetail(ExportBillDetailDataSet.ExportBillDetailDataTable exportBillDetailDataTable)
        {
            try 
            {
                var exportBillDetailTableAdapter = new ExportBillDetailTableAdapter();
                exportBillDetailTableAdapter.Fill(exportBillDetailDataTable);
            }
            catch
            {
                throw;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RestaurantDTO;
using RestaurantDTO.ExportBillsDataSetTableAdapters;

namespace RestaurantController
{
    public class ExportBillController
    {
        public void UpdateExportBill(ExportBillsDataSet.ExportBillDataTable exportBillDataTable)
        {
            try
            {
                var exportBillTableAdapter = new ExportBillTableAdapter();
                exportBillTableAdapter.Update(exportBillDataTable);

            }
            catch 
            {
                throw;
            }
        }

        public void GetAllExportBill(ExportBillsDataSet.ExportBillDataTable exportBillDataTable)
        {
            try
            {
                var exportBillTableAdapter = new ExportBillTableAdapter();
                exportBillTableAdapter.FillByAll(exportBillDataTable);

            }
            catch
            {
                throw;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RestaurantDTO;
using RestaurantDTO.ImportBillDetailDataSetTableAdapters;

namespace RestaurantController
{
    public class ImportBillDetailController
    {
        public void UpdateImportBillDetail(ImportBillDetailDataSet.ImportBillDetailDataTable ImportBillDetailDataTable)
        {
            try
            {
                var ImportBillDetailTableAdapter = new ImportBillDetailTableAdapter();
                ImportBillDetailTableAdapter.Update(ImportBillDetailDataTable);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void GetByImportBillDetailId(ImportBillDetailDataSet.ImportBillDetailDataTable ImportBillDetailDataTable, Int64 ImportBillDetailId)
        {
            using (var ImportBillDetailTableAdapter = new ImportBillDetailTableAdapter())
            {
                ImportBillDetailTableAdapter.FillByImportBillDetailId(ImportBillDetailDataTable, ImportBillDetailId);
            }
        }

        public void GetByImportBillId(ImportBillDetailDataSet.ImportBillDetailDataTable ImportBillDetailDataTable, string ImportBillId)
        {
            using (var ImportBillDetailTableAdapter = new ImportBillDetailTableAdapter())
            {
                ImportBillDetailTableAdapter.FillByImportBillId(ImportBillDetailDataTable, ImportBillId);
            }
        }

        public void GetByImportBillId(ImportBillDetailDataSet.SearchImportBillDetailDataTable searchImportBillDetailDataTable, string ImportBillId)
        {
            using (var searchImportBillDetailTableAdapter = new SearchImportBillDetailTableAdapter())
            {
                searchImportBillDetailTableAdapter.FillByImportBillId(searchImportBillDetailDataTable, ImportBillId);
            }
        }
    }
}

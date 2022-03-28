using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RestaurantCommon;
using RestaurantDTO.FunctionsDetailDataSetTableAdapters;
using RestaurantDTO;

namespace RestaurantController
{
    public class FunctionDetailController
    {
        public void GetFunctionDetailByStaffId(FunctionsDetailDataSet.FunctionDetailDataTable functionDetailDataTable, int staffId)
        {
            try
            {
                FunctionDetailTableAdapter functionDetailTableAdapter = new FunctionDetailTableAdapter();
                functionDetailTableAdapter.FillByStaffId(functionDetailDataTable, staffId);
            }
            catch
            {
                throw;
            }
        }

        public void UpdateFunctionDetail(FunctionsDetailDataSet.FunctionDetailDataTable functionDetailDataTable)
        {
            try
            {
                FunctionDetailTableAdapter functionDetailTableAdapter = new FunctionDetailTableAdapter();
                functionDetailTableAdapter.Update(functionDetailDataTable);
            }
            catch
            {
                throw;
            }
        }
    }
}

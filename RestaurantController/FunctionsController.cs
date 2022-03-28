using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RestaurantDTO;
using RestaurantDTO.FunctionsDataSetTableAdapters;
namespace RestaurantController
{
    public class FunctionsController
    {
        public void GetAllBill(FunctionsDataSet.FunctionsDataTable functionsDataTable)
        {
            using (var functionsAdapter = new FunctionsTableAdapter())
            {
                functionsAdapter.FillByAll(functionsDataTable);
            }
        }
    }
}

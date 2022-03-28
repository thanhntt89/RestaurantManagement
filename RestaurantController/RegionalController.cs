using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RestaurantDTO;
using RestaurantDTO.RegionalDataSetTableAdapters;

namespace RestaurantController
{
    public class RegionalController
    {

        public void UpdateRegional(RegionalDataSet.RegionalDataTable RegionalDataTable)
        {
            try
            {
                var RegionalTableAdapter = new RegionalTableAdapter();
                RegionalTableAdapter.Update(RegionalDataTable);
            }
            catch
            {
                throw;
            }
        }

        public void GetAllRegional(RegionalDataSet.RegionalDataTable RegionalDataTable)
        {
            using (var RegionalTableAdapter = new RegionalTableAdapter())
            {
                RegionalTableAdapter.FillByAllRegional(RegionalDataTable);
            }
        }

        public void GetRegionalByRegionalId(RegionalDataSet.RegionalDataTable RegionalDataTable, int RegionalId)
        {
            using (var RegionalTableAdapter = new RegionalTableAdapter())
            {
                RegionalTableAdapter.FillByRegionalId(RegionalDataTable, RegionalId);
            }
        }
    }
}

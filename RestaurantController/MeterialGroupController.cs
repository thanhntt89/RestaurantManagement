using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RestaurantDTO;
using RestaurantDTO.MeterialGroupDataSetTableAdapters;

namespace RestaurantController
{
    public class MeterialGroupController
    {
        public void UpdateMeterialGroup(MeterialGroupDataSet.MeterialGroupDataTable MeterialGroupDataTable)
        {
            try
            {
                var MeterialGroupTableAdapter = new MeterialGroupTableAdapter();
                MeterialGroupTableAdapter.Update(MeterialGroupDataTable);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void GetByMerterialGroupId(MeterialGroupDataSet.MeterialGroupDataTable MeterialGroupDataTable, int meterialGroupId)
        {
            using (var MeterialGroupTableAdapter = new MeterialGroupTableAdapter())
            {
                MeterialGroupTableAdapter.FillByMeterialGroupId(MeterialGroupDataTable, meterialGroupId);
            }
        }

        public void GetMeterialGroupByAll(MeterialGroupDataSet.MeterialGroupDataTable MeterialGroupDataTable)
        {
            using (var MeterialGroupTableAdapter = new MeterialGroupTableAdapter())
            {
                MeterialGroupTableAdapter.FillByAll(MeterialGroupDataTable);
            }
        }
    }
}

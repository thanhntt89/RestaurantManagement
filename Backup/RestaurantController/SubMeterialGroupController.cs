using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RestaurantDTO;
using RestaurantDTO.SubMeterialGroupDataSetTableAdapters;

namespace RestaurantController
{
    public class SubMeterialGroupController
    {
        public void UpdateSubMeterialGroup(SubMeterialGroupDataSet.SubMeterialGroupDataTable SubMeterialGroupDataTable)
        {
            try
            {
                var SubMeterialGroupTableAdapter = new SubMeterialGroupTableAdapter();
                SubMeterialGroupTableAdapter.Update(SubMeterialGroupDataTable);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void GetBySubMerterialGroupId(SubMeterialGroupDataSet.SubMeterialGroupDataTable SubMeterialGroupDataTable, int SubMeterialGroupId)
        {
            using (var SubMeterialGroupTableAdapter = new SubMeterialGroupTableAdapter())
            {
                SubMeterialGroupTableAdapter.FillBySubMeterialGroupId(SubMeterialGroupDataTable, SubMeterialGroupId);
            }
        }

        public void GetByMerterialGroupId(SubMeterialGroupDataSet.SubMeterialGroupDataTable SubMeterialGroupDataTable, int meterialGroupId)
        {
            using (var SubMeterialGroupTableAdapter = new SubMeterialGroupTableAdapter())
            {
                SubMeterialGroupTableAdapter.FillByMeterialGroupId(SubMeterialGroupDataTable, meterialGroupId);
            }
        }


        public void GetBySunMeterialGroupAll(SubMeterialGroupDataSet.SubMeterialGroupDataTable SubMeterialGroupDataTable)
        {
            using (var SubMeterialGroupTableAdapter = new SubMeterialGroupTableAdapter())
            {
                SubMeterialGroupTableAdapter.FillSubMeterialGroupByAll(SubMeterialGroupDataTable);
            }
        }
    }
}

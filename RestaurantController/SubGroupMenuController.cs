using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RestaurantDTO;
using RestaurantDTO.SubGroupMenuDataSetTableAdapters;

namespace RestaurantController
{
    public class SubGroupMenuController
    {
        public void UpdateSubGroupMenu(SubGroupMenuDataSet.SubGroupMenuDataTable SubGroupMenuDataTable)
        {
            try
            {
                SubGroupMenuTableAdapter subGroupMenuAdapter = new SubGroupMenuTableAdapter();
                subGroupMenuAdapter.Update(SubGroupMenuDataTable);
            }
            catch
            {
                throw;
            }
        }

        public void GetAllSubGroupMenu(SubGroupMenuDataSet.SubGroupMenuDataTable SubGroupMenuDataTable)
        {
            using(var subGroupMenuAdapter = new SubGroupMenuTableAdapter())
            {
                subGroupMenuAdapter.FillByAll(SubGroupMenuDataTable);
            }
        }

        public void GetSubGroupMenuBySubGroupMenuId(SubGroupMenuDataSet.SubGroupMenuDataTable SubGroupMenuDataTable,int subGroupId)
        {
            using (var subGroupMenuAdapter = new SubGroupMenuTableAdapter())
            {
                subGroupMenuAdapter.FillBySubGroupId(SubGroupMenuDataTable, subGroupId);
            }
        }

        public void GetSubGroupMenuByGroupMenuId(SubGroupMenuDataSet.SubGroupMenuDataTable SubGroupMenuDataTable, int GroupId)
        {
            using (var subGroupMenuAdapter = new SubGroupMenuTableAdapter())
            {
                subGroupMenuAdapter.FillByGroupId(SubGroupMenuDataTable, GroupId);
            }
        }

    }
}

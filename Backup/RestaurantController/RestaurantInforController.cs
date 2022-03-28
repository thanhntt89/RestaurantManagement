using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RestaurantDTO.RestaurantInforDataSetTableAdapters;
using RestaurantDTO;

namespace RestaurantController
{
    public class RestaurantInforController
    {
        public void UpdateRestaurantInfor(RestaurantInforDataSet.RestaurantInforDataTable RestaurantInforDataTable)
        {
            try
            {
                RestaurantInforTableAdapter RestaurantInforTableAdapter = new RestaurantInforTableAdapter();
                RestaurantInforTableAdapter.Update(RestaurantInforDataTable);
            }
            catch { throw; }
        }

        public void GetAllRestaurantInforByRestaurantInforId(RestaurantInforDataSet.RestaurantInforDataTable RestaurantInforDataTable, int restaurantInforId)
        {
            try
            {
                RestaurantInforTableAdapter RestaurantInforTableAdapter = new RestaurantInforTableAdapter();
                RestaurantInforTableAdapter.FillByRestaurantId(RestaurantInforDataTable,restaurantInforId);
            }
            catch { throw; }
        }
    }
}

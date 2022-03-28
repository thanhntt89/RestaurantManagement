using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RestaurantDTO;
using RestaurantDTO.MenuGroupDataSetTableAdapters;

namespace RestaurantController
{
    public class MenuGroupController
    {
        public void UpdateMenuGroup(MenuGroupDataSet.MenuGroupDataTable MenuGroupDataTable)
        {
            try
            {
                MenuGroupTableAdapter MenuGroupTableAdapter = new MenuGroupTableAdapter();
                MenuGroupTableAdapter.Update(MenuGroupDataTable);
            }
            catch { throw; }
        }

        public void GetAllMenuGroup(MenuGroupDataSet.MenuGroupDataTable MenuGroupDataTable)
        {
            using (var menuGroupTableAdapter = new MenuGroupTableAdapter())
            {
                menuGroupTableAdapter.FillByAllGroup(MenuGroupDataTable);
            }
        }

        public void GetMenuGroupByMenuGroupId(MenuGroupDataSet.MenuGroupDataTable MenuGroupDataTable,int menuGroupId)
        {
            using (var menuGroupTableAdapter = new MenuGroupTableAdapter())
            {
                menuGroupTableAdapter.FillByGroupId(MenuGroupDataTable, menuGroupId);
            }
        }

    }
}

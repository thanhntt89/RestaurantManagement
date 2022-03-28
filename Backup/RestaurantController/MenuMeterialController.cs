using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RestaurantDTO;
using RestaurantDTO.MenuMeterialsDataSetTableAdapters;

namespace RestaurantController
{
    public class MenuMeterialController
    {

        public void UpdateMenuMeterial(MenuMeterialsDataSet.MenuMaterialsDataTable menuMaterialsDataTable)
        {
            try
            {
                var menuMeterialTableAdapter = new MenuMaterialsTableAdapter();
                menuMeterialTableAdapter.Update(menuMaterialsDataTable);
            }
            catch
            {
                throw;
            }
        }

        public void GetAllMenuMeterial(MenuMeterialsDataSet.MenuMaterialsDataTable menuMaterialsDataTable)
        {
            try
            {
                var menuMeterialTableAdapter = new MenuMaterialsTableAdapter();
                menuMeterialTableAdapter.FillByAll(menuMaterialsDataTable);
            }
            catch
            {
                throw;
            }
        }

        public void GetMenuMeterialByMeterialId(MenuMeterialsDataSet.MenuMaterialsDataTable menuMaterialsDataTable,int meterialId)
        {
            try
            {
                var menuMeterialTableAdapter = new MenuMaterialsTableAdapter();
                menuMeterialTableAdapter.FillByMeterialId(menuMaterialsDataTable,meterialId);
            }
            catch
            {
                throw;
            }
        }

        public void GetMenuMeterialByMenuId(MenuMeterialsDataSet.MenuMaterialsDataTable menuMaterialsDataTable, int menuId)
        {
            try
            {
                var menuMeterialTableAdapter = new MenuMaterialsTableAdapter();
                menuMeterialTableAdapter.FillByMenuId(menuMaterialsDataTable, menuId);
            }
            catch
            {
                throw;
            }
        }

        public void GetMenuMeterialByMenuId(MenuMeterialsDataSet.MenuMeterialDetailDataTable menuMeterialDetailDataTable, int menuId)
        {
            try
            {
                var menuMeterialDetailTableAdapter = new MenuMeterialDetailTableAdapter();
                menuMeterialDetailTableAdapter.FillByMenuId(menuMeterialDetailDataTable, menuId);
            }
            catch
            {
                throw;
            }
        }

        public void GetMenuMeterialByMenuMeterialId(MenuMeterialsDataSet.MenuMeterialDetailDataTable menuMeterialDetailDataTable, int menuMeterialId)
        {
            try
            {
                var menuMeterialDetailTableAdapter = new MenuMeterialDetailTableAdapter();
                menuMeterialDetailTableAdapter.FillByMenuMeterialId(menuMeterialDetailDataTable, menuMeterialId);
            }
            catch
            {
                throw;
            }
        }

        public void GetMenuMeterialByMenuMeterialId(MenuMeterialsDataSet.MenuMaterialsDataTable menuMaterialsDataTable, int menuMeterialId)
        {
            try
            {
                var menuMaterialsTableAdapter = new MenuMaterialsTableAdapter();
                menuMaterialsTableAdapter.FillByMenuMeterialId(menuMaterialsDataTable, menuMeterialId);
            }
            catch
            {
                throw;
            }
        }

        public void GetMenuByMeterialId(MenuMeterialsDataSet.MenuByMeterialDataTable menuByMeterialDataTable, int meterialId)
        {
            try
            {
                var menuByMeterialTableAdapter = new MenuByMeterialTableAdapter();
                menuByMeterialTableAdapter.FillByMeterialId(menuByMeterialDataTable, meterialId);
            }
            catch
            {
                throw;
            }
        }
    }
}

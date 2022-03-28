using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RestaurantDTO;
using RestaurantDTO.TablesDataSetTableAdapters;

namespace RestaurantController
{
    public class TablesController
    {
        public void UpdateTable(TablesDataSet.TablesDataTable TablesDataTable)
        {
            try
            {
                var TablesTableAdapter = new TablesTableAdapter();
                TablesTableAdapter.Update(TablesDataTable);
            }
            catch
            {
                throw;
            }
        }

        public void GetAllTable(TablesDataSet.TablesDataTable tablesDataTable)
        {
            try
            {
                var TablesTableAdapter = new TablesTableAdapter();
                TablesTableAdapter.FillTablesByAll(tablesDataTable);
            }
            catch
            {
                throw;
            }
        }

        public void GetAllTableByStatus(TablesDataSet.TablesDataTable TablesDataTable, int Status)
        {
            using (var TablesTableAdapter = new TablesTableAdapter())
            {
                TablesTableAdapter.FillByStatus(TablesDataTable, Status);
            }
        }

        public void GetAllTableByRegionalId(TablesDataSet.TablesDataTable TablesDataTable, int RegionalId)
        {
            using (var TablesTableAdapter = new TablesTableAdapter())
            {
                TablesTableAdapter.FillTablesByRegionalId(TablesDataTable, RegionalId);
            }
        }

        public void GetAllTableByTableId(TablesDataSet.TablesDataTable TablesDataTable, int TableId)
        {
            using (var TablesTableAdapter = new TablesTableAdapter())
            {
                TablesTableAdapter.FillTableByTableId(TablesDataTable, TableId);
            }
        }

        public void GetTableByRegionalIdAndStatus(TablesDataSet.TablesDataTable TablesDataTable, int regionalId, int status)
        {
            using (var TablesTableAdapter = new TablesTableAdapter())
            {
                TablesTableAdapter.FillByRegionalIdAndStatus(TablesDataTable, regionalId, status);
            }
        }
    }
}

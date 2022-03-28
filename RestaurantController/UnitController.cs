using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RestaurantDTO;
using RestaurantDTO;
using RestaurantDTO.UnitDataSetTableAdapters;

namespace RestaurantController
{
    public class UnitController
    {
        public void GetAllUnit(UnitDataSet.UnitDataTable UnitDataTable)
        {
            using (var UnitTableAdapter = new UnitTableAdapter())
            {
                UnitTableAdapter.FillAllUnit(UnitDataTable);
            }
        }

        public void UpdateUnit(UnitDataSet.UnitDataTable UnitDataTable)
        {
            try
            {
                var UnitTableAdapter = new UnitTableAdapter();
                UnitTableAdapter.Update(UnitDataTable);
            }
            catch 
            {
                throw;
            }
        }

        public void GetUnitByUnitId(UnitDataSet.UnitDataTable UnitDataTable,int unitId)
        {
            using (var UnitTableAdapter = new UnitTableAdapter())
            {
                UnitTableAdapter.FillByUnitId(UnitDataTable, unitId);
            }
        }
    }
}

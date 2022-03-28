using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RestaurantDTO;
using RestaurantDTO.ShiftDataSetTableAdapters;

namespace RestaurantController
{
    public class ShiftsController
    {
        public void UpdateShift(ShiftDataSet.ShiftsDataTable ShiftsDataTable)
        {
            try
            {
                ShiftsTableAdapter shiftsTableAdapter = new ShiftsTableAdapter();
                shiftsTableAdapter.Update(ShiftsDataTable);
            }
            catch
            {
                throw;
            }
        }

        public void GetShiftByShiftId(ShiftDataSet.ShiftsDataTable ShiftsDataTable, int ShiftId)
        {
            using (var shiftTableAdapter = new ShiftsTableAdapter())
            {
                shiftTableAdapter.FillShiftByShiftId(ShiftsDataTable, ShiftId);
            }
        }

        public void GetAllShift(ShiftDataSet.ShiftsDataTable ShiftsDataTable)
        {
            using (var shiftTableAdapter = new ShiftsTableAdapter())
            {
                shiftTableAdapter.FillAllShift(ShiftsDataTable);
            }
        }
    }
}

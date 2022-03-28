using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RestaurantDTO;
using RestaurantDTO.StaffDataSetTableAdapters;

namespace RestaurantController
{
    public class StaffController
    {
        public void UpdateStaff(StaffDataSet.StaffsDataTable StaffsDataTable)
        {
            try
            {
                StaffsTableAdapter StaffsTableAdapter = new StaffsTableAdapter();
                StaffsTableAdapter.Update(StaffsDataTable);
            }
            catch
            {
                throw;
            }
        }

        public void GetAllStaff(StaffDataSet.StaffsDataTable StaffsDataTable)
        {
            using (var staffAdapter = new StaffsTableAdapter())
            {
                staffAdapter.FillByAllStaff(StaffsDataTable);
            }
        }

        public void GetStaffByStaffCode(StaffDataSet.StaffsDataTable staffDataTable, string staffCode)
        {
            using (var staffAdapter = new StaffsTableAdapter())
            {
                staffAdapter.FillByStaffCode(staffDataTable, staffCode);
            }
        }

        public void GetStaffByUserName(StaffDataSet.StaffsDataTable staffDataTable, string userName)
        {
            using (var staffAdapter = new StaffsTableAdapter())
            {
                staffAdapter.FillByUserName(staffDataTable, userName);
            }
        }

        public void GetStaffByStaffId(StaffDataSet.StaffsDataTable StaffsDataTable, int StaffId)
        {
            using (var staffAdapter = new StaffsTableAdapter())
            {
                staffAdapter.FillByStaffId(StaffsDataTable, StaffId);
            }
        }
    }
}

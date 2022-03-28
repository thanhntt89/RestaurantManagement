using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Management;

namespace RestaurantManagement
{
    public class GetComputerInfor
    {
        public string Hdd_id()
        {
            ManagementObjectSearcher searcher = new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_BIOS");

            foreach (ManagementObject wmi in searcher.Get())
            {
                try
                {
                    return wmi.GetPropertyValue("SerialNumber").ToString().Trim();
                }
                catch { }
            }

            return "0986648910";
        }
    }
}

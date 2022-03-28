using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.NetworkInformation;
using System.Runtime.InteropServices;
using SoftwareLocker;
using System.Windows.Forms;

namespace RestaurantManagement
{
    public class CheckSoftRegister
    {
        public static bool CheckRegister()
        {
            GetComputerInfor hdd_id = new GetComputerInfor();
            TrialMaker trial = new TrialMaker(hdd_id.Hdd_id(), Application.StartupPath + "\\RegFile.reg", Application.StartupPath + "\\TMSetup.dft",
           " Liên hệ: Nguyễn Tất Thành Mobile: 098 664 8910 \n Email: thanhntt89@yahoo.com ", 60, 3, "189");
            byte[] MyOwnKey =  { 97, 250,  1,  5,  84, 21,   7, 63,
                         4,  54, 87, 56, 123, 10,   3, 62,
                         7,   9, 20, 36,  37, 21, 101, 57};
            trial.TripleDESKey = MyOwnKey;
            TrialMaker.RunTypes RT = trial.ShowDialog();

            if (RT != TrialMaker.RunTypes.Expired)
            {
                if (RT == TrialMaker.RunTypes.Full)
                    return false;
                else
                    return true;
            }
            else
            {
                return false;
            }
        }
    }
}

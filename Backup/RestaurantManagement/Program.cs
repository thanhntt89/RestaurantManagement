using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using SoftwareLocker;

namespace RestaurantManagement
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            GetComputerInfor hdd_id = new GetComputerInfor();
            TrialMaker trial = new TrialMaker(hdd_id.Hdd_id(), Application.StartupPath + "\\RegFile.reg", Application.StartupPath + "\\TMSetup.dft",
           " Liên hệ: Nguyễn Tất Thành Mobile: 098 664 8910 \n Email: thanhntt89@yahoo.com ", 60, 18000, "189");
            byte[] MyOwnKey =  { 97, 250,  1,  5,  84, 21,   7, 63,
                         4,  54, 87, 56, 123, 10,   3, 62,
                         7,   9, 20, 36,  37, 21, 101, 57};
            trial.TripleDESKey = MyOwnKey;
            TrialMaker.RunTypes RT = trial.ShowDialog();
            bool isTrial = false;
            if (RT != TrialMaker.RunTypes.Expired)
            {
                if (RT == TrialMaker.RunTypes.Full)
                    isTrial= false;
                else
                    isTrial= true;

                if (CheckLogin.CheckConnectionString())
                {
                    Application.Run(new FormMainUI(isTrial));
                }
                else
                    Application.Exit();
            }
        }
    }
}

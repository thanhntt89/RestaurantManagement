using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using SoftwareLocker;

namespace RestaurantManagement
{
    public partial class AboutUs : DevComponents.DotNetBar.Metro.MetroForm
    {
        private bool isTrial = true;

        public AboutUs(bool isTrial)
        {
            InitializeComponent();
            this.isTrial = isTrial;

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AboutUs_Load(object sender, EventArgs e)
        {
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            RegistedInfor RegistedInfor = new RegistedInfor(isTrial);
            RegistedInfor.ShowDialog();
        }
    }
}
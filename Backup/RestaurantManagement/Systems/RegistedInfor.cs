using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using System.Net;

namespace RestaurantManagement
{
    public partial class RegistedInfor : DevComponents.DotNetBar.Metro.MetroForm
    {
        public RegistedInfor(bool isTrial)
        {
            InitializeComponent();
            if (isTrial)
            {
                lbInfor.Text = "Phiên bản phần mềm dùng thử";
            }
            lbUserName.Text = Dns.GetHostName();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
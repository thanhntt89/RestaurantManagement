using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;

namespace RestaurantManagement
{
    public partial class Processing : DevComponents.DotNetBar.Metro.MetroForm
    {
        private ProcessingEntity processingEntity = null;

        public Processing(ProcessingEntity processingEntity)
        {
            InitializeComponent();
            this.processingEntity = processingEntity;
            if (processingEntity.Completed)
                this.Close();
        }

        private void Processing_Load(object sender, EventArgs e)
        {
            timer.Enabled = true;
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            if (processingEntity.Completed)
            {
                timer.Dispose();
                timer.Enabled = false;
                this.Close();
            }
        }
    }
}
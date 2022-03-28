using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using RestaurantDTO;
using RestaurantController;
namespace RestaurantManagement
{
    public partial class MeterialAdjusting : DevComponents.DotNetBar.Metro.MetroForm
    {
        public delegate void ReLoadData();
        public event ReLoadData reLoadData;

        private int meterialId = 0;

        private MeterialDataSet.MeterialsDataTable meterialsDataTable = null;
        private MeterialController meterialController = new MeterialController();

        public MeterialAdjusting(int meterialId, string mterialName, string quantity)
        {
            InitializeComponent();
            this.txtOldQuantity.Text = quantity;
            lbItemName.Text = mterialName;
            this.meterialId = meterialId;
        }

        public MeterialAdjusting()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtOK_Click(object sender, EventArgs e)
        {
            AdjustQuantity();
        }

        private void AdjustQuantity()
        {
            meterialsDataTable = new MeterialDataSet.MeterialsDataTable();
            meterialController.GetByMerterialId(meterialsDataTable, meterialId);
            if (meterialsDataTable.Rows.Count == 0)
                return;

            meterialsDataTable.First().Quantity = txtQuantityAdjusting.Value;

            try 
            {
                meterialController.UpdateMeterial(meterialsDataTable);
                reLoadData();
                this.Close();
            }
            catch 
            {
                MessageBox.Show("Thêm mặt hàng mới không thành công", Constants.CaptionErrorMessage, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}

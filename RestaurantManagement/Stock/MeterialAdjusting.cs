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
using RestaurantCommon;
namespace RestaurantManagement
{
    public partial class MeterialAdjusting : DevComponents.DotNetBar.Metro.MetroForm
    {
        public delegate void ReLoadData();
        public event ReLoadData reLoadData;

        private int meterialId = 0;

        private MeterialDataSet.MeterialsDataTable meterialsDataTable = null;
        private MeterialController meterialController = new MeterialController();
        private UserFunctionList userFunctionList;

        public MeterialAdjusting(int meterialId, string meterialName, string quantity, UserFunctionList userFunctionList)
        {
            InitializeComponent();
            this.txtOldQuantity.Text = quantity;
            lbItemName.Text = meterialName;
            this.meterialId = meterialId;
            this.userFunctionList = userFunctionList;
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
            string meterialName = meterialsDataTable.First().MeterialName;
            meterialsDataTable.First().Quantity = txtQuantityAdjusting.Value;

            try
            {
                meterialController.UpdateMeterial(meterialsDataTable);
                LogHistories.InsertLogHistories("Điều chỉnh số lượng mặt hàng " + meterialName + " Số lượng đầu:" + txtOldQuantity.Text + " số lượng mới: " + txtQuantityAdjusting.Text, DateTime.Now, userFunctionList.UserName, "Thành công");
                reLoadData();
                this.Close();
            }
            catch
            {
                LogHistories.InsertLogHistories("Điều chỉnh số lượng mặt hàng " + meterialName + " Số lượng đầu:" + txtOldQuantity.Text + " số lượng mới: " + txtQuantityAdjusting.Text, DateTime.Now, userFunctionList.UserName, "Lỗi");
                MessageBox.Show("Điều chỉnh tồn kho không thành công", Constants.CaptionErrorMessage, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Enter)
                AdjustQuantity();
            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
}

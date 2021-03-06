using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using RestaurantDTO;
using RestaurantController;
using RestaurantCommon;

namespace RestaurantManagement
{
    public partial class DetailBillByMenu : DevComponents.DotNetBar.Metro.MetroForm
    {
        private BillsDataSet.BillByMenuDataTable billByMenuDataTable = null;
        private BillController billController = new BillController();

        private int menuId;
        int type = 0;
        public DetailBillByMenu(int menuId, string menuName, DateTime fromDate, DateTime toDate, int type)
        {
            InitializeComponent();
            dtpFromDate.Checked = true;
            dtpToDate.Checked = true;
            this.type = type;
            if (type == 0)
            {
                dtpFromDate.CustomFormat = "dd/MM/yyyy";
                dtpToDate.CustomFormat = "dd/MM/yyyy";
            }
            else if (type == 1)
            {
                dtpFromDate.CustomFormat = "MM/yyyy";
                dtpToDate.CustomFormat = "MM/yyyy";
            }
            else if (type == 2)
            {
                dtpFromDate.CustomFormat = "yyyy";
                dtpToDate.CustomFormat = "yyyy";
            }
            dtpFromDate.Value = fromDate;
            dtpToDate.Value = toDate;
            this.menuId = menuId;
            this.lbMenuName.Text = menuName;
        }

        private void LoadBillByMenuId()
        {
            dgvBills.Rows.Clear();

            BillEntity billEntity = new BillEntity();
            billEntity.MenuId = menuId;
            if (dtpFromDate.Checked)
            {
                if (type == 0)
                {
                    billEntity.FromDate = dtpFromDate.Value.ToString("yyy-MM-dd 00:00:01");
                }
                else if (type == 1)
                {
                    billEntity.FromMonth = dtpFromDate.Value.Month;
                    billEntity.FromYear = dtpFromDate.Value.Year;
                }
                else if (type == 2)
                {
                    billEntity.FromYear = dtpToDate.Value.Year;
                }
            }
            if (dtpToDate.Checked)
            {
                if (type == 0)
                {
                    billEntity.ToDate = dtpToDate.Value.ToString("yyy-MM-dd 23:59:59");
                }
                else if (type == 1)
                {
                    billEntity.ToMonth = dtpToDate.Value.Month;
                    billEntity.ToYear = dtpToDate.Value.Year;
                    //billEntity.FromMonth = dtpFromDate.Value.Month;
                    //billEntity.FromYear = dtpFromDate.Value.Year;
                }
                else if (type == 2)
                {
                    billEntity.ToYear = dtpToDate.Value.Year;
                }
            }
            billByMenuDataTable = new BillsDataSet.BillByMenuDataTable();
            billController.GetAllBillByMenuId(billByMenuDataTable, billEntity);
            if (billByMenuDataTable.Rows.Count == 0)
            {
                MessageBox.Show("Không có kết quả tìm kiếm thỏa mãn", Constants.CaptionInformationMessage, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            dgvBills.Rows.Clear();

            int index = 0;
            dgvBills.AllowUserToAddRows = true;

            foreach (BillsDataSet.BillByMenuRow item in billByMenuDataTable.Rows)
            {
                dgvBills.Rows.Add();
                DataGridViewRow row = dgvBills.Rows[index];
                row.Cells["STT"].Value = index + 1;
                row.Cells["BillCode"].Value = item.IsBillCodeNull() ? string.Empty : item.BillCode;
                row.Cells["BillDate"].Value = item.BillDate.ToString("dd/MM/yyyy");
                row.Cells["Quantity"].Value = item.Quatity;

                index++;
            }
            dgvBills.AllowUserToAddRows = false;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void DetailBillByMenu_Load(object sender, EventArgs e)
        {
            LoadBillByMenuId();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            LoadBillByMenuId();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Enter)
                LoadBillByMenuId();
            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
}
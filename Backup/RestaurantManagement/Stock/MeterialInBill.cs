using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using RestaurantController;
using RestaurantDTO;
using RestaurantCommon;

namespace RestaurantManagement
{
    public partial class MeterialInBill : DevComponents.DotNetBar.Metro.MetroForm
    {
        private MeterialController meterialController = new MeterialController();
        private MeterialDataSet.MeterialsDataTable meterialsDataTable = null;

        private MenuMeterialsDataSet.MenuByMeterialDataTable menuByMeterialDataTable = null;
        private MenuMeterialController menuMeterialController = new MenuMeterialController();

        private BillsDataSet.BillByMenuDataTable billByMenuDataTable = null;
        private BillController billController = new BillController();

        int type = 0;
        int meterialId = -1;
        public MeterialInBill(int meterialId, DateTime fromDate, DateTime toDate, int type)
        {
            InitializeComponent();
            this.meterialId = meterialId;
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
        }

        private void MeterialInBill_Load(object sender, EventArgs e)
        {
            LoadAllMeterial();
        }

        private void LoadAllMeterial()
        {
            meterialsDataTable = new MeterialDataSet.MeterialsDataTable();
            meterialController.GetMeterialByAll(meterialsDataTable);
            if (meterialsDataTable.Rows.Count == 0)
                return;

            var row = meterialsDataTable.NewMeterialsRow();
            row.MeterialId = -1;
            row.MeterialCode = string.Empty;
            row.MeterialName = string.Empty;
            row.Note = string.Empty;
            row.Quantity = 0;
            row.UnitId = 0;
            row.SubMeterialGroupId = 0;
            meterialsDataTable.AddMeterialsRow(row);

            cboMeterial.DataSource = meterialsDataTable;
            cboMeterial.DisplayMember = meterialsDataTable.MeterialNameColumn.ColumnName;
            cboMeterial.ValueMember = meterialsDataTable.MeterialIdColumn.ColumnName;
            cboMeterial.SelectedValue = meterialId;
        }

        private void SearchBill()
        {
            dgvBills.Rows.Clear();
            BillEntity billEntity = new BillEntity();
            if (dtpFromDate.Checked)
            {
                if (type == 0)
                {
                    billEntity.FromDate = dtpFromDate.Value.ToString("yyy-MM-dd 00:00:00");
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
                    billEntity.ToMonth = dtpFromDate.Value.Month;
                    billEntity.ToYear = dtpFromDate.Value.Year;
                }
                else if (type == 2)
                {
                    billEntity.ToYear = dtpToDate.Value.Year;
                }
            }
            bool isSelected = false;
            for (int i = 0; i < dgvMenu.Rows.Count; i++)
            {
                isSelected = (bool)dgvMenu.Rows[i].Cells["Selected"].Value;

                if (!isSelected)
                    continue;

                billEntity.MenuId = int.Parse(dgvMenu.Rows[i].Cells["MenuId"].Value.ToString());
                LoadBillByMenuId(billEntity);
            }
        }

        private void LoadBillByMenuId(BillEntity billEntity)
        {
            billByMenuDataTable = new BillsDataSet.BillByMenuDataTable();
            billController.GetAllBillByMenuId(billByMenuDataTable, billEntity);

            int index = dgvBills.Rows.Count;
            if (billByMenuDataTable.Rows.Count == 0)
            {
               // MessageBox.Show("Không có kết quả tìm kiếm thỏa mãn", Constants.CaptionInformationMessage, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

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

        private void LoadMenuByMeterialId(int meterialId)
        {
            dgvMenu.Rows.Clear();
            menuByMeterialDataTable = new MenuMeterialsDataSet.MenuByMeterialDataTable();
            menuMeterialController.GetMenuByMeterialId(menuByMeterialDataTable, meterialId);
            int index = 0;
            dgvMenu.AllowUserToAddRows = true;
            foreach (MenuMeterialsDataSet.MenuByMeterialRow item in menuByMeterialDataTable.Rows)
            {
                dgvMenu.Rows.Add();
                DataGridViewRow row = dgvMenu.Rows[index];
                row.Cells["Index"].Value = index + 1;
                row.Cells["MenuName"].Value = item.ItemName;
                row.Cells["MenuId"].Value = item.MenuId;
                row.Cells["Selected"].Value = true;

                index++;
            }
            dgvMenu.AllowUserToAddRows = false;
            SearchBill();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            SearchBill();
        }

        private void dgvMenu_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void cboMeterial_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboMeterial.SelectedIndex > 0)
                LoadMenuByMeterialId((int)cboMeterial.SelectedValue);

        }
    }
}
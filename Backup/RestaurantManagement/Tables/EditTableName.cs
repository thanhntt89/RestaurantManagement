using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using System.Linq;
using RestaurantController;
using RestaurantDTO;

namespace RestaurantManagement
{
    public partial class EditTableName : DevComponents.DotNetBar.Metro.MetroForm
    {
        public delegate void ReLoadData();
        public event ReLoadData reLoadData;

        private int tableId = -1;
        private string tableName = string.Empty;
        private TablesController tablesController = new TablesController();
        private TablesDataSet.TablesDataTable tablesDataTable = null;

        public EditTableName(int tableId, string tableName)
        {
            InitializeComponent();
            this.tableId = tableId;
            txtOldTableName.Text = tableName;
        }
        public EditTableName()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnChangedName_Click(object sender, EventArgs e)
        {
            ChangedTableName();
        }

        private void ChangedTableName()
        {
            if (string.IsNullOrEmpty(txtNewTableName.Text))
            {
                MessageBox.Show("Tên của bàn không được để trống.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            tablesDataTable = new TablesDataSet.TablesDataTable();
            tablesController.GetAllTableByTableId(tablesDataTable, tableId);
            if (tablesDataTable.Rows.Count == 0)
                return;
            tablesDataTable.First().TableName = txtNewTableName.Text;
            tablesDataTable.First().Note = txtChairNumber.Text;
            try
            {
                tablesController.UpdateTable(tablesDataTable);
                MessageBox.Show("Đổi tên bàn thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                reLoadData();
                this.Close();
            }
            catch
            {
                MessageBox.Show("Đổi tên bàn không thành công.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
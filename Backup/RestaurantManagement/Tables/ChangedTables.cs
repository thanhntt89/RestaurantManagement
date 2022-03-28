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
    public partial class ChangedTables : DevComponents.DotNetBar.Metro.MetroForm
    {
        public delegate void ReLoadData();
        public event ReLoadData reLoadData;

        private int tableId = -1;
        private string tableName = string.Empty;
        private RegionalDataSet.RegionalDataTable regionalDataTable = null;
        private RegionalController regionalController = new RegionalController();
        private TablesDataSet.TablesDataTable tablesDataTable = null;
        private TablesController tablesController = new TablesController();
        private BillsDataSet.BillDataTable billDataTable = null;
        private BillController billController = new BillController();

        public ChangedTables(int tableId, string tableName)
        {
            InitializeComponent();
            this.tableId = tableId;
            this.tableName = tableName;
            lbOldTableName.Text = tableName;
        }

        public ChangedTables()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnChangedTable_Click(object sender, EventArgs e)
        {
            ChangedTable();
        }

        private void ChangedTable()
        {
            if (cboTables.SelectedValue == null)
                return;

            tablesDataTable = new TablesDataSet.TablesDataTable();
            tablesController.GetAllTableByTableId(tablesDataTable, tableId);
            if (tablesDataTable.Rows.Count == 0)
                return;
            tablesDataTable.First().Status = 0;
            try
            {
                // Đưa bàn đang sử dụng về trạng thái free
                tablesController.UpdateTable(tablesDataTable);
            }
            catch
            {
                MessageBox.Show("Chuyển bàn không thành công!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int tableNewId = -1;
            tableNewId = int.Parse(cboTables.SelectedValue.ToString());

            // Chuyển trạng thái bàn mới sang sử dụng
            tablesDataTable = new TablesDataSet.TablesDataTable();
            tablesController.GetAllTableByTableId(tablesDataTable, tableNewId);
            if (tablesDataTable.Rows.Count == 0)
                return;
            tablesDataTable.First().Status = 1;
            try
            {
                // Đưa bàn đang sử dụng về trạng thái free
                tablesController.UpdateTable(tablesDataTable);
            }
            catch
            {
                MessageBox.Show("Chuyển bàn không thành công!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Chuyển trạng thái bàn mới sang sử dụng trong hoá đơn
            billDataTable = new BillsDataSet.BillDataTable();
            // Lấy về thông tin hoá đơn của bàn cần chuyển đang sử dụng
            billController.GetBillByTableIdAndStatus(billDataTable, tableId, 1);

            if (billDataTable.Rows.Count == 0)
                return;

            billDataTable.First().TableId = tableNewId;
            try
            {
                // Cập nhật đổi bàn cũ sang bàn mới
                billController.UpdateBill(billDataTable);
                MessageBox.Show("Chuyển bàn thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch
            {
                MessageBox.Show("Chuyển bàn không thành công!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            reLoadData();
            this.Close();
        }

        private void LoadAllRegion()
        {
            regionalDataTable = new RegionalDataSet.RegionalDataTable();
            regionalController.GetAllRegional(regionalDataTable);
            if (regionalDataTable.Rows.Count == 0)
                return;
            cboRegional.DataSource = regionalDataTable;
            cboRegional.DisplayMembers = regionalDataTable.RegionalNameColumn.ColumnName;
            cboRegional.ValueMember = regionalDataTable.RegionalIdColumn.ColumnName;
        }

        private void LoadTablesByRegionalId(int regionalId)
        {
            tablesDataTable = new TablesDataSet.TablesDataTable();
            tablesController.GetTableByRegionalIdAndStatus(tablesDataTable, regionalId, 0);
            if (tablesDataTable.Rows.Count == 0)
                return;
            // Loại bỏ bàn đang sử dụng khỏi vị trí chuyển
            DataRow[] drr = tablesDataTable.Select("TableId=' " + tableId + " ' ");
            for (int i = 0; i < drr.Length; i++)
                tablesDataTable.Rows.Remove(drr[i]);
            tablesDataTable.AcceptChanges();

            cboTables.DataSource = tablesDataTable;
            cboTables.DisplayMembers = tablesDataTable.TableNameColumn.ColumnName;
            cboTables.ValueMember = tablesDataTable.TableIdColumn.ColumnName;
        }

        private void ChangedTables_Load(object sender, EventArgs e)
        {
            LoadAllRegion();
        }

        private void cboRegional_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cboRegional.SelectedValue == null)
                return;

            int regionalId = int.Parse(cboRegional.SelectedValue.ToString());
            LoadTablesByRegionalId(regionalId);
        }
    }
}

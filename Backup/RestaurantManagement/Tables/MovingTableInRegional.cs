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
using System.Linq;

namespace RestaurantManagement
{
    public partial class MovingTableInRegional : DevComponents.DotNetBar.Metro.MetroForm
    {

        public delegate void ReLoadData();
        public event ReLoadData reLoadData;

        private int tableId = -1;
        private int regionalId = -1;
        private string regionalName = string.Empty;
        private string tableName = string.Empty;
        private RegionalDataSet.RegionalDataTable regionalDataTable = null;
        private RegionalController regionalController = new RegionalController();
        private TablesDataSet.TablesDataTable tablesDataTable = null;
        private TablesController tablesController = new TablesController();

        public MovingTableInRegional(int tableId, int regionalId, string tableName, string regionalName)
        {
            InitializeComponent();
            this.tableId = tableId;
            this.tableName = tableName;
            this.regionalId = regionalId;
            this.regionalName = regionalName;
        }
        public MovingTableInRegional()
        {
            InitializeComponent();
        }

        private void LoadData()
        {
            txtOldRegional.Text = regionalName;
            txtTableName.Text = tableName;
            regionalDataTable = new RegionalDataSet.RegionalDataTable();
            regionalController.GetAllRegional(regionalDataTable);

            if (regionalDataTable.Rows.Count == 0)
                return;

            DataRow[] drr = regionalDataTable.Select("RegionalId=' " + regionalId + " ' ");
            for (int i = 0; i < drr.Length; i++)
                regionalDataTable.Rows.Remove(drr[i]);
            regionalDataTable.AcceptChanges();


            cboNewRegional.DataSource = regionalDataTable;
            cboNewRegional.DisplayMembers = regionalDataTable.RegionalNameColumn.ColumnName;
            cboNewRegional.ValueMember = regionalDataTable.RegionalIdColumn.ColumnName;
        }

        private void MovingTable_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnMovingTable_Click(object sender, EventArgs e)
        {
            MoveTable();
        }

        private void MoveTable()
        {
            tablesDataTable = new TablesDataSet.TablesDataTable();
            tablesController.GetAllTableByTableId(tablesDataTable, tableId);
            if (tablesDataTable.Rows.Count == 0)
                return;
           tablesDataTable.First().RegionalId = int.Parse(cboNewRegional.SelectedValue.ToString());

           try 
           {
               tablesController.UpdateTable(tablesDataTable);
               MessageBox.Show("Chuyển bàn sang khu vực mới thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
               reLoadData();
               this.Close();
           }
           catch 
           {
               MessageBox.Show("Chuyển bàn sang khu vực mới không thành công!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
           }
        }
    }
}
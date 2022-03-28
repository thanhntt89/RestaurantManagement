using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using RestaurantController;
using RestaurantDTO;

namespace RestaurantManagement
{
    public partial class AddTable : DevComponents.DotNetBar.Metro.MetroForm
    {
        public delegate void ReLoadData();
        public event ReLoadData reLoadData;

        private TablesDataSet.TablesDataTable tablesDataTable = null;
        private TablesController tablesController = new TablesController();
        private RegionalDataSet.RegionalDataTable regionalDataTable = null;
        private RegionalController regionalController = new RegionalController();

        private bool isTrial = false;

        public AddTable(bool isTrial)
        {
            InitializeComponent();
            this.isTrial = isTrial;
        }

        public AddTable()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            AddNewTable();
        }

        private bool CheckItem()
        {
            if (cboRegional.SelectedIndex < 0)
            {
                cboRegional.Focus();
                MessageBox.Show("Bạn hãy chọn vị trí đặt bàn!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            if (string.IsNullOrEmpty(txtTableName.Text))
            {
                txtTableName.Focus();
                MessageBox.Show("Bạn hãy nhập vào tên bàn!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            return true;
        }

        private void Clear()
        {
            txtTableName.Text = string.Empty;
            txtChairNumber.Text = string.Empty;
        }

        private void AddNewTable()
        {
            if (!CheckItem())
                return;
            if (isTrial)
            {
                if (TableCount() >= 10)
                {
                    MessageBox.Show("Đây là phiên bản dùng thử bạn chỉ thêm được tối đa 10 bàn.\n Để sử dụng được nhiều hơn bạn vui lòng đăng ký sử dụng!\n Liên hệ: Nguyễn Tất Thành Mobile: 098 664 8910", "Phiên bản dùng thử", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.Close();
                    return;
                }
            }

            tablesDataTable = new TablesDataSet.TablesDataTable();

            var newRow = tablesDataTable.NewTablesRow();
            newRow.RegionalId = int.Parse(cboRegional.SelectedValue.ToString());
            newRow.TableName = txtTableName.Text;
            newRow.Note = txtChairNumber.Text;
            newRow.Status = 0;
            tablesDataTable.AddTablesRow(newRow);

            try
            {
                tablesController.UpdateTable(tablesDataTable);
                MessageBox.Show("Thêm thông tin thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Clear();
                reLoadData();
            }
            catch
            {
                MessageBox.Show("Thêm thông tin không thành công!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadRegional()
        {
            regionalDataTable = new RegionalDataSet.RegionalDataTable();
            regionalController.GetAllRegional(regionalDataTable);
            if (regionalDataTable.Rows.Count == 0)
                return;

            cboRegional.DataSource = regionalDataTable;
            cboRegional.DisplayMembers = regionalDataTable.RegionalNameColumn.ColumnName;
            cboRegional.ValueMember = regionalDataTable.RegionalIdColumn.ColumnName;
            cboRegional.Text = string.Empty;
        }

        private void AddTable_Load(object sender, EventArgs e)
        {
            LoadRegional();
        }

        private int TableCount()
        {
            tablesDataTable = new TablesDataSet.TablesDataTable();
            tablesController.GetAllTable(tablesDataTable);
            int countTable = 0;
            countTable = tablesDataTable.Rows.Count;
            return countTable;
        }
    }
}

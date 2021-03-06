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
using System.Linq;
using RestaurantCommon;

namespace RestaurantManagement
{
    public partial class RegionalManagement : DevComponents.DotNetBar.Metro.MetroForm
    {
        public delegate void ReLoadData();
        public event ReLoadData reLoadData;

        private TablesDataSet.TablesDataTable tablesDataTable = null;
        private TablesController tablesController = new TablesController();

        private RegionalController regionalController = new RegionalController();
        private RegionalDataSet.RegionalDataTable regionalDataTable = null;

        private UserFunctionList userFunctionList = null;

        public RegionalManagement(UserFunctionList userFunctionList)
        {
            InitializeComponent();
            this.userFunctionList = userFunctionList;
            CheckRole();
        }

        private void CheckRole()
        {
            btnDelete.Enabled = false;
            btnSave.Enabled = false;
            dgvRegional.AllowUserToAddRows = false;

            if (userFunctionList.Services[0].Add == 1)
            {
                btnSave.Enabled = true;
                dgvRegional.AllowUserToAddRows = true;
            }
            if (userFunctionList.Services[0].Edit == 1)
            {
                btnSave.Enabled = true;
            }
            if (userFunctionList.Services[0].Delete == 1)
            {
                btnDelete.Enabled = true;
            }
        }

        public RegionalManagement()
        {
            InitializeComponent();
        }

        private void LoadRegional()
        {
            regionalDataTable = new RegionalDataSet.RegionalDataTable();
            regionalController.GetAllRegional(regionalDataTable);
            if (regionalDataTable.Rows.Count == 0)
                return;

            DataGridViewTextBoxCell sTT, regionalName, note, regionalId;

            int index = 0;

            foreach (RegionalDataSet.RegionalRow row in regionalDataTable.Rows)
            {
                index++;

                sTT = new DataGridViewTextBoxCell();
                sTT.Value = index;

                regionalName = new DataGridViewTextBoxCell();
                regionalName.Value = row.RegionalName;

                note = new DataGridViewTextBoxCell();
                note.Value = row.IsNoteNull() ? string.Empty : row.Note;

                regionalId = new DataGridViewTextBoxCell();
                regionalId.Value = row.RegionalId;

                dgvRegional.Rows.Add(sTT.Value, regionalName.Value, note.Value, regionalId.Value);
            }
        }

        private void RegionalManagement_Load(object sender, EventArgs e)
        {
            LoadRegional();
        }

        private void dgvRegional_UserAddedRow(object sender, DataGridViewRowEventArgs e)
        {
            dgvRegional.CurrentRow.Cells["STT"].Value = e.Row.Index;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            RegionalSave();
        }

        private bool CheckItem()
        {
            for (int i = 0; i < dgvRegional.Rows.Count - 1; i++)
            {
                if (dgvRegional.Rows[i].Cells["RegionalName"].Value == null)
                {
                    MessageBox.Show("Tên khu vực không được để trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }

            return true;
        }

        private void RegionalSave()
        {
            if (!CheckItem())
            {
                return;
            }

            string regionalId = string.Empty;
            regionalDataTable = new RegionalDataSet.RegionalDataTable();

            for (int i = 0; i < dgvRegional.Rows.Count - 1; i++)
            {
                // Cập nhật
                if (dgvRegional.Rows[i].Cells["RegionalId"].Value != null)
                {
                    regionalId = dgvRegional.Rows[i].Cells["RegionalId"].Value.ToString();
                    regionalController.GetRegionalByRegionalId(regionalDataTable, int.Parse(regionalId));
                    if (regionalDataTable.Rows.Count == 0)
                        continue;
                    regionalDataTable.First().RegionalName = dgvRegional.Rows[i].Cells["RegionalName"].Value.ToString();
                    regionalDataTable.First().Note = dgvRegional.Rows[i].Cells["Note"].Value == null ? string.Empty : dgvRegional.Rows[i].Cells["Note"].Value.ToString();

                    try
                    {
                        regionalController.UpdateRegional(regionalDataTable);
                    }
                    catch
                    {
                        MessageBox.Show("Thêm mới khu vực không thành công!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                // Thêm mới
                else
                {
                    var newRow = regionalDataTable.NewRegionalRow();
                    newRow.RegionalName = dgvRegional.Rows[i].Cells["RegionalName"].Value.ToString();
                    newRow.Note = dgvRegional.Rows[i].Cells["Note"].Value == null ? string.Empty : dgvRegional.Rows[i].Cells["Note"].Value.ToString();

                    regionalDataTable.AddRegionalRow(newRow);

                    try
                    {
                        regionalController.UpdateRegional(regionalDataTable);
                    }
                    catch
                    {
                        MessageBox.Show("Thêm mới khu vực không thành công!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
            }
            reLoadData();

            MessageBox.Show("Lưu thông tin thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DeleteRegional();
        }
        private bool IsExistTableInRegional(int regionalId)
        {
            tablesDataTable = new TablesDataSet.TablesDataTable();
            tablesController.GetAllTableByRegionalId(tablesDataTable, regionalId);
            if (tablesDataTable.Rows.Count > 0)
            {
                MessageBox.Show("Bàn ăn đang tồn tại ở khu vực này bạn không thể xoá được", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }
        private void DeleteRegional()
        {
            string regionalId = string.Empty;
            regionalDataTable = new RegionalDataSet.RegionalDataTable();
            string regionalName = string.Empty;
            int rowCount = dgvRegional.Rows.Count - 1;
            if (dgvRegional.CurrentRow.Index > rowCount)
                return;
            regionalName = dgvRegional.CurrentRow.Cells["RegionalName"].Value.ToString();
            DialogResult rst = MessageBox.Show("Bạn có muốn xoá vùng " + regionalName + " này không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (rst != DialogResult.Yes)
                return;

            // Xoá trong database nếu có
            if (dgvRegional.CurrentRow.Cells["RegionalId"].Value != null)
            {
                regionalId = dgvRegional.CurrentRow.Cells["RegionalId"].Value.ToString();
                if (!IsExistTableInRegional(int.Parse(regionalId)))
                    return;

                regionalController.GetRegionalByRegionalId(regionalDataTable, int.Parse(regionalId));
                regionalDataTable.First().Delete();
                try
                {
                    regionalController.UpdateRegional(regionalDataTable);
                }
                catch
                {
                    MessageBox.Show("Thêm mới khu vực không thành công!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                dgvRegional.Rows.RemoveAt(dgvRegional.CurrentRow.Index);
            }
            else
            {
                dgvRegional.Rows.RemoveAt(dgvRegional.CurrentRow.Index);
            }
            reLoadData();
        }

    }
}
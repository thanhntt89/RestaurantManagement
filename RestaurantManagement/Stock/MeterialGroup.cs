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
using RestaurantCommon;

namespace RestaurantManagement
{
    public partial class MeterialGroup : DevComponents.DotNetBar.Metro.MetroForm
    {
        public delegate void ReLoadData();
        public event ReLoadData reLoadData;
        private MeterialGroupDataSet.MeterialGroupDataTable meterialGroupDataTable = null;
        private MeterialGroupController meterialGroupController = new MeterialGroupController();
        private UserFunctionList userFunctionList;

        public MeterialGroup(UserFunctionList userFunctionList)
        {
            InitializeComponent();
            this.userFunctionList = userFunctionList;
            CheckRole();
        }

        private void CheckRole()
        {
            dgvGroupName.Columns["Delete"].Visible = false;
            dgvGroupName.AllowUserToAddRows = false;
            btnSave.Enabled = false;

            if (userFunctionList.Stocks[0].Add == 1)
            {
                btnSave.Enabled = true;
                dgvGroupName.AllowUserToAddRows = true;
            }
            if (userFunctionList.Stocks[0].Edit == 1)
            {
                btnSave.Enabled = true;
            }
            if (userFunctionList.Stocks[0].Delete == 1)
            {
                dgvGroupName.Columns["Delete"].Visible = true;
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvGroupName_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 3)
            {
                DeleteMeterialById(e.RowIndex);
            }
        }

        private void DeleteMeterialById(int rowIndex)
        {
            object meterialGroupId = dgvGroupName.Rows[rowIndex].Cells["MenuGroupId"].Value;
            if (meterialGroupId == null)
            {
                dgvGroupName.Rows.RemoveAt(rowIndex);
                for (int i = 0; i < dgvGroupName.Rows.Count - 1; i++)
                {
                    dgvGroupName.Rows[i].Cells["STT"].Value = i + 1;
                }
                return;
            }
            string meterialGroupName = (string)dgvGroupName.Rows[rowIndex].Cells["MeterialGroupName"].Value;
            DialogResult rst = MessageBox.Show("Bạn có muốn xoá bỏ nhóm " + meterialGroupName + " này không?", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (rst == DialogResult.No)
                return;
            meterialGroupDataTable = new MeterialGroupDataSet.MeterialGroupDataTable();
            meterialGroupController.GetByMerterialGroupId(meterialGroupDataTable, (int)meterialGroupId);
            if (meterialGroupDataTable.Rows.Count == 0)
                return;

            meterialGroupDataTable.First().Delete();
            try
            {
                meterialGroupController.UpdateMeterialGroup(meterialGroupDataTable);
                reLoadData();
                MessageBox.Show("Xoá thông tin thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch
            {
                MessageBox.Show("Danh mục đang có nhóm con sử dụng. Không xoá được danh mục này!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            dgvGroupName.Rows.RemoveAt(rowIndex);
            for (int i = 0; i < dgvGroupName.Rows.Count - 1; i++)
            {
                dgvGroupName.Rows[i].Cells["STT"].Value = i + 1;
            }
        }

        private void LoadAllMeterialGroup()
        {
            meterialGroupDataTable = new MeterialGroupDataSet.MeterialGroupDataTable();
            meterialGroupController.GetMeterialGroupByAll(meterialGroupDataTable);
            if (meterialGroupDataTable.Rows.Count == 0)
                return;

            int indexRow = 0;

            foreach (MeterialGroupDataSet.MeterialGroupRow item in meterialGroupDataTable.Rows)
            {
                indexRow++;
                dgvGroupName.Rows.Add();
                DataGridViewRow row = dgvGroupName.Rows[indexRow - 1];

                row.Cells["STT"].Value = indexRow;
                row.Cells["MeterialGroupName"].Value = item.MeterialGroupName;
                row.Cells["Note"].Value = item.IsNoteNull() ? string.Empty : item.Note;
                row.Cells["Delete"].Value = "Xoá";
                row.Cells["MenuGroupId"].Value = item.MeterialGroupId;
            }
        }

        private void SaveMeterialGroup()
        {
            if (!CheckItem())
                return;

            object meterialGroupId = null;
            for (int i = 0; i < dgvGroupName.Rows.Count - 1; i++)
            {
                meterialGroupId = dgvGroupName.Rows[i].Cells["MenuGroupId"].Value;
                meterialGroupDataTable = new MeterialGroupDataSet.MeterialGroupDataTable();
                // Thêm mới
                if (meterialGroupId == null)
                {
                    var row = meterialGroupDataTable.NewMeterialGroupRow();
                    row.MeterialGroupName = dgvGroupName.Rows[i].Cells["MeterialGroupName"].Value.ToString();
                    row.Note = dgvGroupName.Rows[i].Cells["Note"].Value == null ? string.Empty : dgvGroupName.Rows[i].Cells["Note"].Value.ToString();

                    meterialGroupDataTable.AddMeterialGroupRow(row);
                    try
                    {
                        meterialGroupController.UpdateMeterialGroup(meterialGroupDataTable);

                    }
                    catch
                    {
                        MessageBox.Show("Lưu thông tin không thành công!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                // Cập nhật
                else
                {
                    meterialGroupController.GetByMerterialGroupId(meterialGroupDataTable, (int)meterialGroupId);
                    if (meterialGroupDataTable.Rows.Count == 0)
                        return;
                    meterialGroupDataTable.First().MeterialGroupName = dgvGroupName.Rows[i].Cells["MeterialGroupName"].Value.ToString();
                    meterialGroupDataTable.First().Note = dgvGroupName.Rows[i].Cells["Note"].Value == null ? string.Empty : dgvGroupName.Rows[i].Cells["Note"].Value.ToString();
                    try
                    {
                        meterialGroupController.UpdateMeterialGroup(meterialGroupDataTable);

                    }
                    catch
                    {
                        MessageBox.Show("Lưu thông tin không thành công!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
            }
            reLoadData();
            MessageBox.Show("Lưu thông tin thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private bool CheckItem()
        {
            for (int i = 0; i < dgvGroupName.Rows.Count - 1; i++)
            {
                if (dgvGroupName.Rows[i].Cells["MeterialGroupName"].Value == null)
                {
                    MessageBox.Show("Tên danh mục nhóm mặt hàng không để trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            return true;
        }

        private void MeterialGroup_Load(object sender, EventArgs e)
        {
            LoadAllMeterialGroup();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveMeterialGroup();
        }

        private void dgvGroupName_UserAddedRow(object sender, DataGridViewRowEventArgs e)
        {
            dgvGroupName.CurrentRow.Cells["STT"].Value = e.Row.Index;
        }
    }
}

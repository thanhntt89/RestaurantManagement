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
    public partial class MeterialManagement : DevComponents.DotNetBar.Metro.MetroForm
    {
        public delegate void ReLoadData();
        public event ReLoadData reLoadData;

        private UnitDataSet.UnitDataTable unitDataTable = null;
        private UnitController unitController = new UnitController();
        private UserFunctionList userFunctionList;

        public MeterialManagement(UserFunctionList userFunctionList)
        {
            InitializeComponent();
            this.userFunctionList = userFunctionList;
            CheckRole();
        }

        private void CheckRole()
        {
            dgvUnit.Columns["Delete"].Visible = false;
            dgvUnit.AllowUserToAddRows = false;
            btnSave.Enabled = false;

            if (userFunctionList.Menus[0].Add == 1 | userFunctionList.Stocks[0].Add == 1)
            {
                btnSave.Enabled = true;
                dgvUnit.AllowUserToAddRows = true;
            }
            if (userFunctionList.Menus[0].Edit == 1 | userFunctionList.Stocks[0].Edit == 1)
            {
                btnSave.Enabled = true;
            }
            if (userFunctionList.Menus[0].Delete == 1 | userFunctionList.Stocks[0].Delete == 1)
            {
                dgvUnit.Columns["Delete"].Visible = true;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
            if (reLoadData != null)
                reLoadData();
        }

        private void LoadAllUnit()
        {
            unitDataTable = new UnitDataSet.UnitDataTable();
            unitController.GetAllUnit(unitDataTable);

            int index = 0;
            //           dgvUnit.AllowUserToAddRows = true;

            foreach (UnitDataSet.UnitRow item in unitDataTable.Rows)
            {
                dgvUnit.Rows.Add();
                DataGridViewRow row = dgvUnit.Rows[index];

                row.Cells["STT"].Value = index + 1;
                row.Cells["UnitName"].Value = item.UnitName;
                row.Cells["Note"].Value = item.Field<string>("Note");
                row.Cells["UnitId"].Value = item.UnitId;

                index++;
            }

            //         dgvUnit.AllowUserToAddRows = false;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveUnit();
        }

        private void SaveUnit()
        {
            if (!CheckItem())
            {
                return;
            }
            string unitId = string.Empty;
            unitDataTable = new UnitDataSet.UnitDataTable();

            for (int i = 0; i < dgvUnit.Rows.Count - 1; i++)
            {
                // Cập nhật
                if (dgvUnit.Rows[i].Cells["UnitId"].Value != null)
                {
                    unitId = dgvUnit.Rows[i].Cells["UnitId"].Value.ToString();
                    unitController.GetUnitByUnitId(unitDataTable, int.Parse(unitId));
                    if (unitDataTable.Rows.Count == 0)
                        continue;
                    unitDataTable.First().UnitName = dgvUnit.Rows[i].Cells["UnitName"].Value.ToString();
                    unitDataTable.First().Note = dgvUnit.Rows[i].Cells["Note"].Value == null ? string.Empty : dgvUnit.Rows[i].Cells["Note"].Value.ToString();

                    try
                    {
                        unitController.UpdateUnit(unitDataTable);
                        LogHistories.InsertLogHistories("Cập nhật đơn vị tính " + dgvUnit.Rows[i].Cells["UnitName"].Value.ToString(), DateTime.Now, userFunctionList.UserName, "Thành công");
                    }
                    catch
                    {
                        LogHistories.InsertLogHistories("Cập nhật đơn vị tính " + dgvUnit.Rows[i].Cells["UnitName"].Value.ToString(), DateTime.Now, userFunctionList.UserName, "Lỗi");
                        MessageBox.Show("Cập nhật đơn vị tính " + dgvUnit.Rows[i].Cells["UnitName"].Value.ToString() + " không thành công!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                // Thêm mới
                else
                {
                    var newRow = unitDataTable.NewUnitRow();
                    newRow.UnitName = dgvUnit.Rows[i].Cells["UnitName"].Value.ToString();
                    newRow.Note = dgvUnit.Rows[i].Cells["Note"].Value == null ? string.Empty : dgvUnit.Rows[i].Cells["Note"].Value.ToString();

                    unitDataTable.AddUnitRow(newRow);

                    try
                    {
                        unitController.UpdateUnit(unitDataTable);
                        LogHistories.InsertLogHistories("Thêm mới đơn vị tính " + dgvUnit.Rows[i].Cells["UnitName"].Value.ToString(), DateTime.Now, userFunctionList.UserName, "Thành công");

                    }
                    catch
                    {
                        LogHistories.InsertLogHistories("Thêm mới đơn vị tính " + dgvUnit.Rows[i].Cells["UnitName"].Value.ToString(), DateTime.Now, userFunctionList.UserName, "Lỗi");
                        MessageBox.Show("Thêm mới đơn vị tính " + dgvUnit.Rows[i].Cells["UnitName"].Value.ToString() + " không thành công!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
            }

            MessageBox.Show("Lưu thông tin thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private bool CheckItem()
        {
            for (int i = 0; i < dgvUnit.Rows.Count - 1; i++)
            {
                if (dgvUnit.Rows[i].Cells["UnitName"].Value == null)
                {
                    MessageBox.Show("Ký hiệu đơn vị dòng " + (i + 1) + " không để trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }

            return true;
        }

        private void dgvUnit_UserAddedRow(object sender, DataGridViewRowEventArgs e)
        {
            dgvUnit.CurrentRow.Cells["STT"].Value = e.Row.Index;
        }

        private void DeleteUnitByUnitId(int indexRow)
        {
            int unitId = 0;
            unitDataTable = new UnitDataSet.UnitDataTable();
            string UnitName = string.Empty;
            int rowCount = dgvUnit.Rows.Count - 1;
            if (dgvUnit.CurrentRow.Cells["UnitName"].Value == null)
                return;
            UnitName = dgvUnit.CurrentRow.Cells["UnitName"].Value.ToString();
            DialogResult rst = MessageBox.Show("Bạn có muốn xoá đơn vị tính " + UnitName + " này không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (rst != DialogResult.Yes)
                return;

            // Xoá trong database nếu có
            if (dgvUnit.Rows[indexRow].Cells["UnitId"].Value != null)
            {
                unitId = int.Parse(dgvUnit.CurrentRow.Cells["UnitId"].Value.ToString());

                unitController.GetUnitByUnitId(unitDataTable, unitId);
                unitDataTable.First().Delete();
                try
                {
                    unitController.UpdateUnit(unitDataTable);
                    LogHistories.InsertLogHistories("Xóa đơn vị tính " + UnitName, DateTime.Now, userFunctionList.UserName, "Thành công");
                    MessageBox.Show("Xoá thông tin thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch
                {
                    LogHistories.InsertLogHistories("Xóa đơn vị tính " + UnitName, DateTime.Now, userFunctionList.UserName, "Lỗi");
                    MessageBox.Show("Đơn vị tính đang được sử dụng bạn không thể xoá!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            dgvUnit.Rows.RemoveAt(indexRow);
        }

        private void dgvUnit_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 3)
            {
                DeleteUnitByUnitId(e.RowIndex);
            }
        }

        private void MeterialManagement_Load(object sender, EventArgs e)
        {
            LoadAllUnit();
        }

    }
}
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
    public partial class UserControlRolesFunction : UserControl
    {

        private FunctionsDataSet.FunctionsDataTable functionsDataTable = null;
        private FunctionsController functionsController = new FunctionsController();

        private FunctionsDetailDataSet.FunctionDetailDataTable functionDetailDataTable = null;
        private FunctionDetailController functionDetailController = new FunctionDetailController();

        private StaffDataSet.StaffsDataTable staffsDataTable = null;
        private StaffController staffController = new StaffController();

        private int staffId;
        private int roleId;
        public UserControlRolesFunction(int roleId)
        {
            InitializeComponent();
            this.roleId = roleId;
        }

        public void LoadAllStaff()
        {
            staffsDataTable = new StaffDataSet.StaffsDataTable();
            staffController.GetAllStaff(staffsDataTable);
            int index = 0;
            dgvStaff.AllowUserToAddRows = true;
            foreach (StaffDataSet.StaffsRow item in staffsDataTable.Rows)
            {
                dgvStaff.Rows.Add();
                DataGridViewRow row = dgvStaff.Rows[index];
                row.Cells["STT"].Value = index + 1;
                row.Cells["StaffCode"].Value = item.StaffCode;
                row.Cells["FullName"].Value = item.FullName;
                if (item.RoleId == 2)
                    row.Cells["RoleId"].Value = "Supper Admin";
                else
                    if (item.RoleId == 1)
                        row.Cells["RoleId"].Value = "Quản lý";
                    else
                        row.Cells["RoleId"].Value = "Nhân viên";

                row.Cells["StaffIds"].Value = item.StaffId;
                index++;
            }
            dgvStaff.AllowUserToAddRows = false;
        }

        /// <summary>
        /// Lấy về tất cả danh sách quyền người dùng
        /// </summary>
        private void LoadAllFunctions()
        {
            dgvFunctions.Rows.Clear();

            functionsDataTable = new FunctionsDataSet.FunctionsDataTable();
            functionsController.GetAllBill(functionsDataTable);
            int index = 0;
            dgvFunctions.AllowUserToAddRows = true;
            foreach (FunctionsDataSet.FunctionsRow item in functionsDataTable.Rows)
            {
                dgvFunctions.Rows.Add();
                DataGridViewRow row = dgvFunctions.Rows[index];
                row.Cells["STTS"].Value = index + 1;
                row.Cells["FunctionsName"].Value = item.FunctionName;
                row.Cells["FunctionId"].Value = item.FunctionId;
                index++;
            }
            dgvFunctions.AllowUserToAddRows = false;
        }

        /// <summary>
        /// Lấy về danh sách quyền người dùng theo mã người dùng
        /// </summary>
        /// <param name="staffId"></param>
        public void LoadAllFuntionsDetailByStaffId(int staffId)
        {
            dgvFunctions.Rows.Clear();
            ckViewAll.Checked = false;
            clAddAll.Checked = false;
            ckEditAll.Checked = false;
            ckDeleteAll.Checked = false;

            functionDetailDataTable = new FunctionsDetailDataSet.FunctionDetailDataTable();
            functionDetailController.GetFunctionDetailByStaffId(functionDetailDataTable, staffId);

            functionsDataTable = new FunctionsDataSet.FunctionsDataTable();
            functionsController.GetAllBill(functionsDataTable);
            int itemIndex = 0;
            dgvFunctions.AllowUserToAddRows = true;
            foreach (FunctionsDataSet.FunctionsRow functionIndex in functionsDataTable.Rows)
            {
                dgvFunctions.Rows.Add();
                DataGridViewRow rows = dgvFunctions.Rows[itemIndex];
                rows.Cells["STTS"].Value = itemIndex + 1;
                rows.Cells["FunctionsName"].Value = functionIndex.FunctionName;
                rows.Cells["FunctionId"].Value = functionIndex.FunctionId;
                rows.Cells["View"].Value = false;
                rows.Cells["Add"].Value = false;
                rows.Cells["Edit"].Value = false;
                rows.Cells["Delete"].Value = false;
                foreach (FunctionsDetailDataSet.FunctionDetailRow item in functionDetailDataTable.Rows)
                {
                    if (!functionIndex.FunctionId.Equals(item.FunctionId))
                        continue;

                    if (item.Status == 1)
                        rows.Cells["View"].Value = true;
                    else
                        rows.Cells["View"].Value = false;

                    if (item.AddRole == 1)
                        rows.Cells["Add"].Value = true;
                    else
                        rows.Cells["Add"].Value = false;

                    if (item.EditRole == 1)
                        rows.Cells["Edit"].Value = true;
                    else
                        rows.Cells["Edit"].Value = false;

                    if (item.DeleteRole == 1)
                        rows.Cells["Delete"].Value = true;
                    else
                        rows.Cells["Delete"].Value = false;
                }
                itemIndex++;
            }
            dgvFunctions.AllowUserToAddRows = false;
        }

        private void RolesFunction_Load(object sender, EventArgs e)
        {
            panel1.CenterHorizontally();
            panel1.CenterVertically();
            LoadAllStaff();
            LoadAllFunctions();
        }

        private void dgvStaff_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;
            staffId = int.Parse(dgvStaff.Rows[e.RowIndex].Cells["StaffIds"].Value.ToString());
            LoadAllFuntionsDetailByStaffId(staffId);
        }

        private void SaveFunction()
        {
            int count = dgvFunctions.Rows.Count;
            string functionName = string.Empty;
            functionDetailDataTable = new FunctionsDetailDataSet.FunctionDetailDataTable();

            functionDetailController.GetFunctionDetailByStaffId(functionDetailDataTable, staffId);
            for (int i = 0; i < functionDetailDataTable.Rows.Count; i++)
            {
                functionDetailDataTable[i].Delete();
            }
            try
            {
                functionDetailController.UpdateFunctionDetail(functionDetailDataTable);
            }
            catch
            {
                MessageBox.Show("Cập nhật quyền không thành công.", Constants.CaptionErrorMessage, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            for (int i = 0; i < count; i++)
            {
                var row = functionDetailDataTable.NewFunctionDetailRow();
                row.FunctionId = dgvFunctions.Rows[i].Cells["FunctionId"].Value.ToString();
                row.StaffId = staffId;
                row.EditRole = (bool)dgvFunctions.Rows[i].Cells["Edit"].Value ? 1 : 0;
                row.AddRole = (bool)dgvFunctions.Rows[i].Cells["Add"].Value ? 1 : 0;
                row.Status = (bool)dgvFunctions.Rows[i].Cells["View"].Value ? 1 : 0;
                row.DeleteRole = (bool)dgvFunctions.Rows[i].Cells["Delete"].Value ? 1 : 0;
                functionDetailDataTable.AddFunctionDetailRow(row);
            }

            try
            {
                functionDetailController.UpdateFunctionDetail(functionDetailDataTable);
                MessageBox.Show("Cập nhật quyền cho người dùng thành công", Constants.CaptionInformationMessage, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch
            {
                MessageBox.Show("Cập nhật quyền không thành công.", Constants.CaptionErrorMessage, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveFunction();
        }

        private void RolesFunction_SizeChanged(object sender, EventArgs e)
        {
            panel1.CenterHorizontally();
            panel1.CenterVertically();
        }

        private void ckViewAll_CheckedChanged(object sender, EventArgs e)
        {
            if (ckViewAll.Checked)
                CheckDataGridViewAll(true, "View");
            else
                CheckDataGridViewAll(false, "View");
        }

        private void CheckDataGridViewAll(bool status, string Columne)
        {
            for (int i = 0; i < dgvFunctions.Rows.Count; i++)
            {
                dgvFunctions.Rows[i].Cells[Columne].Value = status;
            }
        }

        private void clAddAll_CheckedChanged(object sender, EventArgs e)
        {
            if (clAddAll.Checked)
                CheckDataGridViewAll(true, "Add");
            else
                CheckDataGridViewAll(false, "Add");
        }

        private void ckEditAll_CheckedChanged(object sender, EventArgs e)
        {
            if (ckEditAll.Checked)
                CheckDataGridViewAll(true, "Edit");
            else
                CheckDataGridViewAll(false, "Edit");
        }

        private void ckDeleteAll_CheckedChanged(object sender, EventArgs e)
        {
            if (ckDeleteAll.Checked)
                CheckDataGridViewAll(true, "Delete");
            else
                CheckDataGridViewAll(false, "Delete");
        }
    }
}
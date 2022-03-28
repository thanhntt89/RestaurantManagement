using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using RestaurantCommon;
using RestaurantDTO;
using RestaurantController;

namespace RestaurantManagement
{
    public partial class UserControlLogHistories : UserControl
    {
        private UserFunctionList userFunctionList;
        private HistoriesDataSet.LogHistoryDataTable logHistoryDataTable = null;
        private CheckBox checkboxHeader = null;
        private StaffController staffController = new StaffController();
        private StaffDataSet.StaffsDataTable staffsDataTable = null;

        public UserControlLogHistories(UserFunctionList userFunctionList)
        {
            InitializeComponent();
            this.userFunctionList = userFunctionList;
        }

        private void LoadAllHistories()
        {
            logHistoryDataTable = new HistoriesDataSet.LogHistoryDataTable();
            HistoriesController.GetAllHistories(logHistoryDataTable);
        }

        private void UserControlLogHistories_Load(object sender, EventArgs e)
        {
            LoadAllStaff();
        }

        private void SearchLogHistories()
        {
            dgvLogHistories.Rows.Clear();
            dgvLogHistories.Controls.RemoveByKey("checkboxHeader");

            logHistoryDataTable = new HistoriesDataSet.LogHistoryDataTable();
            HistoriesController.GetAllHistories(logHistoryDataTable);

            var querry = from row in logHistoryDataTable
                         select row;
            if (cboUserName.SelectedValue != null && cboUserName.SelectedValue.ToString() != string.Empty)
            {
                querry = querry.Where(r => r.UserName.IndexOf(cboUserName.Text, StringComparison.OrdinalIgnoreCase) >= 0);
            }

            querry = querry.Where(r => r.DateTime.Date >= dtpFromDate.Value.Date);
            querry = querry.Where(r => r.DateTime.Date <= dtpToDate.Value.Date);

            if (querry.Count() <= 0)
            {
                MessageBox.Show("Không có thông tin lịch sử truy cập.", Constants.CaptionInformationMessage, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            dgvLogHistories.AllowUserToAddRows = true;
            int indexRow = 0;
            foreach (var item in querry)
            {
                dgvLogHistories.Rows.Add();
                DataGridViewRow row = dgvLogHistories.Rows[indexRow];
                row.Cells["STT"].Value = indexRow + 1;
                row.Cells["DateTime"].Value = item.DateTime;
                row.Cells["Contents"].Value = item.ContentsLog;
                row.Cells["Status"].Value = item.Note;
                row.Cells["UserName"].Value = item.UserName;
                row.Cells["HistoriesId"].Value = item.HistoryId;
                row.Cells["Select"].Value = false;

                indexRow++;
            }
            dgvLogHistories.AllowUserToAddRows = false;

            Rectangle rect = dgvLogHistories.GetCellDisplayRectangle(5, -1, true);
            rect.X = rect.Location.X + dgvLogHistories.Columns["Select"].Width / 2;//rect.Location.X + 23;
            rect.Y = 4;

            checkboxHeader = new CheckBox();
            checkboxHeader.BackColor = Color.Transparent;
            checkboxHeader.Name = "checkboxHeader";
            checkboxHeader.Size = new Size(16, 16);
            checkboxHeader.Location = rect.Location;
            checkboxHeader.CheckedChanged += new EventHandler(checkboxHeader_CheckedChanged);
            dgvLogHistories.Controls.Add(checkboxHeader);

            checkboxHeader.Checked = false;
        }

        private void checkboxHeader_CheckedChanged(object sender, EventArgs e)
        {
            if (dgvLogHistories.Rows.Count == 0)
                return;

            dgvLogHistories.Rows[0].Cells[0].Selected = true;
            dgvLogHistories.MultiSelect = false;
            for (int i = 0; i < dgvLogHistories.Rows.Count; i++)
            {
                if (checkboxHeader.Checked)
                    dgvLogHistories.Rows[i].Cells["Select"].Value = true;
                else
                    dgvLogHistories.Rows[i].Cells["Select"].Value = false;
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            SearchLogHistories();
        }

        private void LoadAllStaff()
        {
            staffsDataTable = new StaffDataSet.StaffsDataTable();
            staffController.GetAllStaff(staffsDataTable);

            if (staffsDataTable.Rows.Count == 0)
                return;
            var newRow = staffsDataTable.NewStaffsRow();
            newRow.StaffId = 0;
            newRow.StaffCode = string.Empty;
            newRow.FullName = string.Empty;
            newRow.Status = -1;
            newRow.UserName = string.Empty;
            newRow.PassWord = string.Empty;
            newRow.Mobile = string.Empty;
            newRow.Email = string.Empty;
            newRow.Address = string.Empty;
            newRow.Image = null;
            newRow.RoleId = -1;
            staffsDataTable.Rows.InsertAt(newRow, 0);
            cboUserName.DataSource = staffsDataTable;
            cboUserName.ValueMember = staffsDataTable.StaffIdColumn.ColumnName;
            cboUserName.DisplayMembers = staffsDataTable.UserNameColumn.ColumnName;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            Delete();
        }

        private void Delete()
        {
            Int64 historiesId = 0;
            bool isSelected = false;
            bool isDelete = false;

            DialogResult rst = MessageBox.Show("Bạn có muốn xóa bỏ thông tin lịch sử truy cập này không?", Constants.CaptionInformationMessage, MessageBoxButtons.YesNo, MessageBoxIcon.Information);

            if (rst == DialogResult.No)
                return;
            int rowCount = dgvLogHistories.Rows.Count;
            for (int i = 0; i < rowCount; i++)
            {
                logHistoryDataTable = new HistoriesDataSet.LogHistoryDataTable();
                historiesId = (Int64)dgvLogHistories.Rows[i].Cells["HistoriesId"].Value;
                isSelected = (bool)dgvLogHistories.Rows[i].Cells["Select"].Value;
                if (!isSelected)
                    continue;

                HistoriesController.GetHistoriesByHistoriesId(logHistoryDataTable, historiesId);
                logHistoryDataTable.First().Delete();
                try
                {
                    HistoriesController.UpdateHistories(logHistoryDataTable);
                    //  dgvLogHistories.Rows.RemoveAt(i);
                    isDelete = true;
                }
                catch
                {
                    isDelete = false;
                    break;
                }
            }

            if (isDelete)
            {
                MessageBox.Show("Xóa thông tin lịch sử người dùng thành công.", Constants.CaptionInformationMessage, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("Không xóa được lịch sử người dùng.", Constants.CaptionErrorMessage, MessageBoxButtons.OK, MessageBoxIcon.Error);
            SearchLogHistories();
        }
    }
}

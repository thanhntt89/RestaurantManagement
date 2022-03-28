using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using RestaurantController;
using RestaurantDTO;
using RestaurantCommon;

namespace RestaurantManagement
{
    public partial class UserControlStockManagement : UserControl
    {
        private MeterialGroupController meterialGroupController = new MeterialGroupController();
        private MeterialGroupDataSet.MeterialGroupDataTable meterialGroupDataTable = null;
        private SubMeterialGroupDataSet.SubMeterialGroupDataTable subMeterialGroupDataTable = null;
        private SubMeterialGroupController subMeterialGroupController = new SubMeterialGroupController();
        private MeterialDataSet.MeterialsDataTable meterialsDataTable = new MeterialDataSet.MeterialsDataTable();
        private MeterialController meterialController = new MeterialController();

        private int SubMeterialGroupId = 0;
        private string SubMterialGroupName = string.Empty;
        private int MeterialGroupId = 0;
        private UserFunctionList userFunctionList = null;
        private string UserName = string.Empty;
        public UserControlStockManagement(UserFunctionList userFunctionList)
        {
            InitializeComponent();
            this.userFunctionList = userFunctionList;
            CheckRole();
        }

        public UserControlStockManagement()
        {
            InitializeComponent();
        }

        private void CheckRole()
        {
            mnAddFoodGroupName.Enabled = false;
            mnDeleteFoodGroup.Enabled = false;
            mnEditFoodGroupName.Enabled = false;
            btnAddFood.Enabled = false;
            btnEditFood.Enabled = false;
            btnDeleteFood.Enabled = false;
            btnQuantityAdjusting.Enabled = false;
            btnImportBill.Enabled = false;
            btnExportMeterial.Enabled = false;

            if (userFunctionList.Stocks[0].Add == 1)
            {
                btnAddFood.Enabled = true;
                mnAddFoodGroupName.Enabled = true;
                btnImportBill.Enabled = true;
            }
            if (userFunctionList.Stocks[0].Edit == 1)
            {
                btnEditFood.Enabled = true;
                mnEditFoodGroupName.Enabled = true;
                btnExportMeterial.Enabled = true;
                btnQuantityAdjusting.Enabled = true;
            }
            if (userFunctionList.Stocks[0].Delete == 1)
            {
                mnDeleteFoodGroup.Enabled = true;
                btnDeleteFood.Enabled = true;
            }
        }

        private void LoadMeterialGroup()
        {
            meterialGroupDataTable = new MeterialGroupDataSet.MeterialGroupDataTable();
            meterialGroupController.GetMeterialGroupByAll(meterialGroupDataTable);
            if (meterialGroupDataTable.Rows.Count == 0)
                return;

            var newRow = meterialGroupDataTable.NewMeterialGroupRow();
            newRow.MeterialGroupId = -1;
            newRow.MeterialGroupName = string.Empty;
            newRow.Note = string.Empty;

            meterialGroupDataTable.Rows.InsertAt(newRow, 0);
            cboMeterialGroup.DataSource = meterialGroupDataTable;
            cboMeterialGroup.DisplayMembers = meterialGroupDataTable.MeterialGroupNameColumn.ColumnName;
            cboMeterialGroup.ValueMember = meterialGroupDataTable.MeterialGroupIdColumn.ColumnName;
        }

        private void LoadAllSubMeterialGroup()
        {
            // Lấy về danh sách nhóm con của nguyên liệu
            subMeterialGroupDataTable = new SubMeterialGroupDataSet.SubMeterialGroupDataTable();
            subMeterialGroupController.GetBySunMeterialGroupAll(subMeterialGroupDataTable);
        }

        private void LoadInitilize()
        {
            LoadAllSubMeterialGroup();
            LoadMeterialGroup();
        }

        /// <summary>
        /// Load danh sách nhóm và phân nhóm mặt hàng
        /// </summary>
        private void LoadAllMeterialGroupAndSubMeterialGroup()
        {
            listViewMeterialGroup.Items.Clear();
            meterialGroupDataTable = new MeterialGroupDataSet.MeterialGroupDataTable();
            // Lấy về danh sách nhóm của nguyên liệu
            meterialGroupController.GetMeterialGroupByAll(meterialGroupDataTable);
            if (meterialGroupDataTable == null)
                return;
            LoadAllSubMeterialGroup();
            var querry = from row in meterialGroupDataTable
                         select row;
            if (cboMeterialGroup.SelectedIndex > 0)
                querry = querry.Where(r => r.MeterialGroupId == int.Parse(cboMeterialGroup.SelectedValue.ToString()));

            //meterialGroupDataTable = new MeterialGroupDataSet.MeterialGroupDataTable();
            //// Lấy về danh sách nhóm của nguyên liệu
            //meterialGroupController.GetMeterialGroupByAll(meterialGroupDataTable);

            //if (meterialGroupDataTable.Rows.Count == 0)
            //    return;
            ListViewGroup listViewGroup = null;
            foreach (var item in querry)
            {
                // Khai báo một GroupListview hiện thị MeterialGroup
                listViewGroup = new ListViewGroup();
                listViewGroup.Name = item.MeterialGroupId.ToString();
                listViewGroup.Header = item.MeterialGroupName;
                listViewMeterialGroup.Groups.Add(listViewGroup);

                LoadSubMeterialGroupByMeterialGroupId(listViewGroup, item.MeterialGroupId);
            }
        }

        private void LoadSubMeterialGroupByMeterialGroupId(ListViewGroup listViewGroup, int meterialGroupId)
        {
            // Khai báo một listviewitem hiện thị sub meterial group
            ListViewItem listViewItem = null;
            if (subMeterialGroupDataTable.Rows.Count == 0)
                return;
            var querry = from row in subMeterialGroupDataTable
                         where row.MeterialGroupId == meterialGroupId
                         select row;

            foreach (var item in querry)
            {
                listViewItem = new ListViewItem();
                listViewItem.Name = item.SubMeterialGroupId.ToString();
                listViewItem.Text = item.SubMeterialGroupName;
                listViewItem.Group = listViewGroup;
                listViewItem.ImageIndex = 0;
                listViewMeterialGroup.Items.Add(listViewItem);
            }
        }

        private void mnAddFoodGroupName_Click(object sender, EventArgs e)
        {
            SubMeterialGroup SubMeterialGroup = new SubMeterialGroup(userFunctionList);
            SubMeterialGroup.reLoadData += new SubMeterialGroup.ReLoadData(LoadAllMeterialGroupAndSubMeterialGroup);
            SubMeterialGroup.ShowDialog();
        }

        private void UserControlStockManagement_Load(object sender, EventArgs e)
        {
            LoadInitilize();
            //LoadAllMeterialGroupAndSubMeterialGroup();
            LogHistories.InsertLogHistories("Vào chức năng quản lý kho", DateTime.Now, userFunctionList.UserName, "");
        }

        private void LoadMeterialBySubMeterialGroupId()
        {
            dgvMeterialMenu.Rows.Clear();
            SubMeterialGroupId = 0;
            try
            {
                SubMeterialGroupId = int.Parse(listViewMeterialGroup.SelectedItems[0].Name);
                SubMterialGroupName = listViewMeterialGroup.SelectedItems[0].Text;
                MeterialGroupId = int.Parse(listViewMeterialGroup.SelectedItems[0].Group.Name);
            }
            catch
            {
                // return;
            }
            // LoadInitilize();
            MeterialDataSet.MeterialUnitAndSubGroupMeterialDataTable meterialUnitAndSubGroupMeterialDataTable = new MeterialDataSet.MeterialUnitAndSubGroupMeterialDataTable();
            meterialsDataTable = new MeterialDataSet.MeterialsDataTable();
            if (cboMeterialGroup.SelectedIndex != 0 | SubMeterialGroupId > 0)
            {
               // dgvMeterialMenu.Columns["MeterialName"].HeaderText = "Tên mặt hàng (Nhóm: " + SubMterialGroupName + ")";
                meterialController.GetBySubMeterialGroupId(meterialUnitAndSubGroupMeterialDataTable, SubMeterialGroupId);
            }
            else
            {
                //dgvMeterialMenu.Columns["MeterialName"].HeaderText = "Tên mặt hàng";
                meterialController.GetMeterialByAll(meterialUnitAndSubGroupMeterialDataTable);
            }
            if (meterialUnitAndSubGroupMeterialDataTable.Rows.Count == 0)
                return;

            var querry = from row in meterialUnitAndSubGroupMeterialDataTable
                         select row;

            if (!string.IsNullOrEmpty(txtItemName.Text))
            {
                querry = querry.Where(r => r.MeterialName.IndexOf(txtItemName.Text, StringComparison.OrdinalIgnoreCase) >= 0);
            }

            dgvMeterialMenu.AllowUserToAddRows = true;
            int index = 0;
            foreach (var item in querry)
            {
                dgvMeterialMenu.Rows.Add();
                DataGridViewRow row = dgvMeterialMenu.Rows[index];
                row.Cells["STT"].Value = index + 1;
                row.Cells["SubGroupMeterialName"].Value = item.SubMeterialGroupName;
                row.Cells["MeterialName"].Value = item.MeterialName;
                row.Cells["Unit"].Value = item.UnitName;
                row.Cells["Total"].Value = item.IsQuantityNull() ? 0 : item.Quantity;
                if (item.Quantity < 4)
                    row.DefaultCellStyle.ForeColor = Color.Red;
                row.Cells["MeterialId"].Value = item.MeterialId;
                row.Cells["SubGroupMeterialId"].Value = item.SubMeterialGroupId;
                index++;
            }
            dgvMeterialMenu.AllowUserToAddRows = false;
        }

        private void listViewMeterialGroup_Click(object sender, EventArgs e)
        {
            LoadMeterialBySubMeterialGroupId();
        }

        private void btnMeterialGroup_Click(object sender, EventArgs e)
        {
            MeterialGroup MeterialGroup = new MeterialGroup(userFunctionList);
            MeterialGroup.reLoadData += new MeterialGroup.ReLoadData(LoadMeterialBySubMeterialGroupId);
            MeterialGroup.ShowDialog();
        }

        private void mnEditFoodGroupName_Click(object sender, EventArgs e)
        {
            UpdateSubMeterialGroup UpdateSubMeterialGroup = new UpdateSubMeterialGroup(MeterialGroupId, SubMeterialGroupId, SubMterialGroupName, userFunctionList);
            UpdateSubMeterialGroup.reLoadData += new UpdateSubMeterialGroup.ReLoadData(LoadAllMeterialGroupAndSubMeterialGroup);
            UpdateSubMeterialGroup.ShowDialog();
        }

        private void btnAddFood_Click(object sender, EventArgs e)
        {
            RegisterMeterial RegisterMeterial = new RegisterMeterial(SubMeterialGroupId, SubMterialGroupName, userFunctionList);
            RegisterMeterial.reLoadData += new RegisterMeterial.ReLoadData(LoadMeterialBySubMeterialGroupId);
            RegisterMeterial.ShowDialog();
        }

        private void btnEditFood_Click(object sender, EventArgs e)
        {
            UpdateMeterialByMeterialId();
        }

        private void UpdateMeterialByMeterialId()
        {
            try
            {
                object meterialId = dgvMeterialMenu.CurrentRow.Cells["MeterialId"].Value;
                SubMeterialGroupId = (int)dgvMeterialMenu.CurrentRow.Cells["SubGroupMeterialId"].Value;
                UpdateMeterial UpdateMeterial = new UpdateMeterial((int)meterialId, SubMeterialGroupId, SubMterialGroupName, userFunctionList);
                UpdateMeterial.reLoadData += new UpdateMeterial.ReLoadData(LoadMeterialBySubMeterialGroupId);
                UpdateMeterial.ShowDialog();
            }
            catch { }
        }

        private void dgvMeterialMenu_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            UpdateMeterialByMeterialId();
        }

        private void btnDeleteFood_Click(object sender, EventArgs e)
        {
            if (dgvMeterialMenu.Rows.Count > 0)
                DeleteMeterialByMeterialId(dgvMeterialMenu.CurrentRow.Index);
        }

        private void DeleteMeterialByMeterialId(int rowIndex)
        {
            int menuId = 0;
            double quantity = -1;
            meterialsDataTable = new MeterialDataSet.MeterialsDataTable();
            string ItemName = string.Empty;

            if (dgvMeterialMenu.Rows[rowIndex].Cells["MeterialId"].Value == null)
                return;

            quantity = (double)dgvMeterialMenu.Rows[rowIndex].Cells["Total"].Value;
            if (quantity > 0)
            {
                MessageBox.Show("Không thể xoá được: Mặt hàng đang còn tồn trong kho.!", Constants.CaptionErrorMessage, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            menuId = int.Parse(dgvMeterialMenu.Rows[rowIndex].Cells["MeterialId"].Value.ToString());

            ItemName = dgvMeterialMenu.Rows[rowIndex].Cells["MeterialName"].Value.ToString();
            DialogResult rst = MessageBox.Show("Bạn có muốn xoá mặt hàng " + ItemName + " này không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (rst != DialogResult.Yes)
                return;

            meterialController.GetByMerterialId(meterialsDataTable, menuId);
            meterialsDataTable.First().Delete();
            try
            {
                meterialController.UpdateMeterial(meterialsDataTable);
                LogHistories.InsertLogHistories("Xoá mặt hàng " + ItemName + " Không thể xoá được: Mặt hàng đang được sử dụng trong menu.!", DateTime.Now, userFunctionList.UserName, "Thành công");
                MessageBox.Show("Xoá thông tin thành công!", Constants.CaptionInformationMessage, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch
            {
                LogHistories.InsertLogHistories("Xoá mặt hàng " + ItemName, DateTime.Now, userFunctionList.UserName, "Lỗi");
                MessageBox.Show("Không thể xoá được: Mặt hàng đang được sử dụng trong menu.!", Constants.CaptionErrorMessage, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            dgvMeterialMenu.Rows.RemoveAt(rowIndex);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            LoadMeterialBySubMeterialGroupId();
        }

        private void btnQuantityAdjusting_Click(object sender, EventArgs e)
        {
            if (dgvMeterialMenu.Rows.Count == 0)
                return;

            int meterialId = (int)dgvMeterialMenu.CurrentRow.Cells["MeterialId"].Value;
            string meterialName = dgvMeterialMenu.CurrentRow.Cells["MeterialName"].Value.ToString();
            string quantity = dgvMeterialMenu.CurrentRow.Cells["Total"].Value.ToString();

            MeterialAdjusting MeterialAdjusting = new MeterialAdjusting(meterialId, meterialName, quantity, userFunctionList);
            MeterialAdjusting.reLoadData += new MeterialAdjusting.ReLoadData(LoadMeterialBySubMeterialGroupId);
            MeterialAdjusting.ShowDialog();
        }

        private void btnImportBill_Click(object sender, EventArgs e)
        {
            ImportBills ImportBills = new ImportBills(userFunctionList);
            ImportBills.reLoadData += new ImportBills.ReLoadData(LoadMeterialBySubMeterialGroupId);
            ImportBills.ShowDialog();
        }

        private void btnExportMeterial_Click(object sender, EventArgs e)
        {
            ExportBills ExportBills = new ExportBills(userFunctionList);
            ExportBills.reLoadData += new ExportBills.ReLoadData(LoadMeterialBySubMeterialGroupId);
            ExportBills.ShowDialog();
        }

        private void btnInventories_Click(object sender, EventArgs e)
        {
            MeterialInventories MeterialInventories = new MeterialInventories(userFunctionList);
            MeterialInventories.ShowDialog();
        }

        private void mnDeleteFoodGroup_Click(object sender, EventArgs e)
        {
            DeleteFoodGroup();
        }

        private void DeleteFoodGroup()
        {
            DialogResult rst = MessageBox.Show("Bạn có muốn xóa danh mục mặt hàng " + SubMterialGroupName + " này không", Constants.CaptionInformationMessage, MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (rst == DialogResult.No)
                return;

            subMeterialGroupDataTable = new SubMeterialGroupDataSet.SubMeterialGroupDataTable();
            subMeterialGroupController.GetBySubMerterialGroupId(subMeterialGroupDataTable, SubMeterialGroupId);
            if (subMeterialGroupDataTable.Rows.Count == 0)
                return;
            subMeterialGroupDataTable.First().Delete();
            try
            {
                subMeterialGroupController.UpdateSubMeterialGroup(subMeterialGroupDataTable);
                LogHistories.InsertLogHistories("Xóa danh mục mặt hàng " + SubMterialGroupName, DateTime.Now, userFunctionList.UserName, "Thành công");
                MessageBox.Show("Xóa phân nhóm nguyên liệu thành công", Constants.CaptionInformationMessage, MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadAllMeterialGroupAndSubMeterialGroup();
            }
            catch
            {
                LogHistories.InsertLogHistories("Xóa danh mục mặt hàng " + SubMterialGroupName, DateTime.Now, userFunctionList.UserName, "Lỗi");
                MessageBox.Show("Xóa phân nhóm nguyên liệu thành công", Constants.CaptionInformationMessage, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void cboMeterialGroup_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadAllMeterialGroupAndSubMeterialGroup();
            LoadMeterialBySubMeterialGroupId();
        }
    }
}

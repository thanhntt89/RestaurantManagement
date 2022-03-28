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

        public UserControlStockManagement()
        {
            InitializeComponent();
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

            if (meterialGroupDataTable.Rows.Count == 0)
                return;
            ListViewGroup listViewGroup = null;
            foreach (MeterialGroupDataSet.MeterialGroupRow item in meterialGroupDataTable.Rows)
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
            // Lấy về danh sách nhóm con của nguyên liệu
            subMeterialGroupDataTable = new SubMeterialGroupDataSet.SubMeterialGroupDataTable();
            subMeterialGroupController.GetBySunMeterialGroupAll(subMeterialGroupDataTable);
            if (subMeterialGroupDataTable.Rows.Count == 0)
                return;
            // Khai báo một listviewitem hiện thị sub meterial group
            ListViewItem listViewItem = null;

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
            SubMeterialGroup SubMeterialGroup = new SubMeterialGroup();
            SubMeterialGroup.reLoadData += new SubMeterialGroup.ReLoadData(LoadAllMeterialGroupAndSubMeterialGroup);
            SubMeterialGroup.ShowDialog();
        }

        private void UserControlStockManagement_Load(object sender, EventArgs e)
        {
            LoadAllMeterialGroupAndSubMeterialGroup();
        }

        private void LoadMeterialBySubMeterialGroupId()
        {
            dgvMeterialMenu.Rows.Clear();

            try
            {
                SubMeterialGroupId = int.Parse(listViewMeterialGroup.SelectedItems[0].Name);
                SubMterialGroupName = listViewMeterialGroup.SelectedItems[0].Text;
                MeterialGroupId = int.Parse(listViewMeterialGroup.SelectedItems[0].Group.Name);
            }
            catch
            {
                return;
            }

            dgvMeterialMenu.Columns["MeterialName"].HeaderText = "Tên mặt hàng (Nhóm: " + SubMterialGroupName + ")";
            MeterialDataSet.MeterialUnitAndSubGroupMeterialDataTable meterialUnitAndSubGroupMeterialDataTable = new MeterialDataSet.MeterialUnitAndSubGroupMeterialDataTable();
            meterialsDataTable = new MeterialDataSet.MeterialsDataTable();
            meterialController.GetBySubMeterialGroupId(meterialUnitAndSubGroupMeterialDataTable, SubMeterialGroupId);

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
                row.Cells["MeterialName"].Value = item.MeterialName;
                row.Cells["Unit"].Value = item.UnitName;
                row.Cells["Total"].Value = item.IsQuantityNull() ? 0 : item.Quantity;
                row.Cells["MeterialId"].Value = item.MeterialId;
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
            MeterialGroup MeterialGroup = new MeterialGroup();
            MeterialGroup.reLoadData += new MeterialGroup.ReLoadData(LoadMeterialBySubMeterialGroupId);
            MeterialGroup.ShowDialog();
        }

        private void mnEditFoodGroupName_Click(object sender, EventArgs e)
        {
            try
            {
                UpdateSubMeterialGroup UpdateSubMeterialGroup = new UpdateSubMeterialGroup(MeterialGroupId, SubMeterialGroupId, SubMterialGroupName);
                UpdateSubMeterialGroup.reLoadData += new UpdateSubMeterialGroup.ReLoadData(LoadAllMeterialGroupAndSubMeterialGroup);
                UpdateSubMeterialGroup.ShowDialog();
            }
            catch
            {
            }
        }

        private void btnAddFood_Click(object sender, EventArgs e)
        {
            RegisterMeterial RegisterMeterial = new RegisterMeterial(SubMeterialGroupId, SubMterialGroupName);
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
                UpdateMeterial UpdateMeterial = new UpdateMeterial((int)meterialId, SubMeterialGroupId, SubMterialGroupName);
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
                MessageBox.Show("Xoá thông tin thành công!", Constants.CaptionInformationMessage, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch
            {
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

            MeterialAdjusting MeterialAdjusting = new MeterialAdjusting(meterialId, meterialName, quantity);
            MeterialAdjusting.reLoadData += new MeterialAdjusting.ReLoadData(LoadMeterialBySubMeterialGroupId);
            MeterialAdjusting.ShowDialog();
        }

        private void btnImportBill_Click(object sender, EventArgs e)
        {
            ImportBills ImportBills = new ImportBills();
            ImportBills.ShowDialog();
        }
    }
}

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
    public partial class UpdateMenu : DevComponents.DotNetBar.Metro.MetroForm
    {
        public delegate void ReLoadData();
        public event ReLoadData reLoadData;

        private int menuGroupId = 0;
        private int subGroupId = 0;
        private string subGroupName = string.Empty;
        private string menuGroupName = string.Empty;
        private int menuId = 0;

        private MenuDataSet.MenuDataTable MenuDataTable = null;
        private MenuController menuController = new MenuController();
        private UnitDataSet.UnitDataTable UnitDataTable = null;
        private UnitController unitController = new UnitController();

        private MenuMeterialsDataSet.MenuMaterialsDataTable menuMaterialsDataTable = null;
        private MenuMeterialController menuMeterialController = new MenuMeterialController();

        private MenuMeterialsDataSet.MenuMeterialDetailDataTable menuMeterialDetailDataTable = null;

        private MeterialDataSet.MeterialsDataTable meterialsDataTable = null;
        private MeterialController meterialController = new MeterialController();

        private UserFunctionList userFunctionList = null;

        public UpdateMenu(int menuId, int idSubGroup, int menuGrouId, string subGroupName, string ParentNodeName, UserFunctionList userFunctionList)
        {
            InitializeComponent();
            this.menuId = menuId;
            this.subGroupId = idSubGroup;
            this.subGroupName = subGroupName;
            this.menuGroupName = ParentNodeName;
            this.userFunctionList = userFunctionList;
        }

        public UpdateMenu()
        {
            InitializeComponent();
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void EditFood_Load(object sender, EventArgs e)
        {
            LoadUpdate();
        }

        private void LoadUpdate()
        {
            this.Text = "Cập nhật thực đơn nhóm " + menuGroupName;
            txtSubGroupMenu.Text = subGroupName;
            LoadAllUnit();
            LoadMenuByMenuId(menuId);
            LoadMeterialByMenuId(menuId);
            LoadAllMeterial();
        }

        private void LoadAllUnit()
        {
            UnitDataTable = new UnitDataSet.UnitDataTable();
            unitController.GetAllUnit(UnitDataTable);
            if (UnitDataTable.Rows.Count == 0)
                return;

            cboUnit.DataSource = UnitDataTable;
            cboUnit.DisplayMembers = UnitDataTable.UnitNameColumn.ColumnName;
            cboUnit.ValueMember = UnitDataTable.UnitIdColumn.ColumnName;
        }

        private void LoadAllMeterial()
        {
            meterialsDataTable = new MeterialDataSet.MeterialsDataTable();
            meterialController.GetMeterialByAll(meterialsDataTable);

            if (meterialsDataTable.Rows.Count == 0)
                return;
            var newRow = meterialsDataTable.NewMeterialsRow();
            newRow.MeterialId = -1;
            newRow.MeterialCode = string.Empty;
            newRow.MeterialName = string.Empty;
            newRow.Quantity = 0;
            newRow.Note = string.Empty;
            newRow.UnitId = -1;
            newRow.SubMeterialGroupId = -1;

            meterialsDataTable.Rows.InsertAt(newRow, 0);

            cboMeterial.DataSource = meterialsDataTable;
            cboMeterial.DisplayMember = meterialsDataTable.MeterialNameColumn.ColumnName;
            cboMeterial.ValueMember = meterialsDataTable.MeterialIdColumn.ColumnName;
        }

        private void LoadMenuByMenuId(int menuId)
        {
            MenuDataTable = new MenuDataSet.MenuDataTable();
            menuController.GetMenuByMenuId(MenuDataTable, menuId);
            if (MenuDataTable.Rows.Count == 0)
                return;
            txtCost.Value = MenuDataTable.First().Cost;
            txtNote.Text = MenuDataTable.First().Field<string>("Note");
            txtOriginalCost.Value = MenuDataTable.First().OriginalCost;
            txtFoodName.Text = MenuDataTable.First().ItemName;
            cboUnit.SelectedValue = MenuDataTable.First().UnitId;
            ptbImage.Image = MenuDataTable.First().IsImageMenuNull() ? null : Utilities.ConvertByteToImage(MenuDataTable.First().ImageMenu);
        }

        private bool CheckItem()
        {
            if (string.IsNullOrEmpty(txtFoodName.Text))
            {
                txtFoodName.Focus();
                MessageBox.Show("Tên thực đơn không được để trống", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (txtOriginalCost.Value < 0)
            {
                txtOriginalCost.Focus();
                MessageBox.Show("Giá chế biến không để trống.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (txtCost.Value < 0)
            {
                txtCost.Focus();
                MessageBox.Show("Giá thực đơn không để trống.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            for (int i = 0; i < dgvMeterial.Rows.Count; i++)
            {
                if (double.Parse(dgvMeterial.Rows[i].Cells["Quantity"].Value.ToString()) <= 0)
                {
                    MessageBox.Show("Định lượng nguyên liệu không để trống.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            return true;
        }

        private void UpdateMenuItem(int menuId)
        {
            if (!CheckItem())
                return;

            MenuDataTable = new MenuDataSet.MenuDataTable();
            menuController.GetMenuByMenuId(MenuDataTable, menuId);
            if (MenuDataTable.Rows.Count == 0)
                return;
            MenuDataTable.First().ItemName = txtFoodName.Text;
            MenuDataTable.First().Cost = txtCost.Value;
            MenuDataTable.First().Note = txtNote.Text;
            MenuDataTable.First().UnitId = int.Parse(cboUnit.SelectedValue.ToString());
            MenuDataTable.First().ImageMenu = ptbImage.Image == null ? null : Utilities.ConvertImageToByte(ptbImage.Image);
            MenuDataTable.First().OriginalCost = txtOriginalCost.Value;
            try
            {
                menuController.UpdateMenu(MenuDataTable);
                SaveMenuMeterial(menuId);
                LogHistories.InsertLogHistories("Cập thực đơn " + txtFoodName.Text, DateTime.Now, userFunctionList.UserName, "Thành công");
                reLoadData();
               // MessageBox.Show("Cập thực đơn thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch
            {
                LogHistories.InsertLogHistories("Cập thực đơn " + txtFoodName.Text, DateTime.Now, userFunctionList.UserName, "Lỗi");
                MessageBox.Show("Không cập được nhật thực đơn.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            this.Close();
        }

        private void LoadMeterialByMenuId(int menuId)
        {
            menuMeterialDetailDataTable = new MenuMeterialsDataSet.MenuMeterialDetailDataTable();
            menuMeterialController.GetMenuMeterialByMenuId(menuMeterialDetailDataTable, menuId);

            int indexRow = 0;

            foreach (MenuMeterialsDataSet.MenuMeterialDetailRow item in menuMeterialDetailDataTable.Rows)
            {
                AddNewMeterial(indexRow, item.UnitId, item.MeterialId, item.MeterialName, item.MeterialQuatity, item.MenuMeterialId);
                indexRow++;
            }
        }

        private void btnAddFood_Click(object sender, EventArgs e)
        {
            UpdateMenuItem(menuId);
        }

        private void btnImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog openfileDialog = new OpenFileDialog();
            Utilities.ConvertImgeToByte(openfileDialog, ptbImage);
        }

        private void btnUnit_Click(object sender, EventArgs e)
        {
            MeterialManagement MeterialManagement = new MeterialManagement(userFunctionList);
            MeterialManagement.reLoadData += new MeterialManagement.ReLoadData(LoadAllUnit);
            MeterialManagement.ShowDialog();
        }

        private void InsertMeterial()
        {
            DataRowView row = (DataRowView)cboMeterial.SelectedItem;
            int unitId = row.Row.Field<int>("UnitId");
            int indexMax = dgvMeterial.Rows.Count;
            int meterialId = int.Parse(cboMeterial.SelectedValue.ToString());
            bool isExist = false;

            // Kiểm tra xem MenuId đã tồn tại hay chưa, nếu chưa có thì tiến hành thêm mới, ngược lại thì update thêm số lượng
            for (int i = 0; i < dgvMeterial.Rows.Count; i++)
            {
                // Nếu tồn tại thực đơn trong danh sách rồi thì cập nhật
                if (dgvMeterial.Rows[i].Cells["MeterialId"].Value.ToString().Equals(meterialId.ToString()))
                {
                    MessageBox.Show("Nguyên liệu này đã có bạn hãy điều chỉnh lại định lượng trên bảng", Constants.CaptionInformationMessage, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }

            //Trường hợp đây là thực đơn mới
            if (!isExist)
            {
                AddNewMeterial(indexMax, unitId, meterialId, cboMeterial.Text, 0, -1);
            }
        }

        private void AddNewMeterial(int IndexMax, int unitId, int meterialId, string meterialName, double quantity, int menuMeterialId)
        {
            string unitName = UnitDataTable.FindByUnitId(unitId).UnitName;
            dgvMeterial.AllowUserToAddRows = true;
            // Thực hiện thêm một dòng mới
            dgvMeterial.Rows.Add();

            // Khai báo biến hàng mới cho bảng
            DataGridViewRow Rows = dgvMeterial.Rows[IndexMax];

            // Gán các giá trị vào từng cột tương ứng của hàng vừa thêm
            Rows.Cells["STT"].Value = IndexMax + 1;
            Rows.Cells["MeterialName"].Value = meterialName;
            Rows.Cells["Quantity"].Value = quantity;
            Rows.Cells["UnitName"].Value = unitName;
            Rows.Cells["MeterialId"].Value = meterialId;
            Rows.Cells["MenuMeterialId"].Value = menuMeterialId;

            // Khoá tính năng cho phép thêm dòng
            dgvMeterial.AllowUserToAddRows = false;
            dgvMeterial.Rows[IndexMax].Selected = true;
        }


        private void SaveMenuMeterial(int menuId)
        {
            menuMaterialsDataTable = new MenuMeterialsDataSet.MenuMaterialsDataTable();
            int menuMeterialId = 0;
            int meterialId = 0;
            double quantity = 0;

            for (int i = 0; i < dgvMeterial.Rows.Count; i++)
            {
                menuMeterialId = (int)dgvMeterial.Rows[i].Cells["MenuMeterialId"].Value;
                meterialId = (int)dgvMeterial.Rows[i].Cells["MeterialId"].Value;
                quantity = double.Parse(dgvMeterial.Rows[i].Cells["Quantity"].Value.ToString());
                //Thêm mới
                if (menuMeterialId == -1)
                {
                    var newRow = menuMaterialsDataTable.NewMenuMaterialsRow();
                    newRow.MenuId = menuId;
                    newRow.MeterialId = meterialId;
                    newRow.MeterialQuatity = quantity;
                    newRow.Note = string.Empty;

                    menuMaterialsDataTable.AddMenuMaterialsRow(newRow);
                    try
                    {
                        menuMeterialController.UpdateMenuMeterial(menuMaterialsDataTable);
                    }
                    catch
                    {
                        MessageBox.Show("Lỗi thêm thực đơn thành công.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                else // Cập nhật
                {

                    menuMeterialController.GetMenuMeterialByMenuMeterialId(menuMaterialsDataTable,menuMeterialId);

                    if (menuMaterialsDataTable.Rows.Count == 0)
                        continue;
                    menuMaterialsDataTable.First().MeterialQuatity = quantity;

                    try
                    {
                        menuMeterialController.UpdateMenuMeterial(menuMaterialsDataTable);
                        LogHistories.InsertLogHistories("Cập nhật nguyên liệu " + dgvMeterial.Rows[i].Cells["MeterialName"].Value.ToString() + " cho thực đơn: " + txtFoodName.Text, DateTime.Now, userFunctionList.UserName, "Thành công");
                    }
                    catch
                    {
                        LogHistories.InsertLogHistories("Cập nhật nguyên liệu " + dgvMeterial.Rows[i].Cells["MeterialName"].Value.ToString() + " cho thực đơn: " + txtFoodName.Text, DateTime.Now, userFunctionList.UserName, "Lỗi");
                        MessageBox.Show("Thêm mới nhóm " + dgvMeterial.Rows[i].Cells["MeterialName"].Value.ToString() + " không thành công!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
            }

            MessageBox.Show("Cập nhật thực đơn thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void cboMeterial_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboMeterial.SelectedIndex == 0)
            {
                return;
            }
            InsertMeterial();
        }

        private void DeleteMeterial(int indexRow)
        {
            int menuMeterialId = 0;
            menuMaterialsDataTable = new MenuMeterialsDataSet.MenuMaterialsDataTable();
            string meterialName = string.Empty;
            int rowCount = dgvMeterial.Rows.Count;

            meterialName = dgvMeterial.Rows[indexRow].Cells["MeterialName"].Value.ToString();

            DialogResult rst = MessageBox.Show("Bạn có muốn xoá vùng " + meterialName + " này không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (rst != DialogResult.Yes)
                return;

            // Xoá trong database nếu có
            if ((int)dgvMeterial.Rows[indexRow].Cells["MenuMeterialId"].Value != -1)
            {
                menuMeterialId = int.Parse(dgvMeterial.Rows[indexRow].Cells["MenuMeterialId"].Value.ToString());

                menuMeterialController.GetMenuMeterialByMenuMeterialId(menuMaterialsDataTable, menuMeterialId);
                menuMaterialsDataTable.First().Delete();
                try
                {
                    menuMeterialController.UpdateMenuMeterial(menuMaterialsDataTable);
                    LogHistories.InsertLogHistories("Xóa nguyên liệu " + meterialName, DateTime.Now, userFunctionList.UserName, "Thành công");

                    MessageBox.Show("Xoá thông tin thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch
                {
                    LogHistories.InsertLogHistories("Xóa nguyên liệu " + meterialName, DateTime.Now, userFunctionList.UserName, "Lỗi");
                    MessageBox.Show("Không xóa được nguyên liệu này!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            dgvMeterial.Rows.RemoveAt(indexRow);
        }

        private void dgvMeterial_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex != 4)
                return;

            DeleteMeterial(e.RowIndex);
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Enter)
                btnAddFood_Click(null, null);
            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
}

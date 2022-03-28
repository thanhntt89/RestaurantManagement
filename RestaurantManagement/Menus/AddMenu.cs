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
    public partial class AddMenu : DevComponents.DotNetBar.Metro.MetroForm
    {
        public delegate void ReLoadData();
        public event ReLoadData reLoadData;

        private int subGroupId = 0;
        private string subGroupName = string.Empty;
        private string menuGroupName = string.Empty;

        private MenuDataSet.MenuDataTable MenuDataTable = null;
        private MenuController menuController = new MenuController();
        private UnitDataSet.UnitDataTable UnitDataTable = null;
        private UnitController unitController = new UnitController();

        private MeterialDataSet.MeterialsDataTable meterialsDataTable = null;
        private MeterialController meterialController = new MeterialController();

        private MenuMeterialsDataSet.MenuMaterialsDataTable menuMaterialsDataTable = null;
        private MenuMeterialController menuMeterialController = new MenuMeterialController();

        private UserFunctionList userFunctionList;


        public AddMenu(int idSubGroup, string subGroupName, string ParentNodeName, UserFunctionList userFunctionList)
        {
            InitializeComponent();
            this.subGroupId = idSubGroup;
            this.subGroupName = subGroupName;
            this.menuGroupName = ParentNodeName;
            this.userFunctionList = userFunctionList;
        }
        public AddMenu()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AddFood_Load(object sender, EventArgs e)
        {
            LoadInfor();
        }

        private void LoadInfor()
        {
            this.Text = "Thêm thực đơn nhóm " + menuGroupName;
            txtSubGroupMenu.Text = subGroupName;
            LoadAllUnit();
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

        private void btnClose_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAddMenu_Click(object sender, EventArgs e)
        {
            AddMenuItem();
        }

        private bool CheckItem()
        {
            if (string.IsNullOrEmpty(txtFoodName.Text))
            {
                txtFoodName.Focus();
                MessageBox.Show("Tên thực đơn không được để trống", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (txtCost.Value < 0)
            {
                txtCost.Focus();
                MessageBox.Show("Giá thực đơn không để trống.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (txtOriginalCost.Value < 0)
            {
                txtOriginalCost.Focus();
                MessageBox.Show("Giá chế biến không để trống.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void AddMenuItem()
        {
            if (!CheckItem())
                return;

            MenuDataTable = new MenuDataSet.MenuDataTable();
            menuController.GetMaxMenuId(MenuDataTable);

            int menuId = MenuDataTable.First().MenuId + 1;

            MenuDataTable = new MenuDataSet.MenuDataTable();
            var newRow = MenuDataTable.NewMenuRow();

            newRow.MenuId = menuId;
            newRow.SubGroupId = subGroupId;
            newRow.ItemName = txtFoodName.Text;
            newRow.Cost = txtCost.Value;
            newRow.OriginalCost = txtOriginalCost.Value;
            newRow.Note = txtNote.Text;
            newRow.UnitId = int.Parse(cboUnit.SelectedValue.ToString());
            newRow.ImageMenu = ptbImage.Image == null ? null : Utilities.ConvertImageToByte(ptbImage.Image);

            MenuDataTable.AddMenuRow(newRow);

            try
            {
                LogHistories.InsertLogHistories("Thêm thực đơn " + txtFoodName.Text, DateTime.Now, userFunctionList.UserName, "Thành công");
                menuController.UpdateMenu(MenuDataTable);
                SaveMenuMeterial(menuId);
                reLoadData();
                Clean();
            }
            catch
            {
                LogHistories.InsertLogHistories("Cập nhật thực đơn " + txtFoodName.Text, DateTime.Now, userFunctionList.UserName, "Lỗi");
                MessageBox.Show("Không cập được nhật thực đơn.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);

                MenuDataTable = new MenuDataSet.MenuDataTable();
                menuController.GetMenuByMenuId(MenuDataTable,menuId);
                if (MenuDataTable.Rows.Count == 0)
                    return;

                MenuDataTable.First().Delete();
                menuController.UpdateMenu(MenuDataTable);
            }
        }

        private void btnImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog openfileDialog = new OpenFileDialog();
            Utilities.ConvertImgeToByte(openfileDialog, ptbImage);
        }

        private void Clean()
        {
            dgvMeterial.Rows.Clear();
            txtFoodName.Focus();
            txtOriginalCost.Value = 0;
            txtFoodName.Text = string.Empty;
            txtNote.Text = string.Empty;
            txtCost.Value = 0;
            ptbImage.Image = null;
        }

        private void btnUnit_Click(object sender, EventArgs e)
        {
            MeterialManagement MeterialManagement = new MeterialManagement(userFunctionList);
            MeterialManagement.reLoadData += new MeterialManagement.ReLoadData(LoadAllUnit);
            MeterialManagement.ShowDialog();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Enter)
                btnAddMenu_Click(null, null);
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void cboMeterial_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboMeterial.SelectedIndex == 0)
            {
                return;
            }
            InsertMeterial();
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
                AddNewMeterial(indexMax, unitId, meterialId, cboMeterial.Text);
            }
        }

        private void AddNewMeterial(int IndexMax, int unitId, int meterialId, string meterialName)
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
            Rows.Cells["Quantity"].Value = 0;
            Rows.Cells["UnitName"].Value = unitName;
            Rows.Cells["MeterialId"].Value = meterialId;

            // Khoá tính năng cho phép thêm dòng
            dgvMeterial.AllowUserToAddRows = false;
            dgvMeterial.Rows[IndexMax].Selected = true;
        }

        private void dgvMeterial_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex != 4)
                return;
            dgvMeterial.Rows.RemoveAt(e.RowIndex);
        }

        private void SaveMenuMeterial(int menuId)
        {
            menuMaterialsDataTable = new MenuMeterialsDataSet.MenuMaterialsDataTable();
            
            for (int i = 0; i < dgvMeterial.Rows.Count; i++)
            {
                var newRow = menuMaterialsDataTable.NewMenuMaterialsRow();
                newRow.MenuId = menuId;
                newRow.MeterialId = int.Parse(dgvMeterial.Rows[i].Cells["MeterialId"].Value.ToString());
                newRow.MeterialQuatity = double.Parse(dgvMeterial.Rows[i].Cells["Quantity"].Value.ToString());
                newRow.Note = string.Empty;

                menuMaterialsDataTable.AddMenuMaterialsRow(newRow);
            }
            try
            {
                menuMeterialController.UpdateMenuMeterial(menuMaterialsDataTable);
                MessageBox.Show("Thêm thực đơn thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch
            {
                MessageBox.Show("Lỗi thêm thực đơn thành công.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using RestaurantDTO;
using RestaurantController;
using System.IO;
using System.Net;
using System.Runtime.Serialization.Formatters.Binary;
using DevComponents.DotNetBar.Controls;
using RestaurantCommon;

namespace RestaurantManagement
{
    public partial class UserControlMainServices : UserControl
    {
        #region Khai báo tham số đặt bàn ăn
        private CustomerController customerController = new CustomerController();
        private CustomerDataSet.CustomersDataTable customersDataTable = null;

        private RegionalDataSet.RegionalDataTable RegionalDataTable = null;
        private RegionalController regionalController = new RegionalController();
        private TablesDataSet.TablesDataTable tablesDataTable = null;
        private TablesController tablesController = new TablesController();
        private BillController BillController = new BillController();
        private BillsDataSet.BillDataTable billDataTable = null;
        private BillDetailDataSet.BillDetailDataTable BillDetailDataTable = null;
        private BillDetailController billDetailController = new BillDetailController();

        private RestaurantInforController restaurantInforController = new RestaurantInforController();
        private RestaurantInforDataSet.RestaurantInforDataTable restaurantInforDataTable = null;

        private int tableImageIndex = -1;
        private int tableIndex = -1;
        private int tableId = -1;
        private string tableName = string.Empty;
        private int regionalId = -1;
        private string regionalName = string.Empty;
        private string billId = string.Empty;
        private bool isTrial = false;
        #endregion

        private UserFunctionList userFunctionList = null;
        #region Xử lý đặt bàn ăn

        public UserControlMainServices(bool isTrial, UserFunctionList userFunctionList)
        {
            InitializeComponent();
            this.isTrial = isTrial;
            this.userFunctionList = userFunctionList;
            CheckRole();
        }

        private void CheckRole()
        {
            mnAddNewTable.Visible = false;
            mnRegionalManagement.Visible = false;
            mnDeleteTable.Visible = false;
            mnChangedTable.Visible = false;
            mnMovingTable.Visible = false;
            if (userFunctionList.RoleId == 0)
                cboStaff.Enabled = false;

            if (userFunctionList.Services[0].Add == 1)
            {
                mnAddNewTable.Visible = true;
                mnRegionalManagement.Visible = true;
            }
            if (userFunctionList.Services[0].Edit == 1)
            {
                mnChangedTable.Visible = true;
                mnMovingTable.Visible = true;
            }
            if (userFunctionList.Services[0].Delete == 1)
            {
                mnDeleteTable.Visible = true;
            }
        }

        public UserControlMainServices()
        {
            InitializeComponent();
        }

        private void btnPay_Click(object sender, EventArgs e)
        {
            CheckOut();
        }

        private void mnUsingTable_Click(object sender, EventArgs e)
        {
            CreateBill(tableId);
        }

        private void LoadAllShift()
        {
            ShiftDataSet.ShiftsDataTable ShiftsDataTable = new ShiftDataSet.ShiftsDataTable();
            ShiftsController ShiftsController = new ShiftsController();
            ShiftsController.GetAllShift(ShiftsDataTable);
            if (ShiftsDataTable.Rows.Count == 0)
                return;
            cboShift.DataSource = ShiftsDataTable;
            cboShift.DisplayMembers = ShiftsDataTable.ShiftNameColumn.ColumnName;
            cboShift.ValueMember = ShiftsDataTable.ShiftIdColumn.ColumnName;
            cboShift.Text = string.Empty;
        }

        private void LoadRestaurantInfor()
        {
            restaurantInforDataTable = new RestaurantInforDataSet.RestaurantInforDataTable();
            restaurantInforController.GetAllRestaurantInforByRestaurantInforId(restaurantInforDataTable, 1);
            if (restaurantInforDataTable.Rows.Count == 0)
                return;

            txtRestaurentName.Text = restaurantInforDataTable.First().Field<string>("RestaurantName");
            lbRestaurentMobile.Text = restaurantInforDataTable.First().Field<string>("RestaurantMobile");
            lbRestaurentAddress.Text = restaurantInforDataTable.First().Field<string>("RestaurantAddress");
            ptbLogo.Image = restaurantInforDataTable.First().IsRestaurantLogoNull() ? null : Utilities.ConvertByteToImage(restaurantInforDataTable.First().RestaurantLogo);
        }

        /// <summary>
        /// Đặt thuộc tính cho bàn 
        /// </summary>
        /// <param name="tableId">Mã bàn</param>
        /// <param name="status">0 Trạng thái chưa sử dụng| 1 Trạng thái bàn đang sử dụng </param>
        private void SetTableStatus(int tableId, int status)
        {
            try
            {
                listViewTables.SelectedItems[0].ImageIndex = status;
            }
            catch
            {
                MessageBox.Show("Bạn chưa chọn mục nào để thao tác", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            // Chuyển bàn sang trạng thái không sử dụng
            if (status == 0)
            {
                DisableButton();
            }
            else
            {
                EnableButton();
            }

            // Cập nhật trạng thái vào database
            tablesDataTable = new TablesDataSet.TablesDataTable();
            tablesController.GetAllTableByTableId(tablesDataTable, tableId);
            if (tablesDataTable.Rows.Count == 0)
                return;
            tablesDataTable.First().Status = status;
            try
            {
                tablesController.UpdateTable(tablesDataTable);
                LogHistories.InsertLogHistories("Chuyển bàn " + tableId + " về trạng thái free sau khi thanh toán hóa đơn bán hàng mã hóa đơn: " + billCode, DateTime.Now, userFunctionList.UserName, "Thành công");
            }
            catch
            {
                LogHistories.InsertLogHistories("Chuyển bàn " + tableId + " về trạng thái free sau khi thanh toán hóa đơn bán hàng mã hóa đơn: " + billCode, DateTime.Now, userFunctionList.UserName, "Lỗi");
            }
        }

        private void contextMenuStripTableStatus_Opening(object sender, CancelEventArgs e)
        {
            //GetTableInfor();
        }

        private void GetTableInfor()
        {
            try
            {
                tableImageIndex = listViewTables.SelectedItems[0].ImageIndex;

                // Nếu bàn chưa sử dụng
                if (tableImageIndex == 0)
                {
                    DisableMouseRightMenuClick();
                    mnCanncel.Enabled = false;
                    mnUsingTable.Enabled = true;
                }
                // Nếu bàn đang sử dụng
                else
                {
                    EnableMouseRightMenuClick();
                    mnCanncel.Enabled = true;
                    mnUsingTable.Enabled = false;
                }
                tableIndex = listViewTables.SelectedItems[0].Index;
                tableId = int.Parse(listViewTables.SelectedItems[0].Name);
                tableName = listViewTables.SelectedItems[0].Text;
                regionalName = listViewTables.SelectedItems[0].Group.Header;
                regionalId = int.Parse(listViewTables.SelectedItems[0].Group.Name);
            }
            catch { }
        }

        private void LoadAllTable()
        {
            listViewTables.Groups.Clear();
            listViewTables.Items.Clear();
            RegionalDataTable = new RegionalDataSet.RegionalDataTable();
            tablesDataTable = new TablesDataSet.TablesDataTable();
            ListViewGroup lisViewGroup = null;
            ListViewItem listViewItem = null;
            // Lấy về thông tin vùng
            regionalController.GetAllRegional(RegionalDataTable);

            if (RegionalDataTable.Rows.Count == 0)
                return;

            // Lấy thông tin bàn theo vùng
            foreach (RegionalDataSet.RegionalRow row in RegionalDataTable.Rows)
            {
                // Hiện thị vùng lên listView
                tablesController.GetAllTableByRegionalId(tablesDataTable, row.RegionalId);

                // Thêm nhóm
                lisViewGroup = new ListViewGroup(row.RegionalId.ToString(), row.RegionalName);

                // Thêm nhóm vào listView
                listViewTables.Groups.Add(lisViewGroup);
                // Nếu không có bàn nào thì tiếp tục chuyển sang vùng tiếp theo
                if (tablesDataTable.Rows.Count == 0)
                    continue;

                //// Thêm item vào cho listView
                foreach (TablesDataSet.TablesRow item in tablesDataTable.Rows)
                {
                    listViewItem = new ListViewItem();
                    listViewItem.Name = item.TableId.ToString();
                    listViewItem.Text = item.TableName;
                    listViewItem.Group = lisViewGroup;
                    if (item.Status == 0)
                        listViewItem.ImageIndex = 0;
                    else if (item.Status == 1)
                        listViewItem.ImageIndex = 1;
                    listViewTables.Items.Add(listViewItem);
                }
            }
        }

        private void UserControlMainServices_Load(object sender, EventArgs e)
        {
            LoadInitialize();
        }

        private void LoadInitialize()
        {
            LoadAllTable();
            LoadAllShift();
            LoadStaffAll();
            LoadAllMenuGroup();
            LoadAllMenu();
            LoadRestaurantInfor();
            LoadAllCustomer();
        }

        private void mnAddNewTable_Click(object sender, EventArgs e)
        {
            AddTable AddTable = new AddTable(isTrial);
            AddTable.reLoadData += new AddTable.ReLoadData(LoadAllTable);
            AddTable.ShowDialog();
        }

        private void mnChangedTableName_Click(object sender, EventArgs e)
        {
            EditTableName EditTableName = new EditTableName(tableId, tableName);
            EditTableName.reLoadData += new EditTableName.ReLoadData(LoadAllTable);
            EditTableName.ShowDialog();
        }

        private void mnRegionalManagement_Click(object sender, EventArgs e)
        {
            RegionalManagement RegionalManagement = new RegionalManagement(userFunctionList);
            RegionalManagement.reLoadData += new RegionalManagement.ReLoadData(LoadAllTable);
            RegionalManagement.ShowDialog();
        }

        private void mnMovingTable_Click(object sender, EventArgs e)
        {
            MovingTableInRegional MovingTable = new MovingTableInRegional(tableId, regionalId, tableName, regionalName);
            MovingTable.reLoadData += new MovingTableInRegional.ReLoadData(LoadAllTable);
            MovingTable.ShowDialog();
        }

        private void mnDeleteTable_Click(object sender, EventArgs e)
        {
            DeleteTable();
        }

        private void DisableMouseRightMenuClick()
        {
            mnPayOut.Enabled = false;
            mnCanncel.Enabled = false;
            mnChangedTable.Enabled = false;
            mnBillPlus.Enabled = false;
            mnBillDiv.Enabled = false;
        }

        private void EnableMouseRightMenuClick()
        {
            mnPayOut.Enabled = true;
            mnCanncel.Enabled = true;
            mnChangedTable.Enabled = true;
            mnBillPlus.Enabled = true;
            mnBillDiv.Enabled = true;

        }

        private void DeleteTable()
        {
            if (tableId == -1 || tableIndex == -1)
                return;

            DialogResult rst = MessageBox.Show("Bạn có muốn xoá bàn " + tableName + " này không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (rst != DialogResult.Yes)
                return;

            tablesDataTable = new TablesDataSet.TablesDataTable();
            tablesController.GetAllTableByTableId(tablesDataTable, tableId);
            if (tablesDataTable.Rows.Count == 0)
                return;
            tablesDataTable.First().Delete();
            try
            {
                tablesController.UpdateTable(tablesDataTable);
                listViewTables.Items.RemoveAt(tableIndex);
                MessageBox.Show("Xoá bàn thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch
            {
                MessageBox.Show("Bàn đang có hoá đơn bạn không thể xoá được!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void mnCanncel_Click(object sender, EventArgs e)
        {
            CanncelUsingTable(tableId);
        }
        private void ClearBill()
        {
            txtBillCode.Text = string.Empty;
            cboCustomerName.Text = string.Empty;
            //txtNote.Text = string.Empty;
            txtTableResgional.Text = string.Empty;
            txtMobile.Text = string.Empty;
            dgbBill.Rows.Clear();
        }

        private bool CheckItem()
        {
            //if (!Utilities.CheckMaxLength("Ghi chú", txtNote.Text, 200))
            //{
            //    txtNote.Focus();
            //    return false;
            //}

            return true;
        }

        private void CanncelUsingTable(int tableId)
        {
            DialogResult rst = MessageBox.Show("Bạn có muốn huỷ hoá đơn thanh toán của bàn " + txtTableResgional.Text + " này không?", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (rst != DialogResult.Yes)
                return;

            int menuId = 0;
            double quantity = 0;
            for (int i = 0; i < dgbBill.Rows.Count; i++)
            {
                menuId = (int)dgbBill.Rows[i].Cells["MenuId"].Value;
                quantity = double.Parse(dgbBill.Rows[i].Cells["Quantity"].Value.ToString());
                // Cập nhật lại lượng tồn kho
                UpdateMeterialInventories(0, quantity, menuId);
            }

            billDataTable = new BillsDataSet.BillDataTable();
            // BillDetailDataTable = new BillDetailDataSet.BillDetailDataTable();

            BillController.GetBillByBillId(billDataTable, billId);

            if (billDataTable.Rows.Count > 0)
            {

                billDataTable.First().Delete();

                try
                {
                    BillController.UpdateBill(billDataTable);
                    LogHistories.InsertLogHistories("Hủy sử dụng hóa đơn phục vụ mã hóa đơn:" + txtBillCode.Text, DateTime.Now, userFunctionList.UserName, "Thành công");

                }
                catch
                {
                    LogHistories.InsertLogHistories("Hủy sử dụng hóa đơn phục vụ mã hóa đơn:" + txtBillCode.Text, DateTime.Now, userFunctionList.UserName, "Lỗi");
                    MessageBox.Show("Huỷ bàn không thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            // Đặt trạng thái bàn về không sử dụng 
            SetTableStatus(tableId, 0);

            ClearBill();
            LoadAllTable();
        }

        private void listViewTables_DoubleClick(object sender, EventArgs e)
        {
            if (tableImageIndex == 0)
                CreateBill(tableId);
        }

        /// <summary>
        /// Load danh sách nhân viên
        /// </summary>
        private void LoadStaffAll()
        {
            StaffController StaffController = new StaffController();
            StaffDataSet.StaffsDataTable StaffsDataTable = new StaffDataSet.StaffsDataTable();
            StaffDataSet.StaffsDataTable thuNganDataTable = new StaffDataSet.StaffsDataTable();

            StaffController.GetAllStaff(StaffsDataTable);

            if (StaffsDataTable.Rows.Count == 0)
                return;

            thuNganDataTable.Merge(StaffsDataTable);

            cboStaff.DataSource = StaffsDataTable;
            cboStaff.DisplayMembers = StaffsDataTable.FullNameColumn.ColumnName;
            cboStaff.ValueMember = StaffsDataTable.StaffIdColumn.ColumnName;
            cboStaff.SelectedValue = userFunctionList.StaffId;

            cboThuNgan.DataSource = thuNganDataTable;
            cboThuNgan.DisplayMembers = thuNganDataTable.FullNameColumn.ColumnName;
            cboThuNgan.ValueMember = thuNganDataTable.StaffIdColumn.ColumnName;
            cboThuNgan.SelectedValue = userFunctionList.StaffId;
        }

        /// <summary>
        /// Tạo hoá đơn cho bàn
        /// </summary>
        /// <param name="tableId">Mã bàn tạo hoá đơn</param>
        private void CreateBill(int tableId)
        {
            if (!CheckItem())
                return;

            // Tạo hoá đơn cho bàn
            txtTableResgional.Text = regionalName + "-" + tableName;
            // Tạo mã hoá đơn
            billId = Utilities.CreatedFirstBillId("CB", DateTime.Now);
            txtBillCode.Text = billId;
            dtpBillDate.Value = DateTime.Now;
            billDataTable = new BillsDataSet.BillDataTable();
            cboCustomerName.Text = "Khách lẻ";
            var newRow = billDataTable.NewBillRow();

            newRow.BillId = billId;
            newRow.BillCode = txtBillCode.Text;
            newRow.BillDate = DateTime.Now;
            newRow.StaffId = int.Parse(cboStaff.SelectedValue.ToString());
            newRow.Status = Constants.IsNotPay;// Chưa thanh toán
            newRow.TableId = tableId;
            newRow.ShiftId = int.Parse(cboShift.SelectedValue.ToString());
            newRow.TotalCost = 0;
            newRow.Note = int.Parse(cboThuNgan.SelectedValue.ToString());

            billDataTable.AddBillRow(newRow);
            try
            {
                BillController.UpdateBill(billDataTable);
            }
            catch
            {
                MessageBox.Show("Tạo bàn không thành công!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Chuyển bàn sang trạng thái sử dụng
            SetTableStatus(tableId, Constants.TableIsUsed);
        }

        /// <summary>
        /// Cập nhật thông tin hoá đơn
        /// </summary>
        /// <param name="billId">Mã hoá đơn</param>
        /// <param name="status">Trạng thái sử lý</param>
        private void UpdateBill(string billId, int status)
        {
            billDataTable = new BillsDataSet.BillDataTable();
            // Cập nhật thông tin hoá đơn theo bàn chưa thanh toán
            BillController.GetBillByTableIdAndStatus(billDataTable, tableId, Constants.TableIsUsed);
            if (billDataTable.Rows.Count == 0)
                return;
            billDataTable.First().BillCode = txtBillCode.Text;
            billDataTable.First().StaffId = (int)cboStaff.SelectedValue;
            billDataTable.First().ShiftId = (int)cboShift.SelectedValue;
            if (cboCustomerName.SelectedValue != null)
                billDataTable.First().CustomerId = int.Parse(cboCustomerName.SelectedValue.ToString());
            billDataTable.First().BillDate = dtpBillDate.Value;
            billDataTable.First().Note = int.Parse(cboThuNgan.SelectedValue.ToString());
            billDataTable.First().OtherServices = txtServiceOther.Value;
            billDataTable.First().Vat = int.Parse(txtVATPercent.Text);
            billDataTable.First().OffSale = int.Parse(txtSaleOffPercent.Text);
            billDataTable.First().Status = status;
            billDataTable.First().TotalCost = txtPayTotal.Value;
            try
            {
                BillController.UpdateBill(billDataTable);
            }
            catch
            {
                MessageBox.Show("Cập nhật hoá đơn không thành công", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        /// <summary>
        /// Tạo chi tiết nội dung hoá đơn
        /// </summary>
        private void CreateBillDetail(int tableId, string billId)
        {
            Int64 billDetailId = 0;
            double quantity = 0;
            double quantityIndatabase = 0;
            int menuId = 0;
            int saleOff = 0;

            for (int i = 0; i < dgbBill.Rows.Count; i++)
            {
                BillDetailDataTable = new BillDetailDataSet.BillDetailDataTable();
                billDetailId = (Int64)dgbBill.Rows[i].Cells["BillDetailId"].Value;
                quantity = double.Parse(dgbBill.Rows[i].Cells["Quantity"].Value.ToString());
                quantityIndatabase = double.Parse(dgbBill.Rows[i].Cells["QuantityInDatabase"].Value.ToString());
                menuId = (int)dgbBill.Rows[i].Cells["MenuId"].Value;
                saleOff = 0;

                if (dgbBill.Rows[i].Cells["SalesOff"].Value != null)
                    saleOff = int.Parse(dgbBill.Rows[i].Cells["SalesOff"].Value.ToString());

                // Trường hợp chưa có chi tiết hoá đơn thì thêm mới
                if (billDetailId == -1)
                {
                    // Cập nhật thông tin chi tiết hoá đơn
                    var newRow = BillDetailDataTable.NewBillDetailRow();
                    newRow.BillId = billId;
                    newRow.MenuId = int.Parse(dgbBill.Rows[i].Cells["MenuId"].Value.ToString());
                    newRow.Quatity = double.Parse(dgbBill.Rows[i].Cells["Quantity"].Value.ToString());

                    if (saleOff == 0)
                        newRow.IsOffSaleNull();
                    else
                        newRow.OffSale = saleOff;

                    newRow.Cost = double.Parse(dgbBill.Rows[i].Cells["Cost"].Value.ToString());
                    newRow.UnitName = dgbBill.Rows[i].Cells["UnitName"].Value.ToString();

                    BillDetailDataTable.AddBillDetailRow(newRow);
                    try
                    {
                        billDetailController.UpdateBillDetail(BillDetailDataTable);
                        UpdateMeterialInventories(quantity, quantityIndatabase, menuId);

                    }
                    catch
                    {
                    }
                }
                // Trường hợp đã có chi tiết hoá đơn rồi thì tiến hành cập nhật
                else
                {
                    billDetailController.GetBillDetailByBillDetailId(BillDetailDataTable, billDetailId);
                    if (BillDetailDataTable.Rows.Count == 0)
                        return;

                    BillDetailDataTable.First().UnitName = dgbBill.Rows[i].Cells["UnitName"].Value.ToString();
                    BillDetailDataTable.First().Quatity = quantity;
                    BillDetailDataTable.First().OffSale = saleOff;
                    try
                    {
                        billDetailController.UpdateBillDetail(BillDetailDataTable);
                        UpdateMeterialInventories(quantity, quantityIndatabase, menuId);
                    }
                    catch { }
                }
            }
        }

        private void listViewTables_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtBillCode.Text))
            {
                UpdateBill(billId, 1);
                //CreateBillDetail(tableId, billId);
            }
            GetTableInfor();
            LoadBillByStatusAndTableId(tableId, Constants.TableIsUsed);
        }

        private void EnableButton()
        {
            btnCancel.Enabled = true;
            btnMovingTable.Enabled = true;
            btnPay.Enabled = true;
            btnPrintingBills.Enabled = true;
            btnTablePlus.Enabled = true;
            txtServiceOther.IsInputReadOnly = false;
            txtSaleOffPercent.ReadOnly = false;
            txtVATPercent.ReadOnly = false;
            txtCustomerMoney.IsInputReadOnly = false;
            cboCustomerName.Enabled = true;
            btnCustomer.Enabled = true;
            txtMobile.ReadOnly = false;
        }

        private void DisableButton()
        {
            ClearBill();
            txtMobile.ReadOnly = true;
            btnCustomer.Enabled = false;
            cboCustomerName.Enabled = false;
            btnCancel.Enabled = false;
            btnMovingTable.Enabled = false;
            btnPay.Enabled = false;
            btnPrintingBills.Enabled = false;
            btnTablePlus.Enabled = false;
            txtServiceOther.IsInputReadOnly = true;
            txtSaleOffPercent.ReadOnly = true;
            txtVATPercent.ReadOnly = true;
            txtCustomerMoney.IsInputReadOnly = true;

            txtCustomerMoney.Text = "0";
            txtMoneyTotal.Text = "0";
            txtVATPercent.Text = "0";
            txtServiceOther.Text = "0";
            txtSaleOffPercent.Text = "0";
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="tableId"></param>
        /// <param name="status">1 bàn đang sử dụng, 0 bàn đã thanh toán</param>
        private void LoadBillByStatusAndTableId(int tableId, int status)
        {
            // string billId = string.Empty;
            billDataTable = new BillsDataSet.BillDataTable();
            BillController.GetBillByTableIdAndStatus(billDataTable, tableId, status);
            if (billDataTable.Rows.Count == 0)
            {
                DisableButton();
                return;
            }

            EnableButton();
            LoadAllCustomer();
            LoadAllShift();
            LoadStaffAll();
            billId = billDataTable.First().BillId;
            txtBillCode.Text = billDataTable.First().Field<string>("BillCode");
            dtpBillDate.Value = billDataTable.First().BillDate;
            cboCustomerName.SelectedValue = billDataTable.First().IsCustomerIdNull() ? -1 : billDataTable.First().CustomerId;
            cboThuNgan.SelectedValue = billDataTable.First().Note;
            cboStaff.SelectedValue = billDataTable.First().StaffId;
            txtTableResgional.Text = regionalName + "-" + tableName;
            cboShift.SelectedValue = billDataTable.First().ShiftId;
            txtServiceOther.Value = billDataTable.First().IsOtherServicesNull() ? 0 : billDataTable.First().OtherServices;
            txtVATPercent.Text = billDataTable.First().IsVatNull() ? "0" : billDataTable.First().Vat.ToString();
            txtSaleOffPercent.Text = billDataTable.First().IsOffSaleNull() ? "0" : billDataTable.First().OffSale.ToString();
            LoadBillDetailByBillId(billId);
        }

        private void LoadBillDetailByBillId(string billId)
        {
            dgbBill.Rows.Clear();
            BillDetailDataSet.BillDetailAndMenuDataTable billDetailAndMenuDataTable = new BillDetailDataSet.BillDetailAndMenuDataTable();
            billDetailController.GetBillDetailAndMenuByBillId(billDetailAndMenuDataTable, billId);

            if (billDetailAndMenuDataTable.Rows.Count == 0)
                return;

            int index = 0;
            foreach (BillDetailDataSet.BillDetailAndMenuRow row in billDetailAndMenuDataTable.Rows)
            {
                int SaleOff = 0;
                SaleOff = row.IsOffSaleNull() ? 0 : row.OffSale;
                AddNewMenuRow(index, row.ItemName, row.Quatity, row.UnitName, row.Cost, SaleOff, row.MenuId, row.BillDetailId, row.Quatity);
                index++;
            }
            TotalMoneyCellEndEdit();
            Calculator();
        }

        private void mnChangedTable_Click(object sender, EventArgs e)
        {
            ChangedTables ChangedTables = new ChangedTables(tableId, tableName);
            ChangedTables.reLoadData += new ChangedTables.ReLoadData(LoadAllTable);
            ChangedTables.ShowDialog();
        }

        private void txtVATPercent_TextChanged(object sender, EventArgs e)
        {
            Calculator();
        }

        private void Calculator()
        {
            VAT();
            SaleOff();
            float MoneyToal = 0;
            float SaleOffMoney = 0;
            float VatMoeny = 0;
            float OtherService = 0;

            if (!float.TryParse(txtMoneyTotal.Text, out MoneyToal))
                MoneyToal = 0;

            if (!float.TryParse(txtSaleOffMoney.Text, out SaleOffMoney))
                SaleOffMoney = 0;

            if (!float.TryParse(txtVATMoney.Text, out VatMoeny))
                VatMoeny = 0;

            if (!float.TryParse(txtServiceOther.Text, out OtherService))
                OtherService = 0;

            txtPayTotal.Text = (MoneyToal + OtherService + VatMoeny - SaleOffMoney).ToString();
        }

        private void VAT()
        {
            float MoneyToal = 0;
            float SaleOffMoney = 0;
            float OtherService = 0;
            int vatPercent = 0;
            if (!int.TryParse(txtVATPercent.Text, out vatPercent))
            {
                txtVATPercent.Text = "0";
                txtVATPercent.Focus();
                return;
            }

            if (vatPercent > 100 || vatPercent < 0)
            {
                txtVATPercent.Text = "0";
                txtVATMoney.Text = "0";
                MessageBox.Show("VAT không vượt quá 100%!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!float.TryParse(txtMoneyTotal.Text, out MoneyToal))
                MoneyToal = 0;

            if (!float.TryParse(txtSaleOffMoney.Text, out SaleOffMoney))
                SaleOffMoney = 0;

            if (!float.TryParse(txtServiceOther.Text, out OtherService))
                OtherService = 0;

            txtVATMoney.Text = ((int)((MoneyToal + OtherService - SaleOffMoney) * vatPercent / 100)).ToString();
        }

        private void SaleOff()
        {
            double MoneyToal = 0;
            double OtherService = 0;
            double saleOffPercent = 0;

            if (!double.TryParse(txtSaleOffPercent.Text, out saleOffPercent))
            {
                txtSaleOffPercent.Text = "0";
                txtSaleOffPercent.Focus();
                return;
            }
            if (saleOffPercent > 100 || saleOffPercent < 0)
            {
                txtSaleOffPercent.Text = "0";
                txtSaleOffPercent.Focus();
                MessageBox.Show("Giá trị nhập vào vượt quá định dạng cho phép", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!double.TryParse(txtMoneyTotal.Text, out MoneyToal))
                MoneyToal = 0;

            if (!double.TryParse(txtServiceOther.Text, out OtherService))
                OtherService = 0;
            if (saleOffPercent == 100)
                txtVATMoney.Text = "0";

            txtSaleOffMoney.Text = ((double)((MoneyToal + OtherService) * saleOffPercent / 100)).ToString();
        }

        private void PayBack()
        {
            if (string.IsNullOrEmpty(txtCustomerMoney.Text))
                return;

            double customerMoney = 0;
            double totalPay = 0;
            if (!double.TryParse(txtCustomerMoney.Text, out customerMoney))
            {
                customerMoney = 0;
            }
            if (!double.TryParse(txtPayTotal.Text, out totalPay))
            {
                totalPay = 0;
            }
            if (customerMoney == totalPay)
                txtReplyMoney.Text = "0";
            txtReplyMoney.Text = (customerMoney - totalPay).ToString();
        }

        private void txtSaleOffPercent_TextChanged(object sender, EventArgs e)
        {
            Calculator();
        }

        private void txtServiceOther_ValueChanged(object sender, EventArgs e)
        {
            Calculator();
        }

        private void txtCustomerMoney_ValueChanged(object sender, EventArgs e)
        {
            PayBack();
        }

        private void txtMoneyTotal_ValueChanged(object sender, EventArgs e)
        {
            Calculator();
            PayBack();
        }

        private void txtPayTotal_ValueChanged(object sender, EventArgs e)
        {
            PayBack();
        }

        private void dgbBill_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            quantityBill = double.Parse(dgbBill.Rows[e.RowIndex].Cells["Quantity"].Value.ToString());
            DeleteMenuButtonDataGridView(e);
        }

        private void DeleteMenuButtonDataGridView(DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex != 7)
            {
                return;
            }

            DialogResult rst = MessageBox.Show("Bạn có muốn xoá bỏ thực đơn này không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (rst == DialogResult.Yes)
            {
                BillDetailDataTable = new BillDetailDataSet.BillDetailDataTable();

                int billDetailId = int.Parse(dgbBill.Rows[e.RowIndex].Cells["BillDetailId"].Value.ToString());
                int menuId = (int)dgbBill.Rows[e.RowIndex].Cells["MenuId"].Value;
                double quantity = double.Parse(dgbBill.Rows[e.RowIndex].Cells["Quantity"].Value.ToString());
                if (billDetailId > -1)
                {
                    billDetailController.GetBillDetailByBillDetailId(BillDetailDataTable, billDetailId);
                    if (BillDetailDataTable.Rows.Count > 0)
                        BillDetailDataTable.First().Delete();
                    try
                    {
                        billDetailController.UpdateBillDetail(BillDetailDataTable);
                        // Cập nhật lại lượng tồn kho
                        UpdateMeterialInventories(0, quantity, menuId);
                        dgbBill.Rows.RemoveAt(e.RowIndex);
                        TotalMoneyCellEndEdit();
                        UpdateBill(billId, Constants.TableIsUsed);
                    }
                    catch
                    {
                        MessageBox.Show("Xoá thực đơn không thành công!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }

            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            CanncelUsingTable(tableId);
        }

        private void btnMovingTable_Click(object sender, EventArgs e)
        {
            mnChangedTable_Click(null, null);
        }
        #endregion

        #region Xử lý menu
        private MenuController menuController = new MenuController();
        private MenuDataSet.MenuAndSubGroupMenuDataTable menuAndSubGroupMenuDataTable = null;
        private MenuGroupController menuGroupController = new MenuGroupController();
        private SubGroupMenuDataSet.SubGroupMenuDataTable subGroupMenuDataTable = null;
        private SubGroupMenuController subGroupMenuController = new SubGroupMenuController();
        private MenuGroupDataSet.MenuGroupDataTable menuGroupDataTable = null;
        private RestaurantManagement.Resports.CrystalReportBill crytal = null;
        private string billCode = string.Empty;

        private MenuMeterialController menuMeterialController = new MenuMeterialController();
        private MenuMeterialsDataSet.MenuMaterialsDataTable menuMaterialsDataTable = null;
        private MeterialDataSet.MeterialsDataTable meterialsDataTable = null;
        private ExportBillController exportBillController = new ExportBillController();
        private MeterialController meterialController = new MeterialController();

        private double quantityBill = 0;

        private void LoadAllMenuGroup()
        {
            menuGroupDataTable = new MenuGroupDataSet.MenuGroupDataTable();
            menuGroupController.GetAllMenuGroup(menuGroupDataTable);
            if (menuGroupDataTable.Rows.Count == 0)
                return;
            var newRow = menuGroupDataTable.NewMenuGroupRow();
            newRow.GroupId = -1;
            newRow.GroupName = string.Empty;
            newRow.GroupNote = string.Empty;
            menuGroupDataTable.Rows.InsertAt(newRow, 0);

            cboMenuGroup.DataSource = menuGroupDataTable;
            cboMenuGroup.DisplayMembers = menuGroupDataTable.GroupNameColumn.ColumnName;
            cboMenuGroup.ValueMember = menuGroupDataTable.GroupIdColumn.ColumnName;
        }

        private void LoadAllMenu()
        {
            listViewMenus.Items.Clear();

            // Ẩn các cột không muốn hiện thị là cột mã thực đơn và mã đơn vị tính
            listViewMenus.Columns[4].Width = 0;
            listViewMenus.Columns[5].Width = 0;
            listViewMenus.Columns[3].Width = 0;
            // Lấy danh sách sub menu
            subGroupMenuDataTable = new SubGroupMenuDataSet.SubGroupMenuDataTable();
            if (cboMenuGroup.SelectedIndex < 1)
                subGroupMenuController.GetAllSubGroupMenu(subGroupMenuDataTable);
            else
                subGroupMenuController.GetSubGroupMenuByGroupMenuId(subGroupMenuDataTable, int.Parse(cboMenuGroup.SelectedValue.ToString()));

            if (subGroupMenuDataTable.Rows.Count == 0)
                return;

            // Lấy về danh sách menu chi tiết
            menuAndSubGroupMenuDataTable = new MenuDataSet.MenuAndSubGroupMenuDataTable();
            menuController.GetAllMenuAndSubGroupMenu(menuAndSubGroupMenuDataTable);

            if (menuAndSubGroupMenuDataTable.Rows.Count == 0)
                return;
            ImageList imageList = new ImageList();
            imageList.ImageSize = new Size(32, 32);
            imageList.ColorDepth = ColorDepth.Depth32Bit;
            listViewMenus.SmallImageList = imageList;
            listViewMenus.LargeImageList = imageList;
            // Khai báo nhóm
            ListViewGroup subGroup = null;
            ListViewItem menuName = null;
            ListViewItem.ListViewSubItem unitName = null;
            ListViewItem.ListViewSubItem cost = null;
            ListViewItem.ListViewSubItem rest = null;
            int indexImage = -1;
            // Hiện thị subgorup lên listivew trước
            foreach (SubGroupMenuDataSet.SubGroupMenuRow rows in subGroupMenuDataTable.Rows)
            {
                // Hiện thị thông tin subgorupMenu
                subGroup = new ListViewGroup(rows.SubGroupId.ToString(), rows.SubGroupName);
                listViewMenus.Groups.Add(subGroup);

                // Lấy về các thực đơn trong từng subGroupMenu
                var querryMenu = from menuRow in menuAndSubGroupMenuDataTable
                                 where menuRow.SubGroupId == rows.SubGroupId
                                 select menuRow;

                // Hiện thị các menu lên từng nhóm
                foreach (var item in querryMenu)
                {

                    // Thêm tên thực đơn vào cột thực đơn
                    menuName = new ListViewItem();
                    menuName.Name = item.MenuId.ToString();
                    menuName.Text = item.ItemName;
                    menuName.Group = subGroup;
                    if (!item.IsImageMenuNull())
                    {
                        indexImage++;
                        imageList.Images.Add(Utilities.ConvertByteToImage(item.ImageMenu));
                        menuName.ImageIndex = indexImage;
                    }
                    listViewMenus.Items.Add(menuName);

                    unitName = new ListViewItem.ListViewSubItem();
                    unitName.Name = item.UnitId.ToString();
                    unitName.Text = item.UnitName;
                    menuName.SubItems.Add(unitName);

                    cost = new ListViewItem.ListViewSubItem(menuName, item.Cost.ToString("###,#0"));
                    menuName.SubItems.Add(cost);

                    rest = new ListViewItem.ListViewSubItem(menuName, string.Empty);
                    menuName.SubItems.Add(rest);
                }
            }
        }

        private void AddMenuToBill()
        {
            if (string.IsNullOrEmpty(txtBillCode.Text))
            {
                MessageBox.Show("Bàn phải được sử dụng trước khi dùng tính năng này", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            try
            {
                if (listViewMenus.SelectedItems == null | listViewMenus.SelectedItems[0].SubItems == null)
                    return;
            }
            catch 
            {
                return;
            }
            string menuName = listViewMenus.SelectedItems[0].SubItems[0].Text;
            string unitName = listViewMenus.SelectedItems[0].SubItems[1].Text;
            string cost = listViewMenus.SelectedItems[0].SubItems[2].Text;
            string menuId = listViewMenus.SelectedItems[0].SubItems[0].Name;
            string unitId = listViewMenus.SelectedItems[0].SubItems[1].Name;
            double quantity = 0;
            bool isExist = false;

            int indexMax = dgbBill.Rows.Count;
            quantityBill = 0;
            double quantityInDatabase = 0;

            // Kiểm tra xem MenuId đã tồn tại hay chưa, nếu chưa có thì tiến hành thêm mới, ngược lại thì update thêm số lượng
            for (int i = 0; i < dgbBill.Rows.Count; i++)
            {
                // Nếu tồn tại thực đơn trong danh sách rồi thì cập nhật
                if (dgbBill.Rows[i].Cells["MenuId"].Value.ToString().Equals(menuId))
                {
                    quantityBill = double.Parse(dgbBill.Rows[i].Cells["Quantity"].Value.ToString());
                    quantityInDatabase = double.Parse(dgbBill.Rows[i].Cells["QuantityInDatabase"].Value.ToString());
                    dgbBill.Rows[i].Selected = true;
                    indexMax = i;
                    isExist = true;
                    quantity = double.Parse(dgbBill.Rows[i].Cells["Quantity"].Value.ToString());
                    quantity++;
                    if (!CheckQuantityInventories(quantity, quantityInDatabase, int.Parse(menuId)))
                    {
                        dgbBill.Rows[i].Cells["Quantity"].Value = quantityBill;
                        return;
                    }
                    dgbBill.Rows[i].Cells["Quantity"].Value = quantity;
                    dgbBill.Rows[i].Cells["UnitName"].Value = unitName;
                    dgbBill.Rows[i].Cells["Cost"].Value = cost;

                    break;
                }
            }

            //Trường hợp đây là thực đơn mới
            if (!isExist)
            {
                if (!CheckQuantityInventories(1, 0, int.Parse(menuId)))
                {
                    return;
                }
                AddNewMenuRow(indexMax, menuName, 1, unitName, double.Parse(cost), 0, int.Parse(menuId), -1, 0);
            }

            // Tính lại tiền hoá đơn sau khi bổ xung thêm thực đơn
            TotalMoneyCellEndEdit();
            SaveBill();
        }

        private bool CheckQuantityInventories(double quantityInput, double quantityInventories, int menuId)
        {
            // lượng xuất kho lúc sau = (lượng xuất mới - lượng đã xuất)* định lượng
            double detalValue = (quantityInput - quantityInventories);
            double exportQuantity = 0;
            menuMaterialsDataTable = new MenuMeterialsDataSet.MenuMaterialsDataTable();

            // Lấy về thông tin của mặt hàng theo menuId
            menuMeterialController.GetMenuMeterialByMenuId(menuMaterialsDataTable, menuId);

            foreach (MenuMeterialsDataSet.MenuMaterialsRow item in menuMaterialsDataTable.Rows)
            {
                exportQuantity = detalValue * item.MeterialQuatity;
                meterialsDataTable = new MeterialDataSet.MeterialsDataTable();
                meterialController.GetByMerterialId(meterialsDataTable, item.MeterialId);
                if (meterialsDataTable.Rows.Count > 0 && meterialsDataTable.First().Quantity < exportQuantity)
                {
                    MessageBox.Show("Nguyên liệu thực đơn " + meterialsDataTable.First().MeterialName + " không đủ để chế biến.", Constants.CaptionErrorMessage, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// Cập nhật thông tin cho mặt hàng tồn kho
        /// </summary>
        /// <param name="quantityInput"></param>
        /// <param name="quantityInventories"></param>
        /// <param name="meterialId"></param>
        private void UpdateMeterialInventories(double quantityInput, double quantityInventories, int menuId)
        {
            // lượng xuất kho lúc sau = (lượng xuất mới - lượng đã xuất)* định lượng
            double detalValue = (quantityInput - quantityInventories);
            double exportQuantity = 0;
            menuMaterialsDataTable = new MenuMeterialsDataSet.MenuMaterialsDataTable();

            // Lấy về thông tin của mặt hàng theo menuId
            menuMeterialController.GetMenuMeterialByMenuId(menuMaterialsDataTable, menuId);

            if (menuMaterialsDataTable.Rows.Count == 0)
                return;

            foreach (MenuMeterialsDataSet.MenuMaterialsRow item in menuMaterialsDataTable.Rows)
            {
                exportQuantity = detalValue * item.MeterialQuatity;
                UpdateMeterial(item.MeterialId, exportQuantity);
            }
        }

        private void UpdateMeterial(int meterialId, double exportQuantity)
        {
            meterialsDataTable = new MeterialDataSet.MeterialsDataTable();
            meterialController.GetByMerterialId(meterialsDataTable, meterialId);

            // Lượng tồn cuối = lượng tồn đầu - lượng xuất kho
            meterialsDataTable.First().Quantity = meterialsDataTable.First().Quantity - exportQuantity;
            try
            {
                meterialController.UpdateMeterial(meterialsDataTable);
            }
            catch
            {
            }
        }

        private void AddNewMenuRow(int IndexMax, string menuName, double quantity, string unitName, double cost, int saleOff, int menuId, Int64 billDetailId, double quantityInDatabase)
        {
            // Bật tính năng cho phép thêm dòng
            dgbBill.AllowUserToAddRows = true;

            // Thực hiện thêm một dòng mới
            dgbBill.Rows.Add();

            // Khai báo biến hàng mới cho bảng
            DataGridViewRow Rows = dgbBill.Rows[IndexMax];

            // Gán các giá trị vào từng cột tương ứng của hàng vừa thêm
            Rows.Cells["STT"].Value = IndexMax + 1;
            Rows.Cells["MenuName"].Value = menuName;
            Rows.Cells["Quantity"].Value = quantity;
            Rows.Cells["UnitName"].Value = unitName;
            Rows.Cells["Cost"].Value = cost;
            Rows.Cells["SalesOff"].Value = saleOff;
            Rows.Cells["MenuId"].Value = menuId;
            Rows.Cells["TotalCost"].Value = quantity * cost * (1 - double.Parse(saleOff.ToString()) / 100);
            Rows.Cells["BillDetailId"].Value = billDetailId;
            Rows.Cells["QuantityInDatabase"].Value = quantityInDatabase;

            // Khoá tính năng cho phép thêm dòng
            dgbBill.AllowUserToAddRows = false;
            dgbBill.Rows[IndexMax].Selected = true;
        }

        #endregion

        private void listViewMenus_ColumnWidthChanging(object sender, ColumnWidthChangingEventArgs e)
        {
            if (e.ColumnIndex > 2)
            {
                e.Cancel = true;
                e.NewWidth = 0;
            }
        }

        private void listViewMenus_DoubleClick(object sender, EventArgs e)
        {
            AddMenuToBill();
        }

        private void SaveBill()
        {
            UpdateBill(billId, Constants.TableIsUsed);
            CreateBillDetail(tableId, billId);
            LoadBillDetailByBillId(billId);
        }

        private void dgbBill_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            // Lấy giá trị số lượng ban đầu
            quantityBill = double.Parse(dgbBill.Rows[e.RowIndex].Cells["Quantity"].Value.ToString());
        }

        private void dgbBill_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            double quantity = double.Parse(dgbBill.Rows[e.RowIndex].Cells["Quantity"].Value.ToString());
            double quantityInventories = double.Parse(dgbBill.Rows[e.RowIndex].Cells["QuantityInDatabase"].Value.ToString());
            int menuId = int.Parse(dgbBill.Rows[e.RowIndex].Cells["MenuId"].Value.ToString());
            if (!CheckQuantityInventories(quantity, quantityInventories, menuId))
            {
                dgbBill.Rows[e.RowIndex].Cells["Quantity"].Value = quantityBill;
                return;
            }
            TotalMoneyCellEndEdit();
            UpdateBill(billId, Constants.TableIsUsed);
            CreateBillDetail(tableId, billId);
        }

        private void TotalMoneyCellEndEdit()
        {
            double saleOffPercent = 0;
            double moneyTotal = 0;
            double quantity = 0;
            double cost = 0;
            for (int i = 0; i < dgbBill.Rows.Count; i++)
            {
                dgbBill.Rows[i].Cells["STT"].Value = i + 1;

                if (dgbBill.Rows[i].Cells["Quantity"].Value != null)
                    quantity = double.Parse(dgbBill.Rows[i].Cells["Quantity"].Value.ToString());
                if (dgbBill.Rows[i].Cells["Cost"].Value != null)
                    cost = double.Parse(dgbBill.Rows[i].Cells["Cost"].Value.ToString());
                if (dgbBill.Rows[i].Cells["SalesOff"].Value != null)
                    saleOffPercent = double.Parse(dgbBill.Rows[i].Cells["SalesOff"].Value.ToString());

                dgbBill.Rows[i].Cells["TotalCost"].Value = cost * quantity * (1 - saleOffPercent / 100);

                if (dgbBill.Rows[i].Cells["TotalCost"].Value != null)
                    moneyTotal += double.Parse(dgbBill.Rows[i].Cells["TotalCost"].Value.ToString());
            }
            txtMoneyTotal.Value = moneyTotal;
        }

        private void cboMenuGroup_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadAllMenu();
        }

        private void btnViewList_Click(object sender, EventArgs e)
        {
            listViewMenus.View = View.Details;
        }

        private void btnViewIcon_Click(object sender, EventArgs e)
        {
            listViewMenus.View = View.LargeIcon;
        }

        private void mnPayOut_Click(object sender, EventArgs e)
        {
            CheckOut();
        }

        private void CheckOut()
        {
            DialogResult rst = MessageBox.Show("Bạn muốn thanh toán hoá đơn cho bàn " + txtTableResgional.Text + " này?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (rst != DialogResult.Yes)
            {
                return;
            }
            if (!CheckItem())
                return;
            if (dgbBill.Rows.Count == 0)
            {
                dgbBill.Focus();
                DialogResult dialogResult = MessageBox.Show("Hoá đơn không có thực đơn. Bạn có muốn huỷ hoá đơn này không?", Constants.CaptionErrorMessage, MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (dialogResult == DialogResult.Yes)
                    CanncelUsingTable(tableId);
                return;
            }
            LogHistories.InsertLogHistories("Thanh toán hóa đơn ", DateTime.Now, userFunctionList.UserName, "Thành công");

            // Cập nhật thông tin chi tiết hoá đơn
            UpdateBill(billId, Constants.TableIsFree);

            // Tạo thông tin hoá đơn chi tiết
            CreateBillDetail(tableId, billId);
            // In hoá đơn ra file
            PrintingBill();

            // Chuyển bàn về trạng thái đã thanh toán
            SetTableStatus(tableId, Constants.TableIsFree);

            DialogResult rstcheckOut = MessageBox.Show("Bạn có muốn in hóa đơn không?", Constants.CaptionInformationMessage, MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (rstcheckOut == DialogResult.Yes)
            {
                crytal.PrintToPrinter(1, true, 1, 1);
                LogHistories.InsertLogHistories("In hóa đơn bán hàng mã hóa đơn: " + billCode, DateTime.Now, userFunctionList.UserName, "Thành công");
            }
        }

        private void PrintingBill()
        {
            DataSetRestaurantManagement dataset = new DataSetRestaurantManagement();
            DataSetRestaurantManagement.BillDataTable billDataTable = new DataSetRestaurantManagement.BillDataTable();
            DataSetRestaurantManagement.BillToPrintDataTable billToPrintDataTable = new DataSetRestaurantManagement.BillToPrintDataTable();
            DataSetRestaurantManagement.RestaurantInforDataTable restaurantInforDataTableToPrint = new DataSetRestaurantManagement.RestaurantInforDataTable();

            restaurantInforDataTable = new RestaurantInforDataSet.RestaurantInforDataTable();
            restaurantInforController = new RestaurantInforController();
            restaurantInforController.GetAllRestaurantInforByRestaurantInforId(restaurantInforDataTable, 1);
            restaurantInforDataTableToPrint.Merge(restaurantInforDataTable);

            billCode = txtBillCode.Text;

            var billRow = billDataTable.NewBillRow();
            billRow.BillId = "1";
            billRow.BillCode = txtBillCode.Text;
            billRow.BillDate = dtpBillDate.Text;
            billRow.CustomerName = cboCustomerName.Text;
            billRow.CustomerMobile = txtMobile.Text;
            billRow.StaffName = cboStaff.Text;
            billRow.ShiftName = cboShift.Text;
            billRow.TableName = txtTableResgional.Text;
            billRow.TotalPay = txtMoneyTotal.Value;
            billRow.OtherServices = txtServiceOther.Value;
            billRow.Vat = double.Parse(txtVATPercent.Text);
            billRow.VatMoney = txtVATMoney.Value;
            billRow.SaleOff = double.Parse(txtSaleOffPercent.Text);
            billRow.SaleOffMoney = txtSaleOffMoney.Value;
            billRow.CustomerCash = txtPayTotal.Value;
            billRow.Note = cboThuNgan.Text;
            billRow.ConvertMoneyToString = Utilities.DocSo((decimal)txtPayTotal.Value);
            billDataTable.AddBillRow(billRow);

            for (int i = 0; i < dgbBill.Rows.Count; i++)
            {
                var newRow = billToPrintDataTable.NewBillToPrintRow();
                newRow.STT = dgbBill.Rows[i].Cells["STT"].Value.ToString();
                newRow.MenuName = dgbBill.Rows[i].Cells["MenuName"].Value.ToString();
                newRow.Quantity = dgbBill.Rows[i].Cells["Quantity"].Value == null ? 0 : double.Parse(dgbBill.Rows[i].Cells["Quantity"].Value.ToString());
                newRow.UnitName = dgbBill.Rows[i].Cells["UnitName"].Value.ToString();
                newRow.Cost = (double)dgbBill.Rows[i].Cells["Cost"].Value;
                newRow.SaleOff = int.Parse(dgbBill.Rows[i].Cells["SalesOff"].Value.ToString());
                newRow.PayTotal = (double)dgbBill.Rows[i].Cells["TotalCost"].Value;

                billToPrintDataTable.AddBillToPrintRow(newRow);
            }

            crytal = new RestaurantManagement.Resports.CrystalReportBill();
            dataset.Merge(billDataTable);
            dataset.Merge(billToPrintDataTable);
            dataset.Merge(restaurantInforDataTableToPrint);
            crytal.SetDataSource(dataset);
            // crystalReportViewer.Visible = true;
            // crystalReportViewer.ReportSource = crytal;
            // crytal.PrintToPrinter(2, true, 1, 1);
        }

        private void LoadAllCustomer()
        {
            customersDataTable = new CustomerDataSet.CustomersDataTable();
            customerController.GetAllCustomer(customersDataTable);
            cboCustomerName.DataSource = customersDataTable;
            cboCustomerName.DisplayMember = customersDataTable.CustomerNameColumn.ColumnName;
            cboCustomerName.ValueMember = customersDataTable.CustomerIdColumn.ColumnName;
            cboCustomerName.SelectedIndex = -1;
        }

        private void btnPrintingBills_Click(object sender, EventArgs e)
        {
            PrintingBill();
            crytal.PrintToPrinter(1, true, 1, 1);
        }

        private void btnTablePlus_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Chức năng này đang được xây dựng, sẽ được cập nhật vào phiên bản sau?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
        }

        private void btnCustomer_Click(object sender, EventArgs e)
        {
            CustomerSearchForBill CustomerSearchForBill = new CustomerSearchForBill(userFunctionList);
            CustomerSearchForBill.getCustomerInfor += new CustomerSearchForBill.GetCustomerInfor(SetCustomerInfor);
            CustomerSearchForBill.ShowDialog();
        }

        private void SetCustomerInfor(int customerId)
        {
            LoadAllCustomer();
            cboCustomerName.SelectedValue = customerId;
        }

        private void cboCustomerName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboCustomerName.SelectedIndex == -1)
            {
                txtMobile.Text = string.Empty;
                return;
            }
            DataRowView row = (DataRowView)cboCustomerName.SelectedItem;
            txtMobile.Text = row.Row.Field<string>("CustomerMobile");
        }
    }
}

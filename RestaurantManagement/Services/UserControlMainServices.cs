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
        #endregion

        #region Xử lý đặt bàn ăn
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
            lbRestaurentMobile.Text = "Điện thoại: " + restaurantInforDataTable.First().Field<string>("RestaurantMobile");
            lbRestaurentAddress.Text = "Địa chỉ: " + restaurantInforDataTable.First().Field<string>("RestaurantAddress");
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
            }
            catch
            {
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
            LoadAllTable();
            LoadAllShift();
            LoadStaffAll();
            LoadAllMenuGroup();
            LoadAllMenu();
            LoadRestaurantInfor();
        }

        private void mnAddNewTable_Click(object sender, EventArgs e)
        {
            AddTable AddTable = new AddTable();
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
            RegionalManagement RegionalManagement = new RegionalManagement();
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
            txtBillId.Text = string.Empty;
            txtCustomer.Text = string.Empty;
            txtNote.Text = string.Empty;
            txtDateTime.Text = string.Empty;
            txtTableResgional.Text = string.Empty;
            dgbBill.Rows.Clear();
        }
        private void CanncelUsingTable(int tableId)
        {
            DialogResult rst = MessageBox.Show("Bạn có muốn huỷ hoá đơn thanh toán của bàn " + txtTableResgional.Text + " này không?", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (rst != DialogResult.Yes)
                return;

            billDataTable = new BillsDataSet.BillDataTable();
            BillDetailDataTable = new BillDetailDataSet.BillDetailDataTable();

            BillController.GetBillByTableIdAndStatus(billDataTable, tableId, 1);
            if (billDataTable.Rows.Count == 0)
                return;

            billDataTable.First().Delete();

            try
            {
                BillController.UpdateBill(billDataTable);
            }
            catch
            {
                MessageBox.Show("Huỷ bàn không thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
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
            StaffController.GetAllStaff(StaffsDataTable);

            if (StaffsDataTable.Rows.Count == 0)
                return;
            cboStaff.DataSource = StaffsDataTable;
            cboStaff.DisplayMembers = StaffsDataTable.FullNameColumn.ColumnName;
            cboStaff.ValueMember = StaffsDataTable.StaffIdColumn.ColumnName;
        }

        /// <summary>
        /// Tạo hoá đơn cho bàn
        /// </summary>
        /// <param name="tableId">Mã bàn tạo hoá đơn</param>
        private void CreateBill(int tableId)
        {
            // Tạo hoá đơn cho bàn
            txtTableResgional.Text = regionalName + "-" + tableName;
            // Tạo mã hoá đơn
            string billId = string.Empty;
            billId = Utilities.CreatedFirstBillId("CB", DateTime.Now);
            txtBillId.Text = billId;
            txtDateTime.Text = DateTime.Now.ToString();
            billDataTable = new BillsDataSet.BillDataTable();

            var newRow = billDataTable.NewBillRow();

            newRow.BillId = billId;
            newRow.BillDate = DateTime.Now;
            newRow.StaffId = int.Parse(cboStaff.SelectedValue.ToString());
            newRow.Status = 1;// Chưa thanh toán
            newRow.TableId = tableId;
            newRow.ShiftId = int.Parse(cboShift.SelectedValue.ToString());
            newRow.TotalCost = 0;
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
            SetTableStatus(tableId, 1);
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
            BillController.GetBillByTableIdAndStatus(billDataTable, tableId, 1);
            if (billDataTable.Rows.Count == 0)
                return;
            billDataTable.First().CustomerName = txtCustomer.Text;
            //  billDataTable.First().CustomerId = 1;
            billDataTable.First().Note = txtNote.Text;
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
            BillDetailDataTable = new BillDetailDataSet.BillDetailDataTable();

            for (int i = 0; i < dgbBill.Rows.Count; i++)
            {
                // Trường hợp chưa có chi tiết hoá đơn thì thêm mới
                if (int.Parse(dgbBill.Rows[i].Cells["BillDetailId"].Value.ToString()) == -1)
                {
                    // Cập nhật thông tin chi tiết hoá đơn
                    var newRow = BillDetailDataTable.NewBillDetailRow();
                    newRow.BillId = billId;
                    newRow.MenuId = int.Parse(dgbBill.Rows[i].Cells["MenuId"].Value.ToString());
                    newRow.Quatity = int.Parse(dgbBill.Rows[i].Cells["Quantity"].Value.ToString());

                    if (dgbBill.Rows[i].Cells["SalesOff"].Value == null)
                        newRow.IsOffSaleNull();
                    else
                        newRow.OffSale = int.Parse(dgbBill.Rows[i].Cells["SalesOff"].Value.ToString());

                    newRow.Cost = int.Parse(dgbBill.Rows[i].Cells["Cost"].Value.ToString());
                    newRow.UnitName = dgbBill.Rows[i].Cells["UnitName"].Value.ToString();

                    BillDetailDataTable.AddBillDetailRow(newRow);
                    try
                    {
                        billDetailController.UpdateBillDetail(BillDetailDataTable);
                    }
                    catch
                    {
                    }
                }
                // Trường hợp đã có chi tiết hoá đơn rồi thì tiến hành cập nhật
                else
                {
                    BillDetailDataTable = new BillDetailDataSet.BillDetailDataTable();
                    int billDetailId = int.Parse(dgbBill.Rows[i].Cells["BillDetailId"].Value.ToString());

                    double quantity = double.Parse(dgbBill.Rows[i].Cells["Quantity"].Value.ToString());
                    int saleOff = 0;

                    if (dgbBill.Rows[i].Cells["SalesOff"].Value != null)
                        saleOff = int.Parse(dgbBill.Rows[i].Cells["SalesOff"].Value.ToString());

                    billDetailController.GetBillDetailByBillDetailId(BillDetailDataTable, billDetailId);
                    if (BillDetailDataTable.Rows.Count == 0)
                        return;

                    BillDetailDataTable.First().Quatity = quantity;
                    BillDetailDataTable.First().OffSale = saleOff;
                    try
                    {
                        billDetailController.UpdateBillDetail(BillDetailDataTable);
                    }
                    catch { }
                }
            }
        }

        private void listViewTables_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtBillId.Text))
            {
                UpdateBill(txtBillId.Text, 1);
                CreateBillDetail(tableId, txtBillId.Text);
            }
            GetTableInfor();
            LoadBillByStatusAndTableId(tableId, 1);
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
        }

        private void DisableButton()
        {
            ClearBill();
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
            string billId = string.Empty;
            billDataTable = new BillsDataSet.BillDataTable();
            BillController.GetBillByTableIdAndStatus(billDataTable, tableId, status);
            if (billDataTable.Rows.Count == 0)
            {
                DisableButton();
                return;
            }
            EnableButton();

            txtBillId.Text = billDataTable.First().BillId;
            txtDateTime.Text = billDataTable.First().BillDate.ToString();
            txtCustomer.Text = billDataTable.First().Field<string>("CustomerName");
            txtNote.Text = billDataTable.First().Field<string>("Note");
            cboStaff.SelectedValue = billDataTable.First().StaffId;
            txtTableResgional.Text = regionalName + "-" + tableName;
            cboShift.SelectedValue = billDataTable.First().ShiftId;
            txtServiceOther.Value = billDataTable.First().IsOtherServicesNull() ? 0 : billDataTable.First().OtherServices;
            txtVATPercent.Text = billDataTable.First().IsVatNull() ? "0" : billDataTable.First().Vat.ToString();
            txtSaleOffPercent.Text = billDataTable.First().IsOffSaleNull() ? "0" : billDataTable.First().OffSale.ToString();
            LoadBillDetailByBillId(txtBillId.Text);
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
                AddNewMenuRow(index, row.ItemName, row.Quatity, row.UnitName, row.Cost, SaleOff, row.MenuId, row.BillDetailId);
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
            float MoneyToal = 0;
            float OtherService = 0;
            float saleOffPercent = 0;

            if (!float.TryParse(txtSaleOffPercent.Text, out saleOffPercent))
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

            if (!float.TryParse(txtMoneyTotal.Text, out MoneyToal))
                MoneyToal = 0;

            if (!float.TryParse(txtServiceOther.Text, out OtherService))
                OtherService = 0;
            if (saleOffPercent == 100)
                txtVATMoney.Text = "0";

            txtSaleOffMoney.Text = ((int)((MoneyToal + OtherService) * saleOffPercent / 100)).ToString();
        }

        private void PayBack()
        {
            if (string.IsNullOrEmpty(txtCustomerMoney.Text))
                return;

            float customerMoney = 0;
            float totalPay = 0;
            if (!float.TryParse(txtCustomerMoney.Text, out customerMoney))
            {
                customerMoney = 0;
            }
            if (!float.TryParse(txtPayTotal.Text, out totalPay))
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
                if (billDetailId > -1)
                {
                    billDetailController.GetBillDetailByBillDetailId(BillDetailDataTable, billDetailId);
                    if (BillDetailDataTable.Rows.Count > 0)
                        BillDetailDataTable.First().Delete();
                    try
                    {
                        billDetailController.UpdateBillDetail(BillDetailDataTable);
                    }
                    catch
                    {
                        MessageBox.Show("Xoá thực đơn không thành công!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                dgbBill.Rows.RemoveAt(e.RowIndex);
                TotalMoneyCellEndEdit();
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
                    indexImage++;
                    imageList.Images.Add(Utilities.ConvertByteToImage(item.ImageMenu));

                    // Thêm tên thực đơn vào cột thực đơn
                    menuName = new ListViewItem();
                    menuName.Name = item.MenuId.ToString();
                    menuName.Text = item.ItemName;
                    menuName.Group = subGroup;
                    menuName.ImageIndex = indexImage;
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
            if (string.IsNullOrEmpty(txtBillId.Text))
            {
                MessageBox.Show("Bàn phải được sử dụng trước khi dùng tính năng này", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

            // Kiểm tra xem MenuId đã tồn tại hay chưa, nếu chưa có thì tiến hành thêm mới, ngược lại thì update thêm số lượng
            for (int i = 0; i < dgbBill.Rows.Count; i++)
            {
                // Nếu tồn tại thực đơn trong danh sách rồi thì cập nhật
                if (dgbBill.Rows[i].Cells["MenuId"].Value.ToString().Equals(menuId))
                {
                    dgbBill.Rows[i].Selected = true;
                    indexMax = i;
                    isExist = true;
                    quantity = double.Parse(dgbBill.Rows[i].Cells["Quantity"].Value.ToString());
                    quantity++;
                    dgbBill.Rows[i].Cells["Quantity"].Value = quantity;

                    break;
                }
            }

            //Trường hợp đây là thực đơn mới
            if (!isExist)
            {
                AddNewMenuRow(indexMax, menuName, 1, unitName, double.Parse(cost), 0, int.Parse(menuId), -1);
            }

            // Tính lại tiền hoá đơn sau khi bổ xung thêm thực đơn
            TotalMoneyCellEndEdit();
        }

        private void AddNewMenuRow(int IndexMax, string menuName, double quantity, string unitName, double cost, int saleOff, int menuId, Int64 billDetailId)
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

        private void dgbBill_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            TotalMoneyCellEndEdit();
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

            // Cập nhật thông tin chi tiết hoá đơn
            UpdateBill(txtBillId.Text, 0);

            // Tạo thông tin hoá đơn chi tiết
            CreateBillDetail(tableId, txtBillId.Text);

            // In hoá đơn ra file
            PrintingBill();

            // Chuyển bàn về trạng thái đã thanh toán
            SetTableStatus(tableId, 0);
        }

        private void PrintingBill()
        {

        }

        private void btnPrintingBills_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Chức năng này đang được xây dựng, sẽ được cập nhật vào phiên bản sau?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
        }

        private void btnTablePlus_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Chức năng này đang được xây dựng, sẽ được cập nhật vào phiên bản sau?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
        }

    }
}

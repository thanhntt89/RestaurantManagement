using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using RestaurantDTO;
using RestaurantCommon;
using RestaurantController;
using DevComponents.AdvTree;
using System.IO;

namespace RestaurantManagement
{
    public partial class UserControlMenuReport : UserControl
    {
        private BillEntity billEntity = null;
        public delegate void RemovedUserControler(string controler);
        public event RemovedUserControler removedUserControler;

        private MenuGroupDataSet.MenuGroupDataTable menuGroupDataTable = null;
        private MenuGroupController menuGroupController = new MenuGroupController();

        private SubGroupMenuDataSet.SubGroupMenuDataTable subGroupMenuDataTable = null;
        private SubGroupMenuController subGroupMenuController = new SubGroupMenuController();

        private MenuDataSet.MenuDataTable menuDataTable = null;
        private MenuController menuController = new MenuController();

        private MenuDataSet.MenuQuantityByBillDateDataTable menuQuantityByBillDateDataTable = null;
        private UserFunctionList userFunctionList;

        private ExcelExportEntity excelEntity = null;
        private ProcessingEntity processingEntity = null;
        private bool IsExportSuccess;

        public UserControlMenuReport(string MenuType, UserFunctionList userFunctionList)
        {
            InitializeComponent();
            LoadMenuAll();
            this.userFunctionList = userFunctionList;
        }

        public UserControlMenuReport()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            if (removedUserControler != null)
                removedUserControler(this.Name);
        }

        private void LoadDateTimeType(string ImporBillType)
        {
            dtpFormDate.Value = DateTime.Now.AddDays(-1);
            dtpToDate.Value = DateTime.Now;

            if (ImporBillType.Equals(Constants.Day))
            {
                dtpToDate.CustomFormat = "dd/MM/yyyy";
                dtpFormDate.CustomFormat = "dd/MM/yyyy";
                cboReportType.SelectedIndex = (int)ReportViewByType.DairyImport;
            }
            if (ImporBillType.Equals(Constants.Month))
            {
                lbFormDate.Text = "Từ tháng năm";
                lbToDate.Text = "Đến tháng năm";
                dtpToDate.CustomFormat = "MM/yyyy";
                dtpFormDate.CustomFormat = "MM/yyyy";
                cboReportType.SelectedIndex = (int)ReportViewByType.MonthImport;
            }
            if (ImporBillType.Equals(Constants.Year))
            {
                lbFormDate.Text = "Từ năm";
                lbToDate.Text = "Đến năm";
                dtpToDate.CustomFormat = "yyyy";
                dtpFormDate.CustomFormat = "yyyy";

                cboReportType.SelectedIndex = (int)ReportViewByType.YearImport;
            }
        }

        private void cboReportType_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadDateTimeType(cboReportType.SelectedNode.Name);
        }

        private void LoadMenuAll()
        {
            treeViewMenu.Nodes.Clear();
            menuGroupDataTable = new MenuGroupDataSet.MenuGroupDataTable();
            menuGroupController.GetAllMenuGroup(menuGroupDataTable);
            if (menuGroupDataTable.Rows.Count == 0)
                return;
            TreeNode RootNode = null;
            TreeNode subRootNode = null;
            TreeNode node = null;
            int indexNode = -1;
            int indexSubRoot = -1;
            treeViewMenu.Nodes.Add(Constants.HOMMENU);
            // Lấy về danh sách nhóm sub menu nếu có
            foreach (MenuGroupDataSet.MenuGroupRow item in menuGroupDataTable.Rows)
            {
                subGroupMenuDataTable = new SubGroupMenuDataSet.SubGroupMenuDataTable();
                subGroupMenuController.GetSubGroupMenuByGroupMenuId(subGroupMenuDataTable, item.GroupId);
                if (subGroupMenuDataTable.Rows.Count == 0)
                {
                    continue;
                }
                RootNode = new TreeNode(item.GroupName);
                treeViewMenu.Nodes[0].Nodes.Add(RootNode);
                indexSubRoot++;
                indexNode = -1;
                foreach (SubGroupMenuDataSet.SubGroupMenuRow subrow in subGroupMenuDataTable.Rows)
                {
                    menuDataTable = new MenuDataSet.MenuDataTable();
                    menuController.GetMenuBySubGroupId(menuDataTable, subrow.SubGroupId);

                    if (menuDataTable.Rows.Count == 0)
                    {
                        treeViewMenu.Nodes.RemoveByKey(item.GroupName);
                        continue;
                    }
                    subRootNode = new TreeNode();
                    subRootNode.Text = subrow.SubGroupName;
                    subRootNode.Name = "SubRoot" + subrow.SubGroupId;

                    treeViewMenu.Nodes[0].Nodes[indexSubRoot].Nodes.Add(subRootNode);

                    indexNode++;

                    // Lấy về danh sách các thực đơn
                    foreach (MenuDataSet.MenuRow menuRow in menuDataTable.Rows)
                    {
                        node = new TreeNode();
                        node.Text = menuRow.ItemName;
                        node.Name = menuRow.MenuId.ToString();

                        treeViewMenu.Nodes[0].Nodes[indexSubRoot].Nodes[indexNode].Nodes.Add(node);
                    }
                }
            }


            treeViewMenu.ExpandAll();
        }

        private void treeViewMenu_AfterCheck(object sender, TreeViewEventArgs e)
        {
            foreach (TreeNode childNode in e.Node.Nodes)
            {
                childNode.Checked = e.Node.Checked;
            }
        }

        private void btnSearchReport_Click(object sender, EventArgs e)
        {
            Search();
        }

        private void Search()
        {
            dgvReportBill.Rows.Clear();
            string billInfor = string.Empty;
            billEntity = new BillEntity();
            if (cboReportType.SelectedNode == null)
                return;

            if (cboReportType.SelectedNode.Name.Equals(Constants.Day))
            {
                if (dtpToDate.Checked)
                    billEntity.ToDate = dtpToDate.Value.ToString("yyyy-MM-dd 23:59:59");
                if (dtpFormDate.Checked)
                    billEntity.FromDate = dtpFormDate.Value.ToString("yyyy-MM-dd 00:00:01");

                billInfor = "Thống kê thực đơn ngày từ:" + billEntity.FromDate + " đến " + billEntity.ToDate + "";
                LogHistories.InsertLogHistories(billInfor, DateTime.Now, userFunctionList.UserName, "Tìm kiếm");
            }
            if (cboReportType.SelectedNode.Name.Equals(Constants.Month))
            {
                billEntity.ToMonth = dtpToDate.Value.Month;
                billEntity.FromMonth = dtpFormDate.Value.Month;
                billEntity.ToYear = dtpToDate.Value.Year;
                billEntity.FromYear = dtpFormDate.Value.Year;
                billInfor = "Thống kê thực đơn tháng từ: 01/" + dtpFormDate.Value.ToString("MM/yyyy") + " đến " + RestaurantCommon.Utilities.GetLastDayOfMonth(dtpToDate.Value) + "/" + dtpToDate.Value.ToString("MM/yyyy");
                LogHistories.InsertLogHistories(billInfor, DateTime.Now, userFunctionList.UserName, "Tìm kiếm");
            }
            if (cboReportType.SelectedNode.Name.Equals(Constants.Year))
            {
                billEntity.ToYear = dtpToDate.Value.Year;
                billEntity.FromYear = dtpFormDate.Value.Year;
                billInfor = "Thống kê thực đơn năm từ:" + billEntity.FromYear + " đến " + billEntity.ToYear + "";
                LogHistories.InsertLogHistories(billInfor, DateTime.Now, userFunctionList.UserName, "Tìm kiếm");
            }

            billEntity.Status = 0;

            int index = 0;
            int Root = 0;
            int subRoot = 0;

            string nodeRoot = string.Empty;
            foreach (TreeNode item in treeViewMenu.Nodes[0].Nodes)
            {
                subRoot = 0;

                foreach (TreeNode subroot in treeViewMenu.Nodes[0].Nodes[Root].Nodes)
                {
                    foreach (TreeNode node in treeViewMenu.Nodes[0].Nodes[Root].Nodes[subRoot].Nodes)
                    {
                        if (node.Checked)
                        {
                            billEntity.MenuId = int.Parse(node.Name);
                            menuQuantityByBillDateDataTable = new MenuDataSet.MenuQuantityByBillDateDataTable();
                            menuController.SearchImportBillByBillEntity(menuQuantityByBillDateDataTable, billEntity);

                            if (menuQuantityByBillDateDataTable.Rows.Count == 0)
                                continue;

                            dgvReportBill.AllowUserToAddRows = true;
                            dgvReportBill.Rows.Add();
                            DataGridViewRow row = dgvReportBill.Rows[index];
                            row.Cells["STT"].Value = index + 1;
                            row.Cells["BillDate"].Value = billInfor;
                            row.Cells["MenuName"].Value = menuQuantityByBillDateDataTable.First().ItemName;
                            row.Cells["UnitName"].Value = menuQuantityByBillDateDataTable.First().UnitName;
                            row.Cells["Quantity"].Value = menuQuantityByBillDateDataTable.First().Quantity;
                            row.Cells["MenuId"].Value = menuQuantityByBillDateDataTable.First().MenuId;

                            index++;
                            dgvReportBill.AllowUserToAddRows = false;
                        }
                    }
                    subRoot++;
                }
                Root++;
            }
        }

        private void btnExportToExcel_Click(object sender, EventArgs e)
        {
            SaveFileDialog save = new SaveFileDialog();
            save.Title = "Đặt tên file để lưu";
            save.Filter = "Excel XP/2003|*.xls|Excel 2007/2010|*.xlsx";
            if (save.ShowDialog() == DialogResult.Cancel)
                return;
            processingEntity = new ProcessingEntity();
            excelEntity = new ExcelExportEntity();

            if (Path.GetExtension(save.FileName).CompareTo(".xls") == 0)
                excelEntity.ExcelFormat = Constants.ExcelXP2003;
            else if (Path.GetExtension(save.FileName).CompareTo(".xlsx") == 0)
                excelEntity.ExcelFormat = Constants.Excel20072010;

            excelEntity.FilePath = save.FileName;
            excelEntity.Caption = "Báo cáo thực đơn bán theo" + cboReportType.Text;
            excelEntity.Title = "Báo cáo thực đơn bán theo " + cboReportType.Text;
            excelEntity.FromDate = lbFormDate.Text + ": " + dtpFormDate.Text;
            excelEntity.ToDate = lbToDate.Text + ": " + dtpToDate.Text;
            excelEntity.SheetName = "BCTKT";
            
            if (backgroundWorkerExportExcel == null)
            {
                backgroundWorkerExportExcel = new BackgroundWorker();
                backgroundWorkerExportExcel.DoWork +=new DoWorkEventHandler(backgroundWorkerExportExcel_DoWork);
                backgroundWorkerExportExcel.RunWorkerCompleted +=new RunWorkerCompletedEventHandler(backgroundWorkerExportExcel_RunWorkerCompleted);
            }
            processingEntity.Completed = false;
            backgroundWorkerExportExcel.RunWorkerAsync();

            Processing processing = new Processing(processingEntity);
            processing.ShowDialog();

            if (IsExportSuccess)
            {
                LogHistories.InsertLogHistories("Xuất file " + excelEntity.Caption, DateTime.Now, userFunctionList.UserName, "Thành công");
                MessageBox.Show("Xuất thông tin thành công!", Constants.CaptionInformationMessage, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                LogHistories.InsertLogHistories("Xuất file " + excelEntity.Caption, DateTime.Now, userFunctionList.UserName, "Lỗi");
                MessageBox.Show("Lỗi: Xuất thông tin không thành công!", Constants.CaptionErrorMessage, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBills_Click(object sender, EventArgs e)
        {
            ShowBills();
        }

        private void ShowBills()
        {
            if (dgvReportBill.Rows.Count == 0)
                return;

            int type = 0;
            if (cboReportType.SelectedNode.Name.Equals(Constants.Day))
                type = 0;
            else if (cboReportType.SelectedNode.Name.Equals(Constants.Month))
                type = 1;
            else if (cboReportType.SelectedNode.Name.Equals(Constants.Year))
                type = 2;

            int menuId = 0;
            string menuName = string.Empty;

            menuName = (string)dgvReportBill.CurrentRow.Cells["MenuName"].Value;
            menuId = int.Parse(dgvReportBill.CurrentRow.Cells["MenuId"].Value.ToString());
            DetailBillByMenu detailBillByMenu = new DetailBillByMenu(menuId, menuName, dtpFormDate.Value, dtpToDate.Value, type);
            detailBillByMenu.ShowDialog();
        }

        private void dgvReportBill_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            ShowBills();
        }

        private void backgroundWorkerExportExcel_DoWork(object sender, DoWorkEventArgs e)
        {
            IsExportSuccess = ExcelExportController.ExportMenu(dgvReportBill, excelEntity);
        }

        private void backgroundWorkerExportExcel_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            processingEntity.Completed = true;
            backgroundWorkerExportExcel.Dispose();
            backgroundWorkerExportExcel = null;
            GC.Collect();
        }
    }
}

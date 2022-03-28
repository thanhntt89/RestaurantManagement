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
using RestaurantCommon;
using System.IO;

namespace RestaurantManagement
{
    public partial class MeterialInventories : DevComponents.DotNetBar.Metro.MetroForm
    {

        private MeterialGroupDataSet.MeterialGroupDataTable meterialGroupDataTable = null;
        private MeterialGroupController meterialGroupController = new MeterialGroupController();

        private SubMeterialGroupDataSet.SubMeterialGroupDataTable subMeterialGroupDataTable = null;
        private SubMeterialGroupController subMeterialGroupController = new SubMeterialGroupController();

        private MeterialDataSet.MeterialUnitAndSubGroupMeterialDataTable meterialUnitAndSubGroupMeterialDataTable = null;
        private MeterialController meterialController = new MeterialController();

        private MeterialDataSet.MeterialsDataTable meterialsDataTable = null;
        private UserFunctionList userFunctionList;

        private ExcelExportEntity excelEntity = null;
        private ProcessingEntity processingEntity = null;
        private bool IsExportSuccess;

        private MenuMeterialsDataSet.MenuMaterialsDataTable menuMaterialsDataTable = null;
        private MenuMeterialController menuMeterialController = new MenuMeterialController();

        private BillController billController = new BillController();
        private BillsDataSet.CountMenuIdDataTable countMenuIdDataTable = null;

        private MeterialDataSet.MeterialImportDataTable meterialImportDataTable = null;

        public MeterialInventories(UserFunctionList userFunctionList)
        {
            InitializeComponent();
            this.userFunctionList = userFunctionList;
            cboReportType.SelectedIndex = 1;
        }

        private void MeterialInventories_Load(object sender, EventArgs e)
        {
            LoadMenuAll();
            //  treeViewMenu_AfterCheck(null, null);
            // btnSearchReport_Click(null, null);
        }

        private void LoadMenuAll()
        {
            treeViewMenu.Nodes.Clear();
            meterialGroupDataTable = new MeterialGroupDataSet.MeterialGroupDataTable();
            meterialGroupController.GetMeterialGroupByAll(meterialGroupDataTable);
            if (meterialGroupDataTable.Rows.Count == 0)
                return;
            TreeNode RootNode = null;
            TreeNode subRootNode = null;
            TreeNode node = null;
            int indexNode = -1;
            int indexSubRoot = -1;
            treeViewMenu.Nodes.Add(Constants.HOMEMETERIAL);
            // Lấy về danh sách nhóm sub menu nếu có
            foreach (MeterialGroupDataSet.MeterialGroupRow item in meterialGroupDataTable.Rows)
            {
                subMeterialGroupDataTable = new SubMeterialGroupDataSet.SubMeterialGroupDataTable();
                subMeterialGroupController.GetByMerterialGroupId(subMeterialGroupDataTable, item.MeterialGroupId);

                if (subMeterialGroupDataTable.Rows.Count == 0)
                {
                    continue;
                }

                RootNode = new TreeNode(item.MeterialGroupName);
                treeViewMenu.Nodes[0].Nodes.Add(RootNode);
                indexSubRoot++;
                indexNode = -1;

                foreach (SubMeterialGroupDataSet.SubMeterialGroupRow subrow in subMeterialGroupDataTable.Rows)
                {
                    meterialsDataTable = new MeterialDataSet.MeterialsDataTable();
                    meterialController.GetBySubMeterialGroupId(meterialsDataTable, subrow.SubMeterialGroupId);

                    if (meterialsDataTable.Rows.Count == 0)
                    {
                        treeViewMenu.Nodes.RemoveByKey(item.MeterialGroupName);
                        continue;
                    }

                    subRootNode = new TreeNode();
                    subRootNode.Text = subrow.SubMeterialGroupName;
                    subRootNode.Name = "SubRoot" + subrow.SubMeterialGroupId;

                    treeViewMenu.Nodes[0].Nodes[indexSubRoot].Nodes.Add(subRootNode);

                    indexNode++;

                    // Lấy về danh sách các thực đơn
                    foreach (MeterialDataSet.MeterialsRow menuRow in meterialsDataTable.Rows)
                    {
                        node = new TreeNode();
                        node.Text = menuRow.MeterialName;
                        node.Name = menuRow.MeterialId.ToString();

                        treeViewMenu.Nodes[0].Nodes[indexSubRoot].Nodes[indexNode].Nodes.Add(node);
                    }
                }
            }
            treeViewMenu.ExpandAll();
        }

        private void Inventories()
        {
            dgvReportBill.Rows.Clear();
            string billInfor = string.Empty;
            BillEntity billEntity = new BillEntity();
            double exportQuantity = 0;
            double importQuantity = 0;
            int index = 0;
            int Root = 0;
            int subRoot = 0;
            string nodeRoot = string.Empty;
            double reInventoriesQuantity = 0;
            foreach (TreeNode item in treeViewMenu.Nodes[0].Nodes)
            {
                subRoot = 0;

                foreach (TreeNode subroot in treeViewMenu.Nodes[0].Nodes[Root].Nodes)
                {
                    foreach (TreeNode node in treeViewMenu.Nodes[0].Nodes[Root].Nodes[subRoot].Nodes)
                    {
                        if (node.Checked)
                        {
                            billEntity.MeterialId = int.Parse(node.Name);
                            meterialUnitAndSubGroupMeterialDataTable = new MeterialDataSet.MeterialUnitAndSubGroupMeterialDataTable();
                            meterialController.GetByMerterialId(meterialUnitAndSubGroupMeterialDataTable, billEntity.MeterialId);
                            if (meterialUnitAndSubGroupMeterialDataTable.Rows.Count == 0)
                                continue;

                            importQuantity = MeterialImportQuantity(billEntity.MeterialId);
                            exportQuantity = MeterialExportQuantity(billEntity.MeterialId);
                            reInventoriesQuantity = meterialUnitAndSubGroupMeterialDataTable.First().Quantity;
                            dgvReportBill.AllowUserToAddRows = true;
                            dgvReportBill.Rows.Add();
                            DataGridViewRow row = dgvReportBill.Rows[index];
                            row.Cells["STT"].Value = index + 1;
                            row.Cells["MeterialId"].Value = billEntity.MeterialId;
                            row.Cells["MeterialName"].Value = meterialUnitAndSubGroupMeterialDataTable.First().MeterialName;
                            row.Cells["UnitName"].Value = meterialUnitAndSubGroupMeterialDataTable.First().UnitName;
                            row.Cells["ImportQuantity"].Value = importQuantity;
                            row.Cells["ExportQuantity"].Value = exportQuantity;
                            row.Cells["QuantityInventories"].Value = importQuantity - exportQuantity;
                            row.Cells["RealInventoriesQuantity"].Value = reInventoriesQuantity;
                            if (reInventoriesQuantity < 4)
                                row.DefaultCellStyle.ForeColor = Color.Red;

                            index++;
                            dgvReportBill.AllowUserToAddRows = false;
                        }
                    }
                    subRoot++;
                }
                Root++;
            }
        }

        /// <summary>
        /// Lấy về số lượng xuất kho theo nguyên liệu
        /// </summary>
        /// <param name="MeterialId"></param>
        /// <returns></returns>
        private double MeterialExportQuantity(int meterialId)
        {
            double exportQuantity = 0;
            // lấy thông tin thực đơn theo nguyên liệu 
            menuMaterialsDataTable = new MenuMeterialsDataSet.MenuMaterialsDataTable();
            menuMeterialController.GetMenuMeterialByMeterialId(menuMaterialsDataTable, meterialId);

            if (menuMaterialsDataTable.Rows.Count == 0)
                return 0;

            BillEntity billEntity = new BillEntity();
            if (cboReportType.SelectedNode == null)
                return 0;
            if (cboReportType.SelectedNode.Name.Equals(Constants.Day))
            {
                if (dtpToDate.Checked)
                    billEntity.ToDate = dtpToDate.Value.ToString("yyyy-MM-dd 00:00:00");
                if (dtpFormDate.Checked)
                    billEntity.FromDate = dtpFormDate.Value.ToString("yyyy-MM-dd 23:59:59");
            }
            if (cboReportType.SelectedNode.Name.Equals(Constants.Month))
            {
                billEntity.ToMonth = dtpToDate.Value.Month;
                billEntity.FromMonth = dtpFormDate.Value.Month;
                billEntity.ToYear = dtpToDate.Value.Year;
                billEntity.FromYear = dtpFormDate.Value.Year;
            }
            if (cboReportType.SelectedNode.Name.Equals(Constants.Year))
            {
                billEntity.ToYear = dtpToDate.Value.Year;
                billEntity.FromYear = dtpFormDate.Value.Year;
            }

            //Kiểm tra xem có thực đơn nào được tìm thấy trong thời gian yêu cầu hay không
            foreach (MenuMeterialsDataSet.MenuMaterialsRow item in menuMaterialsDataTable.Rows)
            {
                billEntity.MenuId = item.MenuId;
                countMenuIdDataTable = new BillsDataSet.CountMenuIdDataTable();
                billController.CountMeterialQuantity(countMenuIdDataTable, billEntity);

                if (countMenuIdDataTable.Rows.Count > 0)
                    exportQuantity += item.MeterialQuatity * countMenuIdDataTable.First().TotalQuantity;
            }
            return exportQuantity;
        }

        private double MeterialImportQuantity(int meterialId)
        {
            double importQuantity = 0;
            BillEntity billEntity = new BillEntity();
            billEntity.MeterialId = meterialId;
            if (cboReportType.SelectedNode == null)
                return 0;
            if (cboReportType.SelectedNode.Name.Equals(Constants.Day))
            {
                if (dtpToDate.Checked)
                    billEntity.ToDate = dtpToDate.Value.ToString("yyyy-MM-dd 00:00:00");
                if (dtpFormDate.Checked)
                    billEntity.FromDate = dtpFormDate.Value.ToString("yyyy-MM-dd 23:59:59");
            }
            if (cboReportType.SelectedNode.Name.Equals(Constants.Month))
            {
                billEntity.ToMonth = dtpToDate.Value.Month;
                billEntity.FromMonth = dtpFormDate.Value.Month;
                billEntity.ToYear = dtpToDate.Value.Year;
                billEntity.FromYear = dtpFormDate.Value.Year;
            }
            if (cboReportType.SelectedNode.Name.Equals(Constants.Year))
            {
                billEntity.ToYear = dtpToDate.Value.Year;
                billEntity.FromYear = dtpFormDate.Value.Year;
            }

            meterialImportDataTable = new MeterialDataSet.MeterialImportDataTable();
            meterialController.SearchMeterialImportByBillEntity(meterialImportDataTable, billEntity);
            if (meterialImportDataTable.Rows.Count > 0)
                importQuantity = meterialImportDataTable.First().Quantity;
            return importQuantity;
        }

        private void btnSearchReport_Click(object sender, EventArgs e)
        {
            LogHistories.InsertLogHistories("Thống kê tồn kho", DateTime.Now, userFunctionList.UserName, "Thành công");
            Inventories();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void treeViewMenu_AfterCheck(object sender, TreeViewEventArgs e)
        {
            foreach (TreeNode childNode in e.Node.Nodes)
            {
                childNode.Checked = e.Node.Checked;
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
            excelEntity.Caption = "Báo cáo tồn kho theo ";
            excelEntity.Title = "Báo cáo tồn kho từ:" + dtpFormDate.Text + " tới: " + dtpToDate.Text;
            excelEntity.SheetName = "BCTKT";

            if (backgroundWorkerExportExcel == null)
            {
                backgroundWorkerExportExcel = new BackgroundWorker();
                backgroundWorkerExportExcel.DoWork += new DoWorkEventHandler(backgroundWorkerExportExcel_DoWork);
                backgroundWorkerExportExcel.RunWorkerCompleted += new RunWorkerCompletedEventHandler(backgroundWorkerExportExcel_RunWorkerCompleted);
            }

            processingEntity.Completed = false;
            backgroundWorkerExportExcel.RunWorkerAsync();

            Processing processing = new Processing(processingEntity);
            processing.ShowDialog();

            if (IsExportSuccess)
            {
                LogHistories.InsertLogHistories("Xuất ra file thống kê tồn kho", DateTime.Now, userFunctionList.UserName, "Thành công");
                MessageBox.Show("Xuất thông tin thành công!", Constants.CaptionInformationMessage, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                LogHistories.InsertLogHistories("Xuất ra file thống kê tồn kho", DateTime.Now, userFunctionList.UserName, "Lỗi");
                MessageBox.Show("Lỗi: Xuất thông tin không thành công!", Constants.CaptionErrorMessage, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void backgroundWorkerExportExcel_DoWork(object sender, DoWorkEventArgs e)
        {
            IsExportSuccess = ExcelExportController.ExportMeterialInventories(dgvReportBill, excelEntity);
        }

        private void backgroundWorkerExportExcel_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            processingEntity.Completed = true;
            backgroundWorkerExportExcel.Dispose();
            backgroundWorkerExportExcel = null;
            GC.Collect();
        }

        private void cboReportType_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadDateTimeType(cboReportType.SelectedNode.Name);
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

        private void ShowBillForm()
        {
            int type = 0;
            if (cboReportType.SelectedNode.Name.Equals(Constants.Day))
                type = 0;
            else if (cboReportType.SelectedNode.Name.Equals(Constants.Month))
                type = 1;
            else if (cboReportType.SelectedNode.Name.Equals(Constants.Year))
                type = 2;
            int meterialId = (int)dgvReportBill.CurrentRow.Cells["MeterialId"].Value;

            MeterialInBill MeterialInBill = new MeterialInBill(meterialId, dtpFormDate.Value, dtpToDate.Value, type);
            MeterialInBill.ShowDialog();
        }

        private void dgvReportBill_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            ShowBillForm();
        }

        private void btnMenuDetail_Click(object sender, EventArgs e)
        {
            ShowBillForm();
        }
    }
}

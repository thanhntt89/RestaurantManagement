using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using RestaurantDTO;
using Excel = Microsoft.Office.Interop.Excel;
using System.Diagnostics;
using RestaurantCommon;

namespace RestaurantController
{
    public class ExcelExportController
    {
        [DllImport("user32.dll")]
        public static extern uint GetWindowThreadProcessId(IntPtr hWnd, out uint lpdwProcessId);

        public static bool ExportMeterialInventories(DataGridView dataGridView, ExcelExportEntity excelEntity)
        {
            try
            {
                Excel.ApplicationClass ExcelApp = new Excel.ApplicationClass();

                ExcelApp.Application.Workbooks.Add(Type.Missing);

                object missValue = System.Reflection.Missing.Value;
                Excel.Worksheet SheetName = (Excel.Worksheet)ExcelApp.Sheets[1];

                SheetName.Name = excelEntity.SheetName;
                ExcelApp.Caption = excelEntity.Caption;

                int indexRow = 4;

                SheetName.Cells[1, "B"] = excelEntity.Title;
                SheetName.Cells[2, "B"] = excelEntity.FullName;
                SheetName.Cells[3, "B"] = dataGridView.Columns["STT"].HeaderText;
                SheetName.Cells[3, "C"] = dataGridView.Columns["MeterialName"].HeaderText;
                SheetName.Cells[3, "D"] = dataGridView.Columns["UnitName"].HeaderText;
                SheetName.Cells[3, "E"] = dataGridView.Columns["ImportQuantity"].HeaderText;
                SheetName.Cells[3, "F"] = dataGridView.Columns["ExportQuantity"].HeaderText;
                SheetName.Cells[3, "G"] = dataGridView.Columns["QuantityInventories"].HeaderText;
                SheetName.Cells[3, "H"] = dataGridView.Columns["RealInventoriesQuantity"].HeaderText;
               
                // Đặt border cho bảng
                ((Excel.Range)SheetName.Cells[3, "B"]).Borders.ColorIndex = 25;
                ((Excel.Range)SheetName.Cells[3, "C"]).Borders.ColorIndex = 25;
                ((Excel.Range)SheetName.Cells[3, "D"]).Borders.ColorIndex = 25;
                ((Excel.Range)SheetName.Cells[3, "E"]).Borders.ColorIndex = 25;
                ((Excel.Range)SheetName.Cells[3, "F"]).Borders.ColorIndex = 25;
                ((Excel.Range)SheetName.Cells[3, "G"]).Borders.ColorIndex = 25;
                ((Excel.Range)SheetName.Cells[3, "H"]).Borders.ColorIndex = 25;
                // Đặt kích thước cho từng cột
                ((Excel.Range)SheetName.Cells[3, "B"]).ColumnWidth = 5;
                ((Excel.Range)SheetName.Cells[3, "C"]).ColumnWidth = 35;
                ((Excel.Range)SheetName.Cells[3, "D"]).ColumnWidth = 10;
                ((Excel.Range)SheetName.Cells[3, "E"]).ColumnWidth = 15;
                ((Excel.Range)SheetName.Cells[3, "F"]).ColumnWidth = 15;
                ((Excel.Range)SheetName.Cells[3, "G"]).ColumnWidth = 15;
                ((Excel.Range)SheetName.Cells[3, "H"]).ColumnWidth = 15;
                // Format tiêu đề
                ((Excel.Range)SheetName.Cells[3, "B"]).HorizontalAlignment = Excel.Constants.xlCenter;
                ((Excel.Range)SheetName.Cells[3, "C"]).HorizontalAlignment = Excel.Constants.xlCenter;
                ((Excel.Range)SheetName.Cells[3, "D"]).HorizontalAlignment = Excel.Constants.xlCenter;
                ((Excel.Range)SheetName.Cells[3, "E"]).HorizontalAlignment = Excel.Constants.xlCenter;
                ((Excel.Range)SheetName.Cells[3, "F"]).HorizontalAlignment = Excel.Constants.xlCenter;
                ((Excel.Range)SheetName.Cells[3, "G"]).HorizontalAlignment = Excel.Constants.xlCenter;
                ((Excel.Range)SheetName.Cells[3, "H"]).HorizontalAlignment = Excel.Constants.xlCenter;

                // Điền thông tin báo cáo
                for (int i = 0; i < dataGridView.Rows.Count; i++)
                {
                    ((Excel.Range)SheetName.Cells[indexRow, "B"]).Borders.ColorIndex = 25;
                    ((Excel.Range)SheetName.Cells[indexRow, "C"]).Borders.ColorIndex = 25;
                    ((Excel.Range)SheetName.Cells[indexRow, "D"]).Borders.ColorIndex = 25;
                    ((Excel.Range)SheetName.Cells[indexRow, "E"]).Borders.ColorIndex = 25;
                    ((Excel.Range)SheetName.Cells[indexRow, "F"]).Borders.ColorIndex = 25;
                    ((Excel.Range)SheetName.Cells[indexRow, "G"]).Borders.ColorIndex = 25;
                    ((Excel.Range)SheetName.Cells[indexRow, "H"]).Borders.ColorIndex = 25;

                    ((Excel.Range)SheetName.Cells[indexRow, "B"]).HorizontalAlignment = Excel.Constants.xlCenter;
                    ((Excel.Range)SheetName.Cells[indexRow, "D"]).HorizontalAlignment = Excel.Constants.xlCenter;
                    SheetName.Cells[indexRow, "B"] = i + 1;
                    SheetName.Cells[indexRow, "C"] = dataGridView.Rows[i].Cells["MeterialName"].Value.ToString();
                    SheetName.Cells[indexRow, "D"] = dataGridView.Rows[i].Cells["UnitName"].Value.ToString();
                    SheetName.Cells[indexRow, "E"] = dataGridView.Rows[i].Cells["ImportQuantity"].Value.ToString();
                    SheetName.Cells[indexRow, "F"] = dataGridView.Rows[i].Cells["ExportQuantity"].Value.ToString();
                    SheetName.Cells[indexRow, "G"] = dataGridView.Rows[i].Cells["QuantityInventories"].Value.ToString();
                    SheetName.Cells[indexRow, "H"] = dataGridView.Rows[i].Cells["RealInventoriesQuantity"].Value.ToString();

                    indexRow++;
                }

                if (excelEntity.ExcelFormat.Equals(Constants.Excel20072010))
                {
                    ExcelApp.ActiveWorkbook.SaveAs(excelEntity.FilePath, Excel.XlFileFormat.xlWorkbookDefault, missValue, missValue, missValue, missValue, Excel.XlSaveAsAccessMode.xlExclusive, missValue, missValue, missValue, missValue, missValue);
                    //ExcelApp.ActiveWorkbook.Saved = true;
                    ExcelApp.ActiveWorkbook.Close(true, missValue, missValue);
                }
                else if (excelEntity.ExcelFormat.Equals(Constants.ExcelXP2003))
                {
                    ExcelApp.ActiveWorkbook.SaveAs(excelEntity.FilePath, Excel.XlFileFormat.xlWorkbookNormal, missValue, missValue, missValue, missValue, Excel.XlSaveAsAccessMode.xlNoChange, missValue, missValue, missValue, missValue, missValue);
                    ExcelApp.ActiveWorkbook.Saved = true;
                    ExcelApp.ActiveWorkbook.Close(Excel.XlSaveAction.xlSaveChanges, missValue, missValue);
                }

                ExcelApp.Quit();
                int hWnd = ExcelApp.Application.Hwnd;
                uint processID;
                GetWindowThreadProcessId((IntPtr)hWnd, out processID);
                Process[] procs = Process.GetProcessesByName("EXCEL");
                foreach (Process p in procs)
                {
                    if (p.Id == processID)
                        p.Kill();
                }
                Marshal.FinalReleaseComObject(ExcelApp);

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public static bool ExportImportBill(DataGridView dataGridView, ExcelExportEntity excelEntity)
        {
            try
            {
                Excel.ApplicationClass ExcelApp = new Excel.ApplicationClass();

                ExcelApp.Application.Workbooks.Add(Type.Missing);

                object missValue = System.Reflection.Missing.Value;
                Excel.Worksheet SheetName = (Excel.Worksheet)ExcelApp.Sheets[1];

                SheetName.Name = excelEntity.SheetName;
                ExcelApp.Caption = excelEntity.Caption;

                int indexRow = 5;

                SheetName.Cells[1, "B"] = excelEntity.Title;
                SheetName.Cells[2, "B"] = excelEntity.FromDate;
                SheetName.Cells[3, "B"] = excelEntity.ToDate;
                SheetName.Cells[2, "D"] = "Tổng hoá đơn:";
                SheetName.Cells[3, "D"] = "Tổng số tiền:";

                SheetName.Cells[4, "B"] = dataGridView.Columns["STT"].HeaderText;
                SheetName.Cells[4, "C"] = dataGridView.Columns["BillDate"].HeaderText;
                SheetName.Cells[4, "D"] = dataGridView.Columns["BillTotal"].HeaderText;
                SheetName.Cells[4, "E"] = dataGridView.Columns["MoneyTotal"].HeaderText;

                // Đặt border cho bảng
                ((Excel.Range)SheetName.Cells[4, "B"]).Borders.ColorIndex = 25;
                ((Excel.Range)SheetName.Cells[4, "C"]).Borders.ColorIndex = 25;
                ((Excel.Range)SheetName.Cells[4, "D"]).Borders.ColorIndex = 25;
                ((Excel.Range)SheetName.Cells[4, "E"]).Borders.ColorIndex = 25;
                // Đặt kích thước cho từng cột
                ((Excel.Range)SheetName.Cells[4, "B"]).ColumnWidth = 5;
                ((Excel.Range)SheetName.Cells[4, "C"]).ColumnWidth = 45;
                ((Excel.Range)SheetName.Cells[4, "D"]).ColumnWidth = 20;
                ((Excel.Range)SheetName.Cells[4, "E"]).ColumnWidth = 25;

                // Format tiêu đề
                ((Excel.Range)SheetName.Cells[4, "B"]).HorizontalAlignment = Excel.Constants.xlCenter;
                ((Excel.Range)SheetName.Cells[4, "C"]).HorizontalAlignment = Excel.Constants.xlCenter;
                ((Excel.Range)SheetName.Cells[4, "D"]).HorizontalAlignment = Excel.Constants.xlCenter;
                ((Excel.Range)SheetName.Cells[4, "E"]).HorizontalAlignment = Excel.Constants.xlCenter;

                // Điền thông tin báo cáo
                for (int i = 0; i < dataGridView.Rows.Count; i++)
                {
                    ((Excel.Range)SheetName.Cells[indexRow, "B"]).Borders.ColorIndex = 25;
                    ((Excel.Range)SheetName.Cells[indexRow, "C"]).Borders.ColorIndex = 25;
                    ((Excel.Range)SheetName.Cells[indexRow, "D"]).Borders.ColorIndex = 25;
                    ((Excel.Range)SheetName.Cells[indexRow, "E"]).Borders.ColorIndex = 25;
                    ((Excel.Range)SheetName.Cells[indexRow, "B"]).HorizontalAlignment = Excel.Constants.xlCenter;
                    ((Excel.Range)SheetName.Cells[indexRow, "D"]).NumberFormat = "###,#0";
                    SheetName.Cells[indexRow, "B"] = i + 1;
                    SheetName.Cells[indexRow, "C"] = dataGridView.Rows[i].Cells["BillDate"].Value.ToString();
                    SheetName.Cells[indexRow, "D"] = dataGridView.Rows[i].Cells["BillTotal"].Value.ToString();
                    SheetName.Cells[indexRow, "E"] = dataGridView.Rows[i].Cells["MoneyTotal"].Value.ToString();

                    indexRow++;
                }
                ((Excel.Range)SheetName.Cells[3, "E"]).NumberFormat = "###,#0";

                // Tổng tiền
                SheetName.Cells[3, "E"] = "=SUM(E5:E" + indexRow + ")";
                // Tổng hoá đơn
                SheetName.Cells[2, "E"] = "=SUM(D5:D" + indexRow + ")";

                if (excelEntity.ExcelFormat.Equals(Constants.Excel20072010))
                {
                    ExcelApp.ActiveWorkbook.SaveAs(excelEntity.FilePath, Excel.XlFileFormat.xlWorkbookDefault, missValue, missValue, missValue, missValue, Excel.XlSaveAsAccessMode.xlExclusive, missValue, missValue, missValue, missValue, missValue);
                    //ExcelApp.ActiveWorkbook.Saved = true;
                    ExcelApp.ActiveWorkbook.Close(true, missValue, missValue);
                }
                else if (excelEntity.ExcelFormat.Equals(Constants.ExcelXP2003))
                {
                    ExcelApp.ActiveWorkbook.SaveAs(excelEntity.FilePath, Excel.XlFileFormat.xlWorkbookNormal, missValue, missValue, missValue, missValue, Excel.XlSaveAsAccessMode.xlNoChange, missValue, missValue, missValue, missValue, missValue);
                    ExcelApp.ActiveWorkbook.Saved = true;
                    ExcelApp.ActiveWorkbook.Close(Excel.XlSaveAction.xlSaveChanges, missValue, missValue);
                }

                ExcelApp.Quit();
                int hWnd = ExcelApp.Application.Hwnd;
                uint processID;
                GetWindowThreadProcessId((IntPtr)hWnd, out processID);
                Process[] procs = Process.GetProcessesByName("EXCEL");
                foreach (Process p in procs)
                {
                    if (p.Id == processID)
                        p.Kill();
                }
                Marshal.FinalReleaseComObject(ExcelApp);

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public static bool ExportMeterialImport(DataGridView dataGridView, ExcelExportEntity excelEntity)
        {
            try
            {
                Excel.ApplicationClass ExcelApp = new Excel.ApplicationClass();

                ExcelApp.Application.Workbooks.Add(Type.Missing);

                object missValue = System.Reflection.Missing.Value;
                Excel.Worksheet SheetName = (Excel.Worksheet)ExcelApp.Sheets[1];

                SheetName.Name = excelEntity.SheetName;
                ExcelApp.Caption = excelEntity.Caption;

                int indexRow = 5;

                SheetName.Cells[1, "B"] = excelEntity.Title;
                SheetName.Cells[2, "B"] = excelEntity.FromDate;
                SheetName.Cells[3, "B"] = excelEntity.ToDate;
                SheetName.Cells[3, "F"] = "Tổng số tiền:";

                SheetName.Cells[4, "B"] = dataGridView.Columns["STT"].HeaderText;
                SheetName.Cells[4, "C"] = dataGridView.Columns["BillDate"].HeaderText;
                SheetName.Cells[4, "D"] = dataGridView.Columns["MeterialName"].HeaderText;
                SheetName.Cells[4, "E"] = dataGridView.Columns["UnitName"].HeaderText;
                SheetName.Cells[4, "F"] = dataGridView.Columns["Quantity"].HeaderText;
                SheetName.Cells[4, "G"] = dataGridView.Columns["MoenyTotal"].HeaderText;

                // Đặt border cho bảng
                ((Excel.Range)SheetName.Cells[4, "B"]).Borders.ColorIndex = 25;
                ((Excel.Range)SheetName.Cells[4, "C"]).Borders.ColorIndex = 25;
                ((Excel.Range)SheetName.Cells[4, "D"]).Borders.ColorIndex = 25;
                ((Excel.Range)SheetName.Cells[4, "E"]).Borders.ColorIndex = 25;
                ((Excel.Range)SheetName.Cells[4, "F"]).Borders.ColorIndex = 25;
                ((Excel.Range)SheetName.Cells[4, "G"]).Borders.ColorIndex = 25;
                // Đặt kích thước cho từng cột
                ((Excel.Range)SheetName.Cells[4, "B"]).ColumnWidth = 5;
                ((Excel.Range)SheetName.Cells[4, "C"]).ColumnWidth = 50;
                ((Excel.Range)SheetName.Cells[4, "D"]).ColumnWidth = 25;
                ((Excel.Range)SheetName.Cells[4, "E"]).ColumnWidth = 10;
                ((Excel.Range)SheetName.Cells[4, "F"]).ColumnWidth = 20;
                ((Excel.Range)SheetName.Cells[4, "G"]).ColumnWidth = 25;

                // Format tiêu đề
                ((Excel.Range)SheetName.Cells[4, "B"]).HorizontalAlignment = Excel.Constants.xlCenter;
                ((Excel.Range)SheetName.Cells[4, "C"]).HorizontalAlignment = Excel.Constants.xlCenter;
                ((Excel.Range)SheetName.Cells[4, "D"]).HorizontalAlignment = Excel.Constants.xlCenter;
                ((Excel.Range)SheetName.Cells[4, "E"]).HorizontalAlignment = Excel.Constants.xlCenter;
                ((Excel.Range)SheetName.Cells[4, "F"]).HorizontalAlignment = Excel.Constants.xlCenter;
                ((Excel.Range)SheetName.Cells[4, "G"]).HorizontalAlignment = Excel.Constants.xlCenter;

                // Điền thông tin báo cáo
                for (int i = 0; i < dataGridView.Rows.Count; i++)
                {
                    ((Excel.Range)SheetName.Cells[indexRow, "B"]).Borders.ColorIndex = 25;
                    ((Excel.Range)SheetName.Cells[indexRow, "C"]).Borders.ColorIndex = 25;
                    ((Excel.Range)SheetName.Cells[indexRow, "D"]).Borders.ColorIndex = 25;
                    ((Excel.Range)SheetName.Cells[indexRow, "E"]).Borders.ColorIndex = 25;
                    ((Excel.Range)SheetName.Cells[indexRow, "F"]).Borders.ColorIndex = 25;
                    ((Excel.Range)SheetName.Cells[indexRow, "G"]).Borders.ColorIndex = 25;

                    ((Excel.Range)SheetName.Cells[indexRow, "B"]).HorizontalAlignment = Excel.Constants.xlCenter;
                    ((Excel.Range)SheetName.Cells[indexRow, "E"]).HorizontalAlignment = Excel.Constants.xlCenter;
                    ((Excel.Range)SheetName.Cells[indexRow, "G"]).NumberFormat = "###,#0";
                    SheetName.Cells[indexRow, "B"] = i + 1;
                    SheetName.Cells[indexRow, "C"] = dataGridView.Rows[i].Cells["BillDate"].Value.ToString();
                    SheetName.Cells[indexRow, "D"] = dataGridView.Rows[i].Cells["MeterialName"].Value.ToString();
                    SheetName.Cells[indexRow, "E"] = dataGridView.Rows[i].Cells["UnitName"].Value.ToString();
                    SheetName.Cells[indexRow, "F"] = dataGridView.Rows[i].Cells["Quantity"].Value.ToString();
                    SheetName.Cells[indexRow, "G"] = dataGridView.Rows[i].Cells["MoenyTotal"].Value.ToString();

                    indexRow++;
                }
                ((Excel.Range)SheetName.Cells[3, "G"]).NumberFormat = "###,#0";

                // Tổng tiền
                SheetName.Cells[3, "G"] = "=SUM(G5:G" + indexRow + ")";

                if (excelEntity.ExcelFormat.Equals(Constants.Excel20072010))
                {
                    ExcelApp.ActiveWorkbook.SaveAs(excelEntity.FilePath, Excel.XlFileFormat.xlWorkbookDefault, missValue, missValue, missValue, missValue, Excel.XlSaveAsAccessMode.xlExclusive, missValue, missValue, missValue, missValue, missValue);
                    //ExcelApp.ActiveWorkbook.Saved = true;
                    ExcelApp.ActiveWorkbook.Close(true, missValue, missValue);
                }
                else if (excelEntity.ExcelFormat.Equals(Constants.ExcelXP2003))
                {
                    ExcelApp.ActiveWorkbook.SaveAs(excelEntity.FilePath, Excel.XlFileFormat.xlWorkbookNormal, missValue, missValue, missValue, missValue, Excel.XlSaveAsAccessMode.xlNoChange, missValue, missValue, missValue, missValue, missValue);
                    ExcelApp.ActiveWorkbook.Saved = true;
                    ExcelApp.ActiveWorkbook.Close(Excel.XlSaveAction.xlSaveChanges, missValue, missValue);
                }

                ExcelApp.Quit();
                int hWnd = ExcelApp.Application.Hwnd;
                uint processID;
                GetWindowThreadProcessId((IntPtr)hWnd, out processID);
                Process[] procs = Process.GetProcessesByName("EXCEL");
                foreach (Process p in procs)
                {
                    if (p.Id == processID)
                        p.Kill();
                }
                Marshal.FinalReleaseComObject(ExcelApp);

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public static bool ExportBillSale(DataGridView dataGridView, ExcelExportEntity excelEntity)
        {
            try
            {
                return ExportImportBill(dataGridView, excelEntity);
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public static bool ExportMenu(DataGridView dataGridView, ExcelExportEntity excelEntity)
        {
            try
            {
                Excel.ApplicationClass ExcelApp = new Excel.ApplicationClass();

                ExcelApp.Application.Workbooks.Add(Type.Missing);

                object missValue = System.Reflection.Missing.Value;
                Excel.Worksheet SheetName = (Excel.Worksheet)ExcelApp.Sheets[1];

                SheetName.Name = excelEntity.SheetName;
                ExcelApp.Caption = excelEntity.Caption;

                int indexRow = 5;

                SheetName.Cells[1, "B"] = excelEntity.Title;
                SheetName.Cells[2, "B"] = excelEntity.FromDate;
                SheetName.Cells[3, "B"] = excelEntity.ToDate;

                SheetName.Cells[4, "B"] = dataGridView.Columns["STT"].HeaderText;
                SheetName.Cells[4, "C"] = dataGridView.Columns["BillDate"].HeaderText;
                SheetName.Cells[4, "D"] = dataGridView.Columns["MenuName"].HeaderText;
                SheetName.Cells[4, "F"] = dataGridView.Columns["UnitName"].HeaderText;
                SheetName.Cells[4, "E"] = dataGridView.Columns["Quantity"].HeaderText;

                // Đặt border cho bảng
                ((Excel.Range)SheetName.Cells[4, "B"]).Borders.ColorIndex = 25;
                ((Excel.Range)SheetName.Cells[4, "C"]).Borders.ColorIndex = 25;
                ((Excel.Range)SheetName.Cells[4, "D"]).Borders.ColorIndex = 25;
                ((Excel.Range)SheetName.Cells[4, "F"]).Borders.ColorIndex = 25;
                ((Excel.Range)SheetName.Cells[4, "E"]).Borders.ColorIndex = 25;
                // Đặt kích thước cho từng cột
                ((Excel.Range)SheetName.Cells[4, "B"]).ColumnWidth = 5;
                ((Excel.Range)SheetName.Cells[4, "C"]).ColumnWidth = 50;
                ((Excel.Range)SheetName.Cells[4, "D"]).ColumnWidth = 25;
                ((Excel.Range)SheetName.Cells[4, "F"]).ColumnWidth = 10;
                ((Excel.Range)SheetName.Cells[4, "E"]).ColumnWidth = 10;

                // Format tiêu đề
                ((Excel.Range)SheetName.Cells[4, "B"]).HorizontalAlignment = Excel.Constants.xlCenter;
                ((Excel.Range)SheetName.Cells[4, "C"]).HorizontalAlignment = Excel.Constants.xlCenter;
                ((Excel.Range)SheetName.Cells[4, "D"]).HorizontalAlignment = Excel.Constants.xlCenter;
                ((Excel.Range)SheetName.Cells[4, "E"]).HorizontalAlignment = Excel.Constants.xlCenter;
                ((Excel.Range)SheetName.Cells[4, "F"]).HorizontalAlignment = Excel.Constants.xlCenter;

                // Điền thông tin báo cáo
                for (int i = 0; i < dataGridView.Rows.Count; i++)
                {
                    ((Excel.Range)SheetName.Cells[indexRow, "B"]).Borders.ColorIndex = 25;
                    ((Excel.Range)SheetName.Cells[indexRow, "C"]).Borders.ColorIndex = 25;
                    ((Excel.Range)SheetName.Cells[indexRow, "D"]).Borders.ColorIndex = 25;
                    ((Excel.Range)SheetName.Cells[indexRow, "E"]).Borders.ColorIndex = 25;
                    ((Excel.Range)SheetName.Cells[indexRow, "F"]).Borders.ColorIndex = 25;

                    ((Excel.Range)SheetName.Cells[indexRow, "B"]).HorizontalAlignment = Excel.Constants.xlCenter;
                    ((Excel.Range)SheetName.Cells[indexRow, "E"]).HorizontalAlignment = Excel.Constants.xlCenter;
                    SheetName.Cells[indexRow, "B"] = i + 1;
                    SheetName.Cells[indexRow, "C"] = dataGridView.Rows[i].Cells["BillDate"].Value.ToString();
                    SheetName.Cells[indexRow, "D"] = dataGridView.Rows[i].Cells["MenuName"].Value.ToString();
                    SheetName.Cells[indexRow, "F"] = dataGridView.Rows[i].Cells["UnitName"].Value.ToString();
                    SheetName.Cells[indexRow, "E"] = dataGridView.Rows[i].Cells["Quantity"].Value.ToString();

                    indexRow++;
                }

                if (excelEntity.ExcelFormat.Equals(Constants.Excel20072010))
                {
                    ExcelApp.ActiveWorkbook.SaveAs(excelEntity.FilePath, Excel.XlFileFormat.xlWorkbookDefault, missValue, missValue, missValue, missValue, Excel.XlSaveAsAccessMode.xlExclusive, missValue, missValue, missValue, missValue, missValue);
                    //ExcelApp.ActiveWorkbook.Saved = true;
                    ExcelApp.ActiveWorkbook.Close(true, missValue, missValue);
                }
                else if (excelEntity.ExcelFormat.Equals(Constants.ExcelXP2003))
                {
                    ExcelApp.ActiveWorkbook.SaveAs(excelEntity.FilePath, Excel.XlFileFormat.xlWorkbookNormal, missValue, missValue, missValue, missValue, Excel.XlSaveAsAccessMode.xlNoChange, missValue, missValue, missValue, missValue, missValue);
                    ExcelApp.ActiveWorkbook.Saved = true;
                    ExcelApp.ActiveWorkbook.Close(Excel.XlSaveAction.xlSaveChanges, missValue, missValue);
                }

                ExcelApp.Quit();
                int hWnd = ExcelApp.Application.Hwnd;
                uint processID;
                GetWindowThreadProcessId((IntPtr)hWnd, out processID);
                Process[] procs = Process.GetProcessesByName("EXCEL");
                foreach (Process p in procs)
                {
                    if (p.Id == processID)
                        p.Kill();
                }
                Marshal.FinalReleaseComObject(ExcelApp);

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public static bool ExportServicesBill(DataGridView dataGridView, ExcelExportEntity excelEntity)
        {
            try
            {
                Excel.ApplicationClass ExcelApp = new Excel.ApplicationClass();

                ExcelApp.Application.Workbooks.Add(Type.Missing);

                object missValue = System.Reflection.Missing.Value;
                Excel.Worksheet SheetName = (Excel.Worksheet)ExcelApp.Sheets[1];

                SheetName.Name = excelEntity.SheetName;
                ExcelApp.Caption = excelEntity.Caption;

                int indexRow = 5;

                SheetName.Cells[1, "B"] = excelEntity.Title;
                SheetName.Cells[2, "B"] = excelEntity.FromDate;
                SheetName.Cells[3, "B"] = excelEntity.ToDate;

                SheetName.Cells[4, "B"] = dataGridView.Columns["STT"].HeaderText;
                SheetName.Cells[4, "C"] = dataGridView.Columns["StaffName"].HeaderText;
                SheetName.Cells[4, "D"] = dataGridView.Columns["ShiftName"].HeaderText;
                SheetName.Cells[4, "E"] = dataGridView.Columns["BillCode"].HeaderText;
                SheetName.Cells[4, "F"] = dataGridView.Columns["BillDate"].HeaderText;
                SheetName.Cells[4, "G"] = dataGridView.Columns["TableName"].HeaderText;
                SheetName.Cells[4, "H"] = dataGridView.Columns["TotalCost"].HeaderText;
                SheetName.Cells[4, "I"] = dataGridView.Columns["Status"].HeaderText;

                // Đặt border cho bảng
                ((Excel.Range)SheetName.Cells[4, "B"]).Borders.ColorIndex = 25;
                ((Excel.Range)SheetName.Cells[4, "C"]).Borders.ColorIndex = 25;
                ((Excel.Range)SheetName.Cells[4, "D"]).Borders.ColorIndex = 25;
                ((Excel.Range)SheetName.Cells[4, "F"]).Borders.ColorIndex = 25;
                ((Excel.Range)SheetName.Cells[4, "E"]).Borders.ColorIndex = 25;
                ((Excel.Range)SheetName.Cells[4, "G"]).Borders.ColorIndex = 25;
                ((Excel.Range)SheetName.Cells[4, "H"]).Borders.ColorIndex = 25;
                ((Excel.Range)SheetName.Cells[4, "I"]).Borders.ColorIndex = 25;
                // Đặt kích thước cho từng cột
                ((Excel.Range)SheetName.Cells[4, "B"]).ColumnWidth = 5;
                ((Excel.Range)SheetName.Cells[4, "C"]).ColumnWidth = 32;
                ((Excel.Range)SheetName.Cells[4, "D"]).ColumnWidth = 21;
                ((Excel.Range)SheetName.Cells[4, "F"]).ColumnWidth = 22;
                ((Excel.Range)SheetName.Cells[4, "E"]).ColumnWidth = 13;
                ((Excel.Range)SheetName.Cells[4, "G"]).ColumnWidth = 25;
                ((Excel.Range)SheetName.Cells[4, "H"]).ColumnWidth = 18;
                ((Excel.Range)SheetName.Cells[4, "I"]).ColumnWidth = 15;

                // Format tiêu đề
                ((Excel.Range)SheetName.Cells[4, "B"]).HorizontalAlignment = Excel.Constants.xlCenter;
                ((Excel.Range)SheetName.Cells[4, "C"]).HorizontalAlignment = Excel.Constants.xlCenter;
                ((Excel.Range)SheetName.Cells[4, "D"]).HorizontalAlignment = Excel.Constants.xlCenter;
                ((Excel.Range)SheetName.Cells[4, "E"]).HorizontalAlignment = Excel.Constants.xlCenter;
                ((Excel.Range)SheetName.Cells[4, "F"]).HorizontalAlignment = Excel.Constants.xlCenter;
                ((Excel.Range)SheetName.Cells[4, "G"]).HorizontalAlignment = Excel.Constants.xlCenter;
                ((Excel.Range)SheetName.Cells[4, "H"]).HorizontalAlignment = Excel.Constants.xlCenter;
                ((Excel.Range)SheetName.Cells[4, "I"]).HorizontalAlignment = Excel.Constants.xlCenter;

                // Điền thông tin báo cáo
                for (int i = 0; i < dataGridView.Rows.Count; i++)
                {
                    ((Excel.Range)SheetName.Cells[indexRow, "B"]).Borders.ColorIndex = 25;
                    ((Excel.Range)SheetName.Cells[indexRow, "C"]).Borders.ColorIndex = 25;
                    ((Excel.Range)SheetName.Cells[indexRow, "D"]).Borders.ColorIndex = 25;
                    ((Excel.Range)SheetName.Cells[indexRow, "E"]).Borders.ColorIndex = 25;
                    ((Excel.Range)SheetName.Cells[indexRow, "F"]).Borders.ColorIndex = 25;
                    ((Excel.Range)SheetName.Cells[indexRow, "G"]).Borders.ColorIndex = 25;
                    ((Excel.Range)SheetName.Cells[indexRow, "H"]).Borders.ColorIndex = 25;
                    ((Excel.Range)SheetName.Cells[indexRow, "I"]).Borders.ColorIndex = 25;

                    ((Excel.Range)SheetName.Cells[indexRow, "B"]).HorizontalAlignment = Excel.Constants.xlCenter;
                    ((Excel.Range)SheetName.Cells[indexRow, "E"]).HorizontalAlignment = Excel.Constants.xlCenter;

                    SheetName.Cells[indexRow, "B"] = i + 1;
                    SheetName.Cells[indexRow, "C"] = dataGridView.Rows[i].Cells["StaffName"].Value == null ? string.Empty : dataGridView.Rows[i].Cells["StaffName"].Value.ToString();
                    SheetName.Cells[indexRow, "D"] = dataGridView.Rows[i].Cells["ShiftName"].Value == null ? string.Empty : dataGridView.Rows[i].Cells["ShiftName"].Value.ToString();
                    SheetName.Cells[indexRow, "F"] = dataGridView.Rows[i].Cells["BillDate"].Value.ToString();
                    SheetName.Cells[indexRow, "E"] = dataGridView.Rows[i].Cells["BillCode"].Value == null ? string.Empty : dataGridView.Rows[i].Cells["BillCode"].Value.ToString();
                    SheetName.Cells[indexRow, "G"] = dataGridView.Rows[i].Cells["TableName"].Value.ToString();
                    SheetName.Cells[indexRow, "H"] = dataGridView.Rows[i].Cells["TotalCost"].Value.ToString();
                    ((Excel.Range)SheetName.Cells[indexRow, "H"]).NumberFormat = "###,#0";

                    if ((bool)dataGridView.Rows[i].Cells["Status"].Value)
                        SheetName.Cells[indexRow, "I"] = "X";

                    indexRow++;
                }

                if (excelEntity.ExcelFormat.Equals(Constants.Excel20072010))
                {
                    ExcelApp.ActiveWorkbook.SaveAs(excelEntity.FilePath, Excel.XlFileFormat.xlWorkbookDefault, missValue, missValue, missValue, missValue, Excel.XlSaveAsAccessMode.xlExclusive, missValue, missValue, missValue, missValue, missValue);
                    //ExcelApp.ActiveWorkbook.Saved = true;
                    ExcelApp.ActiveWorkbook.Close(true, missValue, missValue);
                }
                else if (excelEntity.ExcelFormat.Equals(Constants.ExcelXP2003))
                {
                    ExcelApp.ActiveWorkbook.SaveAs(excelEntity.FilePath, Excel.XlFileFormat.xlWorkbookNormal, missValue, missValue, missValue, missValue, Excel.XlSaveAsAccessMode.xlNoChange, missValue, missValue, missValue, missValue, missValue);
                    ExcelApp.ActiveWorkbook.Saved = true;
                    ExcelApp.ActiveWorkbook.Close(Excel.XlSaveAction.xlSaveChanges, missValue, missValue);
                }

                ExcelApp.Quit();
                int hWnd = ExcelApp.Application.Hwnd;
                uint processID;
                GetWindowThreadProcessId((IntPtr)hWnd, out processID);
                Process[] procs = Process.GetProcessesByName("EXCEL");
                foreach (Process p in procs)
                {
                    if (p.Id == processID)
                        p.Kill();
                }
                Marshal.FinalReleaseComObject(ExcelApp);

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public static bool ExportImportBillMeterial(DataGridView dataGridView, ExcelExportEntity excelEntity)
        {
            try
            {
                Excel.ApplicationClass ExcelApp = new Excel.ApplicationClass();

                ExcelApp.Application.Workbooks.Add(Type.Missing);

                object missValue = System.Reflection.Missing.Value;
                Excel.Worksheet SheetName = (Excel.Worksheet)ExcelApp.Sheets[1];

                SheetName.Name = excelEntity.SheetName;
                ExcelApp.Caption = excelEntity.Caption;

                int indexRow = 6;

                SheetName.Cells[1, "B"] = excelEntity.Title;
                SheetName.Cells[2, "B"] = excelEntity.FromDate;
                SheetName.Cells[3, "B"] = excelEntity.ToDate;
                SheetName.Cells[4, "B"] = "Nhân viên: " + excelEntity.FullName;

                SheetName.Cells[5, "B"] = dataGridView.Columns["ImportIndex"].HeaderText;
                SheetName.Cells[5, "C"] = dataGridView.Columns["ImportStaffName"].HeaderText;
                SheetName.Cells[5, "D"] = dataGridView.Columns["ImportBillCode"].HeaderText;
                SheetName.Cells[5, "E"] = dataGridView.Columns["ImportBillDateTime"].HeaderText;
                SheetName.Cells[5, "F"] = dataGridView.Columns["ImportTotalMoney"].HeaderText;
                SheetName.Cells[5, "G"] = dataGridView.Columns["ImportNote"].HeaderText;

                // Đặt border cho bảng
                ((Excel.Range)SheetName.Cells[5, "B"]).Borders.ColorIndex = 25;
                ((Excel.Range)SheetName.Cells[5, "C"]).Borders.ColorIndex = 25;
                ((Excel.Range)SheetName.Cells[5, "D"]).Borders.ColorIndex = 25;
                ((Excel.Range)SheetName.Cells[5, "E"]).Borders.ColorIndex = 25;
                ((Excel.Range)SheetName.Cells[5, "F"]).Borders.ColorIndex = 25;
                ((Excel.Range)SheetName.Cells[5, "G"]).Borders.ColorIndex = 25;
                // Đặt kích thước cho từng cột
                ((Excel.Range)SheetName.Cells[5, "B"]).ColumnWidth = 5;
                ((Excel.Range)SheetName.Cells[5, "C"]).ColumnWidth = 25;
                ((Excel.Range)SheetName.Cells[5, "D"]).ColumnWidth = 20;
                ((Excel.Range)SheetName.Cells[5, "E"]).ColumnWidth = 20;
                ((Excel.Range)SheetName.Cells[5, "F"]).ColumnWidth = 20;
                ((Excel.Range)SheetName.Cells[5, "G"]).ColumnWidth = 20;
                // Format tiêu đề
                ((Excel.Range)SheetName.Cells[5, "B"]).HorizontalAlignment = Excel.Constants.xlCenter;
                ((Excel.Range)SheetName.Cells[5, "C"]).HorizontalAlignment = Excel.Constants.xlCenter;
                ((Excel.Range)SheetName.Cells[5, "D"]).HorizontalAlignment = Excel.Constants.xlCenter;
                ((Excel.Range)SheetName.Cells[5, "E"]).HorizontalAlignment = Excel.Constants.xlCenter;
                ((Excel.Range)SheetName.Cells[5, "F"]).HorizontalAlignment = Excel.Constants.xlCenter;
                ((Excel.Range)SheetName.Cells[5, "G"]).HorizontalAlignment = Excel.Constants.xlCenter;

                // Điền thông tin báo cáo
                for (int i = 0; i < dataGridView.Rows.Count; i++)
                {
                    ((Excel.Range)SheetName.Cells[indexRow, "B"]).Borders.ColorIndex = 25;
                    ((Excel.Range)SheetName.Cells[indexRow, "C"]).Borders.ColorIndex = 25;
                    ((Excel.Range)SheetName.Cells[indexRow, "D"]).Borders.ColorIndex = 25;
                    ((Excel.Range)SheetName.Cells[indexRow, "E"]).Borders.ColorIndex = 25;
                    ((Excel.Range)SheetName.Cells[indexRow, "F"]).Borders.ColorIndex = 25;
                    ((Excel.Range)SheetName.Cells[indexRow, "G"]).Borders.ColorIndex = 25;
                    ((Excel.Range)SheetName.Cells[indexRow, "E"]).HorizontalAlignment = Excel.Constants.xlCenter;
                    ((Excel.Range)SheetName.Cells[indexRow, "F"]).NumberFormat = "###,#0";

                    SheetName.Cells[indexRow, "B"] = i + 1;
                    SheetName.Cells[indexRow, "C"] = dataGridView.Rows[i].Cells["ImportStaffName"].Value == null ? string.Empty : dataGridView.Rows[i].Cells["ImportStaffName"].Value.ToString();
                    SheetName.Cells[indexRow, "D"] = dataGridView.Rows[i].Cells["ImportBillCode"].Value == null ? string.Empty : dataGridView.Rows[i].Cells["ImportBillCode"].Value.ToString();
                    SheetName.Cells[indexRow, "E"] = dataGridView.Rows[i].Cells["ImportBillDateTime"].Value.ToString();
                    SheetName.Cells[indexRow, "F"] = dataGridView.Rows[i].Cells["ImportTotalMoney"].Value.ToString();
                    SheetName.Cells[indexRow, "G"] = dataGridView.Rows[i].Cells["ImportNote"].Value == null ? string.Empty : dataGridView.Rows[i].Cells["ImportNote"].Value.ToString();

                    indexRow++;
                }
                SheetName.Cells[4, "E"] = "Tổng tiền:";
                ((Excel.Range)SheetName.Cells[4, "E"]).HorizontalAlignment = Excel.Constants.xlRight;
                ((Excel.Range)SheetName.Cells[4, "F"]).NumberFormat = "###,#0";

                // Tổng tiền
                SheetName.Cells[4, "F"] = "=SUM(F6:F" + indexRow + ")";

                if (excelEntity.ExcelFormat.Equals(Constants.Excel20072010))
                {
                    ExcelApp.ActiveWorkbook.SaveAs(excelEntity.FilePath, Excel.XlFileFormat.xlWorkbookDefault, missValue, missValue, missValue, missValue, Excel.XlSaveAsAccessMode.xlExclusive, missValue, missValue, missValue, missValue, missValue);
                    //ExcelApp.ActiveWorkbook.Saved = true;
                    ExcelApp.ActiveWorkbook.Close(true, missValue, missValue);
                }
                else if (excelEntity.ExcelFormat.Equals(Constants.ExcelXP2003))
                {
                    ExcelApp.ActiveWorkbook.SaveAs(excelEntity.FilePath, Excel.XlFileFormat.xlWorkbookNormal, missValue, missValue, missValue, missValue, Excel.XlSaveAsAccessMode.xlNoChange, missValue, missValue, missValue, missValue, missValue);
                    ExcelApp.ActiveWorkbook.Saved = true;
                    ExcelApp.ActiveWorkbook.Close(Excel.XlSaveAction.xlSaveChanges, missValue, missValue);
                }

                ExcelApp.Quit();
                int hWnd = ExcelApp.Application.Hwnd;
                uint processID;
                GetWindowThreadProcessId((IntPtr)hWnd, out processID);
                Process[] procs = Process.GetProcessesByName("EXCEL");
                foreach (Process p in procs)
                {
                    if (p.Id == processID)
                        p.Kill();
                }
                Marshal.FinalReleaseComObject(ExcelApp);

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}

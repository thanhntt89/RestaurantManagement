namespace RestaurantManagement
{
    partial class MeterialInventories
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MeterialInventories));
            this.dgvReportBill = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.node1 = new DevComponents.AdvTree.Node();
            this.node4 = new DevComponents.AdvTree.Node();
            this.treeViewMenu = new System.Windows.Forms.TreeView();
            this.node5 = new DevComponents.AdvTree.Node();
            this.btnSearchReport = new DevComponents.DotNetBar.ButtonX();
            this.btnClose = new DevComponents.DotNetBar.ButtonX();
            this.node2 = new DevComponents.AdvTree.Node();
            this.node3 = new DevComponents.AdvTree.Node();
            this.backgroundWorkerExportExcel = new System.ComponentModel.BackgroundWorker();
            this.label1 = new System.Windows.Forms.Label();
            this.cboReportType = new DevComponents.DotNetBar.Controls.ComboTree();
            this.Day = new DevComponents.AdvTree.Node();
            this.Month = new DevComponents.AdvTree.Node();
            this.Year = new DevComponents.AdvTree.Node();
            this.dtpToDate = new System.Windows.Forms.DateTimePicker();
            this.dtpFormDate = new System.Windows.Forms.DateTimePicker();
            this.lbToDate = new System.Windows.Forms.Label();
            this.lbFormDate = new System.Windows.Forms.Label();
            this.btnExportToExcel = new DevComponents.DotNetBar.ButtonX();
            this.btnMenuDetail = new DevComponents.DotNetBar.ButtonX();
            this.label2 = new System.Windows.Forms.Label();
            this.STT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MeterialName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UnitName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ImportQuantity = new DevComponents.DotNetBar.Controls.DataGridViewDoubleInputColumn();
            this.ExportQuantity = new DevComponents.DotNetBar.Controls.DataGridViewDoubleInputColumn();
            this.QuantityInventories = new DevComponents.DotNetBar.Controls.DataGridViewIntegerInputColumn();
            this.RealInventoriesQuantity = new DevComponents.DotNetBar.Controls.DataGridViewDoubleInputColumn();
            this.MeterialId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReportBill)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvReportBill
            // 
            this.dgvReportBill.AllowUserToAddRows = false;
            this.dgvReportBill.AllowUserToDeleteRows = false;
            this.dgvReportBill.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvReportBill.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvReportBill.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvReportBill.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvReportBill.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.STT,
            this.MeterialName,
            this.UnitName,
            this.ImportQuantity,
            this.ExportQuantity,
            this.QuantityInventories,
            this.RealInventoriesQuantity,
            this.MeterialId});
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvReportBill.DefaultCellStyle = dataGridViewCellStyle8;
            this.dgvReportBill.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.dgvReportBill.Location = new System.Drawing.Point(258, 39);
            this.dgvReportBill.MultiSelect = false;
            this.dgvReportBill.Name = "dgvReportBill";
            this.dgvReportBill.ReadOnly = true;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvReportBill.RowHeadersDefaultCellStyle = dataGridViewCellStyle9;
            this.dgvReportBill.RowHeadersVisible = false;
            this.dgvReportBill.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvReportBill.Size = new System.Drawing.Size(716, 577);
            this.dgvReportBill.TabIndex = 31;
            this.dgvReportBill.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvReportBill_CellDoubleClick);
            // 
            // node1
            // 
            this.node1.Name = "node1";
            this.node1.Text = "Node 1";
            // 
            // node4
            // 
            this.node4.Name = "node4";
            this.node4.Text = "Node 2";
            // 
            // treeViewMenu
            // 
            this.treeViewMenu.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.treeViewMenu.BackColor = System.Drawing.Color.White;
            this.treeViewMenu.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.treeViewMenu.CheckBoxes = true;
            this.treeViewMenu.ForeColor = System.Drawing.Color.Black;
            this.treeViewMenu.FullRowSelect = true;
            this.treeViewMenu.HideSelection = false;
            this.treeViewMenu.Location = new System.Drawing.Point(11, 122);
            this.treeViewMenu.Name = "treeViewMenu";
            this.treeViewMenu.Size = new System.Drawing.Size(241, 494);
            this.treeViewMenu.TabIndex = 35;
            this.treeViewMenu.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.treeViewMenu_AfterCheck);
            // 
            // node5
            // 
            this.node5.Checked = true;
            this.node5.CheckState = System.Windows.Forms.CheckState.Checked;
            this.node5.Name = "node5";
            this.node5.Text = "Node 3";
            // 
            // btnSearchReport
            // 
            this.btnSearchReport.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSearchReport.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnSearchReport.Location = new System.Drawing.Point(11, 93);
            this.btnSearchReport.Name = "btnSearchReport";
            this.btnSearchReport.Size = new System.Drawing.Size(75, 23);
            this.btnSearchReport.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnSearchReport.TabIndex = 32;
            this.btnSearchReport.Text = "Tổng hợp";
            this.btnSearchReport.Click += new System.EventHandler(this.btnSearchReport_Click);
            // 
            // btnClose
            // 
            this.btnClose.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnClose.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnClose.Location = new System.Drawing.Point(180, 93);
            this.btnClose.Name = "btnClose";
            this.btnClose.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.CtrlD);
            this.btnClose.Size = new System.Drawing.Size(71, 23);
            this.btnClose.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnClose.TabIndex = 33;
            this.btnClose.Text = "Đóng lại";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // node2
            // 
            this.node2.Checked = true;
            this.node2.CheckState = System.Windows.Forms.CheckState.Checked;
            this.node2.Expanded = true;
            this.node2.Name = "node2";
            this.node2.Nodes.AddRange(new DevComponents.AdvTree.Node[] {
            this.node1,
            this.node4,
            this.node5});
            this.node2.Text = "Node 1";
            // 
            // node3
            // 
            this.node3.Checked = true;
            this.node3.CheckState = System.Windows.Forms.CheckState.Checked;
            this.node3.Name = "node3";
            this.node3.Text = "Node 2";
            // 
            // backgroundWorkerExportExcel
            // 
            this.backgroundWorkerExportExcel.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerExportExcel_DoWork);
            this.backgroundWorkerExportExcel.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorkerExportExcel_RunWorkerCompleted);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(12, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 13);
            this.label1.TabIndex = 41;
            this.label1.Text = "Thời gian";
            // 
            // cboReportType
            // 
            this.cboReportType.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.cboReportType.BackgroundStyle.Class = "TextBoxBorder";
            this.cboReportType.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.cboReportType.ButtonDropDown.Visible = true;
            this.cboReportType.ColumnsVisible = false;
            this.cboReportType.ForeColor = System.Drawing.Color.Black;
            this.cboReportType.GridColumnLines = false;
            this.cboReportType.Location = new System.Drawing.Point(92, 12);
            this.cboReportType.Name = "cboReportType";
            this.cboReportType.Nodes.AddRange(new DevComponents.AdvTree.Node[] {
            this.Day,
            this.Month,
            this.Year});
            this.cboReportType.Size = new System.Drawing.Size(160, 22);
            this.cboReportType.Style = DevComponents.DotNetBar.eDotNetBarStyle.Metro;
            this.cboReportType.TabIndex = 40;
            this.cboReportType.SelectedIndexChanged += new System.EventHandler(this.cboReportType_SelectedIndexChanged);
            // 
            // Day
            // 
            this.Day.Name = "Day";
            this.Day.Text = "Theo ngày";
            // 
            // Month
            // 
            this.Month.Name = "Month";
            this.Month.Text = "Theo tháng";
            // 
            // Year
            // 
            this.Year.Name = "Year";
            this.Year.Text = "Theo năm";
            // 
            // dtpToDate
            // 
            this.dtpToDate.BackColor = System.Drawing.Color.White;
            this.dtpToDate.CustomFormat = "dd/MM/yyyy";
            this.dtpToDate.ForeColor = System.Drawing.Color.Black;
            this.dtpToDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpToDate.Location = new System.Drawing.Point(92, 67);
            this.dtpToDate.Name = "dtpToDate";
            this.dtpToDate.ShowCheckBox = true;
            this.dtpToDate.Size = new System.Drawing.Size(160, 20);
            this.dtpToDate.TabIndex = 38;
            // 
            // dtpFormDate
            // 
            this.dtpFormDate.BackColor = System.Drawing.Color.White;
            this.dtpFormDate.CustomFormat = "dd/MM/yyyy";
            this.dtpFormDate.ForeColor = System.Drawing.Color.Black;
            this.dtpFormDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFormDate.Location = new System.Drawing.Point(92, 40);
            this.dtpFormDate.Name = "dtpFormDate";
            this.dtpFormDate.ShowCheckBox = true;
            this.dtpFormDate.Size = new System.Drawing.Size(160, 20);
            this.dtpFormDate.TabIndex = 39;
            // 
            // lbToDate
            // 
            this.lbToDate.AutoSize = true;
            this.lbToDate.BackColor = System.Drawing.Color.White;
            this.lbToDate.ForeColor = System.Drawing.Color.Black;
            this.lbToDate.Location = new System.Drawing.Point(10, 68);
            this.lbToDate.Name = "lbToDate";
            this.lbToDate.Size = new System.Drawing.Size(53, 13);
            this.lbToDate.TabIndex = 36;
            this.lbToDate.Text = "Đến ngày";
            // 
            // lbFormDate
            // 
            this.lbFormDate.AutoSize = true;
            this.lbFormDate.BackColor = System.Drawing.Color.White;
            this.lbFormDate.ForeColor = System.Drawing.Color.Black;
            this.lbFormDate.Location = new System.Drawing.Point(9, 39);
            this.lbFormDate.Name = "lbFormDate";
            this.lbFormDate.Size = new System.Drawing.Size(46, 13);
            this.lbFormDate.TabIndex = 37;
            this.lbFormDate.Text = "Từ ngày";
            // 
            // btnExportToExcel
            // 
            this.btnExportToExcel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnExportToExcel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnExportToExcel.Location = new System.Drawing.Point(92, 93);
            this.btnExportToExcel.Name = "btnExportToExcel";
            this.btnExportToExcel.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.CtrlD);
            this.btnExportToExcel.Size = new System.Drawing.Size(82, 23);
            this.btnExportToExcel.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnExportToExcel.TabIndex = 33;
            this.btnExportToExcel.Text = "Xuất ra Excel";
            this.btnExportToExcel.Click += new System.EventHandler(this.btnExportToExcel_Click);
            // 
            // btnMenuDetail
            // 
            this.btnMenuDetail.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnMenuDetail.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnMenuDetail.Location = new System.Drawing.Point(258, 12);
            this.btnMenuDetail.Name = "btnMenuDetail";
            this.btnMenuDetail.Size = new System.Drawing.Size(104, 23);
            this.btnMenuDetail.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnMenuDetail.TabIndex = 32;
            this.btnMenuDetail.Text = "Chi tiết thực đơn";
            this.btnMenuDetail.Click += new System.EventHandler(this.btnMenuDetail_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(532, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 42;
            this.label2.Text = "Tinh theo: ";
            // 
            // STT
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.STT.DefaultCellStyle = dataGridViewCellStyle2;
            this.STT.HeaderText = "STT";
            this.STT.Name = "STT";
            this.STT.ReadOnly = true;
            this.STT.Width = 50;
            // 
            // MeterialName
            // 
            this.MeterialName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.MeterialName.HeaderText = "Tên nguyên liệu";
            this.MeterialName.Name = "MeterialName";
            this.MeterialName.ReadOnly = true;
            // 
            // UnitName
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.UnitName.DefaultCellStyle = dataGridViewCellStyle3;
            this.UnitName.HeaderText = "Đơn vị tính";
            this.UnitName.Name = "UnitName";
            this.UnitName.ReadOnly = true;
            // 
            // ImportQuantity
            // 
            // 
            // 
            // 
            this.ImportQuantity.BackgroundStyle.Class = "DataGridViewNumericBorder";
            this.ImportQuantity.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.ImportQuantity.DefaultCellStyle = dataGridViewCellStyle4;
            this.ImportQuantity.HeaderText = "Nhập";
            this.ImportQuantity.Increment = 1;
            this.ImportQuantity.MinValue = 0;
            this.ImportQuantity.Name = "ImportQuantity";
            this.ImportQuantity.ReadOnly = true;
            this.ImportQuantity.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // ExportQuantity
            // 
            // 
            // 
            // 
            this.ExportQuantity.BackgroundStyle.Class = "DataGridViewNumericBorder";
            this.ExportQuantity.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.ExportQuantity.DefaultCellStyle = dataGridViewCellStyle5;
            this.ExportQuantity.HeaderText = "Xuất";
            this.ExportQuantity.Increment = 1;
            this.ExportQuantity.MinValue = 0;
            this.ExportQuantity.Name = "ExportQuantity";
            this.ExportQuantity.ReadOnly = true;
            this.ExportQuantity.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // QuantityInventories
            // 
            // 
            // 
            // 
            this.QuantityInventories.BackgroundStyle.BackColor = System.Drawing.SystemColors.Window;
            this.QuantityInventories.BackgroundStyle.Class = "DataGridViewNumericBorder";
            this.QuantityInventories.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.QuantityInventories.BackgroundStyle.TextColor = System.Drawing.Color.Black;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.QuantityInventories.DefaultCellStyle = dataGridViewCellStyle6;
            this.QuantityInventories.HeaderText = "Tồn = Nhập - Xuất";
            this.QuantityInventories.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            this.QuantityInventories.MinValue = -1999999;
            this.QuantityInventories.Name = "QuantityInventories";
            this.QuantityInventories.ReadOnly = true;
            this.QuantityInventories.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.QuantityInventories.Width = 120;
            // 
            // RealInventoriesQuantity
            // 
            // 
            // 
            // 
            this.RealInventoriesQuantity.BackgroundStyle.Class = "DataGridViewNumericBorder";
            this.RealInventoriesQuantity.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.RealInventoriesQuantity.DefaultCellStyle = dataGridViewCellStyle7;
            this.RealInventoriesQuantity.HeaderText = "Thực tồn";
            this.RealInventoriesQuantity.Increment = 1;
            this.RealInventoriesQuantity.MinValue = 0;
            this.RealInventoriesQuantity.Name = "RealInventoriesQuantity";
            this.RealInventoriesQuantity.ReadOnly = true;
            this.RealInventoriesQuantity.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.RealInventoriesQuantity.Width = 120;
            // 
            // MeterialId
            // 
            this.MeterialId.HeaderText = "MeterialId";
            this.MeterialId.Name = "MeterialId";
            this.MeterialId.ReadOnly = true;
            this.MeterialId.Visible = false;
            // 
            // MeterialInventories
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(986, 628);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cboReportType);
            this.Controls.Add(this.dtpToDate);
            this.Controls.Add(this.dtpFormDate);
            this.Controls.Add(this.lbToDate);
            this.Controls.Add(this.lbFormDate);
            this.Controls.Add(this.dgvReportBill);
            this.Controls.Add(this.treeViewMenu);
            this.Controls.Add(this.btnMenuDetail);
            this.Controls.Add(this.btnSearchReport);
            this.Controls.Add(this.btnExportToExcel);
            this.Controls.Add(this.btnClose);
            this.DoubleBuffered = true;
            this.FlattenMDIBorder = false;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MeterialInventories";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Báo cáo xuất nhập tồn nguyên liệu";
            this.Load += new System.EventHandler(this.MeterialInventories_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvReportBill)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevComponents.DotNetBar.Controls.DataGridViewX dgvReportBill;
        private DevComponents.AdvTree.Node node1;
        private DevComponents.AdvTree.Node node4;
        private System.Windows.Forms.TreeView treeViewMenu;
        private DevComponents.AdvTree.Node node5;
        private DevComponents.DotNetBar.ButtonX btnSearchReport;
        private DevComponents.DotNetBar.ButtonX btnClose;
        private DevComponents.AdvTree.Node node2;
        private DevComponents.AdvTree.Node node3;
        private System.ComponentModel.BackgroundWorker backgroundWorkerExportExcel;
        private System.Windows.Forms.Label label1;
        private DevComponents.DotNetBar.Controls.ComboTree cboReportType;
        private DevComponents.AdvTree.Node Day;
        private DevComponents.AdvTree.Node Month;
        private DevComponents.AdvTree.Node Year;
        private System.Windows.Forms.DateTimePicker dtpToDate;
        private System.Windows.Forms.DateTimePicker dtpFormDate;
        private System.Windows.Forms.Label lbToDate;
        private System.Windows.Forms.Label lbFormDate;
        private DevComponents.DotNetBar.ButtonX btnExportToExcel;
        private DevComponents.DotNetBar.ButtonX btnMenuDetail;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridViewTextBoxColumn STT;
        private System.Windows.Forms.DataGridViewTextBoxColumn MeterialName;
        private System.Windows.Forms.DataGridViewTextBoxColumn UnitName;
        private DevComponents.DotNetBar.Controls.DataGridViewDoubleInputColumn ImportQuantity;
        private DevComponents.DotNetBar.Controls.DataGridViewDoubleInputColumn ExportQuantity;
        private DevComponents.DotNetBar.Controls.DataGridViewIntegerInputColumn QuantityInventories;
        private DevComponents.DotNetBar.Controls.DataGridViewDoubleInputColumn RealInventoriesQuantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn MeterialId;
    }
}

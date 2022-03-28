namespace RestaurantManagement
{
    partial class UserControlMenuReport
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dtpToDate = new System.Windows.Forms.DateTimePicker();
            this.dtpFormDate = new System.Windows.Forms.DateTimePicker();
            this.lbToDate = new System.Windows.Forms.Label();
            this.lbFormDate = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cboReportType = new DevComponents.DotNetBar.Controls.ComboTree();
            this.Day = new DevComponents.AdvTree.Node();
            this.Month = new DevComponents.AdvTree.Node();
            this.Year = new DevComponents.AdvTree.Node();
            this.dgvReportBill = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.STT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BillDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MenuName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Quantity = new DevComponents.DotNetBar.Controls.DataGridViewIntegerInputColumn();
            this.UnitName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MenuId = new DevComponents.DotNetBar.Controls.DataGridViewIntegerInputColumn();
            this.btnSearchReport = new DevComponents.DotNetBar.ButtonX();
            this.btnExportToExcel = new DevComponents.DotNetBar.ButtonX();
            this.btnClose = new DevComponents.DotNetBar.ButtonX();
            this.node2 = new DevComponents.AdvTree.Node();
            this.node1 = new DevComponents.AdvTree.Node();
            this.node4 = new DevComponents.AdvTree.Node();
            this.node5 = new DevComponents.AdvTree.Node();
            this.node3 = new DevComponents.AdvTree.Node();
            this.treeViewMenu = new System.Windows.Forms.TreeView();
            this.label2 = new System.Windows.Forms.Label();
            this.btnBills = new DevComponents.DotNetBar.ButtonX();
            this.backgroundWorkerExportExcel = new System.ComponentModel.BackgroundWorker();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReportBill)).BeginInit();
            this.SuspendLayout();
            // 
            // dtpToDate
            // 
            this.dtpToDate.Checked = false;
            this.dtpToDate.CustomFormat = "dd/MM/yyyy";
            this.dtpToDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpToDate.Location = new System.Drawing.Point(89, 70);
            this.dtpToDate.Name = "dtpToDate";
            this.dtpToDate.ShowCheckBox = true;
            this.dtpToDate.Size = new System.Drawing.Size(160, 20);
            this.dtpToDate.TabIndex = 5;
            // 
            // dtpFormDate
            // 
            this.dtpFormDate.Checked = false;
            this.dtpFormDate.CustomFormat = "dd/MM/yyyy";
            this.dtpFormDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFormDate.Location = new System.Drawing.Point(89, 43);
            this.dtpFormDate.Name = "dtpFormDate";
            this.dtpFormDate.ShowCheckBox = true;
            this.dtpFormDate.Size = new System.Drawing.Size(160, 20);
            this.dtpFormDate.TabIndex = 6;
            // 
            // lbToDate
            // 
            this.lbToDate.AutoSize = true;
            this.lbToDate.Location = new System.Drawing.Point(7, 71);
            this.lbToDate.Name = "lbToDate";
            this.lbToDate.Size = new System.Drawing.Size(53, 13);
            this.lbToDate.TabIndex = 3;
            this.lbToDate.Text = "Đến ngày";
            // 
            // lbFormDate
            // 
            this.lbFormDate.AutoSize = true;
            this.lbFormDate.Location = new System.Drawing.Point(6, 42);
            this.lbFormDate.Name = "lbFormDate";
            this.lbFormDate.Size = new System.Drawing.Size(46, 13);
            this.lbFormDate.TabIndex = 4;
            this.lbFormDate.Text = "Từ ngày";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Thời gian";
            // 
            // cboReportType
            // 
            this.cboReportType.BackColor = System.Drawing.SystemColors.Window;
            // 
            // 
            // 
            this.cboReportType.BackgroundStyle.Class = "TextBoxBorder";
            this.cboReportType.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.cboReportType.ButtonDropDown.Visible = true;
            this.cboReportType.ColumnsVisible = false;
            this.cboReportType.GridColumnLines = false;
            this.cboReportType.Location = new System.Drawing.Point(89, 15);
            this.cboReportType.Name = "cboReportType";
            this.cboReportType.Nodes.AddRange(new DevComponents.AdvTree.Node[] {
            this.Day,
            this.Month,
            this.Year});
            this.cboReportType.Size = new System.Drawing.Size(160, 22);
            this.cboReportType.Style = DevComponents.DotNetBar.eDotNetBarStyle.Metro;
            this.cboReportType.TabIndex = 7;
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
            this.BillDate,
            this.MenuName,
            this.Quantity,
            this.UnitName,
            this.MenuId});
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvReportBill.DefaultCellStyle = dataGridViewCellStyle5;
            this.dgvReportBill.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.dgvReportBill.Location = new System.Drawing.Point(257, 42);
            this.dgvReportBill.MultiSelect = false;
            this.dgvReportBill.Name = "dgvReportBill";
            this.dgvReportBill.ReadOnly = true;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvReportBill.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dgvReportBill.RowHeadersVisible = false;
            this.dgvReportBill.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvReportBill.Size = new System.Drawing.Size(678, 556);
            this.dgvReportBill.TabIndex = 9;
            this.dgvReportBill.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvReportBill_CellDoubleClick);
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
            // BillDate
            // 
            this.BillDate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.BillDate.HeaderText = "Thời gian";
            this.BillDate.Name = "BillDate";
            this.BillDate.ReadOnly = true;
            // 
            // MenuName
            // 
            this.MenuName.HeaderText = "Tên thực đơn";
            this.MenuName.Name = "MenuName";
            this.MenuName.ReadOnly = true;
            this.MenuName.Width = 150;
            // 
            // Quantity
            // 
            // 
            // 
            // 
            this.Quantity.BackgroundStyle.BackColor = System.Drawing.SystemColors.Window;
            this.Quantity.BackgroundStyle.Class = "DataGridViewNumericBorder";
            this.Quantity.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.Quantity.BackgroundStyle.TextColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.Quantity.DefaultCellStyle = dataGridViewCellStyle3;
            this.Quantity.HeaderText = "Đã bán ra";
            this.Quantity.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            this.Quantity.MinValue = 0;
            this.Quantity.Name = "Quantity";
            this.Quantity.ReadOnly = true;
            this.Quantity.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // UnitName
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.UnitName.DefaultCellStyle = dataGridViewCellStyle4;
            this.UnitName.HeaderText = "Đơn vị tính";
            this.UnitName.Name = "UnitName";
            this.UnitName.ReadOnly = true;
            // 
            // MenuId
            // 
            // 
            // 
            // 
            this.MenuId.BackgroundStyle.Class = "DataGridViewNumericBorder";
            this.MenuId.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.MenuId.HeaderText = "MenuId";
            this.MenuId.Name = "MenuId";
            this.MenuId.ReadOnly = true;
            this.MenuId.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.MenuId.Visible = false;
            // 
            // btnSearchReport
            // 
            this.btnSearchReport.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSearchReport.Location = new System.Drawing.Point(12, 94);
            this.btnSearchReport.Name = "btnSearchReport";
            this.btnSearchReport.Size = new System.Drawing.Size(75, 23);
            this.btnSearchReport.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnSearchReport.TabIndex = 10;
            this.btnSearchReport.Text = "Tổng hợp";
            this.btnSearchReport.Click += new System.EventHandler(this.btnSearchReport_Click);
            // 
            // btnExportToExcel
            // 
            this.btnExportToExcel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnExportToExcel.Location = new System.Drawing.Point(93, 94);
            this.btnExportToExcel.Name = "btnExportToExcel";
            this.btnExportToExcel.Size = new System.Drawing.Size(81, 23);
            this.btnExportToExcel.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnExportToExcel.TabIndex = 12;
            this.btnExportToExcel.Text = "Xuất ra Excel";
            this.btnExportToExcel.Click += new System.EventHandler(this.btnExportToExcel_Click);
            // 
            // btnClose
            // 
            this.btnClose.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnClose.Location = new System.Drawing.Point(180, 94);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(71, 23);
            this.btnClose.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnClose.TabIndex = 11;
            this.btnClose.Text = "Đóng";
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
            // node5
            // 
            this.node5.Checked = true;
            this.node5.CheckState = System.Windows.Forms.CheckState.Checked;
            this.node5.Name = "node5";
            this.node5.Text = "Node 3";
            // 
            // node3
            // 
            this.node3.Checked = true;
            this.node3.CheckState = System.Windows.Forms.CheckState.Checked;
            this.node3.Name = "node3";
            this.node3.Text = "Node 2";
            // 
            // treeViewMenu
            // 
            this.treeViewMenu.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.treeViewMenu.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.treeViewMenu.CheckBoxes = true;
            this.treeViewMenu.FullRowSelect = true;
            this.treeViewMenu.HideSelection = false;
            this.treeViewMenu.Location = new System.Drawing.Point(12, 121);
            this.treeViewMenu.Name = "treeViewMenu";
            this.treeViewMenu.Size = new System.Drawing.Size(239, 477);
            this.treeViewMenu.TabIndex = 13;
            this.treeViewMenu.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.treeViewMenu_AfterCheck);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(255, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(147, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Thống kê thực đơn bán hàng";
            // 
            // btnBills
            // 
            this.btnBills.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnBills.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBills.Location = new System.Drawing.Point(826, 15);
            this.btnBills.Name = "btnBills";
            this.btnBills.Size = new System.Drawing.Size(109, 23);
            this.btnBills.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnBills.TabIndex = 14;
            this.btnBills.Text = "Danh sách hóa đơn";
            this.btnBills.Click += new System.EventHandler(this.btnBills_Click);
            // 
            // backgroundWorkerExportExcel
            // 
            this.backgroundWorkerExportExcel.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerExportExcel_DoWork);
            this.backgroundWorkerExportExcel.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorkerExportExcel_RunWorkerCompleted);
            // 
            // UserControlMenuReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.Controls.Add(this.btnBills);
            this.Controls.Add(this.treeViewMenu);
            this.Controls.Add(this.btnExportToExcel);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSearchReport);
            this.Controls.Add(this.dgvReportBill);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cboReportType);
            this.Controls.Add(this.dtpToDate);
            this.Controls.Add(this.dtpFormDate);
            this.Controls.Add(this.lbToDate);
            this.Controls.Add(this.lbFormDate);
            this.Name = "UserControlMenuReport";
            this.Size = new System.Drawing.Size(948, 613);
            ((System.ComponentModel.ISupportInitialize)(this.dgvReportBill)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dtpToDate;
        private System.Windows.Forms.DateTimePicker dtpFormDate;
        private System.Windows.Forms.Label lbToDate;
        private System.Windows.Forms.Label lbFormDate;
        private System.Windows.Forms.Label label1;
        private DevComponents.DotNetBar.Controls.ComboTree cboReportType;
        private DevComponents.AdvTree.Node Day;
        private DevComponents.AdvTree.Node Month;
        private DevComponents.AdvTree.Node Year;
        private DevComponents.DotNetBar.Controls.DataGridViewX dgvReportBill;
        private DevComponents.DotNetBar.ButtonX btnSearchReport;
        private DevComponents.DotNetBar.ButtonX btnExportToExcel;
        private DevComponents.DotNetBar.ButtonX btnClose;
        private DevComponents.AdvTree.Node node2;
        private DevComponents.AdvTree.Node node3;
        private DevComponents.AdvTree.Node node1;
        private DevComponents.AdvTree.Node node4;
        private DevComponents.AdvTree.Node node5;
        private System.Windows.Forms.TreeView treeViewMenu;
        private System.Windows.Forms.Label label2;
        private DevComponents.DotNetBar.ButtonX btnBills;
        private System.Windows.Forms.DataGridViewTextBoxColumn STT;
        private System.Windows.Forms.DataGridViewTextBoxColumn BillDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn MenuName;
        private DevComponents.DotNetBar.Controls.DataGridViewIntegerInputColumn Quantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn UnitName;
        private DevComponents.DotNetBar.Controls.DataGridViewIntegerInputColumn MenuId;
        private System.ComponentModel.BackgroundWorker backgroundWorkerExportExcel;
    }
}

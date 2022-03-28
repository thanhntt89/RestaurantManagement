namespace RestaurantManagement
{
    partial class UserControlBillsManagement
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnExportToExcel = new DevComponents.DotNetBar.ButtonX();
            this.btnClose = new DevComponents.DotNetBar.ButtonX();
            this.btnSearchReport = new DevComponents.DotNetBar.ButtonX();
            this.txtTotalMoney = new DevComponents.Editors.DoubleInput();
            this.txtBillTotal = new DevComponents.Editors.DoubleInput();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.dtpToDate = new System.Windows.Forms.DateTimePicker();
            this.dtpFormDate = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cboStaff = new DevComponents.DotNetBar.Controls.ComboTree();
            this.cboReportType = new DevComponents.DotNetBar.Controls.ComboTree();
            this.dgvReportBill = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.Sale = new DevComponents.AdvTree.Node();
            this.Import = new DevComponents.AdvTree.Node();
            this.Export = new DevComponents.AdvTree.Node();
            this.STT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StaffName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BillCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BillDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ShiftName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CustomerName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MoneyTotal = new DevComponents.DotNetBar.Controls.DataGridViewDoubleInputColumn();
            this.Delete = new System.Windows.Forms.DataGridViewButtonColumn();
            this.BillId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotalMoney)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBillTotal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReportBill)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.btnExportToExcel);
            this.groupBox1.Controls.Add(this.btnClose);
            this.groupBox1.Controls.Add(this.btnSearchReport);
            this.groupBox1.Controls.Add(this.txtTotalMoney);
            this.groupBox1.Controls.Add(this.txtBillTotal);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.dtpToDate);
            this.groupBox1.Controls.Add(this.dtpFormDate);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.cboStaff);
            this.groupBox1.Controls.Add(this.cboReportType);
            this.groupBox1.Location = new System.Drawing.Point(6, 11);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(946, 110);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông tin nhóm";
            // 
            // btnExportToExcel
            // 
            this.btnExportToExcel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnExportToExcel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExportToExcel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnExportToExcel.Location = new System.Drawing.Point(825, 81);
            this.btnExportToExcel.Name = "btnExportToExcel";
            this.btnExportToExcel.Size = new System.Drawing.Size(81, 23);
            this.btnExportToExcel.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnExportToExcel.TabIndex = 5;
            this.btnExportToExcel.Text = "Xuất ra Excel";
            // 
            // btnClose
            // 
            this.btnClose.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnClose.Location = new System.Drawing.Point(744, 81);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnClose.TabIndex = 5;
            this.btnClose.Text = "Đóng lại";
            // 
            // btnSearchReport
            // 
            this.btnSearchReport.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSearchReport.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnSearchReport.Location = new System.Drawing.Point(92, 81);
            this.btnSearchReport.Name = "btnSearchReport";
            this.btnSearchReport.Size = new System.Drawing.Size(75, 23);
            this.btnSearchReport.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnSearchReport.TabIndex = 5;
            this.btnSearchReport.Text = "Tổng hợp";
            this.btnSearchReport.Click += new System.EventHandler(this.btnSearchReport_Click);
            // 
            // txtTotalMoney
            // 
            this.txtTotalMoney.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.txtTotalMoney.BackgroundStyle.Class = "DateTimeInputBackground";
            this.txtTotalMoney.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtTotalMoney.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.txtTotalMoney.DisplayFormat = "###,#0";
            this.txtTotalMoney.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotalMoney.ForeColor = System.Drawing.Color.Red;
            this.txtTotalMoney.Increment = 1;
            this.txtTotalMoney.IsInputReadOnly = true;
            this.txtTotalMoney.Location = new System.Drawing.Point(744, 53);
            this.txtTotalMoney.MinValue = 0;
            this.txtTotalMoney.Name = "txtTotalMoney";
            this.txtTotalMoney.Size = new System.Drawing.Size(155, 21);
            this.txtTotalMoney.TabIndex = 4;
            // 
            // txtBillTotal
            // 
            this.txtBillTotal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.txtBillTotal.BackgroundStyle.Class = "DateTimeInputBackground";
            this.txtBillTotal.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtBillTotal.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.txtBillTotal.DisplayFormat = "###,#0";
            this.txtBillTotal.ForeColor = System.Drawing.Color.Navy;
            this.txtBillTotal.Increment = 1;
            this.txtBillTotal.IsInputReadOnly = true;
            this.txtBillTotal.Location = new System.Drawing.Point(744, 25);
            this.txtBillTotal.MinValue = 0;
            this.txtBillTotal.Name = "txtBillTotal";
            this.txtBillTotal.Size = new System.Drawing.Size(155, 20);
            this.txtBillTotal.TabIndex = 4;
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Red;
            this.label7.Location = new System.Drawing.Point(905, 56);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(35, 15);
            this.label7.TabIndex = 3;
            this.label7.Text = "VNĐ";
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(635, 53);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(86, 13);
            this.label5.TabIndex = 3;
            this.label5.Text = "Tổng doanh thu:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(9, 50);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(56, 13);
            this.label6.TabIndex = 3;
            this.label6.Text = "Nhân viên";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(635, 26);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(78, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Tổng hoá đơn:";
            // 
            // dtpToDate
            // 
            this.dtpToDate.CustomFormat = "dd/MM/yyyy";
            this.dtpToDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpToDate.Location = new System.Drawing.Point(362, 49);
            this.dtpToDate.Name = "dtpToDate";
            this.dtpToDate.Size = new System.Drawing.Size(108, 20);
            this.dtpToDate.TabIndex = 2;
            // 
            // dtpFormDate
            // 
            this.dtpFormDate.CustomFormat = "dd/MM/yyyy";
            this.dtpFormDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFormDate.Location = new System.Drawing.Point(362, 22);
            this.dtpFormDate.Name = "dtpFormDate";
            this.dtpFormDate.Size = new System.Drawing.Size(108, 20);
            this.dtpFormDate.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(297, 52);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Đến ngày";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(296, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Từ ngày";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Báo cáo theo";
            // 
            // cboStaff
            // 
            this.cboStaff.BackColor = System.Drawing.SystemColors.Window;
            // 
            // 
            // 
            this.cboStaff.BackgroundStyle.Class = "TextBoxBorder";
            this.cboStaff.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.cboStaff.ButtonDropDown.Visible = true;
            this.cboStaff.ColumnsVisible = false;
            this.cboStaff.GridColumnLines = false;
            this.cboStaff.Location = new System.Drawing.Point(92, 49);
            this.cboStaff.Name = "cboStaff";
            this.cboStaff.Size = new System.Drawing.Size(195, 22);
            this.cboStaff.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cboStaff.TabIndex = 0;
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
            this.cboReportType.Location = new System.Drawing.Point(92, 21);
            this.cboReportType.Name = "cboReportType";
            this.cboReportType.Nodes.AddRange(new DevComponents.AdvTree.Node[] {
            this.Sale,
            this.Import,
            this.Export});
            this.cboReportType.Size = new System.Drawing.Size(195, 22);
            this.cboReportType.Style = DevComponents.DotNetBar.eDotNetBarStyle.Metro;
            this.cboReportType.TabIndex = 0;
            // 
            // dgvReportBill
            // 
            this.dgvReportBill.AllowUserToAddRows = false;
            this.dgvReportBill.AllowUserToDeleteRows = false;
            this.dgvReportBill.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvReportBill.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dgvReportBill.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvReportBill.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.STT,
            this.StaffName,
            this.BillCode,
            this.BillDate,
            this.ShiftName,
            this.CustomerName,
            this.MoneyTotal,
            this.Delete,
            this.BillId});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvReportBill.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvReportBill.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.dgvReportBill.Location = new System.Drawing.Point(6, 127);
            this.dgvReportBill.MultiSelect = false;
            this.dgvReportBill.Name = "dgvReportBill";
            this.dgvReportBill.ReadOnly = true;
            this.dgvReportBill.RowHeadersVisible = false;
            this.dgvReportBill.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvReportBill.Size = new System.Drawing.Size(946, 418);
            this.dgvReportBill.TabIndex = 3;
            this.dgvReportBill.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvReportBill_CellClick);
            // 
            // Sale
            // 
            this.Sale.Name = "Sale";
            this.Sale.Text = "Bán hàng";
            // 
            // Import
            // 
            this.Import.Name = "Import";
            this.Import.Text = "Nhập kho";
            // 
            // Export
            // 
            this.Export.Name = "Export";
            this.Export.Text = "Xuất kho";
            // 
            // STT
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.STT.DefaultCellStyle = dataGridViewCellStyle1;
            this.STT.HeaderText = "STT";
            this.STT.Name = "STT";
            this.STT.ReadOnly = true;
            this.STT.Width = 50;
            // 
            // StaffName
            // 
            this.StaffName.HeaderText = "Nhân viên";
            this.StaffName.Name = "StaffName";
            this.StaffName.ReadOnly = true;
            this.StaffName.Width = 250;
            // 
            // BillCode
            // 
            this.BillCode.HeaderText = "Mã hoá đơn";
            this.BillCode.Name = "BillCode";
            this.BillCode.ReadOnly = true;
            this.BillCode.Width = 125;
            // 
            // BillDate
            // 
            this.BillDate.HeaderText = "Thời gian";
            this.BillDate.Name = "BillDate";
            this.BillDate.ReadOnly = true;
            this.BillDate.Width = 120;
            // 
            // ShiftName
            // 
            this.ShiftName.HeaderText = "Ca";
            this.ShiftName.Name = "ShiftName";
            this.ShiftName.ReadOnly = true;
            // 
            // CustomerName
            // 
            this.CustomerName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.CustomerName.HeaderText = "Bàn ăn";
            this.CustomerName.Name = "CustomerName";
            this.CustomerName.ReadOnly = true;
            // 
            // MoneyTotal
            // 
            // 
            // 
            // 
            this.MoneyTotal.BackgroundStyle.BackColor = System.Drawing.SystemColors.Window;
            this.MoneyTotal.BackgroundStyle.Class = "DataGridViewNumericBorder";
            this.MoneyTotal.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.MoneyTotal.BackgroundStyle.TextColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.MoneyTotal.DefaultCellStyle = dataGridViewCellStyle2;
            this.MoneyTotal.DisplayFormat = "###,#0";
            this.MoneyTotal.HeaderText = "Tổng tiền (VNĐ)";
            this.MoneyTotal.Increment = 1;
            this.MoneyTotal.Name = "MoneyTotal";
            this.MoneyTotal.ReadOnly = true;
            this.MoneyTotal.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.MoneyTotal.Width = 120;
            // 
            // Delete
            // 
            this.Delete.HeaderText = "Xoá";
            this.Delete.Name = "Delete";
            this.Delete.ReadOnly = true;
            this.Delete.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Delete.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Delete.Width = 60;
            // 
            // BillId
            // 
            this.BillId.HeaderText = "BillId";
            this.BillId.Name = "BillId";
            this.BillId.ReadOnly = true;
            this.BillId.Visible = false;
            // 
            // UserControlBillsManagement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dgvReportBill);
            this.Name = "UserControlBillsManagement";
            this.Size = new System.Drawing.Size(955, 548);
            this.Load += new System.EventHandler(this.UserControlBillsManagement_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotalMoney)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBillTotal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReportBill)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private DevComponents.DotNetBar.ButtonX btnExportToExcel;
        private DevComponents.DotNetBar.ButtonX btnClose;
        private DevComponents.DotNetBar.ButtonX btnSearchReport;
        private DevComponents.Editors.DoubleInput txtTotalMoney;
        private DevComponents.Editors.DoubleInput txtBillTotal;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dtpToDate;
        private System.Windows.Forms.DateTimePicker dtpFormDate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private DevComponents.DotNetBar.Controls.ComboTree cboStaff;
        private DevComponents.DotNetBar.Controls.ComboTree cboReportType;
        private DevComponents.DotNetBar.Controls.DataGridViewX dgvReportBill;
        private DevComponents.AdvTree.Node Sale;
        private DevComponents.AdvTree.Node Import;
        private DevComponents.AdvTree.Node Export;
        private System.Windows.Forms.DataGridViewTextBoxColumn STT;
        private System.Windows.Forms.DataGridViewTextBoxColumn StaffName;
        private System.Windows.Forms.DataGridViewTextBoxColumn BillCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn BillDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn ShiftName;
        private System.Windows.Forms.DataGridViewTextBoxColumn CustomerName;
        private DevComponents.DotNetBar.Controls.DataGridViewDoubleInputColumn MoneyTotal;
        private System.Windows.Forms.DataGridViewButtonColumn Delete;
        private System.Windows.Forms.DataGridViewTextBoxColumn BillId;
    }
}

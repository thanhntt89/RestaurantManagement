namespace RestaurantManagement
{
    partial class MeterialInBill
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MeterialInBill));
            this.dtpToDate = new System.Windows.Forms.DateTimePicker();
            this.dtpFromDate = new System.Windows.Forms.DateTimePicker();
            this.labelX3 = new DevComponents.DotNetBar.LabelX();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.btnSearch = new DevComponents.DotNetBar.ButtonX();
            this.btnExit = new DevComponents.DotNetBar.ButtonX();
            this.BillId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvBills = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.STT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BillCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BillDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Quantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dgvMenu = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.cboMeterial = new System.Windows.Forms.ComboBox();
            this.Index = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MenuName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Selected = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.MenuId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBills)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMenu)).BeginInit();
            this.SuspendLayout();
            // 
            // dtpToDate
            // 
            this.dtpToDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpToDate.BackColor = System.Drawing.Color.White;
            this.dtpToDate.CustomFormat = "dd/MM/yyyy";
            this.dtpToDate.ForeColor = System.Drawing.Color.Black;
            this.dtpToDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpToDate.Location = new System.Drawing.Point(587, 8);
            this.dtpToDate.Name = "dtpToDate";
            this.dtpToDate.ShowCheckBox = true;
            this.dtpToDate.Size = new System.Drawing.Size(109, 22);
            this.dtpToDate.TabIndex = 11;
            // 
            // dtpFromDate
            // 
            this.dtpFromDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpFromDate.BackColor = System.Drawing.Color.White;
            this.dtpFromDate.CustomFormat = "dd/MM/yyyy";
            this.dtpFromDate.ForeColor = System.Drawing.Color.Black;
            this.dtpFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFromDate.Location = new System.Drawing.Point(423, 9);
            this.dtpFromDate.Name = "dtpFromDate";
            this.dtpFromDate.ShowCheckBox = true;
            this.dtpFromDate.Size = new System.Drawing.Size(103, 22);
            this.dtpFromDate.TabIndex = 12;
            // 
            // labelX3
            // 
            this.labelX3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelX3.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.labelX3.BackgroundStyle.Class = "";
            this.labelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX3.ForeColor = System.Drawing.Color.Black;
            this.labelX3.Location = new System.Drawing.Point(532, 8);
            this.labelX3.Name = "labelX3";
            this.labelX3.Size = new System.Drawing.Size(49, 23);
            this.labelX3.TabIndex = 10;
            this.labelX3.Text = "Đến ngày";
            // 
            // labelX2
            // 
            this.labelX2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelX2.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.labelX2.BackgroundStyle.Class = "";
            this.labelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX2.ForeColor = System.Drawing.Color.Black;
            this.labelX2.Location = new System.Drawing.Point(376, 8);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(49, 23);
            this.labelX2.TabIndex = 8;
            this.labelX2.Text = "Từ ngày";
            // 
            // labelX1
            // 
            this.labelX1.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.Class = "";
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.ForeColor = System.Drawing.Color.Black;
            this.labelX1.Location = new System.Drawing.Point(4, 5);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(64, 23);
            this.labelX1.TabIndex = 7;
            this.labelX1.Text = "Nguyên liệu:";
            // 
            // btnSearch
            // 
            this.btnSearch.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSearch.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnSearch.Location = new System.Drawing.Point(705, 8);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.CtrlD);
            this.btnSearch.Size = new System.Drawing.Size(66, 23);
            this.btnSearch.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnSearch.TabIndex = 5;
            this.btnSearch.Text = "Tìm";
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnExit
            // 
            this.btnExit.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExit.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnExit.Location = new System.Drawing.Point(777, 8);
            this.btnExit.Name = "btnExit";
            this.btnExit.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.CtrlD);
            this.btnExit.Size = new System.Drawing.Size(75, 23);
            this.btnExit.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnExit.TabIndex = 6;
            this.btnExit.Text = "Đóng";
            this.btnExit.Tooltip = "Ctrl + D";
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // BillId
            // 
            this.BillId.HeaderText = "BillId";
            this.BillId.Name = "BillId";
            this.BillId.ReadOnly = true;
            this.BillId.Visible = false;
            // 
            // dgvBills
            // 
            this.dgvBills.AllowUserToAddRows = false;
            this.dgvBills.AllowUserToDeleteRows = false;
            this.dgvBills.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dgvBills.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBills.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.STT,
            this.BillCode,
            this.BillDate,
            this.Quantity,
            this.BillId});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvBills.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvBills.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvBills.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.dgvBills.Location = new System.Drawing.Point(3, 18);
            this.dgvBills.Name = "dgvBills";
            this.dgvBills.ReadOnly = true;
            this.dgvBills.RowHeadersVisible = false;
            this.dgvBills.Size = new System.Drawing.Size(540, 465);
            this.dgvBills.TabIndex = 0;
            // 
            // STT
            // 
            this.STT.HeaderText = "STT";
            this.STT.Name = "STT";
            this.STT.ReadOnly = true;
            this.STT.Width = 50;
            // 
            // BillCode
            // 
            this.BillCode.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.BillCode.HeaderText = "Mã hoá đơn";
            this.BillCode.Name = "BillCode";
            this.BillCode.ReadOnly = true;
            // 
            // BillDate
            // 
            this.BillDate.HeaderText = "Ngày hoá đơn";
            this.BillDate.Name = "BillDate";
            this.BillDate.ReadOnly = true;
            this.BillDate.Width = 120;
            // 
            // Quantity
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Quantity.DefaultCellStyle = dataGridViewCellStyle1;
            this.Quantity.HeaderText = "Số lượng";
            this.Quantity.Name = "Quantity";
            this.Quantity.ReadOnly = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.BackColor = System.Drawing.Color.White;
            this.groupBox1.Controls.Add(this.dgvBills);
            this.groupBox1.ForeColor = System.Drawing.Color.Black;
            this.groupBox1.Location = new System.Drawing.Point(308, 37);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(546, 486);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Danh sách hoá đơn sử dụng thực đơn";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox2.BackColor = System.Drawing.Color.White;
            this.groupBox2.Controls.Add(this.dgvMenu);
            this.groupBox2.ForeColor = System.Drawing.Color.Black;
            this.groupBox2.Location = new System.Drawing.Point(1, 34);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(301, 489);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Danh sách thực đơn sử dụng";
            // 
            // dgvMenu
            // 
            this.dgvMenu.AllowUserToAddRows = false;
            this.dgvMenu.AllowUserToDeleteRows = false;
            this.dgvMenu.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dgvMenu.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMenu.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Index,
            this.MenuName,
            this.Selected,
            this.MenuId});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvMenu.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgvMenu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvMenu.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.dgvMenu.Location = new System.Drawing.Point(3, 18);
            this.dgvMenu.MultiSelect = false;
            this.dgvMenu.Name = "dgvMenu";
            this.dgvMenu.RowHeadersVisible = false;
            this.dgvMenu.Size = new System.Drawing.Size(295, 468);
            this.dgvMenu.TabIndex = 0;
            // 
            // cboMeterial
            // 
            this.cboMeterial.FormattingEnabled = true;
            this.cboMeterial.Location = new System.Drawing.Point(74, 8);
            this.cboMeterial.Name = "cboMeterial";
            this.cboMeterial.Size = new System.Drawing.Size(176, 21);
            this.cboMeterial.TabIndex = 13;
            this.cboMeterial.Text = "Nhập tên nguyên liệu để tìm";
            this.cboMeterial.SelectedIndexChanged += new System.EventHandler(this.cboMeterial_SelectedIndexChanged);
            // 
            // Index
            // 
            this.Index.HeaderText = "STT";
            this.Index.Name = "Index";
            this.Index.ReadOnly = true;
            this.Index.Width = 50;
            // 
            // MenuName
            // 
            this.MenuName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.MenuName.DefaultCellStyle = dataGridViewCellStyle3;
            this.MenuName.HeaderText = "Tên thực đơn";
            this.MenuName.Name = "MenuName";
            this.MenuName.ReadOnly = true;
            // 
            // Selected
            // 
            this.Selected.HeaderText = "Chọn";
            this.Selected.Name = "Selected";
            this.Selected.Width = 50;
            // 
            // MenuId
            // 
            this.MenuId.HeaderText = "MenuId";
            this.MenuId.Name = "MenuId";
            this.MenuId.Visible = false;
            // 
            // MeterialInBill
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(855, 524);
            this.Controls.Add(this.cboMeterial);
            this.Controls.Add(this.dtpToDate);
            this.Controls.Add(this.dtpFromDate);
            this.Controls.Add(this.labelX3);
            this.Controls.Add(this.labelX2);
            this.Controls.Add(this.labelX1);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MeterialInBill";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Hóa đơn sử dụng theo nguyên liệu";
            this.Load += new System.EventHandler(this.MeterialInBill_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvBills)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMenu)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dtpToDate;
        private System.Windows.Forms.DateTimePicker dtpFromDate;
        private DevComponents.DotNetBar.LabelX labelX3;
        private DevComponents.DotNetBar.LabelX labelX2;
        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.DotNetBar.ButtonX btnSearch;
        private DevComponents.DotNetBar.ButtonX btnExit;
        private System.Windows.Forms.DataGridViewTextBoxColumn BillId;
        private DevComponents.DotNetBar.Controls.DataGridViewX dgvBills;
        private System.Windows.Forms.DataGridViewTextBoxColumn STT;
        private System.Windows.Forms.DataGridViewTextBoxColumn BillCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn BillDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn Quantity;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private DevComponents.DotNetBar.Controls.DataGridViewX dgvMenu;
        private System.Windows.Forms.ComboBox cboMeterial;
        private System.Windows.Forms.DataGridViewTextBoxColumn Index;
        private System.Windows.Forms.DataGridViewTextBoxColumn MenuName;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Selected;
        private System.Windows.Forms.DataGridViewTextBoxColumn MenuId;
    }
}
namespace RestaurantManagement
{
    partial class ImportBills
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ImportBills));
            this.dgvImportBill = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.STT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MeterialName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UnitNames = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Quantity = new DevComponents.DotNetBar.Controls.DataGridViewDoubleInputColumn();
            this.Cost = new DevComponents.DotNetBar.Controls.DataGridViewDoubleInputColumn();
            this.TotalCost = new DevComponents.DotNetBar.Controls.DataGridViewDoubleInputColumn();
            this.Delete = new DevComponents.DotNetBar.Controls.DataGridViewButtonXColumn();
            this.MeterialId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cboMeterial = new System.Windows.Forms.ComboBox();
            this.btnImport = new DevComponents.DotNetBar.ButtonX();
            this.btnSave = new DevComponents.DotNetBar.ButtonX();
            this.txtCost = new DevComponents.Editors.DoubleInput();
            this.txtQuantity = new DevComponents.Editors.DoubleInput();
            this.txtTotalMoney = new DevComponents.Editors.DoubleInput();
            this.txtNote = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.dtpBillDate = new System.Windows.Forms.DateTimePicker();
            this.labelX7 = new DevComponents.DotNetBar.LabelX();
            this.labelX3 = new DevComponents.DotNetBar.LabelX();
            this.labelX8 = new DevComponents.DotNetBar.LabelX();
            this.labelX6 = new DevComponents.DotNetBar.LabelX();
            this.labelX4 = new DevComponents.DotNetBar.LabelX();
            this.labelX5 = new DevComponents.DotNetBar.LabelX();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.labelX9 = new DevComponents.DotNetBar.LabelX();
            this.txtBillCode = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX10 = new DevComponents.DotNetBar.LabelX();
            this.txtMeterialCode = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.cboSubGroupMeterial = new System.Windows.Forms.ComboBox();
            this.panelSearch = new System.Windows.Forms.Panel();
            this.btnClose = new DevComponents.DotNetBar.ButtonX();
            this.dgvMeterialSearch = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.MeterialCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MeterialNameSearch = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UnitNameSearch = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.QuantitySearch = new DevComponents.DotNetBar.Controls.DataGridViewDoubleInputColumn();
            this.Choose = new System.Windows.Forms.DataGridViewButtonColumn();
            this.MeterialIdSearch = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtInventories = new DevComponents.Editors.DoubleInput();
            this.labelX11 = new DevComponents.DotNetBar.LabelX();
            this.lbUnitName = new DevComponents.DotNetBar.LabelX();
            this.labelX12 = new DevComponents.DotNetBar.LabelX();
            ((System.ComponentModel.ISupportInitialize)(this.dgvImportBill)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCost)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtQuantity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotalMoney)).BeginInit();
            this.panelSearch.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMeterialSearch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtInventories)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvImportBill
            // 
            this.dgvImportBill.AllowUserToAddRows = false;
            this.dgvImportBill.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvImportBill.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvImportBill.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvImportBill.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvImportBill.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.STT,
            this.MeterialName,
            this.UnitNames,
            this.Quantity,
            this.Cost,
            this.TotalCost,
            this.Delete,
            this.MeterialId});
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvImportBill.DefaultCellStyle = dataGridViewCellStyle7;
            this.dgvImportBill.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.dgvImportBill.Location = new System.Drawing.Point(10, 92);
            this.dgvImportBill.MultiSelect = false;
            this.dgvImportBill.Name = "dgvImportBill";
            this.dgvImportBill.RowHeadersVisible = false;
            this.dgvImportBill.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvImportBill.Size = new System.Drawing.Size(916, 461);
            this.dgvImportBill.TabIndex = 27;
            this.dgvImportBill.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvImportBill_CellEndEdit);
            this.dgvImportBill.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvImportBill_CellClick);
            // 
            // STT
            // 
            this.STT.DataPropertyName = "STT";
            this.STT.HeaderText = "STT";
            this.STT.Name = "STT";
            this.STT.ReadOnly = true;
            this.STT.Width = 50;
            // 
            // MeterialName
            // 
            this.MeterialName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.MeterialName.DataPropertyName = "MeterialName";
            this.MeterialName.HeaderText = "Tên mặt hàng";
            this.MeterialName.Name = "MeterialName";
            this.MeterialName.ReadOnly = true;
            // 
            // UnitNames
            // 
            this.UnitNames.DataPropertyName = "UnitNames";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.UnitNames.DefaultCellStyle = dataGridViewCellStyle2;
            this.UnitNames.HeaderText = "Đơn vị tính";
            this.UnitNames.Name = "UnitNames";
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
            this.Quantity.DataPropertyName = "Quantity";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Quantity.DefaultCellStyle = dataGridViewCellStyle3;
            this.Quantity.HeaderText = "Số lượng";
            this.Quantity.Increment = 1;
            this.Quantity.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            this.Quantity.MinValue = 0;
            this.Quantity.Name = "Quantity";
            this.Quantity.ShowUpDown = true;
            // 
            // Cost
            // 
            // 
            // 
            // 
            this.Cost.BackgroundStyle.BackColor = System.Drawing.SystemColors.Window;
            this.Cost.BackgroundStyle.Class = "DataGridViewNumericBorder";
            this.Cost.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.Cost.BackgroundStyle.TextColor = System.Drawing.Color.Black;
            this.Cost.DataPropertyName = "Cost";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.Cost.DefaultCellStyle = dataGridViewCellStyle4;
            this.Cost.DisplayFormat = "###,#0";
            this.Cost.HeaderText = "Đơn giá ";
            this.Cost.Increment = 1;
            this.Cost.MinValue = 0;
            this.Cost.Name = "Cost";
            // 
            // TotalCost
            // 
            // 
            // 
            // 
            this.TotalCost.BackgroundStyle.BackColor = System.Drawing.SystemColors.Window;
            this.TotalCost.BackgroundStyle.Class = "DataGridViewNumericBorder";
            this.TotalCost.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.TotalCost.BackgroundStyle.TextColor = System.Drawing.Color.Black;
            this.TotalCost.DataPropertyName = "TotalCost";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.TotalCost.DefaultCellStyle = dataGridViewCellStyle5;
            this.TotalCost.DisplayFormat = "###,#0";
            this.TotalCost.HeaderText = "Thành tiền";
            this.TotalCost.Increment = 1;
            this.TotalCost.MinValue = 0;
            this.TotalCost.Name = "TotalCost";
            this.TotalCost.ReadOnly = true;
            // 
            // Delete
            // 
            this.Delete.DataPropertyName = "Delete";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.NullValue = "Xoá";
            this.Delete.DefaultCellStyle = dataGridViewCellStyle6;
            this.Delete.HeaderText = "Xoá";
            this.Delete.Name = "Delete";
            this.Delete.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Delete.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Delete.Text = null;
            this.Delete.Width = 70;
            // 
            // MeterialId
            // 
            this.MeterialId.DataPropertyName = "MeterialId";
            this.MeterialId.HeaderText = "MeterialId";
            this.MeterialId.Name = "MeterialId";
            this.MeterialId.Visible = false;
            // 
            // cboMeterial
            // 
            this.cboMeterial.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboMeterial.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboMeterial.BackColor = System.Drawing.Color.White;
            this.cboMeterial.ForeColor = System.Drawing.Color.Black;
            this.cboMeterial.FormattingEnabled = true;
            this.cboMeterial.Location = new System.Drawing.Point(99, 37);
            this.cboMeterial.Name = "cboMeterial";
            this.cboMeterial.Size = new System.Drawing.Size(222, 21);
            this.cboMeterial.TabIndex = 1;
            this.cboMeterial.SelectedIndexChanged += new System.EventHandler(this.cboMeterial_SelectedIndexChanged);
            // 
            // btnImport
            // 
            this.btnImport.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnImport.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnImport.Location = new System.Drawing.Point(327, 64);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(78, 23);
            this.btnImport.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnImport.TabIndex = 4;
            this.btnImport.Text = "Nhập hàng";
            this.btnImport.Tooltip = "Sử dụng phím để Enter ";
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // btnSave
            // 
            this.btnSave.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(411, 63);
            this.btnSave.Name = "btnSave";
            this.btnSave.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.F2);
            this.btnSave.Size = new System.Drawing.Size(100, 23);
            this.btnSave.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnSave.TabIndex = 5;
            this.btnSave.Text = "Lưu hoá đơn (F2)";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtCost
            // 
            this.txtCost.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtCost.BackgroundStyle.Class = "DateTimeInputBackground";
            this.txtCost.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtCost.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.txtCost.DisplayFormat = "###,#0";
            this.txtCost.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCost.ForeColor = System.Drawing.Color.Black;
            this.txtCost.Increment = 1;
            this.txtCost.Location = new System.Drawing.Point(222, 64);
            this.txtCost.MinValue = 0;
            this.txtCost.Name = "txtCost";
            this.txtCost.Size = new System.Drawing.Size(99, 21);
            this.txtCost.TabIndex = 3;
            // 
            // txtQuantity
            // 
            this.txtQuantity.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtQuantity.BackgroundStyle.Class = "DateTimeInputBackground";
            this.txtQuantity.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtQuantity.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.txtQuantity.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtQuantity.ForeColor = System.Drawing.Color.Black;
            this.txtQuantity.Increment = 1;
            this.txtQuantity.Location = new System.Drawing.Point(99, 63);
            this.txtQuantity.MinValue = 0;
            this.txtQuantity.Name = "txtQuantity";
            this.txtQuantity.Size = new System.Drawing.Size(65, 21);
            this.txtQuantity.TabIndex = 2;
            // 
            // txtTotalMoney
            // 
            this.txtTotalMoney.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTotalMoney.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtTotalMoney.BackgroundStyle.Class = "DateTimeInputBackground";
            this.txtTotalMoney.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtTotalMoney.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.txtTotalMoney.DisplayFormat = "###,#0";
            this.txtTotalMoney.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotalMoney.ForeColor = System.Drawing.Color.Black;
            this.txtTotalMoney.Increment = 1;
            this.txtTotalMoney.IsInputReadOnly = true;
            this.txtTotalMoney.Location = new System.Drawing.Point(613, 37);
            this.txtTotalMoney.MinValue = 0;
            this.txtTotalMoney.Name = "txtTotalMoney";
            this.txtTotalMoney.Size = new System.Drawing.Size(272, 23);
            this.txtTotalMoney.TabIndex = 10;
            // 
            // txtNote
            // 
            this.txtNote.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNote.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtNote.Border.Class = "TextBoxBorder";
            this.txtNote.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtNote.ForeColor = System.Drawing.Color.Black;
            this.txtNote.Location = new System.Drawing.Point(613, 65);
            this.txtNote.Multiline = true;
            this.txtNote.Name = "txtNote";
            this.txtNote.Size = new System.Drawing.Size(313, 23);
            this.txtNote.TabIndex = 8;
            // 
            // dtpBillDate
            // 
            this.dtpBillDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpBillDate.BackColor = System.Drawing.Color.White;
            this.dtpBillDate.CustomFormat = "dd/MM/yyyy";
            this.dtpBillDate.ForeColor = System.Drawing.Color.Black;
            this.dtpBillDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpBillDate.Location = new System.Drawing.Point(826, 9);
            this.dtpBillDate.Name = "dtpBillDate";
            this.dtpBillDate.Size = new System.Drawing.Size(100, 20);
            this.dtpBillDate.TabIndex = 7;
            // 
            // labelX7
            // 
            this.labelX7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelX7.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.labelX7.BackgroundStyle.Class = "";
            this.labelX7.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX7.ForeColor = System.Drawing.Color.Black;
            this.labelX7.Location = new System.Drawing.Point(895, 33);
            this.labelX7.Name = "labelX7";
            this.labelX7.Size = new System.Drawing.Size(43, 27);
            this.labelX7.TabIndex = 14;
            this.labelX7.Text = "VNĐ";
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
            this.labelX3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX3.ForeColor = System.Drawing.Color.Black;
            this.labelX3.Location = new System.Drawing.Point(517, 33);
            this.labelX3.Name = "labelX3";
            this.labelX3.Size = new System.Drawing.Size(90, 27);
            this.labelX3.TabIndex = 15;
            this.labelX3.Text = "Tổng số tiền";
            // 
            // labelX8
            // 
            this.labelX8.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.labelX8.BackgroundStyle.Class = "";
            this.labelX8.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX8.ForeColor = System.Drawing.Color.Black;
            this.labelX8.Location = new System.Drawing.Point(209, 7);
            this.labelX8.Name = "labelX8";
            this.labelX8.Size = new System.Drawing.Size(70, 27);
            this.labelX8.TabIndex = 12;
            this.labelX8.Text = "Nhóm hàng";
            // 
            // labelX6
            // 
            this.labelX6.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.labelX6.BackgroundStyle.Class = "";
            this.labelX6.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX6.ForeColor = System.Drawing.Color.Black;
            this.labelX6.Location = new System.Drawing.Point(170, 59);
            this.labelX6.Name = "labelX6";
            this.labelX6.Size = new System.Drawing.Size(50, 27);
            this.labelX6.TabIndex = 13;
            this.labelX6.Text = "Đơn giá";
            // 
            // labelX4
            // 
            this.labelX4.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.labelX4.BackgroundStyle.Class = "";
            this.labelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX4.ForeColor = System.Drawing.Color.Black;
            this.labelX4.Location = new System.Drawing.Point(14, 35);
            this.labelX4.Name = "labelX4";
            this.labelX4.Size = new System.Drawing.Size(75, 27);
            this.labelX4.TabIndex = 11;
            this.labelX4.Text = "Tên mặt hàng";
            // 
            // labelX5
            // 
            this.labelX5.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.labelX5.BackgroundStyle.Class = "";
            this.labelX5.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX5.ForeColor = System.Drawing.Color.Black;
            this.labelX5.Location = new System.Drawing.Point(14, 60);
            this.labelX5.Name = "labelX5";
            this.labelX5.Size = new System.Drawing.Size(79, 27);
            this.labelX5.TabIndex = 20;
            this.labelX5.Text = "Số lượng nhập";
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
            this.labelX2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX2.ForeColor = System.Drawing.Color.Black;
            this.labelX2.Location = new System.Drawing.Point(517, 57);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(50, 27);
            this.labelX2.TabIndex = 18;
            this.labelX2.Text = "Ghi chú";
            // 
            // labelX1
            // 
            this.labelX1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelX1.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.Class = "";
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX1.ForeColor = System.Drawing.Color.Black;
            this.labelX1.Location = new System.Drawing.Point(755, 3);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(58, 27);
            this.labelX1.TabIndex = 16;
            this.labelX1.Text = "Ngày nhập";
            // 
            // labelX9
            // 
            this.labelX9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelX9.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.labelX9.BackgroundStyle.Class = "";
            this.labelX9.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX9.ForeColor = System.Drawing.Color.Black;
            this.labelX9.Location = new System.Drawing.Point(517, 4);
            this.labelX9.Name = "labelX9";
            this.labelX9.Size = new System.Drawing.Size(90, 27);
            this.labelX9.TabIndex = 16;
            this.labelX9.Text = "Mã số hoá đơn";
            // 
            // txtBillCode
            // 
            this.txtBillCode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBillCode.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtBillCode.Border.Class = "TextBoxBorder";
            this.txtBillCode.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtBillCode.ForeColor = System.Drawing.Color.Black;
            this.txtBillCode.Location = new System.Drawing.Point(613, 8);
            this.txtBillCode.Multiline = true;
            this.txtBillCode.Name = "txtBillCode";
            this.txtBillCode.Size = new System.Drawing.Size(136, 23);
            this.txtBillCode.TabIndex = 9;
            // 
            // labelX10
            // 
            this.labelX10.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.labelX10.BackgroundStyle.Class = "";
            this.labelX10.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX10.ForeColor = System.Drawing.Color.Black;
            this.labelX10.Location = new System.Drawing.Point(14, 8);
            this.labelX10.Name = "labelX10";
            this.labelX10.Size = new System.Drawing.Size(50, 27);
            this.labelX10.TabIndex = 29;
            this.labelX10.Text = "Mã hàng";
            // 
            // txtMeterialCode
            // 
            this.txtMeterialCode.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txtMeterialCode.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtMeterialCode.Border.Class = "TextBoxBorder";
            this.txtMeterialCode.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtMeterialCode.ForeColor = System.Drawing.Color.Black;
            this.txtMeterialCode.Location = new System.Drawing.Point(99, 11);
            this.txtMeterialCode.Multiline = true;
            this.txtMeterialCode.Name = "txtMeterialCode";
            this.txtMeterialCode.Size = new System.Drawing.Size(104, 23);
            this.txtMeterialCode.TabIndex = 0;
            this.txtMeterialCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtMeterialCode_KeyDown);
            this.txtMeterialCode.TextChanged += new System.EventHandler(this.txtMeterialCode_TextChanged);
            // 
            // cboSubGroupMeterial
            // 
            this.cboSubGroupMeterial.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboSubGroupMeterial.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboSubGroupMeterial.BackColor = System.Drawing.Color.White;
            this.cboSubGroupMeterial.ForeColor = System.Drawing.Color.Black;
            this.cboSubGroupMeterial.FormattingEnabled = true;
            this.cboSubGroupMeterial.Location = new System.Drawing.Point(327, 13);
            this.cboSubGroupMeterial.Name = "cboSubGroupMeterial";
            this.cboSubGroupMeterial.Size = new System.Drawing.Size(184, 21);
            this.cboSubGroupMeterial.TabIndex = 6;
            this.cboSubGroupMeterial.SelectedIndexChanged += new System.EventHandler(this.cboSubGroupMeterial_SelectedIndexChanged_1);
            // 
            // panelSearch
            // 
            this.panelSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panelSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelSearch.Controls.Add(this.btnClose);
            this.panelSearch.Controls.Add(this.dgvMeterialSearch);
            this.panelSearch.Location = new System.Drawing.Point(12, 116);
            this.panelSearch.Name = "panelSearch";
            this.panelSearch.Size = new System.Drawing.Size(690, 339);
            this.panelSearch.TabIndex = 49;
            this.panelSearch.Visible = false;
            // 
            // btnClose
            // 
            this.btnClose.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Location = new System.Drawing.Point(627, -1);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(61, 22);
            this.btnClose.Style = DevComponents.DotNetBar.eDotNetBarStyle.Windows7;
            this.btnClose.TabIndex = 49;
            this.btnClose.Text = "Đóng";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // dgvMeterialSearch
            // 
            this.dgvMeterialSearch.AllowUserToAddRows = false;
            this.dgvMeterialSearch.AllowUserToDeleteRows = false;
            this.dgvMeterialSearch.AllowUserToOrderColumns = true;
            this.dgvMeterialSearch.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dgvMeterialSearch.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvMeterialSearch.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle8;
            this.dgvMeterialSearch.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMeterialSearch.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MeterialCode,
            this.MeterialNameSearch,
            this.UnitNameSearch,
            this.QuantitySearch,
            this.Choose,
            this.MeterialIdSearch});
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle12.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle12.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle12.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle12.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvMeterialSearch.DefaultCellStyle = dataGridViewCellStyle12;
            this.dgvMeterialSearch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvMeterialSearch.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.dgvMeterialSearch.Location = new System.Drawing.Point(0, 0);
            this.dgvMeterialSearch.MultiSelect = false;
            this.dgvMeterialSearch.Name = "dgvMeterialSearch";
            this.dgvMeterialSearch.ReadOnly = true;
            dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle13.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle13.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle13.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle13.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle13.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvMeterialSearch.RowHeadersDefaultCellStyle = dataGridViewCellStyle13;
            this.dgvMeterialSearch.RowHeadersVisible = false;
            this.dgvMeterialSearch.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvMeterialSearch.Size = new System.Drawing.Size(688, 337);
            this.dgvMeterialSearch.TabIndex = 48;
            this.dgvMeterialSearch.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvMeterialSearch_CellClick);
            // 
            // MeterialCode
            // 
            this.MeterialCode.HeaderText = "Mã hàng";
            this.MeterialCode.Name = "MeterialCode";
            this.MeterialCode.ReadOnly = true;
            this.MeterialCode.Width = 160;
            // 
            // MeterialNameSearch
            // 
            this.MeterialNameSearch.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.MeterialNameSearch.HeaderText = "Tên mặt hàng";
            this.MeterialNameSearch.Name = "MeterialNameSearch";
            this.MeterialNameSearch.ReadOnly = true;
            // 
            // UnitNameSearch
            // 
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.UnitNameSearch.DefaultCellStyle = dataGridViewCellStyle9;
            this.UnitNameSearch.HeaderText = "Đơn vị tính";
            this.UnitNameSearch.Name = "UnitNameSearch";
            this.UnitNameSearch.ReadOnly = true;
            // 
            // QuantitySearch
            // 
            // 
            // 
            // 
            this.QuantitySearch.BackgroundStyle.BackColor = System.Drawing.SystemColors.Window;
            this.QuantitySearch.BackgroundStyle.Class = "DataGridViewNumericBorder";
            this.QuantitySearch.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.QuantitySearch.BackgroundStyle.TextColor = System.Drawing.Color.Black;
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.QuantitySearch.DefaultCellStyle = dataGridViewCellStyle10;
            this.QuantitySearch.HeaderText = "Lượng tồn kho";
            this.QuantitySearch.Increment = 1;
            this.QuantitySearch.Name = "QuantitySearch";
            this.QuantitySearch.ReadOnly = true;
            // 
            // Choose
            // 
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle11.NullValue = "Chọn";
            this.Choose.DefaultCellStyle = dataGridViewCellStyle11;
            this.Choose.HeaderText = "Chọn";
            this.Choose.Name = "Choose";
            this.Choose.ReadOnly = true;
            this.Choose.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Choose.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Choose.Width = 60;
            // 
            // MeterialIdSearch
            // 
            this.MeterialIdSearch.HeaderText = "MeterialIdSearch";
            this.MeterialIdSearch.Name = "MeterialIdSearch";
            this.MeterialIdSearch.ReadOnly = true;
            this.MeterialIdSearch.Visible = false;
            // 
            // txtInventories
            // 
            this.txtInventories.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtInventories.BackgroundStyle.Class = "DateTimeInputBackground";
            this.txtInventories.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtInventories.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.txtInventories.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtInventories.ForeColor = System.Drawing.Color.Black;
            this.txtInventories.Increment = 1;
            this.txtInventories.IsInputReadOnly = true;
            this.txtInventories.Location = new System.Drawing.Point(378, 37);
            this.txtInventories.MinValue = 0;
            this.txtInventories.Name = "txtInventories";
            this.txtInventories.Size = new System.Drawing.Size(98, 21);
            this.txtInventories.TabIndex = 9;
            // 
            // labelX11
            // 
            this.labelX11.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.labelX11.BackgroundStyle.Class = "";
            this.labelX11.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX11.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX11.ForeColor = System.Drawing.Color.Black;
            this.labelX11.Location = new System.Drawing.Point(327, 33);
            this.labelX11.Name = "labelX11";
            this.labelX11.Size = new System.Drawing.Size(45, 27);
            this.labelX11.TabIndex = 20;
            this.labelX11.Text = "Tồn kho";
            // 
            // lbUnitName
            // 
            this.lbUnitName.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.lbUnitName.BackgroundStyle.Class = "";
            this.lbUnitName.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lbUnitName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbUnitName.ForeColor = System.Drawing.Color.Black;
            this.lbUnitName.Location = new System.Drawing.Point(482, 33);
            this.lbUnitName.Name = "lbUnitName";
            this.lbUnitName.Size = new System.Drawing.Size(29, 27);
            this.lbUnitName.TabIndex = 20;
            this.lbUnitName.Text = "...";
            // 
            // labelX12
            // 
            this.labelX12.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.labelX12.BackgroundStyle.Class = "";
            this.labelX12.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX12.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX12.ForeColor = System.Drawing.Color.Red;
            this.labelX12.Location = new System.Drawing.Point(601, 8);
            this.labelX12.Name = "labelX12";
            this.labelX12.Size = new System.Drawing.Size(13, 27);
            this.labelX12.TabIndex = 12;
            this.labelX12.Text = "*";
            // 
            // ImportBills
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(938, 565);
            this.Controls.Add(this.txtBillCode);
            this.Controls.Add(this.labelX12);
            this.Controls.Add(this.panelSearch);
            this.Controls.Add(this.cboSubGroupMeterial);
            this.Controls.Add(this.dgvImportBill);
            this.Controls.Add(this.cboMeterial);
            this.Controls.Add(this.btnImport);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtCost);
            this.Controls.Add(this.txtInventories);
            this.Controls.Add(this.txtQuantity);
            this.Controls.Add(this.txtTotalMoney);
            this.Controls.Add(this.txtMeterialCode);
            this.Controls.Add(this.txtNote);
            this.Controls.Add(this.dtpBillDate);
            this.Controls.Add(this.labelX7);
            this.Controls.Add(this.labelX3);
            this.Controls.Add(this.labelX10);
            this.Controls.Add(this.labelX8);
            this.Controls.Add(this.labelX6);
            this.Controls.Add(this.labelX4);
            this.Controls.Add(this.lbUnitName);
            this.Controls.Add(this.labelX11);
            this.Controls.Add(this.labelX5);
            this.Controls.Add(this.labelX2);
            this.Controls.Add(this.labelX9);
            this.Controls.Add(this.labelX1);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ImportBills";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Nhập hàng vào kho";
            this.Load += new System.EventHandler(this.ImportBills_Load);
            this.SizeChanged += new System.EventHandler(this.ImportBills_SizeChanged);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ImportBills_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.dgvImportBill)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCost)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtQuantity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotalMoney)).EndInit();
            this.panelSearch.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMeterialSearch)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtInventories)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.Controls.DataGridViewX dgvImportBill;
        private System.Windows.Forms.ComboBox cboMeterial;
        private DevComponents.DotNetBar.ButtonX btnImport;
        private DevComponents.DotNetBar.ButtonX btnSave;
        private DevComponents.Editors.DoubleInput txtCost;
        private DevComponents.Editors.DoubleInput txtQuantity;
        private DevComponents.Editors.DoubleInput txtTotalMoney;
        private DevComponents.DotNetBar.Controls.TextBoxX txtNote;
        private System.Windows.Forms.DateTimePicker dtpBillDate;
        private DevComponents.DotNetBar.LabelX labelX7;
        private DevComponents.DotNetBar.LabelX labelX3;
        private DevComponents.DotNetBar.LabelX labelX8;
        private DevComponents.DotNetBar.LabelX labelX6;
        private DevComponents.DotNetBar.LabelX labelX4;
        private DevComponents.DotNetBar.LabelX labelX5;
        private DevComponents.DotNetBar.LabelX labelX2;
        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.DotNetBar.LabelX labelX9;
        private DevComponents.DotNetBar.Controls.TextBoxX txtBillCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn STT;
        private System.Windows.Forms.DataGridViewTextBoxColumn MeterialName;
        private System.Windows.Forms.DataGridViewTextBoxColumn UnitNames;
        private DevComponents.DotNetBar.Controls.DataGridViewDoubleInputColumn Quantity;
        private DevComponents.DotNetBar.Controls.DataGridViewDoubleInputColumn Cost;
        private DevComponents.DotNetBar.Controls.DataGridViewDoubleInputColumn TotalCost;
        private DevComponents.DotNetBar.Controls.DataGridViewButtonXColumn Delete;
        private System.Windows.Forms.DataGridViewTextBoxColumn MeterialId;
        private DevComponents.DotNetBar.LabelX labelX10;
        private DevComponents.DotNetBar.Controls.TextBoxX txtMeterialCode;
        private System.Windows.Forms.ComboBox cboSubGroupMeterial;
        private System.Windows.Forms.Panel panelSearch;
        private DevComponents.DotNetBar.ButtonX btnClose;
        private DevComponents.DotNetBar.Controls.DataGridViewX dgvMeterialSearch;
        private System.Windows.Forms.DataGridViewTextBoxColumn MeterialCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn MeterialNameSearch;
        private System.Windows.Forms.DataGridViewTextBoxColumn UnitNameSearch;
        private DevComponents.DotNetBar.Controls.DataGridViewDoubleInputColumn QuantitySearch;
        private System.Windows.Forms.DataGridViewButtonColumn Choose;
        private System.Windows.Forms.DataGridViewTextBoxColumn MeterialIdSearch;
        private DevComponents.Editors.DoubleInput txtInventories;
        private DevComponents.DotNetBar.LabelX labelX11;
        private DevComponents.DotNetBar.LabelX lbUnitName;
        private DevComponents.DotNetBar.LabelX labelX12;
    }
}
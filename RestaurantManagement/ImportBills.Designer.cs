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
            this.dgvImportBill = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.cboSubGroupMeterial = new System.Windows.Forms.ComboBox();
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
            this.STT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MeterialName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UnitNames = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Quantity = new DevComponents.DotNetBar.Controls.DataGridViewDoubleInputColumn();
            this.Cost = new DevComponents.DotNetBar.Controls.DataGridViewDoubleInputColumn();
            this.TotalCost = new DevComponents.DotNetBar.Controls.DataGridViewDoubleInputColumn();
            this.Delete = new DevComponents.DotNetBar.Controls.DataGridViewButtonXColumn();
            this.MeterialId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvImportBill)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCost)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtQuantity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotalMoney)).BeginInit();
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
            this.dgvImportBill.Location = new System.Drawing.Point(2, 92);
            this.dgvImportBill.MultiSelect = false;
            this.dgvImportBill.Name = "dgvImportBill";
            this.dgvImportBill.RowHeadersVisible = false;
            this.dgvImportBill.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvImportBill.Size = new System.Drawing.Size(935, 476);
            this.dgvImportBill.TabIndex = 27;
            this.dgvImportBill.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvImportBill_CellEndEdit);
            this.dgvImportBill.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvImportBill_CellClick);
            // 
            // cboSubGroupMeterial
            // 
            this.cboSubGroupMeterial.BackColor = System.Drawing.Color.White;
            this.cboSubGroupMeterial.ForeColor = System.Drawing.Color.Black;
            this.cboSubGroupMeterial.FormattingEnabled = true;
            this.cboSubGroupMeterial.Location = new System.Drawing.Point(98, 8);
            this.cboSubGroupMeterial.Name = "cboSubGroupMeterial";
            this.cboSubGroupMeterial.Size = new System.Drawing.Size(259, 21);
            this.cboSubGroupMeterial.TabIndex = 17;
            this.cboSubGroupMeterial.SelectedIndexChanged += new System.EventHandler(this.cboSubGroupMeterial_SelectedIndexChanged);
            // 
            // cboMeterial
            // 
            this.cboMeterial.BackColor = System.Drawing.Color.White;
            this.cboMeterial.ForeColor = System.Drawing.Color.Black;
            this.cboMeterial.FormattingEnabled = true;
            this.cboMeterial.Location = new System.Drawing.Point(99, 35);
            this.cboMeterial.Name = "cboMeterial";
            this.cboMeterial.Size = new System.Drawing.Size(259, 21);
            this.cboMeterial.TabIndex = 19;
            // 
            // btnImport
            // 
            this.btnImport.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnImport.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnImport.Location = new System.Drawing.Point(363, 62);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(67, 23);
            this.btnImport.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnImport.TabIndex = 24;
            this.btnImport.Text = "Nhập hàng";
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // btnSave
            // 
            this.btnSave.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(436, 62);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(76, 23);
            this.btnSave.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnSave.TabIndex = 25;
            this.btnSave.Text = "Lưu hoá đơn";
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
            this.txtCost.Location = new System.Drawing.Point(213, 64);
            this.txtCost.Name = "txtCost";
            this.txtCost.Size = new System.Drawing.Size(144, 21);
            this.txtCost.TabIndex = 22;
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
            this.txtQuantity.Location = new System.Drawing.Point(98, 62);
            this.txtQuantity.Name = "txtQuantity";
            this.txtQuantity.Size = new System.Drawing.Size(66, 21);
            this.txtQuantity.TabIndex = 21;
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
            this.txtTotalMoney.ForeColor = System.Drawing.Color.Red;
            this.txtTotalMoney.Increment = 1;
            this.txtTotalMoney.IsInputReadOnly = true;
            this.txtTotalMoney.Location = new System.Drawing.Point(617, 38);
            this.txtTotalMoney.MinValue = 0;
            this.txtTotalMoney.Name = "txtTotalMoney";
            this.txtTotalMoney.Size = new System.Drawing.Size(272, 23);
            this.txtTotalMoney.TabIndex = 26;
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
            this.txtNote.Location = new System.Drawing.Point(617, 66);
            this.txtNote.Multiline = true;
            this.txtNote.Name = "txtNote";
            this.txtNote.Size = new System.Drawing.Size(321, 23);
            this.txtNote.TabIndex = 23;
            // 
            // dtpBillDate
            // 
            this.dtpBillDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpBillDate.BackColor = System.Drawing.Color.White;
            this.dtpBillDate.CustomFormat = "dd/MM/yyyy";
            this.dtpBillDate.ForeColor = System.Drawing.Color.Black;
            this.dtpBillDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpBillDate.Location = new System.Drawing.Point(850, 9);
            this.dtpBillDate.Name = "dtpBillDate";
            this.dtpBillDate.Size = new System.Drawing.Size(87, 20);
            this.dtpBillDate.TabIndex = 10;
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
            this.labelX7.ForeColor = System.Drawing.Color.Red;
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
            this.labelX3.Location = new System.Drawing.Point(521, 34);
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
            this.labelX8.Location = new System.Drawing.Point(2, 3);
            this.labelX8.Name = "labelX8";
            this.labelX8.Size = new System.Drawing.Size(90, 27);
            this.labelX8.TabIndex = 12;
            this.labelX8.Text = "Danh mục hàng";
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
            this.labelX6.Location = new System.Drawing.Point(170, 58);
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
            this.labelX4.Location = new System.Drawing.Point(2, 31);
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
            this.labelX5.Location = new System.Drawing.Point(2, 59);
            this.labelX5.Name = "labelX5";
            this.labelX5.Size = new System.Drawing.Size(50, 27);
            this.labelX5.TabIndex = 20;
            this.labelX5.Text = "Số lượng";
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
            this.labelX2.Location = new System.Drawing.Point(521, 58);
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
            this.labelX1.Location = new System.Drawing.Point(786, 5);
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
            this.labelX9.Location = new System.Drawing.Point(521, 8);
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
            this.txtBillCode.Location = new System.Drawing.Point(617, 9);
            this.txtBillCode.Multiline = true;
            this.txtBillCode.Name = "txtBillCode";
            this.txtBillCode.ReadOnly = true;
            this.txtBillCode.Size = new System.Drawing.Size(163, 23);
            this.txtBillCode.TabIndex = 23;
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
            // ImportBills
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(938, 565);
            this.Controls.Add(this.dgvImportBill);
            this.Controls.Add(this.cboSubGroupMeterial);
            this.Controls.Add(this.cboMeterial);
            this.Controls.Add(this.btnImport);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtCost);
            this.Controls.Add(this.txtQuantity);
            this.Controls.Add(this.txtTotalMoney);
            this.Controls.Add(this.txtBillCode);
            this.Controls.Add(this.txtNote);
            this.Controls.Add(this.dtpBillDate);
            this.Controls.Add(this.labelX7);
            this.Controls.Add(this.labelX3);
            this.Controls.Add(this.labelX8);
            this.Controls.Add(this.labelX6);
            this.Controls.Add(this.labelX4);
            this.Controls.Add(this.labelX5);
            this.Controls.Add(this.labelX2);
            this.Controls.Add(this.labelX9);
            this.Controls.Add(this.labelX1);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "ImportBills";
            this.Text = "Nhập hàng vào kho";
            this.Load += new System.EventHandler(this.ImportBills_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvImportBill)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCost)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtQuantity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotalMoney)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.Controls.DataGridViewX dgvImportBill;
        private System.Windows.Forms.ComboBox cboSubGroupMeterial;
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
    }
}
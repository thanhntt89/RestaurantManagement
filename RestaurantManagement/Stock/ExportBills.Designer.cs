namespace RestaurantManagement
{
    partial class ExportBills
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle17 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle18 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle16 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle19 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle22 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle23 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle20 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle21 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ExportBills));
            this.styleManager1 = new DevComponents.DotNetBar.StyleManager(this.components);
            this.dgvExportBill = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.STT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MeterialName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UnitNames = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Inventories = new DevComponents.DotNetBar.Controls.DataGridViewDoubleInputColumn();
            this.Quantity = new DevComponents.DotNetBar.Controls.DataGridViewDoubleInputColumn();
            this.Delete = new DevComponents.DotNetBar.Controls.DataGridViewButtonXColumn();
            this.MeterialId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cboMeterial = new System.Windows.Forms.ComboBox();
            this.btnImport = new DevComponents.DotNetBar.ButtonX();
            this.btnSave = new DevComponents.DotNetBar.ButtonX();
            this.txtQuantity = new DevComponents.Editors.DoubleInput();
            this.txtBillCode = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.txtNote = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.dtpBillDate = new System.Windows.Forms.DateTimePicker();
            this.labelX4 = new DevComponents.DotNetBar.LabelX();
            this.labelX5 = new DevComponents.DotNetBar.LabelX();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.labelX9 = new DevComponents.DotNetBar.LabelX();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.txtMeterialCode = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.dgvMeterialSearch = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.MeterialCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MeterialNameSearch = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UnitNameSearch = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.QuantitySearch = new DevComponents.DotNetBar.Controls.DataGridViewDoubleInputColumn();
            this.Choose = new System.Windows.Forms.DataGridViewButtonColumn();
            this.MeterialIdSearch = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panelSearch = new System.Windows.Forms.Panel();
            this.btnClose = new DevComponents.DotNetBar.ButtonX();
            this.labelX6 = new DevComponents.DotNetBar.LabelX();
            this.txtInventories = new DevComponents.Editors.DoubleInput();
            this.cboSubGroupMeterial = new System.Windows.Forms.ComboBox();
            this.labelX7 = new DevComponents.DotNetBar.LabelX();
            this.labelX3 = new DevComponents.DotNetBar.LabelX();
            this.lbUnitName = new DevComponents.DotNetBar.LabelX();
            ((System.ComponentModel.ISupportInitialize)(this.dgvExportBill)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtQuantity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMeterialSearch)).BeginInit();
            this.panelSearch.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtInventories)).BeginInit();
            this.SuspendLayout();
            // 
            // styleManager1
            // 
            this.styleManager1.ManagerStyle = DevComponents.DotNetBar.eStyle.Metro;
            this.styleManager1.MetroColorParameters = new DevComponents.DotNetBar.Metro.ColorTables.MetroColorGeneratorParameters(System.Drawing.Color.White, System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(163)))), ((int)(((byte)(26))))));
            // 
            // dgvExportBill
            // 
            this.dgvExportBill.AllowUserToAddRows = false;
            this.dgvExportBill.AllowUserToDeleteRows = false;
            this.dgvExportBill.AllowUserToResizeRows = false;
            this.dgvExportBill.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvExportBill.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle14.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle14.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle14.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle14.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle14.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle14.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvExportBill.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle14;
            this.dgvExportBill.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvExportBill.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.STT,
            this.MeterialName,
            this.UnitNames,
            this.Inventories,
            this.Quantity,
            this.Delete,
            this.MeterialId});
            dataGridViewCellStyle17.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle17.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle17.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle17.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle17.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle17.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle17.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvExportBill.DefaultCellStyle = dataGridViewCellStyle17;
            this.dgvExportBill.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.dgvExportBill.Location = new System.Drawing.Point(12, 92);
            this.dgvExportBill.MultiSelect = false;
            this.dgvExportBill.Name = "dgvExportBill";
            dataGridViewCellStyle18.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle18.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle18.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle18.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle18.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle18.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle18.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvExportBill.RowHeadersDefaultCellStyle = dataGridViewCellStyle18;
            this.dgvExportBill.RowHeadersVisible = false;
            this.dgvExportBill.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvExportBill.Size = new System.Drawing.Size(931, 424);
            this.dgvExportBill.TabIndex = 47;
            this.dgvExportBill.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvExportBill_CellEndEdit);
            this.dgvExportBill.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvExportBill_CellClick);
            // 
            // STT
            // 
            this.STT.DataPropertyName = "STT";
            this.STT.HeaderText = "STT";
            this.STT.Name = "STT";
            this.STT.Width = 50;
            // 
            // MeterialName
            // 
            this.MeterialName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.MeterialName.DataPropertyName = "MeterialName";
            this.MeterialName.HeaderText = "Tên mặt hàng";
            this.MeterialName.Name = "MeterialName";
            // 
            // UnitNames
            // 
            this.UnitNames.DataPropertyName = "UnitNames";
            dataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.UnitNames.DefaultCellStyle = dataGridViewCellStyle15;
            this.UnitNames.HeaderText = "Đơn vị tính";
            this.UnitNames.Name = "UnitNames";
            // 
            // Inventories
            // 
            // 
            // 
            // 
            this.Inventories.BackgroundStyle.Class = "DataGridViewNumericBorder";
            this.Inventories.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.Inventories.DataPropertyName = "Inventories";
            dataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.Inventories.DefaultCellStyle = dataGridViewCellStyle16;
            this.Inventories.HeaderText = "Tồn kho";
            this.Inventories.Increment = 1;
            this.Inventories.Name = "Inventories";
            this.Inventories.ReadOnly = true;
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
            this.Quantity.HeaderText = "Xuất kho";
            this.Quantity.Increment = 1;
            this.Quantity.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            this.Quantity.MinValue = 0;
            this.Quantity.Name = "Quantity";
            this.Quantity.ShowUpDown = true;
            // 
            // Delete
            // 
            this.Delete.DataPropertyName = "Delete";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.NullValue = "Xoá";
            this.Delete.DefaultCellStyle = dataGridViewCellStyle4;
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
            this.cboMeterial.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.cboMeterial.BackColor = System.Drawing.Color.White;
            this.cboMeterial.ForeColor = System.Drawing.Color.Black;
            this.cboMeterial.FormattingEnabled = true;
            this.cboMeterial.Location = new System.Drawing.Point(93, 36);
            this.cboMeterial.Name = "cboMeterial";
            this.cboMeterial.Size = new System.Drawing.Size(408, 21);
            this.cboMeterial.TabIndex = 1;
            this.cboMeterial.SelectedIndexChanged += new System.EventHandler(this.cboMeterial_SelectedIndexChanged);
            // 
            // btnImport
            // 
            this.btnImport.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnImport.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnImport.Location = new System.Drawing.Point(307, 64);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(80, 23);
            this.btnImport.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnImport.TabIndex = 3;
            this.btnImport.Text = "Xuất hàng";
            this.btnImport.Tooltip = "Enter để nhập";
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // btnSave
            // 
            this.btnSave.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(393, 63);
            this.btnSave.Name = "btnSave";
            this.btnSave.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.F2);
            this.btnSave.Size = new System.Drawing.Size(108, 23);
            this.btnSave.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnSave.TabIndex = 4;
            this.btnSave.Text = "Lưu hoá đơn (F2)";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
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
            this.txtQuantity.Location = new System.Drawing.Point(232, 65);
            this.txtQuantity.MinValue = 0;
            this.txtQuantity.Name = "txtQuantity";
            this.txtQuantity.Size = new System.Drawing.Size(69, 21);
            this.txtQuantity.TabIndex = 2;
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
            this.txtBillCode.Location = new System.Drawing.Point(622, 33);
            this.txtBillCode.Multiline = true;
            this.txtBillCode.Name = "txtBillCode";
            this.txtBillCode.ReadOnly = true;
            this.txtBillCode.Size = new System.Drawing.Size(163, 23);
            this.txtBillCode.TabIndex = 6;
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
            this.txtNote.Location = new System.Drawing.Point(621, 61);
            this.txtNote.Multiline = true;
            this.txtNote.Name = "txtNote";
            this.txtNote.Size = new System.Drawing.Size(321, 23);
            this.txtNote.TabIndex = 7;
            // 
            // dtpBillDate
            // 
            this.dtpBillDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpBillDate.BackColor = System.Drawing.Color.White;
            this.dtpBillDate.CustomFormat = "dd/MM/yyyy";
            this.dtpBillDate.ForeColor = System.Drawing.Color.Black;
            this.dtpBillDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpBillDate.Location = new System.Drawing.Point(855, 33);
            this.dtpBillDate.Name = "dtpBillDate";
            this.dtpBillDate.Size = new System.Drawing.Size(87, 20);
            this.dtpBillDate.TabIndex = 8;
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
            this.labelX4.Location = new System.Drawing.Point(12, 35);
            this.labelX4.Name = "labelX4";
            this.labelX4.Size = new System.Drawing.Size(75, 27);
            this.labelX4.TabIndex = 29;
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
            this.labelX5.Location = new System.Drawing.Point(187, 64);
            this.labelX5.Name = "labelX5";
            this.labelX5.Size = new System.Drawing.Size(39, 19);
            this.labelX5.TabIndex = 39;
            this.labelX5.Text = "Xuất";
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
            this.labelX2.Location = new System.Drawing.Point(525, 57);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(50, 27);
            this.labelX2.TabIndex = 37;
            this.labelX2.Text = "Ghi chú";
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
            this.labelX9.Location = new System.Drawing.Point(526, 32);
            this.labelX9.Name = "labelX9";
            this.labelX9.Size = new System.Drawing.Size(90, 27);
            this.labelX9.TabIndex = 35;
            this.labelX9.Text = "Mã số hoá đơn";
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
            this.labelX1.Location = new System.Drawing.Point(791, 29);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(58, 27);
            this.labelX1.TabIndex = 34;
            this.labelX1.Text = "Ngày nhập";
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
            this.txtMeterialCode.Location = new System.Drawing.Point(93, 9);
            this.txtMeterialCode.Multiline = true;
            this.txtMeterialCode.Name = "txtMeterialCode";
            this.txtMeterialCode.Size = new System.Drawing.Size(133, 23);
            this.txtMeterialCode.TabIndex = 0;
            this.txtMeterialCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtMeterialCode_KeyDown);
            this.txtMeterialCode.TextChanged += new System.EventHandler(this.txtMeterialCode_TextChanged);
            // 
            // dgvMeterialSearch
            // 
            this.dgvMeterialSearch.AllowUserToAddRows = false;
            this.dgvMeterialSearch.AllowUserToDeleteRows = false;
            this.dgvMeterialSearch.AllowUserToOrderColumns = true;
            this.dgvMeterialSearch.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dgvMeterialSearch.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle19.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle19.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle19.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle19.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle19.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle19.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle19.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvMeterialSearch.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle19;
            this.dgvMeterialSearch.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMeterialSearch.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MeterialCode,
            this.MeterialNameSearch,
            this.UnitNameSearch,
            this.QuantitySearch,
            this.Choose,
            this.MeterialIdSearch});
            dataGridViewCellStyle22.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle22.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle22.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle22.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle22.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle22.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle22.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvMeterialSearch.DefaultCellStyle = dataGridViewCellStyle22;
            this.dgvMeterialSearch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvMeterialSearch.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.dgvMeterialSearch.Location = new System.Drawing.Point(0, 0);
            this.dgvMeterialSearch.MultiSelect = false;
            this.dgvMeterialSearch.Name = "dgvMeterialSearch";
            this.dgvMeterialSearch.ReadOnly = true;
            dataGridViewCellStyle23.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle23.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle23.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle23.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle23.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle23.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle23.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvMeterialSearch.RowHeadersDefaultCellStyle = dataGridViewCellStyle23;
            this.dgvMeterialSearch.RowHeadersVisible = false;
            this.dgvMeterialSearch.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvMeterialSearch.Size = new System.Drawing.Size(692, 337);
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
            dataGridViewCellStyle20.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.UnitNameSearch.DefaultCellStyle = dataGridViewCellStyle20;
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
            dataGridViewCellStyle21.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.QuantitySearch.DefaultCellStyle = dataGridViewCellStyle21;
            this.QuantitySearch.HeaderText = "Lượng tồn kho";
            this.QuantitySearch.Increment = 1;
            this.QuantitySearch.Name = "QuantitySearch";
            this.QuantitySearch.ReadOnly = true;
            // 
            // Choose
            // 
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle10.NullValue = "Chọn";
            this.Choose.DefaultCellStyle = dataGridViewCellStyle10;
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
            // panelSearch
            // 
            this.panelSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panelSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelSearch.Controls.Add(this.btnClose);
            this.panelSearch.Controls.Add(this.dgvMeterialSearch);
            this.panelSearch.Location = new System.Drawing.Point(13, 113);
            this.panelSearch.Name = "panelSearch";
            this.panelSearch.Size = new System.Drawing.Size(694, 339);
            this.panelSearch.TabIndex = 49;
            this.panelSearch.Visible = false;
            // 
            // btnClose
            // 
            this.btnClose.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Location = new System.Drawing.Point(631, -1);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(61, 22);
            this.btnClose.Style = DevComponents.DotNetBar.eDotNetBarStyle.Windows7;
            this.btnClose.TabIndex = 49;
            this.btnClose.Text = "Đóng";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
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
            this.labelX6.Location = new System.Drawing.Point(13, 59);
            this.labelX6.Name = "labelX6";
            this.labelX6.Size = new System.Drawing.Size(50, 27);
            this.labelX6.TabIndex = 39;
            this.labelX6.Text = "Tồn kho";
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
            this.txtInventories.Location = new System.Drawing.Point(93, 64);
            this.txtInventories.MinValue = 0;
            this.txtInventories.Name = "txtInventories";
            this.txtInventories.Size = new System.Drawing.Size(53, 21);
            this.txtInventories.TabIndex = 2;
            // 
            // cboSubGroupMeterial
            // 
            this.cboSubGroupMeterial.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboSubGroupMeterial.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboSubGroupMeterial.BackColor = System.Drawing.Color.White;
            this.cboSubGroupMeterial.ForeColor = System.Drawing.Color.Black;
            this.cboSubGroupMeterial.FormattingEnabled = true;
            this.cboSubGroupMeterial.Location = new System.Drawing.Point(308, 10);
            this.cboSubGroupMeterial.Name = "cboSubGroupMeterial";
            this.cboSubGroupMeterial.Size = new System.Drawing.Size(193, 21);
            this.cboSubGroupMeterial.TabIndex = 5;
            this.cboSubGroupMeterial.SelectedIndexChanged += new System.EventHandler(this.cboSubGroupMeterial_SelectedIndexChanged);
            // 
            // labelX7
            // 
            this.labelX7.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.labelX7.BackgroundStyle.Class = "";
            this.labelX7.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX7.ForeColor = System.Drawing.Color.Black;
            this.labelX7.Location = new System.Drawing.Point(232, 7);
            this.labelX7.Name = "labelX7";
            this.labelX7.Size = new System.Drawing.Size(70, 27);
            this.labelX7.TabIndex = 29;
            this.labelX7.Text = "Nhóm hàng";
            // 
            // labelX3
            // 
            this.labelX3.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.labelX3.BackgroundStyle.Class = "";
            this.labelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX3.ForeColor = System.Drawing.Color.Black;
            this.labelX3.Location = new System.Drawing.Point(13, 6);
            this.labelX3.Name = "labelX3";
            this.labelX3.Size = new System.Drawing.Size(50, 27);
            this.labelX3.TabIndex = 29;
            this.labelX3.Text = "Mã hàng";
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
            this.lbUnitName.Location = new System.Drawing.Point(152, 59);
            this.lbUnitName.Name = "lbUnitName";
            this.lbUnitName.Size = new System.Drawing.Size(29, 27);
            this.lbUnitName.TabIndex = 50;
            this.lbUnitName.Text = "...";
            // 
            // ExportBills
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(954, 528);
            this.Controls.Add(this.panelSearch);
            this.Controls.Add(this.dgvExportBill);
            this.Controls.Add(this.cboSubGroupMeterial);
            this.Controls.Add(this.cboMeterial);
            this.Controls.Add(this.btnImport);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtInventories);
            this.Controls.Add(this.txtQuantity);
            this.Controls.Add(this.txtMeterialCode);
            this.Controls.Add(this.txtBillCode);
            this.Controls.Add(this.txtNote);
            this.Controls.Add(this.dtpBillDate);
            this.Controls.Add(this.labelX7);
            this.Controls.Add(this.labelX3);
            this.Controls.Add(this.labelX4);
            this.Controls.Add(this.labelX6);
            this.Controls.Add(this.labelX5);
            this.Controls.Add(this.labelX2);
            this.Controls.Add(this.labelX9);
            this.Controls.Add(this.labelX1);
            this.Controls.Add(this.lbUnitName);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ExportBills";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Hoá đơn xuất kho";
            this.Load += new System.EventHandler(this.ExportBills_Load);
            this.SizeChanged += new System.EventHandler(this.ExportBills_SizeChanged);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ExportBills_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.dgvExportBill)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtQuantity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMeterialSearch)).EndInit();
            this.panelSearch.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtInventories)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.StyleManager styleManager1;
        private DevComponents.DotNetBar.Controls.DataGridViewX dgvExportBill;
        private System.Windows.Forms.ComboBox cboMeterial;
        private DevComponents.DotNetBar.ButtonX btnImport;
        private DevComponents.DotNetBar.ButtonX btnSave;
        private DevComponents.Editors.DoubleInput txtQuantity;
        private DevComponents.DotNetBar.Controls.TextBoxX txtBillCode;
        private DevComponents.DotNetBar.Controls.TextBoxX txtNote;
        private System.Windows.Forms.DateTimePicker dtpBillDate;
        private DevComponents.DotNetBar.LabelX labelX4;
        private DevComponents.DotNetBar.LabelX labelX5;
        private DevComponents.DotNetBar.LabelX labelX2;
        private DevComponents.DotNetBar.LabelX labelX9;
        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.DotNetBar.Controls.TextBoxX txtMeterialCode;
        private DevComponents.DotNetBar.Controls.DataGridViewX dgvMeterialSearch;
        private System.Windows.Forms.Panel panelSearch;
        private DevComponents.DotNetBar.ButtonX btnClose;
        private System.Windows.Forms.DataGridViewTextBoxColumn MeterialCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn MeterialNameSearch;
        private System.Windows.Forms.DataGridViewTextBoxColumn UnitNameSearch;
        private DevComponents.DotNetBar.Controls.DataGridViewDoubleInputColumn QuantitySearch;
        private System.Windows.Forms.DataGridViewButtonColumn Choose;
        private System.Windows.Forms.DataGridViewTextBoxColumn MeterialIdSearch;
        private DevComponents.DotNetBar.LabelX labelX6;
        private DevComponents.Editors.DoubleInput txtInventories;
        private System.Windows.Forms.ComboBox cboSubGroupMeterial;
        private DevComponents.DotNetBar.LabelX labelX7;
        private DevComponents.DotNetBar.LabelX labelX3;
        private DevComponents.DotNetBar.LabelX lbUnitName;
        private System.Windows.Forms.DataGridViewTextBoxColumn STT;
        private System.Windows.Forms.DataGridViewTextBoxColumn MeterialName;
        private System.Windows.Forms.DataGridViewTextBoxColumn UnitNames;
        private DevComponents.DotNetBar.Controls.DataGridViewDoubleInputColumn Inventories;
        private DevComponents.DotNetBar.Controls.DataGridViewDoubleInputColumn Quantity;
        private DevComponents.DotNetBar.Controls.DataGridViewButtonXColumn Delete;
        private System.Windows.Forms.DataGridViewTextBoxColumn MeterialId;



    }
}

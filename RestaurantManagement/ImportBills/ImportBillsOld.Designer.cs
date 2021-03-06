namespace RestaurantManagement
{
    partial class ImportBillsOld
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
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.dtpBillDate = new System.Windows.Forms.DateTimePicker();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.txtNote = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX3 = new DevComponents.DotNetBar.LabelX();
            this.txtTotalMoney = new DevComponents.Editors.DoubleInput();
            this.btnSave = new DevComponents.DotNetBar.ButtonX();
            this.labelX4 = new DevComponents.DotNetBar.LabelX();
            this.cboMeterial = new System.Windows.Forms.ComboBox();
            this.labelX5 = new DevComponents.DotNetBar.LabelX();
            this.txtQuantity = new DevComponents.Editors.DoubleInput();
            this.labelX6 = new DevComponents.DotNetBar.LabelX();
            this.txtCost = new DevComponents.Editors.DoubleInput();
            this.labelX7 = new DevComponents.DotNetBar.LabelX();
            this.labelX8 = new DevComponents.DotNetBar.LabelX();
            this.cboSubGroupMeterial = new System.Windows.Forms.ComboBox();
            this.btnImport = new DevComponents.DotNetBar.ButtonX();
            this.dgvImportBill = new DevComponents.DotNetBar.Controls.DataGridViewX();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotalMoney)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtQuantity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCost)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvImportBill)).BeginInit();
            this.SuspendLayout();
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
            this.labelX1.Location = new System.Drawing.Point(587, 8);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(78, 27);
            this.labelX1.TabIndex = 1;
            this.labelX1.Text = "Ngày hoá đơn";
            this.labelX1.Click += new System.EventHandler(this.labelX1_Click);
            // 
            // dtpBillDate
            // 
            this.dtpBillDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpBillDate.BackColor = System.Drawing.Color.White;
            this.dtpBillDate.CustomFormat = "dd/MM/yyyy";
            this.dtpBillDate.ForeColor = System.Drawing.Color.Black;
            this.dtpBillDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpBillDate.Location = new System.Drawing.Point(673, 10);
            this.dtpBillDate.Name = "dtpBillDate";
            this.dtpBillDate.Size = new System.Drawing.Size(124, 21);
            this.dtpBillDate.TabIndex = 0;
            this.dtpBillDate.ValueChanged += new System.EventHandler(this.dtpBillDate_ValueChanged);
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
            this.labelX2.Location = new System.Drawing.Point(586, 61);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(50, 27);
            this.labelX2.TabIndex = 1;
            this.labelX2.Text = "Ghi chú";
            this.labelX2.Click += new System.EventHandler(this.labelX2_Click);
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
            this.txtNote.Location = new System.Drawing.Point(673, 66);
            this.txtNote.Multiline = true;
            this.txtNote.Name = "txtNote";
            this.txtNote.Size = new System.Drawing.Size(264, 23);
            this.txtNote.TabIndex = 4;
            this.txtNote.TextChanged += new System.EventHandler(this.txtNote_TextChanged);
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
            this.labelX3.Location = new System.Drawing.Point(586, 36);
            this.labelX3.Name = "labelX3";
            this.labelX3.Size = new System.Drawing.Size(90, 27);
            this.labelX3.TabIndex = 1;
            this.labelX3.Text = "Tổng số tiền";
            this.labelX3.Click += new System.EventHandler(this.labelX3_Click);
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
            this.txtTotalMoney.Location = new System.Drawing.Point(674, 38);
            this.txtTotalMoney.MinValue = 0;
            this.txtTotalMoney.Name = "txtTotalMoney";
            this.txtTotalMoney.Size = new System.Drawing.Size(214, 23);
            this.txtTotalMoney.TabIndex = 8;
            this.txtTotalMoney.ValueChanged += new System.EventHandler(this.txtTotalMoney_ValueChanged);
            // 
            // btnSave
            // 
            this.btnSave.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(436, 66);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(76, 23);
            this.btnSave.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnSave.TabIndex = 5;
            this.btnSave.Text = "Lưu hoá đơn";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
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
            this.labelX4.Location = new System.Drawing.Point(2, 35);
            this.labelX4.Name = "labelX4";
            this.labelX4.Size = new System.Drawing.Size(75, 27);
            this.labelX4.TabIndex = 1;
            this.labelX4.Text = "Tên mặt hàng";
            this.labelX4.Click += new System.EventHandler(this.labelX4_Click);
            // 
            // cboMeterial
            // 
            this.cboMeterial.BackColor = System.Drawing.Color.White;
            this.cboMeterial.ForeColor = System.Drawing.Color.Black;
            this.cboMeterial.FormattingEnabled = true;
            this.cboMeterial.Location = new System.Drawing.Point(99, 39);
            this.cboMeterial.Name = "cboMeterial";
            this.cboMeterial.Size = new System.Drawing.Size(259, 23);
            this.cboMeterial.TabIndex = 1;
            this.cboMeterial.SelectedIndexChanged += new System.EventHandler(this.cboMeterial_SelectedIndexChanged);
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
            this.labelX5.Location = new System.Drawing.Point(2, 63);
            this.labelX5.Name = "labelX5";
            this.labelX5.Size = new System.Drawing.Size(50, 27);
            this.labelX5.TabIndex = 1;
            this.labelX5.Text = "Số lượng";
            this.labelX5.Click += new System.EventHandler(this.labelX5_Click);
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
            this.txtQuantity.Location = new System.Drawing.Point(98, 66);
            this.txtQuantity.Name = "txtQuantity";
            this.txtQuantity.Size = new System.Drawing.Size(66, 21);
            this.txtQuantity.TabIndex = 2;
            this.txtQuantity.ValueChanged += new System.EventHandler(this.txtQuantity_ValueChanged);
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
            this.labelX6.Location = new System.Drawing.Point(170, 62);
            this.labelX6.Name = "labelX6";
            this.labelX6.Size = new System.Drawing.Size(50, 27);
            this.labelX6.TabIndex = 1;
            this.labelX6.Text = "Đơn giá";
            this.labelX6.Click += new System.EventHandler(this.labelX6_Click);
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
            this.txtCost.Location = new System.Drawing.Point(213, 68);
            this.txtCost.Name = "txtCost";
            this.txtCost.Size = new System.Drawing.Size(144, 21);
            this.txtCost.TabIndex = 3;
            this.txtCost.ValueChanged += new System.EventHandler(this.txtCost_ValueChanged);
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
            this.labelX7.Location = new System.Drawing.Point(894, 33);
            this.labelX7.Name = "labelX7";
            this.labelX7.Size = new System.Drawing.Size(43, 27);
            this.labelX7.TabIndex = 1;
            this.labelX7.Text = "VNĐ";
            this.labelX7.Click += new System.EventHandler(this.labelX7_Click);
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
            this.labelX8.Location = new System.Drawing.Point(2, 7);
            this.labelX8.Name = "labelX8";
            this.labelX8.Size = new System.Drawing.Size(90, 27);
            this.labelX8.TabIndex = 1;
            this.labelX8.Text = "Danh mục hàng";
            this.labelX8.Click += new System.EventHandler(this.labelX8_Click);
            // 
            // cboSubGroupMeterial
            // 
            this.cboSubGroupMeterial.BackColor = System.Drawing.Color.White;
            this.cboSubGroupMeterial.ForeColor = System.Drawing.Color.Black;
            this.cboSubGroupMeterial.FormattingEnabled = true;
            this.cboSubGroupMeterial.Location = new System.Drawing.Point(98, 12);
            this.cboSubGroupMeterial.Name = "cboSubGroupMeterial";
            this.cboSubGroupMeterial.Size = new System.Drawing.Size(259, 23);
            this.cboSubGroupMeterial.TabIndex = 1;
            this.cboSubGroupMeterial.SelectedIndexChanged += new System.EventHandler(this.cboSubGroupMeterial_SelectedIndexChanged);
            // 
            // btnImport
            // 
            this.btnImport.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnImport.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnImport.Location = new System.Drawing.Point(363, 66);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(67, 23);
            this.btnImport.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnImport.TabIndex = 5;
            this.btnImport.Text = "Nhập hàng";
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // dgvImportBill
            // 
            this.dgvImportBill.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvImportBill.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgvImportBill.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.dgvImportBill.Location = new System.Drawing.Point(2, 96);
            this.dgvImportBill.Name = "dgvImportBill";
            this.dgvImportBill.Size = new System.Drawing.Size(935, 436);
            this.dgvImportBill.TabIndex = 9;
            this.dgvImportBill.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvImportBill_CellContentClick);
            // 
            // ImportBillsOld
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(940, 535);
            this.Controls.Add(this.dgvImportBill);
            this.Controls.Add(this.cboSubGroupMeterial);
            this.Controls.Add(this.cboMeterial);
            this.Controls.Add(this.btnImport);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtCost);
            this.Controls.Add(this.txtQuantity);
            this.Controls.Add(this.txtTotalMoney);
            this.Controls.Add(this.txtNote);
            this.Controls.Add(this.dtpBillDate);
            this.Controls.Add(this.labelX7);
            this.Controls.Add(this.labelX3);
            this.Controls.Add(this.labelX8);
            this.Controls.Add(this.labelX6);
            this.Controls.Add(this.labelX4);
            this.Controls.Add(this.labelX5);
            this.Controls.Add(this.labelX2);
            this.Controls.Add(this.labelX1);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "ImportBillsOld";
            this.Text = "Hoá đơn nhập hàng ";
            this.Load += new System.EventHandler(this.ImportBills_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txtTotalMoney)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtQuantity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCost)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvImportBill)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.LabelX labelX1;
        private System.Windows.Forms.DateTimePicker dtpBillDate;
        private DevComponents.DotNetBar.LabelX labelX2;
        private DevComponents.DotNetBar.Controls.TextBoxX txtNote;
        private DevComponents.DotNetBar.LabelX labelX3;
        private DevComponents.Editors.DoubleInput txtTotalMoney;
        private DevComponents.DotNetBar.ButtonX btnSave;
        private DevComponents.DotNetBar.LabelX labelX4;
        private System.Windows.Forms.ComboBox cboMeterial;
        private DevComponents.DotNetBar.LabelX labelX5;
        private DevComponents.Editors.DoubleInput txtQuantity;
        private DevComponents.Editors.DoubleInput txtCost;
        private DevComponents.DotNetBar.LabelX labelX6;
        private DevComponents.DotNetBar.LabelX labelX7;
        private DevComponents.DotNetBar.LabelX labelX8;
        private System.Windows.Forms.ComboBox cboSubGroupMeterial;
        private DevComponents.DotNetBar.ButtonX btnImport;
        private DevComponents.DotNetBar.Controls.DataGridViewX dgvImportBill;
    }
}
namespace RestaurantManagement
{
    partial class AddMenu
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddMenu));
            this.txtCost = new DevComponents.Editors.DoubleInput();
            this.cboUnit = new DevComponents.DotNetBar.Controls.ComboTree();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cboMeterial = new System.Windows.Forms.ComboBox();
            this.dgvMeterial = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.STT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MeterialName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UnitName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Quantity = new DevComponents.DotNetBar.Controls.DataGridViewDoubleInputColumn();
            this.Delete = new System.Windows.Forms.DataGridViewButtonColumn();
            this.MeterialId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnUnit = new DevComponents.DotNetBar.ButtonX();
            this.txtOriginalCost = new DevComponents.Editors.DoubleInput();
            this.lbServices = new System.Windows.Forms.Label();
            this.txtNote = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.txtSubGroupMenu = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.txtFoodName = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.labelX5 = new DevComponents.DotNetBar.LabelX();
            this.btnImage = new DevComponents.DotNetBar.ButtonX();
            this.labelX3 = new DevComponents.DotNetBar.LabelX();
            this.ptbImage = new System.Windows.Forms.PictureBox();
            this.labelX6 = new DevComponents.DotNetBar.LabelX();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.labelX4 = new DevComponents.DotNetBar.LabelX();
            this.btnClose = new DevComponents.DotNetBar.ButtonX();
            this.btnAddMenu = new DevComponents.DotNetBar.ButtonX();
            ((System.ComponentModel.ISupportInitialize)(this.txtCost)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMeterial)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtOriginalCost)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbImage)).BeginInit();
            this.SuspendLayout();
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
            this.txtCost.ForeColor = System.Drawing.Color.Black;
            this.txtCost.Increment = 1;
            this.txtCost.Location = new System.Drawing.Point(100, 72);
            this.txtCost.MinValue = 0;
            this.txtCost.Name = "txtCost";
            this.txtCost.Size = new System.Drawing.Size(341, 20);
            this.txtCost.TabIndex = 2;
            // 
            // cboUnit
            // 
            this.cboUnit.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.cboUnit.BackgroundStyle.Class = "TextBoxBorder";
            this.cboUnit.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.cboUnit.ButtonDropDown.Visible = true;
            this.cboUnit.ForeColor = System.Drawing.Color.Black;
            this.cboUnit.Location = new System.Drawing.Point(100, 125);
            this.cboUnit.Name = "cboUnit";
            this.cboUnit.Size = new System.Drawing.Size(310, 23);
            this.cboUnit.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cboUnit.TabIndex = 4;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.White;
            this.groupBox1.Controls.Add(this.cboMeterial);
            this.groupBox1.Controls.Add(this.dgvMeterial);
            this.groupBox1.Controls.Add(this.btnUnit);
            this.groupBox1.Controls.Add(this.txtOriginalCost);
            this.groupBox1.Controls.Add(this.txtCost);
            this.groupBox1.Controls.Add(this.cboUnit);
            this.groupBox1.Controls.Add(this.lbServices);
            this.groupBox1.Controls.Add(this.txtNote);
            this.groupBox1.Controls.Add(this.txtSubGroupMenu);
            this.groupBox1.Controls.Add(this.txtFoodName);
            this.groupBox1.Controls.Add(this.labelX1);
            this.groupBox1.Controls.Add(this.labelX5);
            this.groupBox1.Controls.Add(this.btnImage);
            this.groupBox1.Controls.Add(this.labelX3);
            this.groupBox1.Controls.Add(this.ptbImage);
            this.groupBox1.Controls.Add(this.labelX6);
            this.groupBox1.Controls.Add(this.labelX2);
            this.groupBox1.Controls.Add(this.labelX4);
            this.groupBox1.ForeColor = System.Drawing.Color.Black;
            this.groupBox1.Location = new System.Drawing.Point(11, 7);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(602, 348);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông tin yêu cầu";
            // 
            // cboMeterial
            // 
            this.cboMeterial.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboMeterial.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboMeterial.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboMeterial.FormattingEnabled = true;
            this.cboMeterial.Location = new System.Drawing.Point(100, 181);
            this.cboMeterial.Name = "cboMeterial";
            this.cboMeterial.Size = new System.Drawing.Size(341, 23);
            this.cboMeterial.TabIndex = 12;
            this.cboMeterial.Text = "Nhập tên nguyên liệu để tìm";
            this.cboMeterial.SelectedIndexChanged += new System.EventHandler(this.cboMeterial_SelectedIndexChanged);
            // 
            // dgvMeterial
            // 
            this.dgvMeterial.AllowUserToAddRows = false;
            this.dgvMeterial.AllowUserToDeleteRows = false;
            this.dgvMeterial.AllowUserToResizeColumns = false;
            this.dgvMeterial.AllowUserToResizeRows = false;
            this.dgvMeterial.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dgvMeterial.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMeterial.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.STT,
            this.MeterialName,
            this.UnitName,
            this.Quantity,
            this.Delete,
            this.MeterialId});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvMeterial.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgvMeterial.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.dgvMeterial.Location = new System.Drawing.Point(9, 210);
            this.dgvMeterial.MultiSelect = false;
            this.dgvMeterial.Name = "dgvMeterial";
            this.dgvMeterial.RowHeadersVisible = false;
            this.dgvMeterial.Size = new System.Drawing.Size(578, 132);
            this.dgvMeterial.TabIndex = 11;
            this.dgvMeterial.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvMeterial_CellClick);
            // 
            // STT
            // 
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
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.UnitName.DefaultCellStyle = dataGridViewCellStyle1;
            this.UnitName.HeaderText = "ĐVT";
            this.UnitName.Name = "UnitName";
            this.UnitName.ReadOnly = true;
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
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.Quantity.DefaultCellStyle = dataGridViewCellStyle2;
            this.Quantity.HeaderText = "Định lượng";
            this.Quantity.Increment = 1;
            this.Quantity.MinValue = 0;
            this.Quantity.Name = "Quantity";
            this.Quantity.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Quantity.ShowUpDown = true;
            // 
            // Delete
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.NullValue = "Xóa";
            this.Delete.DefaultCellStyle = dataGridViewCellStyle3;
            this.Delete.HeaderText = "Xóa";
            this.Delete.Name = "Delete";
            this.Delete.Width = 60;
            // 
            // MeterialId
            // 
            this.MeterialId.HeaderText = "MeterialId";
            this.MeterialId.Name = "MeterialId";
            this.MeterialId.Visible = false;
            // 
            // btnUnit
            // 
            this.btnUnit.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnUnit.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUnit.Location = new System.Drawing.Point(416, 125);
            this.btnUnit.Name = "btnUnit";
            this.btnUnit.Size = new System.Drawing.Size(25, 23);
            this.btnUnit.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnUnit.TabIndex = 9;
            this.btnUnit.Text = "...";
            this.btnUnit.Click += new System.EventHandler(this.btnUnit_Click);
            // 
            // txtOriginalCost
            // 
            this.txtOriginalCost.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtOriginalCost.BackgroundStyle.Class = "DateTimeInputBackground";
            this.txtOriginalCost.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtOriginalCost.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.txtOriginalCost.DisplayFormat = "###,#0";
            this.txtOriginalCost.ForeColor = System.Drawing.Color.Black;
            this.txtOriginalCost.Increment = 1;
            this.txtOriginalCost.Location = new System.Drawing.Point(100, 98);
            this.txtOriginalCost.MinValue = 0;
            this.txtOriginalCost.Name = "txtOriginalCost";
            this.txtOriginalCost.Size = new System.Drawing.Size(341, 20);
            this.txtOriginalCost.TabIndex = 3;
            // 
            // lbServices
            // 
            this.lbServices.AutoSize = true;
            this.lbServices.BackColor = System.Drawing.Color.White;
            this.lbServices.ForeColor = System.Drawing.Color.Black;
            this.lbServices.Location = new System.Drawing.Point(6, 48);
            this.lbServices.Name = "lbServices";
            this.lbServices.Size = new System.Drawing.Size(72, 13);
            this.lbServices.TabIndex = 10;
            this.lbServices.Text = "Tên thực đơn";
            // 
            // txtNote
            // 
            this.txtNote.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtNote.Border.Class = "TextBoxBorder";
            this.txtNote.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtNote.ForeColor = System.Drawing.Color.Black;
            this.txtNote.Location = new System.Drawing.Point(100, 155);
            this.txtNote.Name = "txtNote";
            this.txtNote.Size = new System.Drawing.Size(341, 20);
            this.txtNote.TabIndex = 5;
            // 
            // txtSubGroupMenu
            // 
            this.txtSubGroupMenu.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtSubGroupMenu.Border.Class = "TextBoxBorder";
            this.txtSubGroupMenu.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtSubGroupMenu.ForeColor = System.Drawing.Color.Black;
            this.txtSubGroupMenu.Location = new System.Drawing.Point(100, 17);
            this.txtSubGroupMenu.Name = "txtSubGroupMenu";
            this.txtSubGroupMenu.ReadOnly = true;
            this.txtSubGroupMenu.Size = new System.Drawing.Size(341, 20);
            this.txtSubGroupMenu.TabIndex = 0;
            // 
            // txtFoodName
            // 
            this.txtFoodName.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtFoodName.Border.Class = "TextBoxBorder";
            this.txtFoodName.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtFoodName.ForeColor = System.Drawing.Color.Black;
            this.txtFoodName.Location = new System.Drawing.Point(100, 46);
            this.txtFoodName.Name = "txtFoodName";
            this.txtFoodName.Size = new System.Drawing.Size(341, 20);
            this.txtFoodName.TabIndex = 1;
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
            this.labelX1.Location = new System.Drawing.Point(7, 15);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(87, 26);
            this.labelX1.TabIndex = 0;
            this.labelX1.Text = "Danh mục";
            // 
            // labelX5
            // 
            this.labelX5.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.labelX5.BackgroundStyle.Class = "";
            this.labelX5.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX5.ForeColor = System.Drawing.Color.Black;
            this.labelX5.Location = new System.Drawing.Point(9, 92);
            this.labelX5.Name = "labelX5";
            this.labelX5.Size = new System.Drawing.Size(72, 26);
            this.labelX5.TabIndex = 0;
            this.labelX5.Text = "Giá chế biến";
            // 
            // btnImage
            // 
            this.btnImage.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnImage.Location = new System.Drawing.Point(489, 154);
            this.btnImage.Name = "btnImage";
            this.btnImage.Size = new System.Drawing.Size(75, 23);
            this.btnImage.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnImage.TabIndex = 6;
            this.btnImage.Text = "Hình ảnh";
            this.btnImage.Click += new System.EventHandler(this.btnImage_Click);
            // 
            // labelX3
            // 
            this.labelX3.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.labelX3.BackgroundStyle.Class = "";
            this.labelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX3.ForeColor = System.Drawing.Color.Black;
            this.labelX3.Location = new System.Drawing.Point(9, 66);
            this.labelX3.Name = "labelX3";
            this.labelX3.Size = new System.Drawing.Size(63, 26);
            this.labelX3.TabIndex = 0;
            this.labelX3.Text = "Giá bán";
            // 
            // ptbImage
            // 
            this.ptbImage.BackColor = System.Drawing.Color.White;
            this.ptbImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ptbImage.ForeColor = System.Drawing.Color.Black;
            this.ptbImage.Image = ((System.Drawing.Image)(resources.GetObject("ptbImage.Image")));
            this.ptbImage.Location = new System.Drawing.Point(453, 22);
            this.ptbImage.Name = "ptbImage";
            this.ptbImage.Size = new System.Drawing.Size(134, 126);
            this.ptbImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ptbImage.TabIndex = 3;
            this.ptbImage.TabStop = false;
            // 
            // labelX6
            // 
            this.labelX6.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.labelX6.BackgroundStyle.Class = "";
            this.labelX6.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX6.ForeColor = System.Drawing.Color.Black;
            this.labelX6.Location = new System.Drawing.Point(6, 181);
            this.labelX6.Name = "labelX6";
            this.labelX6.Size = new System.Drawing.Size(88, 26);
            this.labelX6.TabIndex = 0;
            this.labelX6.Text = "Nguyên liệu chính";
            // 
            // labelX2
            // 
            this.labelX2.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.labelX2.BackgroundStyle.Class = "";
            this.labelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX2.ForeColor = System.Drawing.Color.Black;
            this.labelX2.Location = new System.Drawing.Point(9, 147);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(63, 26);
            this.labelX2.TabIndex = 0;
            this.labelX2.Text = "Ghi chú";
            // 
            // labelX4
            // 
            this.labelX4.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.labelX4.BackgroundStyle.Class = "";
            this.labelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX4.ForeColor = System.Drawing.Color.Black;
            this.labelX4.Location = new System.Drawing.Point(9, 118);
            this.labelX4.Name = "labelX4";
            this.labelX4.Size = new System.Drawing.Size(63, 26);
            this.labelX4.TabIndex = 0;
            this.labelX4.Text = "Đơn vị tính";
            // 
            // btnClose
            // 
            this.btnClose.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnClose.Location = new System.Drawing.Point(315, 361);
            this.btnClose.Name = "btnClose";
            this.btnClose.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.CtrlD);
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnClose.TabIndex = 8;
            this.btnClose.Text = "Đóng";
            this.btnClose.Tooltip = "Ctrl + D";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click_1);
            // 
            // btnAddMenu
            // 
            this.btnAddMenu.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnAddMenu.Location = new System.Drawing.Point(234, 361);
            this.btnAddMenu.Name = "btnAddMenu";
            this.btnAddMenu.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.CtrlS);
            this.btnAddMenu.Size = new System.Drawing.Size(75, 23);
            this.btnAddMenu.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnAddMenu.TabIndex = 7;
            this.btnAddMenu.Text = "Thêm món";
            this.btnAddMenu.Tooltip = "Enter";
            this.btnAddMenu.Click += new System.EventHandler(this.btnAddMenu_Click);
            // 
            // AddMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(625, 396);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnAddMenu);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "AddMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Thêm món ăn";
            this.Load += new System.EventHandler(this.AddFood_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txtCost)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMeterial)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtOriginalCost)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbImage)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.Editors.DoubleInput txtCost;
        private DevComponents.DotNetBar.Controls.ComboTree cboUnit;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lbServices;
        private DevComponents.DotNetBar.Controls.TextBoxX txtNote;
        private DevComponents.DotNetBar.Controls.TextBoxX txtSubGroupMenu;
        private DevComponents.DotNetBar.Controls.TextBoxX txtFoodName;
        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.DotNetBar.ButtonX btnImage;
        private DevComponents.DotNetBar.LabelX labelX3;
        private System.Windows.Forms.PictureBox ptbImage;
        private DevComponents.DotNetBar.LabelX labelX2;
        private DevComponents.DotNetBar.LabelX labelX4;
        private DevComponents.DotNetBar.ButtonX btnClose;
        private DevComponents.DotNetBar.ButtonX btnAddMenu;
        private DevComponents.Editors.DoubleInput txtOriginalCost;
        private DevComponents.DotNetBar.LabelX labelX5;
        private DevComponents.DotNetBar.ButtonX btnUnit;
        private DevComponents.DotNetBar.Controls.DataGridViewX dgvMeterial;
        private DevComponents.DotNetBar.LabelX labelX6;
        private System.Windows.Forms.ComboBox cboMeterial;
        private System.Windows.Forms.DataGridViewTextBoxColumn STT;
        private System.Windows.Forms.DataGridViewTextBoxColumn MeterialName;
        private System.Windows.Forms.DataGridViewTextBoxColumn UnitName;
        private DevComponents.DotNetBar.Controls.DataGridViewDoubleInputColumn Quantity;
        private System.Windows.Forms.DataGridViewButtonColumn Delete;
        private System.Windows.Forms.DataGridViewTextBoxColumn MeterialId;

    }
}
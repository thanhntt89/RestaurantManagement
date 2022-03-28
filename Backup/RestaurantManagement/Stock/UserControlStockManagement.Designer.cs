namespace RestaurantManagement
{
    partial class UserControlStockManagement
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserControlStockManagement));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.cboMeterialGroup = new DevComponents.DotNetBar.Controls.ComboTree();
            this.listViewMeterialGroup = new DevComponents.DotNetBar.Controls.ListViewEx();
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnAddFoodGroupName = new System.Windows.Forms.ToolStripMenuItem();
            this.mnEditFoodGroupName = new System.Windows.Forms.ToolStripMenuItem();
            this.mnDeleteFoodGroup = new System.Windows.Forms.ToolStripMenuItem();
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.dgvMeterialMenu = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.STT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SubGroupMeterialName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MeterialName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Unit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Total = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MeterialId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SubGroupMeterialId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnExportMeterial = new DevComponents.DotNetBar.ButtonX();
            this.btnQuantityAdjusting = new DevComponents.DotNetBar.ButtonX();
            this.btnDeleteFood = new DevComponents.DotNetBar.ButtonX();
            this.btnEditFood = new DevComponents.DotNetBar.ButtonX();
            this.btnAddFood = new DevComponents.DotNetBar.ButtonX();
            this.btnSearch = new DevComponents.DotNetBar.ButtonX();
            this.txtItemName = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.btnMeterialGroup = new DevComponents.DotNetBar.ButtonX();
            this.btnImportBill = new DevComponents.DotNetBar.ButtonX();
            this.btnInventories = new DevComponents.DotNetBar.ButtonX();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            this.contextMenuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMeterialMenu)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer
            // 
            this.splitContainer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.splitContainer.Location = new System.Drawing.Point(7, 3);
            this.splitContainer.Name = "splitContainer";
            // 
            // splitContainer.Panel1
            // 
            this.splitContainer.Panel1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.splitContainer.Panel1.Controls.Add(this.cboMeterialGroup);
            this.splitContainer.Panel1.Controls.Add(this.listViewMeterialGroup);
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.Controls.Add(this.dgvMeterialMenu);
            this.splitContainer.Panel2.Controls.Add(this.btnExportMeterial);
            this.splitContainer.Size = new System.Drawing.Size(1039, 473);
            this.splitContainer.SplitterDistance = 243;
            this.splitContainer.SplitterWidth = 3;
            this.splitContainer.TabIndex = 5;
            // 
            // cboMeterialGroup
            // 
            this.cboMeterialGroup.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cboMeterialGroup.BackColor = System.Drawing.SystemColors.Window;
            // 
            // 
            // 
            this.cboMeterialGroup.BackgroundStyle.Class = "TextBoxBorder";
            this.cboMeterialGroup.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.cboMeterialGroup.ButtonClear.Visible = true;
            this.cboMeterialGroup.ButtonDropDown.Visible = true;
            this.cboMeterialGroup.Location = new System.Drawing.Point(3, 3);
            this.cboMeterialGroup.Name = "cboMeterialGroup";
            this.cboMeterialGroup.Size = new System.Drawing.Size(237, 27);
            this.cboMeterialGroup.Style = DevComponents.DotNetBar.eDotNetBarStyle.Windows7;
            this.cboMeterialGroup.TabIndex = 3;
            this.cboMeterialGroup.WatermarkText = "Chọn nhóm để lọc";
            this.cboMeterialGroup.SelectedIndexChanged += new System.EventHandler(this.cboMeterialGroup_SelectedIndexChanged);
            // 
            // listViewMeterialGroup
            // 
            this.listViewMeterialGroup.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.listViewMeterialGroup.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.listViewMeterialGroup.Border.Class = "ListViewBorder";
            this.listViewMeterialGroup.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.listViewMeterialGroup.ContextMenuStrip = this.contextMenuStrip;
            this.listViewMeterialGroup.ForeColor = System.Drawing.Color.Black;
            this.listViewMeterialGroup.LargeImageList = this.imageList;
            this.listViewMeterialGroup.Location = new System.Drawing.Point(3, 36);
            this.listViewMeterialGroup.MultiSelect = false;
            this.listViewMeterialGroup.Name = "listViewMeterialGroup";
            this.listViewMeterialGroup.Size = new System.Drawing.Size(240, 437);
            this.listViewMeterialGroup.SmallImageList = this.imageList;
            this.listViewMeterialGroup.TabIndex = 1;
            this.listViewMeterialGroup.UseCompatibleStateImageBehavior = false;
            this.listViewMeterialGroup.View = System.Windows.Forms.View.Tile;
            this.listViewMeterialGroup.Click += new System.EventHandler(this.listViewMeterialGroup_Click);
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnAddFoodGroupName,
            this.mnEditFoodGroupName,
            this.mnDeleteFoodGroup});
            this.contextMenuStrip.Name = "contextMenuStrip";
            this.contextMenuStrip.Size = new System.Drawing.Size(220, 70);
            // 
            // mnAddFoodGroupName
            // 
            this.mnAddFoodGroupName.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.mnAddFoodGroupName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mnAddFoodGroupName.Image = ((System.Drawing.Image)(resources.GetObject("mnAddFoodGroupName.Image")));
            this.mnAddFoodGroupName.Name = "mnAddFoodGroupName";
            this.mnAddFoodGroupName.Size = new System.Drawing.Size(219, 22);
            this.mnAddFoodGroupName.Text = "Thêm danh mục mặt hàng";
            this.mnAddFoodGroupName.Click += new System.EventHandler(this.mnAddFoodGroupName_Click);
            // 
            // mnEditFoodGroupName
            // 
            this.mnEditFoodGroupName.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.mnEditFoodGroupName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mnEditFoodGroupName.Image = ((System.Drawing.Image)(resources.GetObject("mnEditFoodGroupName.Image")));
            this.mnEditFoodGroupName.Name = "mnEditFoodGroupName";
            this.mnEditFoodGroupName.Size = new System.Drawing.Size(219, 22);
            this.mnEditFoodGroupName.Text = "Sửa danh mục mặt hàng";
            this.mnEditFoodGroupName.Click += new System.EventHandler(this.mnEditFoodGroupName_Click);
            // 
            // mnDeleteFoodGroup
            // 
            this.mnDeleteFoodGroup.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.mnDeleteFoodGroup.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mnDeleteFoodGroup.Image = ((System.Drawing.Image)(resources.GetObject("mnDeleteFoodGroup.Image")));
            this.mnDeleteFoodGroup.Name = "mnDeleteFoodGroup";
            this.mnDeleteFoodGroup.Size = new System.Drawing.Size(219, 22);
            this.mnDeleteFoodGroup.Text = "Xoá danh mục mặt hàng";
            this.mnDeleteFoodGroup.Click += new System.EventHandler(this.mnDeleteFoodGroup_Click);
            // 
            // imageList
            // 
            this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
            this.imageList.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList.Images.SetKeyName(0, "folder_icon.png");
            // 
            // dgvMeterialMenu
            // 
            this.dgvMeterialMenu.AllowUserToAddRows = false;
            this.dgvMeterialMenu.AllowUserToDeleteRows = false;
            this.dgvMeterialMenu.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dgvMeterialMenu.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMeterialMenu.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.STT,
            this.SubGroupMeterialName,
            this.MeterialName,
            this.Unit,
            this.Total,
            this.MeterialId,
            this.SubGroupMeterialId});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvMeterialMenu.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvMeterialMenu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvMeterialMenu.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.dgvMeterialMenu.Location = new System.Drawing.Point(0, 0);
            this.dgvMeterialMenu.Name = "dgvMeterialMenu";
            this.dgvMeterialMenu.ReadOnly = true;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvMeterialMenu.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvMeterialMenu.RowHeadersVisible = false;
            this.dgvMeterialMenu.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvMeterialMenu.Size = new System.Drawing.Size(793, 473);
            this.dgvMeterialMenu.TabIndex = 0;
            this.dgvMeterialMenu.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvMeterialMenu_CellDoubleClick);
            // 
            // STT
            // 
            this.STT.HeaderText = "STT";
            this.STT.Name = "STT";
            this.STT.ReadOnly = true;
            this.STT.Width = 50;
            // 
            // SubGroupMeterialName
            // 
            this.SubGroupMeterialName.HeaderText = "Nhóm nguyên liệu";
            this.SubGroupMeterialName.Name = "SubGroupMeterialName";
            this.SubGroupMeterialName.ReadOnly = true;
            this.SubGroupMeterialName.Width = 120;
            // 
            // MeterialName
            // 
            this.MeterialName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.MeterialName.HeaderText = "Tên nguyên liệu";
            this.MeterialName.Name = "MeterialName";
            this.MeterialName.ReadOnly = true;
            // 
            // Unit
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Unit.DefaultCellStyle = dataGridViewCellStyle1;
            this.Unit.HeaderText = "Đơn vị tính";
            this.Unit.Name = "Unit";
            this.Unit.ReadOnly = true;
            // 
            // Total
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.Total.DefaultCellStyle = dataGridViewCellStyle2;
            this.Total.HeaderText = "Số lượng tồn";
            this.Total.Name = "Total";
            this.Total.ReadOnly = true;
            // 
            // MeterialId
            // 
            this.MeterialId.HeaderText = "MeterialId";
            this.MeterialId.Name = "MeterialId";
            this.MeterialId.ReadOnly = true;
            this.MeterialId.Visible = false;
            // 
            // SubGroupMeterialId
            // 
            this.SubGroupMeterialId.HeaderText = "SubGroupMeterialId";
            this.SubGroupMeterialId.Name = "SubGroupMeterialId";
            this.SubGroupMeterialId.ReadOnly = true;
            this.SubGroupMeterialId.Visible = false;
            // 
            // btnExportMeterial
            // 
            this.btnExportMeterial.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnExportMeterial.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExportMeterial.Location = new System.Drawing.Point(12, 399);
            this.btnExportMeterial.Name = "btnExportMeterial";
            this.btnExportMeterial.Size = new System.Drawing.Size(78, 23);
            this.btnExportMeterial.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnExportMeterial.TabIndex = 6;
            this.btnExportMeterial.Text = "Xuất kho (F4)";
            this.btnExportMeterial.Click += new System.EventHandler(this.btnExportMeterial_Click);
            // 
            // btnQuantityAdjusting
            // 
            this.btnQuantityAdjusting.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnQuantityAdjusting.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnQuantityAdjusting.Location = new System.Drawing.Point(413, 481);
            this.btnQuantityAdjusting.Name = "btnQuantityAdjusting";
            this.btnQuantityAdjusting.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.F6);
            this.btnQuantityAdjusting.Size = new System.Drawing.Size(112, 23);
            this.btnQuantityAdjusting.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnQuantityAdjusting.TabIndex = 6;
            this.btnQuantityAdjusting.Text = "Điều chỉnh tồn (F6)";
            this.btnQuantityAdjusting.Click += new System.EventHandler(this.btnQuantityAdjusting_Click);
            // 
            // btnDeleteFood
            // 
            this.btnDeleteFood.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnDeleteFood.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDeleteFood.Location = new System.Drawing.Point(969, 481);
            this.btnDeleteFood.Name = "btnDeleteFood";
            this.btnDeleteFood.Size = new System.Drawing.Size(77, 23);
            this.btnDeleteFood.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnDeleteFood.TabIndex = 8;
            this.btnDeleteFood.Text = "Xoá mặt hàng";
            this.btnDeleteFood.Click += new System.EventHandler(this.btnDeleteFood_Click);
            // 
            // btnEditFood
            // 
            this.btnEditFood.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnEditFood.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEditFood.Location = new System.Drawing.Point(645, 481);
            this.btnEditFood.Name = "btnEditFood";
            this.btnEditFood.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.F8);
            this.btnEditFood.Size = new System.Drawing.Size(102, 23);
            this.btnEditFood.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnEditFood.TabIndex = 6;
            this.btnEditFood.Text = "Sửa mặt hàng (F8)";
            this.btnEditFood.Click += new System.EventHandler(this.btnEditFood_Click);
            // 
            // btnAddFood
            // 
            this.btnAddFood.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnAddFood.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddFood.Location = new System.Drawing.Point(529, 481);
            this.btnAddFood.Name = "btnAddFood";
            this.btnAddFood.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.F7);
            this.btnAddFood.Size = new System.Drawing.Size(112, 23);
            this.btnAddFood.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnAddFood.TabIndex = 7;
            this.btnAddFood.Text = "Thêm mặt hàng (F7)";
            this.btnAddFood.Click += new System.EventHandler(this.btnAddFood_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSearch.Location = new System.Drawing.Point(893, 481);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(70, 23);
            this.btnSearch.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnSearch.TabIndex = 9;
            this.btnSearch.Text = "Tìm";
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // txtItemName
            // 
            this.txtItemName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtItemName.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtItemName.Border.Class = "TextBoxBorder";
            this.txtItemName.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtItemName.ForeColor = System.Drawing.Color.Black;
            this.txtItemName.Location = new System.Drawing.Point(751, 482);
            this.txtItemName.Name = "txtItemName";
            this.txtItemName.Size = new System.Drawing.Size(136, 20);
            this.txtItemName.TabIndex = 10;
            this.txtItemName.WatermarkText = "Nhập tên mặt hàng để tìm ...";
            // 
            // btnMeterialGroup
            // 
            this.btnMeterialGroup.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnMeterialGroup.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnMeterialGroup.Location = new System.Drawing.Point(10, 481);
            this.btnMeterialGroup.Name = "btnMeterialGroup";
            this.btnMeterialGroup.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.F2);
            this.btnMeterialGroup.Size = new System.Drawing.Size(116, 23);
            this.btnMeterialGroup.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnMeterialGroup.TabIndex = 6;
            this.btnMeterialGroup.Text = "Nhóm mặt hàng (F2)";
            this.btnMeterialGroup.Click += new System.EventHandler(this.btnMeterialGroup_Click);
            // 
            // btnImportBill
            // 
            this.btnImportBill.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnImportBill.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnImportBill.Location = new System.Drawing.Point(331, 481);
            this.btnImportBill.Name = "btnImportBill";
            this.btnImportBill.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.F5);
            this.btnImportBill.Size = new System.Drawing.Size(78, 23);
            this.btnImportBill.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnImportBill.TabIndex = 6;
            this.btnImportBill.Text = "Nhập kho (F5)";
            this.btnImportBill.Click += new System.EventHandler(this.btnImportBill_Click);
            // 
            // btnInventories
            // 
            this.btnInventories.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnInventories.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnInventories.Location = new System.Drawing.Point(251, 481);
            this.btnInventories.Name = "btnInventories";
            this.btnInventories.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.F3);
            this.btnInventories.Size = new System.Drawing.Size(76, 23);
            this.btnInventories.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnInventories.TabIndex = 6;
            this.btnInventories.Text = "Tồn kho (F3)";
            this.btnInventories.Click += new System.EventHandler(this.btnInventories_Click);
            // 
            // UserControlStockManagement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.Controls.Add(this.btnDeleteFood);
            this.Controls.Add(this.txtItemName);
            this.Controls.Add(this.btnQuantityAdjusting);
            this.Controls.Add(this.btnAddFood);
            this.Controls.Add(this.splitContainer);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.btnMeterialGroup);
            this.Controls.Add(this.btnEditFood);
            this.Controls.Add(this.btnImportBill);
            this.Controls.Add(this.btnInventories);
            this.Name = "UserControlStockManagement";
            this.Size = new System.Drawing.Size(1058, 508);
            this.Load += new System.EventHandler(this.UserControlStockManagement_Load);
            this.splitContainer.Panel1.ResumeLayout(false);
            this.splitContainer.Panel2.ResumeLayout(false);
            this.splitContainer.ResumeLayout(false);
            this.contextMenuStrip.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMeterialMenu)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem mnAddFoodGroupName;
        private System.Windows.Forms.ToolStripMenuItem mnEditFoodGroupName;
        private System.Windows.Forms.ToolStripMenuItem mnDeleteFoodGroup;
        private DevComponents.DotNetBar.Controls.DataGridViewX dgvMeterialMenu;
        private DevComponents.DotNetBar.ButtonX btnDeleteFood;
        private DevComponents.DotNetBar.ButtonX btnEditFood;
        private DevComponents.DotNetBar.ButtonX btnAddFood;
        private DevComponents.DotNetBar.ButtonX btnSearch;
        private DevComponents.DotNetBar.ButtonX btnQuantityAdjusting;
        private DevComponents.DotNetBar.Controls.TextBoxX txtItemName;
        private System.Windows.Forms.ImageList imageList;
        private DevComponents.DotNetBar.Controls.ListViewEx listViewMeterialGroup;
        private DevComponents.DotNetBar.ButtonX btnMeterialGroup;
        private DevComponents.DotNetBar.ButtonX btnImportBill;
        private DevComponents.DotNetBar.ButtonX btnExportMeterial;
        private DevComponents.DotNetBar.ButtonX btnInventories;
        private DevComponents.DotNetBar.Controls.ComboTree cboMeterialGroup;
        private System.Windows.Forms.DataGridViewTextBoxColumn STT;
        private System.Windows.Forms.DataGridViewTextBoxColumn SubGroupMeterialName;
        private System.Windows.Forms.DataGridViewTextBoxColumn MeterialName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Unit;
        private System.Windows.Forms.DataGridViewTextBoxColumn Total;
        private System.Windows.Forms.DataGridViewTextBoxColumn MeterialId;
        private System.Windows.Forms.DataGridViewTextBoxColumn SubGroupMeterialId;
    }
}

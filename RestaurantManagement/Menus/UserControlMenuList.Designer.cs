namespace RestaurantManagement
{
    partial class UserControlMenuList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserControlMenuList));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.cboMenuGroup = new DevComponents.DotNetBar.Controls.ComboTree();
            this.listViewMenus = new DevComponents.DotNetBar.Controls.ListViewEx();
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnAddFoodGroupName = new System.Windows.Forms.ToolStripMenuItem();
            this.mnEditFoodGroupName = new System.Windows.Forms.ToolStripMenuItem();
            this.mnDeleteFoodGroup = new System.Windows.Forms.ToolStripMenuItem();
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.dgvMenuList = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.btnAddFood = new DevComponents.DotNetBar.ButtonX();
            this.btnEditFood = new DevComponents.DotNetBar.ButtonX();
            this.btnDeleteFood = new DevComponents.DotNetBar.ButtonX();
            this.btnSearch = new DevComponents.DotNetBar.ButtonX();
            this.txtMenuName = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.btnGroupMenu = new DevComponents.DotNetBar.ButtonX();
            this.STT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SubMenuGroup = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ItemName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cost = new DevComponents.DotNetBar.Controls.DataGridViewDoubleInputColumn();
            this.Image = new System.Windows.Forms.DataGridViewImageColumn();
            this.MeterialId = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Delete = new System.Windows.Forms.DataGridViewButtonColumn();
            this.MenuId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            this.contextMenuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMenuList)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer
            // 
            this.splitContainer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.splitContainer.Location = new System.Drawing.Point(14, 3);
            this.splitContainer.Name = "splitContainer";
            // 
            // splitContainer.Panel1
            // 
            this.splitContainer.Panel1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.splitContainer.Panel1.Controls.Add(this.cboMenuGroup);
            this.splitContainer.Panel1.Controls.Add(this.listViewMenus);
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.splitContainer.Panel2.Controls.Add(this.dgvMenuList);
            this.splitContainer.Size = new System.Drawing.Size(997, 541);
            this.splitContainer.SplitterDistance = 243;
            this.splitContainer.SplitterWidth = 3;
            this.splitContainer.TabIndex = 0;
            // 
            // cboMenuGroup
            // 
            this.cboMenuGroup.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cboMenuGroup.BackColor = System.Drawing.SystemColors.Window;
            // 
            // 
            // 
            this.cboMenuGroup.BackgroundStyle.Class = "TextBoxBorder";
            this.cboMenuGroup.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.cboMenuGroup.ButtonClear.Visible = true;
            this.cboMenuGroup.ButtonDropDown.Visible = true;
            this.cboMenuGroup.Location = new System.Drawing.Point(3, 2);
            this.cboMenuGroup.Name = "cboMenuGroup";
            this.cboMenuGroup.Size = new System.Drawing.Size(236, 27);
            this.cboMenuGroup.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cboMenuGroup.TabIndex = 2;
            this.cboMenuGroup.SelectedIndexChanged += new System.EventHandler(this.cboMenuGroup_SelectedIndexChanged);
            // 
            // listViewMenus
            // 
            this.listViewMenus.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.listViewMenus.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.listViewMenus.Border.Class = "ListViewBorder";
            this.listViewMenus.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.listViewMenus.ContextMenuStrip = this.contextMenuStrip;
            this.listViewMenus.ForeColor = System.Drawing.Color.Black;
            this.listViewMenus.FullRowSelect = true;
            this.listViewMenus.LargeImageList = this.imageList;
            this.listViewMenus.Location = new System.Drawing.Point(3, 35);
            this.listViewMenus.Name = "listViewMenus";
            this.listViewMenus.Size = new System.Drawing.Size(236, 506);
            this.listViewMenus.SmallImageList = this.imageList;
            this.listViewMenus.TabIndex = 1;
            this.listViewMenus.UseCompatibleStateImageBehavior = false;
            this.listViewMenus.DoubleClick += new System.EventHandler(this.listViewMenus_DoubleClick);
            this.listViewMenus.Click += new System.EventHandler(this.listViewMenus_Click);
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnAddFoodGroupName,
            this.mnEditFoodGroupName,
            this.mnDeleteFoodGroup});
            this.contextMenuStrip.Name = "contextMenuStrip";
            this.contextMenuStrip.Size = new System.Drawing.Size(215, 70);
            // 
            // mnAddFoodGroupName
            // 
            this.mnAddFoodGroupName.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.mnAddFoodGroupName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mnAddFoodGroupName.Image = ((System.Drawing.Image)(resources.GetObject("mnAddFoodGroupName.Image")));
            this.mnAddFoodGroupName.Name = "mnAddFoodGroupName";
            this.mnAddFoodGroupName.Size = new System.Drawing.Size(214, 22);
            this.mnAddFoodGroupName.Text = "Thêm danh mục thực đơn";
            this.mnAddFoodGroupName.Click += new System.EventHandler(this.mnAddFoodGroupName_Click);
            // 
            // mnEditFoodGroupName
            // 
            this.mnEditFoodGroupName.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.mnEditFoodGroupName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mnEditFoodGroupName.Image = ((System.Drawing.Image)(resources.GetObject("mnEditFoodGroupName.Image")));
            this.mnEditFoodGroupName.Name = "mnEditFoodGroupName";
            this.mnEditFoodGroupName.Size = new System.Drawing.Size(214, 22);
            this.mnEditFoodGroupName.Text = "Sửa danh mục thực đơn";
            this.mnEditFoodGroupName.Click += new System.EventHandler(this.mnEditFoodGroupName_Click);
            // 
            // mnDeleteFoodGroup
            // 
            this.mnDeleteFoodGroup.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.mnDeleteFoodGroup.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mnDeleteFoodGroup.Image = ((System.Drawing.Image)(resources.GetObject("mnDeleteFoodGroup.Image")));
            this.mnDeleteFoodGroup.Name = "mnDeleteFoodGroup";
            this.mnDeleteFoodGroup.Size = new System.Drawing.Size(214, 22);
            this.mnDeleteFoodGroup.Text = "Xoá danh mục thực đơn";
            this.mnDeleteFoodGroup.Click += new System.EventHandler(this.mnDeleteFoodGroup_Click);
            // 
            // imageList
            // 
            this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
            this.imageList.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList.Images.SetKeyName(0, "oot_explorer.png");
            this.imageList.Images.SetKeyName(1, "folder_icon.png");
            // 
            // dgvMenuList
            // 
            this.dgvMenuList.AllowUserToAddRows = false;
            this.dgvMenuList.AllowUserToDeleteRows = false;
            this.dgvMenuList.AllowUserToOrderColumns = true;
            this.dgvMenuList.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dgvMenuList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMenuList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.STT,
            this.SubMenuGroup,
            this.ItemName,
            this.Column3,
            this.Cost,
            this.Image,
            this.MeterialId,
            this.Delete,
            this.MenuId});
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvMenuList.DefaultCellStyle = dataGridViewCellStyle5;
            this.dgvMenuList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvMenuList.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.dgvMenuList.Location = new System.Drawing.Point(0, 0);
            this.dgvMenuList.MultiSelect = false;
            this.dgvMenuList.Name = "dgvMenuList";
            this.dgvMenuList.ReadOnly = true;
            this.dgvMenuList.RowHeadersVisible = false;
            this.dgvMenuList.RowHeadersWidth = 44;
            this.dgvMenuList.RowTemplate.Height = 40;
            this.dgvMenuList.Size = new System.Drawing.Size(751, 541);
            this.dgvMenuList.TabIndex = 0;
            this.dgvMenuList.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvMenuList_CellDoubleClick);
            this.dgvMenuList.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvMenuList_CellClick);
            // 
            // btnAddFood
            // 
            this.btnAddFood.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnAddFood.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddFood.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnAddFood.Location = new System.Drawing.Point(300, 551);
            this.btnAddFood.Name = "btnAddFood";
            this.btnAddFood.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.F3);
            this.btnAddFood.Size = new System.Drawing.Size(111, 27);
            this.btnAddFood.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnAddFood.TabIndex = 1;
            this.btnAddFood.Text = "Thêm thực đơn (F3)";
            this.btnAddFood.Click += new System.EventHandler(this.btnAddFood_Click);
            // 
            // btnEditFood
            // 
            this.btnEditFood.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnEditFood.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEditFood.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnEditFood.Location = new System.Drawing.Point(417, 551);
            this.btnEditFood.Name = "btnEditFood";
            this.btnEditFood.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.F4);
            this.btnEditFood.Size = new System.Drawing.Size(104, 27);
            this.btnEditFood.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnEditFood.TabIndex = 1;
            this.btnEditFood.Text = "Sửa thực đơn (F4)";
            this.btnEditFood.Click += new System.EventHandler(this.btnEditFood_Click);
            // 
            // btnDeleteFood
            // 
            this.btnDeleteFood.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnDeleteFood.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDeleteFood.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnDeleteFood.Location = new System.Drawing.Point(908, 551);
            this.btnDeleteFood.Name = "btnDeleteFood";
            this.btnDeleteFood.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.F6);
            this.btnDeleteFood.Size = new System.Drawing.Size(103, 27);
            this.btnDeleteFood.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnDeleteFood.TabIndex = 1;
            this.btnDeleteFood.Text = "Xoá thực đơn (F6)";
            this.btnDeleteFood.Click += new System.EventHandler(this.btnDeleteFood_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSearch.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnSearch.Location = new System.Drawing.Point(815, 551);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.F5);
            this.btnSearch.Size = new System.Drawing.Size(87, 27);
            this.btnSearch.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnSearch.TabIndex = 1;
            this.btnSearch.Text = "Tìm (F5)";
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // txtMenuName
            // 
            this.txtMenuName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMenuName.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtMenuName.Border.Class = "TextBoxBorder";
            this.txtMenuName.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtMenuName.ForeColor = System.Drawing.Color.Black;
            this.txtMenuName.Location = new System.Drawing.Point(529, 554);
            this.txtMenuName.Name = "txtMenuName";
            this.txtMenuName.Size = new System.Drawing.Size(280, 21);
            this.txtMenuName.TabIndex = 2;
            this.txtMenuName.WatermarkText = "Nhập vào tên món ăn để tìm ...";
            // 
            // btnGroupMenu
            // 
            this.btnGroupMenu.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnGroupMenu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnGroupMenu.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnGroupMenu.Location = new System.Drawing.Point(14, 554);
            this.btnGroupMenu.Name = "btnGroupMenu";
            this.btnGroupMenu.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.F2);
            this.btnGroupMenu.Size = new System.Drawing.Size(116, 27);
            this.btnGroupMenu.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnGroupMenu.TabIndex = 1;
            this.btnGroupMenu.Text = "Nhóm thực đơn (F2)";
            this.btnGroupMenu.Click += new System.EventHandler(this.btnGroupMenu_Click);
            // 
            // STT
            // 
            this.STT.HeaderText = "STT";
            this.STT.Name = "STT";
            this.STT.ReadOnly = true;
            this.STT.Width = 50;
            // 
            // SubMenuGroup
            // 
            this.SubMenuGroup.HeaderText = "Nhóm danh mục";
            this.SubMenuGroup.Name = "SubMenuGroup";
            this.SubMenuGroup.ReadOnly = true;
            this.SubMenuGroup.Width = 150;
            // 
            // ItemName
            // 
            this.ItemName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ItemName.HeaderText = "Tên món ăn";
            this.ItemName.Name = "ItemName";
            this.ItemName.ReadOnly = true;
            // 
            // Column3
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Column3.DefaultCellStyle = dataGridViewCellStyle1;
            this.Column3.HeaderText = "Đơn vị tính";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // Cost
            // 
            // 
            // 
            // 
            this.Cost.BackgroundStyle.BackColor = System.Drawing.SystemColors.Window;
            this.Cost.BackgroundStyle.Class = "DataGridViewNumericBorder";
            this.Cost.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.Cost.BackgroundStyle.TextColor = System.Drawing.Color.Red;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Red;
            this.Cost.DefaultCellStyle = dataGridViewCellStyle2;
            this.Cost.DisplayFormat = "###,#0";
            this.Cost.HeaderText = "Giá bán (VNĐ)";
            this.Cost.Increment = 1;
            this.Cost.MinValue = 0;
            this.Cost.Name = "Cost";
            this.Cost.ReadOnly = true;
            this.Cost.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Cost.Width = 120;
            // 
            // Image
            // 
            this.Image.HeaderText = "Hình ảnh";
            this.Image.Name = "Image";
            this.Image.ReadOnly = true;
            this.Image.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Image.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // MeterialId
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.NullValue = "Chi tiết";
            this.MeterialId.DefaultCellStyle = dataGridViewCellStyle3;
            this.MeterialId.HeaderText = "Chế biến";
            this.MeterialId.Name = "MeterialId";
            this.MeterialId.ReadOnly = true;
            this.MeterialId.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.MeterialId.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.MeterialId.Visible = false;
            // 
            // Delete
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Red;
            dataGridViewCellStyle4.NullValue = "Xoá";
            this.Delete.DefaultCellStyle = dataGridViewCellStyle4;
            this.Delete.HeaderText = "Xoá";
            this.Delete.Name = "Delete";
            this.Delete.ReadOnly = true;
            this.Delete.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Delete.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // MenuId
            // 
            this.MenuId.HeaderText = "MenuId";
            this.MenuId.Name = "MenuId";
            this.MenuId.ReadOnly = true;
            this.MenuId.Visible = false;
            // 
            // UserControlMenuList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.Controls.Add(this.txtMenuName);
            this.Controls.Add(this.splitContainer);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.btnEditFood);
            this.Controls.Add(this.btnDeleteFood);
            this.Controls.Add(this.btnAddFood);
            this.Controls.Add(this.btnGroupMenu);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "UserControlMenuList";
            this.Size = new System.Drawing.Size(1025, 582);
            this.Load += new System.EventHandler(this.UserControlMenuList_Load);
            this.splitContainer.Panel1.ResumeLayout(false);
            this.splitContainer.Panel2.ResumeLayout(false);
            this.splitContainer.ResumeLayout(false);
            this.contextMenuStrip.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMenuList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer;
        private DevComponents.DotNetBar.ButtonX btnAddFood;
        private DevComponents.DotNetBar.ButtonX btnEditFood;
        private DevComponents.DotNetBar.ButtonX btnDeleteFood;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem mnAddFoodGroupName;
        private System.Windows.Forms.ToolStripMenuItem mnEditFoodGroupName;
        private System.Windows.Forms.ToolStripMenuItem mnDeleteFoodGroup;
        private DevComponents.DotNetBar.ButtonX btnSearch;
        private DevComponents.DotNetBar.Controls.TextBoxX txtMenuName;
        private DevComponents.DotNetBar.Controls.ListViewEx listViewMenus;
        private System.Windows.Forms.ImageList imageList;
        private DevComponents.DotNetBar.ButtonX btnGroupMenu;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private DevComponents.DotNetBar.Controls.ComboTree cboMenuGroup;
        private DevComponents.DotNetBar.Controls.DataGridViewX dgvMenuList;
        private System.Windows.Forms.DataGridViewTextBoxColumn STT;
        private System.Windows.Forms.DataGridViewTextBoxColumn SubMenuGroup;
        private System.Windows.Forms.DataGridViewTextBoxColumn ItemName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private DevComponents.DotNetBar.Controls.DataGridViewDoubleInputColumn Cost;
        private System.Windows.Forms.DataGridViewImageColumn Image;
        private System.Windows.Forms.DataGridViewButtonColumn MeterialId;
        private System.Windows.Forms.DataGridViewButtonColumn Delete;
        private System.Windows.Forms.DataGridViewTextBoxColumn MenuId;

    }
}

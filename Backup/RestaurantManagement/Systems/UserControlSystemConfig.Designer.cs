namespace RestaurantManagement
{
    partial class UserControlSystemConfig
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
            this.superTabControl1 = new DevComponents.DotNetBar.SuperTabControl();
            this.panelRestaurantInfor = new DevComponents.DotNetBar.SuperTabControlPanel();
            this.superTabItemRestaurantInfor = new DevComponents.DotNetBar.SuperTabItem();
            this.superPanelRoleUser = new DevComponents.DotNetBar.SuperTabControlPanel();
            this.superTabItemRoleUser = new DevComponents.DotNetBar.SuperTabItem();
            this.panelUnitManagement = new DevComponents.DotNetBar.SuperTabControlPanel();
            this.superTabItemUnitName = new DevComponents.DotNetBar.SuperTabItem();
            this.panelLogHistories = new DevComponents.DotNetBar.SuperTabControlPanel();
            this.tabLogHistories = new DevComponents.DotNetBar.SuperTabItem();
            ((System.ComponentModel.ISupportInitialize)(this.superTabControl1)).BeginInit();
            this.superTabControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // superTabControl1
            // 
            this.superTabControl1.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            // 
            // 
            // 
            this.superTabControl1.ControlBox.CloseBox.Name = "";
            // 
            // 
            // 
            this.superTabControl1.ControlBox.MenuBox.Name = "";
            this.superTabControl1.ControlBox.Name = "";
            this.superTabControl1.ControlBox.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.superTabControl1.ControlBox.MenuBox,
            this.superTabControl1.ControlBox.CloseBox});
            this.superTabControl1.Controls.Add(this.panelLogHistories);
            this.superTabControl1.Controls.Add(this.panelRestaurantInfor);
            this.superTabControl1.Controls.Add(this.panelUnitManagement);
            this.superTabControl1.Controls.Add(this.superPanelRoleUser);
            this.superTabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.superTabControl1.ForeColor = System.Drawing.Color.Black;
            this.superTabControl1.Location = new System.Drawing.Point(0, 0);
            this.superTabControl1.Name = "superTabControl1";
            this.superTabControl1.ReorderTabsEnabled = true;
            this.superTabControl1.SelectedTabFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.superTabControl1.SelectedTabIndex = 2;
            this.superTabControl1.Size = new System.Drawing.Size(819, 585);
            this.superTabControl1.TabAlignment = DevComponents.DotNetBar.eTabStripAlignment.Left;
            this.superTabControl1.TabFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.superTabControl1.TabIndex = 0;
            this.superTabControl1.Tabs.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.superTabItemRestaurantInfor,
            this.superTabItemUnitName,
            this.superTabItemRoleUser,
            this.tabLogHistories});
            this.superTabControl1.TabStyle = DevComponents.DotNetBar.eSuperTabStyle.WinMediaPlayer12;
            this.superTabControl1.Text = "superTabControl1";
            // 
            // panelRestaurantInfor
            // 
            this.panelRestaurantInfor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelRestaurantInfor.Location = new System.Drawing.Point(154, 0);
            this.panelRestaurantInfor.Name = "panelRestaurantInfor";
            this.panelRestaurantInfor.Size = new System.Drawing.Size(665, 585);
            this.panelRestaurantInfor.TabIndex = 1;
            this.panelRestaurantInfor.TabItem = this.superTabItemRestaurantInfor;
            // 
            // superTabItemRestaurantInfor
            // 
            this.superTabItemRestaurantInfor.AttachedControl = this.panelRestaurantInfor;
            this.superTabItemRestaurantInfor.EnableMarkup = false;
            this.superTabItemRestaurantInfor.GlobalItem = false;
            this.superTabItemRestaurantInfor.Image = global::RestaurantManagement.Properties.Resources.information;
            this.superTabItemRestaurantInfor.Name = "superTabItemRestaurantInfor";
            this.superTabItemRestaurantInfor.Text = "Thông tin đơn vị";
            this.superTabItemRestaurantInfor.Click += new System.EventHandler(this.superTabItemRestaurantInfor_Click);
            // 
            // superPanelRoleUser
            // 
            this.superPanelRoleUser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.superPanelRoleUser.Location = new System.Drawing.Point(159, 0);
            this.superPanelRoleUser.Name = "superPanelRoleUser";
            this.superPanelRoleUser.Size = new System.Drawing.Size(660, 585);
            this.superPanelRoleUser.TabIndex = 3;
            this.superPanelRoleUser.TabItem = this.superTabItemRoleUser;
            this.superPanelRoleUser.Visible = false;
            // 
            // superTabItemRoleUser
            // 
            this.superTabItemRoleUser.AttachedControl = this.superPanelRoleUser;
            this.superTabItemRoleUser.GlobalItem = false;
            this.superTabItemRoleUser.Image = global::RestaurantManagement.Properties.Resources.emailcoming;
            this.superTabItemRoleUser.Name = "superTabItemRoleUser";
            this.superTabItemRoleUser.Text = "Phân quyền người dùng";
            this.superTabItemRoleUser.Click += new System.EventHandler(this.superTabItemRoleUser_Click);
            // 
            // panelUnitManagement
            // 
            this.panelUnitManagement.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelUnitManagement.Location = new System.Drawing.Point(154, 0);
            this.panelUnitManagement.Name = "panelUnitManagement";
            this.panelUnitManagement.Size = new System.Drawing.Size(665, 585);
            this.panelUnitManagement.TabIndex = 2;
            this.panelUnitManagement.TabItem = this.superTabItemUnitName;
            // 
            // superTabItemUnitName
            // 
            this.superTabItemUnitName.AttachedControl = this.panelUnitManagement;
            this.superTabItemUnitName.GlobalItem = false;
            this.superTabItemUnitName.Image = global::RestaurantManagement.Properties.Resources.ftp_server_check;
            this.superTabItemUnitName.Name = "superTabItemUnitName";
            this.superTabItemUnitName.Text = "Đơn vị tính";
            this.superTabItemUnitName.Click += new System.EventHandler(this.superTabItemUnitName_Click);
            // 
            // panelLogHistories
            // 
            this.panelLogHistories.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelLogHistories.Location = new System.Drawing.Point(154, 0);
            this.panelLogHistories.Name = "panelLogHistories";
            this.panelLogHistories.Size = new System.Drawing.Size(665, 585);
            this.panelLogHistories.TabIndex = 4;
            this.panelLogHistories.TabItem = this.tabLogHistories;
            // 
            // tabLogHistories
            // 
            this.tabLogHistories.AttachedControl = this.panelLogHistories;
            this.tabLogHistories.GlobalItem = false;
            this.tabLogHistories.Image = global::RestaurantManagement.Properties.Resources._1369428042_check_all_delete;
            this.tabLogHistories.Name = "tabLogHistories";
            this.tabLogHistories.Text = "Lịch sử người dùng";
            this.tabLogHistories.Click += new System.EventHandler(this.tabLogHistories_Click);
            // 
            // UserControlSystemConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.superTabControl1);
            this.Name = "UserControlSystemConfig";
            this.Size = new System.Drawing.Size(819, 585);
            this.Load += new System.EventHandler(this.UserControlSystemConfig_Load);
            ((System.ComponentModel.ISupportInitialize)(this.superTabControl1)).EndInit();
            this.superTabControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.SuperTabControl superTabControl1;
        private DevComponents.DotNetBar.SuperTabControlPanel panelRestaurantInfor;
        private DevComponents.DotNetBar.SuperTabItem superTabItemRestaurantInfor;
        private DevComponents.DotNetBar.SuperTabControlPanel superPanelRoleUser;
        private DevComponents.DotNetBar.SuperTabItem superTabItemRoleUser;
        private DevComponents.DotNetBar.SuperTabControlPanel panelUnitManagement;
        private DevComponents.DotNetBar.SuperTabItem superTabItemUnitName;
        private DevComponents.DotNetBar.SuperTabControlPanel panelLogHistories;
        private DevComponents.DotNetBar.SuperTabItem tabLogHistories;
    }
}

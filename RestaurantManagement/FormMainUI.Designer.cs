namespace RestaurantManagement
{
    partial class FormMainUI
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMainUI));
            this.metroShell = new DevComponents.DotNetBar.Metro.MetroShell();
            this.metroTabPanel4 = new DevComponents.DotNetBar.Metro.MetroTabPanel();
            this.metroTabPanel1 = new DevComponents.DotNetBar.Metro.MetroTabPanel();
            this.metroTabPanel7 = new DevComponents.DotNetBar.Metro.MetroTabPanel();
            this.metroTabPanel5 = new DevComponents.DotNetBar.Metro.MetroTabPanel();
            this.metroTabPanel2 = new DevComponents.DotNetBar.Metro.MetroTabPanel();
            this.metroAppButtonSystem = new DevComponents.DotNetBar.Metro.MetroAppButton();
            this.mnServices = new DevComponents.DotNetBar.Metro.MetroTabItem();
            this.mnMenus = new DevComponents.DotNetBar.Metro.MetroTabItem();
            this.mnStock = new DevComponents.DotNetBar.Metro.MetroTabItem();
            this.mnBills = new DevComponents.DotNetBar.Metro.MetroTabItem();
            this.mnReport = new DevComponents.DotNetBar.Metro.MetroTabItem();
            this.mnCustomer = new DevComponents.DotNetBar.Metro.MetroTabItem();
            this.mnStaff = new DevComponents.DotNetBar.Metro.MetroTabItem();
            this.btnHelp = new DevComponents.DotNetBar.ButtonItem();
            this.btnRegister = new DevComponents.DotNetBar.ButtonItem();
            this.buttonItem1 = new DevComponents.DotNetBar.ButtonItem();
            this.styleManager1 = new DevComponents.DotNetBar.StyleManager(this.components);
            this.metroStatusBar1 = new DevComponents.DotNetBar.Metro.MetroStatusBar();
            this.labelItem1 = new DevComponents.DotNetBar.LabelItem();
            this.lbUserName = new DevComponents.DotNetBar.LabelItem();
            this.labelItem2 = new DevComponents.DotNetBar.LabelItem();
            this.lbFullName = new DevComponents.DotNetBar.LabelItem();
            this.lbRole = new DevComponents.DotNetBar.LabelItem();
            this.panelExMainUI = new DevComponents.DotNetBar.PanelEx();
            this.backgroundWorkerLoadService = new System.ComponentModel.BackgroundWorker();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.btnLogOut = new DevComponents.DotNetBar.ButtonX();
            this.btnSystemConfig = new DevComponents.DotNetBar.ButtonX();
            this.btnChangePassword = new DevComponents.DotNetBar.ButtonX();
            this.metroAppButton1 = new DevComponents.DotNetBar.Metro.MetroAppButton();
            this.backgroundWorkerRestaurantInfor = new System.ComponentModel.BackgroundWorker();
            this.metroShell.SuspendLayout();
            this.SuspendLayout();
            // 
            // metroShell
            // 
            this.metroShell.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.metroShell.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.metroShell.CaptionFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.metroShell.CaptionVisible = true;
            this.metroShell.Controls.Add(this.metroTabPanel5);
            this.metroShell.Controls.Add(this.metroTabPanel4);
            this.metroShell.Controls.Add(this.metroTabPanel2);
            this.metroShell.Controls.Add(this.metroTabPanel1);
            this.metroShell.Controls.Add(this.metroTabPanel7);
            this.metroShell.Dock = System.Windows.Forms.DockStyle.Top;
            this.metroShell.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.metroShell.ForeColor = System.Drawing.Color.Black;
            this.metroShell.HelpButtonText = "THOÁT";
            this.metroShell.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.metroAppButtonSystem,
            this.mnServices,
            this.mnMenus,
            this.mnStock,
            this.mnBills,
            this.mnReport,
            this.mnCustomer,
            this.mnStaff});
            this.metroShell.KeyTipsFont = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.metroShell.Location = new System.Drawing.Point(1, 1);
            this.metroShell.Name = "metroShell";
            this.metroShell.QuickToolbarItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.btnHelp,
            this.buttonItem1});
            this.metroShell.SettingsButtonText = "CÀI ĐẶT DATABASE";
            this.metroShell.Size = new System.Drawing.Size(1043, 55);
            this.metroShell.SystemText.MaximizeRibbonText = "&Maximize the Ribbon";
            this.metroShell.SystemText.MinimizeRibbonText = "Mi&nimize the Ribbon";
            this.metroShell.SystemText.QatAddItemText = "&Add to Quick Access Toolbar";
            this.metroShell.SystemText.QatCustomizeMenuLabel = "<b>Customize Quick Access Toolbar</b>";
            this.metroShell.SystemText.QatCustomizeText = "&Customize Quick Access Toolbar...";
            this.metroShell.SystemText.QatDialogAddButton = "&Add >>";
            this.metroShell.SystemText.QatDialogCancelButton = "Cancel";
            this.metroShell.SystemText.QatDialogCaption = "Customize Quick Access Toolbar";
            this.metroShell.SystemText.QatDialogCategoriesLabel = "&Choose commands from:";
            this.metroShell.SystemText.QatDialogOkButton = "OK";
            this.metroShell.SystemText.QatDialogPlacementCheckbox = "&Place Quick Access Toolbar below the Ribbon";
            this.metroShell.SystemText.QatDialogRemoveButton = "&Remove";
            this.metroShell.SystemText.QatPlaceAboveRibbonText = "&Place Quick Access Toolbar above the Ribbon";
            this.metroShell.SystemText.QatPlaceBelowRibbonText = "&Place Quick Access Toolbar below the Ribbon";
            this.metroShell.SystemText.QatRemoveItemText = "&Remove from Quick Access Toolbar";
            this.metroShell.TabIndex = 0;
            this.metroShell.TabStripFont = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.metroShell.Text = "Phần mềm quản lý nhà hàng, quán cafe quán bar";
            this.metroShell.SettingsButtonClick += new System.EventHandler(this.metroShell1_SettingsButtonClick);
            this.metroShell.HelpButtonClick += new System.EventHandler(this.metroShell1_HelpButtonClick);
            // 
            // metroTabPanel4
            // 
            this.metroTabPanel4.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Windows7;
            this.metroTabPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.metroTabPanel4.Location = new System.Drawing.Point(0, 48);
            this.metroTabPanel4.Name = "metroTabPanel4";
            this.metroTabPanel4.Padding = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.metroTabPanel4.Size = new System.Drawing.Size(1043, 7);
            // 
            // 
            // 
            this.metroTabPanel4.Style.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.metroTabPanel4.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.metroTabPanel4.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.metroTabPanel4.TabIndex = 4;
            this.metroTabPanel4.Visible = false;
            // 
            // metroTabPanel1
            // 
            this.metroTabPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.metroTabPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.metroTabPanel1.Location = new System.Drawing.Point(0, 48);
            this.metroTabPanel1.Name = "metroTabPanel1";
            this.metroTabPanel1.Padding = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.metroTabPanel1.Size = new System.Drawing.Size(1043, 7);
            // 
            // 
            // 
            this.metroTabPanel1.Style.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.metroTabPanel1.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.metroTabPanel1.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.metroTabPanel1.TabIndex = 1;
            this.metroTabPanel1.Visible = false;
            // 
            // metroTabPanel7
            // 
            this.metroTabPanel7.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.metroTabPanel7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.metroTabPanel7.Location = new System.Drawing.Point(0, 48);
            this.metroTabPanel7.Name = "metroTabPanel7";
            this.metroTabPanel7.Padding = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.metroTabPanel7.Size = new System.Drawing.Size(1044, 7);
            // 
            // 
            // 
            this.metroTabPanel7.Style.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.metroTabPanel7.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.metroTabPanel7.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.metroTabPanel7.TabIndex = 7;
            this.metroTabPanel7.Visible = false;
            // 
            // metroTabPanel5
            // 
            this.metroTabPanel5.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.metroTabPanel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.metroTabPanel5.Location = new System.Drawing.Point(0, 48);
            this.metroTabPanel5.Name = "metroTabPanel5";
            this.metroTabPanel5.Padding = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.metroTabPanel5.Size = new System.Drawing.Size(1043, 7);
            // 
            // 
            // 
            this.metroTabPanel5.Style.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.metroTabPanel5.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.metroTabPanel5.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.metroTabPanel5.TabIndex = 5;
            // 
            // metroTabPanel2
            // 
            this.metroTabPanel2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.metroTabPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.metroTabPanel2.Location = new System.Drawing.Point(0, 48);
            this.metroTabPanel2.Name = "metroTabPanel2";
            this.metroTabPanel2.Padding = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.metroTabPanel2.Size = new System.Drawing.Size(1043, 7);
            // 
            // 
            // 
            this.metroTabPanel2.Style.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.metroTabPanel2.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.metroTabPanel2.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.metroTabPanel2.TabIndex = 2;
            this.metroTabPanel2.Visible = false;
            // 
            // metroAppButtonSystem
            // 
            this.metroAppButtonSystem.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.TextOnlyAlways;
            this.metroAppButtonSystem.ColorTable = DevComponents.DotNetBar.eButtonColor.BlueWithBackground;
            this.metroAppButtonSystem.ImageFixedSize = new System.Drawing.Size(20, 16);
            this.metroAppButtonSystem.ImagePaddingHorizontal = 0;
            this.metroAppButtonSystem.ImagePaddingVertical = 0;
            this.metroAppButtonSystem.Name = "metroAppButtonSystem";
            this.metroAppButtonSystem.ShowSubItems = false;
            this.metroAppButtonSystem.Text = "HỆ THỐNG";
            this.metroAppButtonSystem.Tooltip = "Ctrl+0";
            this.metroAppButtonSystem.Click += new System.EventHandler(this.metroAppButtonSystem_Click);
            // 
            // mnServices
            // 
            this.mnServices.Name = "mnServices";
            this.mnServices.Panel = this.metroTabPanel1;
            this.mnServices.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.Ctrl1);
            this.mnServices.Text = "PHỤC VỤ";
            this.mnServices.Tooltip = "Ctrl+1";
            this.mnServices.Click += new System.EventHandler(this.mnServices_Click);
            // 
            // mnMenus
            // 
            this.mnMenus.Name = "mnMenus";
            this.mnMenus.Panel = this.metroTabPanel2;
            this.mnMenus.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.Ctrl2);
            this.mnMenus.Text = "THỰC ĐƠN";
            this.mnMenus.Tooltip = "Ctrl+2";
            this.mnMenus.Click += new System.EventHandler(this.mnMenus_Click);
            // 
            // mnStock
            // 
            this.mnStock.Name = "mnStock";
            this.mnStock.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.Ctrl3);
            this.mnStock.Text = "KHO HÀNG";
            this.mnStock.Tooltip = "Ctrl+3";
            this.mnStock.Click += new System.EventHandler(this.mnStock_Click);
            // 
            // mnBills
            // 
            this.mnBills.Name = "mnBills";
            this.mnBills.Panel = this.metroTabPanel4;
            this.mnBills.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.Ctrl4);
            this.mnBills.Text = "HOÁ ĐƠN";
            this.mnBills.Tooltip = "Ctrl+4";
            this.mnBills.Click += new System.EventHandler(this.mnBills_Click);
            // 
            // mnReport
            // 
            this.mnReport.Checked = true;
            this.mnReport.Name = "mnReport";
            this.mnReport.Panel = this.metroTabPanel5;
            this.mnReport.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.Ctrl5);
            this.mnReport.Text = "BÁO CÁO";
            this.mnReport.Tooltip = "Ctrl+5";
            this.mnReport.Click += new System.EventHandler(this.mnReport_Click);
            // 
            // mnCustomer
            // 
            this.mnCustomer.Name = "mnCustomer";
            this.mnCustomer.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.Ctrl6);
            this.mnCustomer.Text = "KHÁCH HÀNG";
            this.mnCustomer.Tooltip = "Ctrl+6";
            this.mnCustomer.Click += new System.EventHandler(this.mnCustomer_Click);
            // 
            // mnStaff
            // 
            this.mnStaff.Name = "mnStaff";
            this.mnStaff.Panel = this.metroTabPanel7;
            this.mnStaff.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.Ctrl7);
            this.mnStaff.Text = "NHÂN VIÊN";
            this.mnStaff.Tooltip = "Ctrl+7";
            this.mnStaff.Click += new System.EventHandler(this.mnStaff_Click);
            // 
            // btnHelp
            // 
            this.btnHelp.ImageSmall = global::RestaurantManagement.Properties.Resources.checkout;
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.btnRegister});
            this.btnHelp.Text = "Trợ giúp";
            this.btnHelp.Click += new System.EventHandler(this.btnHelp_Click);
            // 
            // btnRegister
            // 
            this.btnRegister.Image = global::RestaurantManagement.Properties.Resources.emailcoming;
            this.btnRegister.Name = "btnRegister";
            this.btnRegister.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor(11, 0, 2, 11);
            this.btnRegister.Text = "Thông tin đăng ký";
            this.btnRegister.Click += new System.EventHandler(this.btnRegister_Click);
            // 
            // buttonItem1
            // 
            this.buttonItem1.Name = "buttonItem1";
            this.buttonItem1.Visible = false;
            // 
            // styleManager1
            // 
            this.styleManager1.ManagerStyle = DevComponents.DotNetBar.eStyle.Metro;
            this.styleManager1.MetroColorParameters = new DevComponents.DotNetBar.Metro.ColorTables.MetroColorGeneratorParameters(System.Drawing.Color.White, System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(163)))), ((int)(((byte)(26))))));
            // 
            // metroStatusBar1
            // 
            this.metroStatusBar1.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.metroStatusBar1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.metroStatusBar1.ContainerControlProcessDialogKey = true;
            this.metroStatusBar1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.metroStatusBar1.DragDropSupport = true;
            this.metroStatusBar1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.World, ((byte)(0)));
            this.metroStatusBar1.ForeColor = System.Drawing.Color.Black;
            this.metroStatusBar1.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.labelItem1,
            this.lbUserName,
            this.labelItem2,
            this.lbFullName,
            this.lbRole});
            this.metroStatusBar1.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F";
            this.metroStatusBar1.Location = new System.Drawing.Point(1, 599);
            this.metroStatusBar1.Name = "metroStatusBar1";
            this.metroStatusBar1.Size = new System.Drawing.Size(1043, 21);
            this.metroStatusBar1.TabIndex = 1;
            // 
            // labelItem1
            // 
            this.labelItem1.Name = "labelItem1";
            this.labelItem1.Text = "READY";
            // 
            // lbUserName
            // 
            this.lbUserName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbUserName.Name = "lbUserName";
            this.lbUserName.Text = "...";
            // 
            // labelItem2
            // 
            this.labelItem2.Name = "labelItem2";
            // 
            // lbFullName
            // 
            this.lbFullName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbFullName.Name = "lbFullName";
            this.lbFullName.Text = "...";
            // 
            // lbRole
            // 
            this.lbRole.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbRole.Name = "lbRole";
            this.lbRole.Text = "...";
            // 
            // panelExMainUI
            // 
            this.panelExMainUI.AutoSize = true;
            this.panelExMainUI.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panelExMainUI.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panelExMainUI.CanvasColor = System.Drawing.SystemColors.ControlLightLight;
            this.panelExMainUI.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2013;
            this.panelExMainUI.DisabledBackColor = System.Drawing.Color.Empty;
            this.panelExMainUI.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelExMainUI.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panelExMainUI.Location = new System.Drawing.Point(1, 56);
            this.panelExMainUI.Name = "panelExMainUI";
            this.panelExMainUI.Size = new System.Drawing.Size(1043, 543);
            this.panelExMainUI.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelExMainUI.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.panelExMainUI.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelExMainUI.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText;
            this.panelExMainUI.Style.GradientAngle = 90;
            this.panelExMainUI.StyleMouseDown.Alignment = System.Drawing.StringAlignment.Center;
            this.panelExMainUI.StyleMouseDown.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemPressedBackground;
            this.panelExMainUI.StyleMouseDown.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemPressedBorder;
            this.panelExMainUI.StyleMouseDown.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemPressedText;
            this.panelExMainUI.StyleMouseOver.Alignment = System.Drawing.StringAlignment.Center;
            this.panelExMainUI.StyleMouseOver.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemHotBackground;
            this.panelExMainUI.StyleMouseOver.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemHotBorder;
            this.panelExMainUI.StyleMouseOver.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemHotText;
            this.panelExMainUI.TabIndex = 2;
            // 
            // backgroundWorkerLoadService
            // 
            this.backgroundWorkerLoadService.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerLoadService_DoWork);
            this.backgroundWorkerLoadService.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorkerLoadService_RunWorkerCompleted);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "door-open-in.png");
            this.imageList1.Images.SetKeyName(1, "emailcoming.jpg");
            this.imageList1.Images.SetKeyName(2, "Exit.png");
            this.imageList1.Images.SetKeyName(3, "lock-unlock_blue.png");
            this.imageList1.Images.SetKeyName(4, "User.png");
            this.imageList1.Images.SetKeyName(5, "user-group-icon.png");
            // 
            // btnLogOut
            // 
            this.btnLogOut.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnLogOut.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLogOut.ColorTable = DevComponents.DotNetBar.eButtonColor.Orange;
            this.btnLogOut.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogOut.Location = new System.Drawing.Point(938, 30);
            this.btnLogOut.Name = "btnLogOut";
            this.btnLogOut.Size = new System.Drawing.Size(78, 20);
            this.btnLogOut.Style = DevComponents.DotNetBar.eDotNetBarStyle.Windows7;
            this.btnLogOut.TabIndex = 8;
            this.btnLogOut.Text = "ĐĂNG XUẤT";
            this.btnLogOut.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // btnSystemConfig
            // 
            this.btnSystemConfig.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSystemConfig.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSystemConfig.ColorTable = DevComponents.DotNetBar.eButtonColor.Orange;
            this.btnSystemConfig.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSystemConfig.Location = new System.Drawing.Point(691, 30);
            this.btnSystemConfig.Name = "btnSystemConfig";
            this.btnSystemConfig.Size = new System.Drawing.Size(139, 20);
            this.btnSystemConfig.Style = DevComponents.DotNetBar.eDotNetBarStyle.Windows7;
            this.btnSystemConfig.TabIndex = 8;
            this.btnSystemConfig.Text = "CẤU HÌNH HỆ THỐNG";
            this.btnSystemConfig.Click += new System.EventHandler(this.btnSystemConfig_Click);
            // 
            // btnChangePassword
            // 
            this.btnChangePassword.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnChangePassword.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnChangePassword.ColorTable = DevComponents.DotNetBar.eButtonColor.Orange;
            this.btnChangePassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnChangePassword.Location = new System.Drawing.Point(836, 30);
            this.btnChangePassword.Name = "btnChangePassword";
            this.btnChangePassword.Size = new System.Drawing.Size(96, 20);
            this.btnChangePassword.Style = DevComponents.DotNetBar.eDotNetBarStyle.Windows7;
            this.btnChangePassword.TabIndex = 8;
            this.btnChangePassword.Text = "ĐỔI MẬT KHẨU";
            this.btnChangePassword.Click += new System.EventHandler(this.btnChangePassword_Click);
            // 
            // metroAppButton1
            // 
            this.metroAppButton1.AutoExpandOnClick = true;
            this.metroAppButton1.CanCustomize = false;
            this.metroAppButton1.ImageFixedSize = new System.Drawing.Size(16, 16);
            this.metroAppButton1.ImagePaddingHorizontal = 0;
            this.metroAppButton1.ImagePaddingVertical = 0;
            this.metroAppButton1.Name = "metroAppButton1";
            this.metroAppButton1.ShowSubItems = false;
            this.metroAppButton1.Text = "&File";
            // 
            // backgroundWorkerRestaurantInfor
            // 
            this.backgroundWorkerRestaurantInfor.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerRestaurantInfor_DoWork);
            this.backgroundWorkerRestaurantInfor.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorkerRestaurantInfor_RunWorkerCompleted);
            // 
            // FormMainUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1045, 621);
            this.Controls.Add(this.btnChangePassword);
            this.Controls.Add(this.btnSystemConfig);
            this.Controls.Add(this.btnLogOut);
            this.Controls.Add(this.panelExMainUI);
            this.Controls.Add(this.metroStatusBar1);
            this.Controls.Add(this.metroShell);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormMainUI";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Phần mềm quản lý nhà hàng, quán bar cafe";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FormMainUI_Load);
            this.metroShell.ResumeLayout(false);
            this.metroShell.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevComponents.DotNetBar.Metro.MetroShell metroShell;
        private DevComponents.DotNetBar.Metro.MetroTabPanel metroTabPanel2;
        private DevComponents.DotNetBar.Metro.MetroAppButton metroAppButtonSystem;
        private DevComponents.DotNetBar.Metro.MetroTabItem mnServices;
        private DevComponents.DotNetBar.Metro.MetroTabItem mnMenus;
        private DevComponents.DotNetBar.ButtonItem buttonItem1;
        private DevComponents.DotNetBar.StyleManager styleManager1;
        private DevComponents.DotNetBar.Metro.MetroStatusBar metroStatusBar1;
        private DevComponents.DotNetBar.LabelItem labelItem1;
        private DevComponents.DotNetBar.Metro.MetroTabPanel metroTabPanel4;
        private DevComponents.DotNetBar.Metro.MetroTabPanel metroTabPanel5;
        private DevComponents.DotNetBar.Metro.MetroTabItem mnStock;
        private DevComponents.DotNetBar.Metro.MetroTabItem mnBills;
        private DevComponents.DotNetBar.Metro.MetroTabItem mnReport;
        private DevComponents.DotNetBar.PanelEx panelExMainUI;
        private DevComponents.DotNetBar.Metro.MetroTabItem mnCustomer;
        private DevComponents.DotNetBar.Metro.MetroTabItem mnStaff;
        private System.ComponentModel.BackgroundWorker backgroundWorkerLoadService;
        private System.Windows.Forms.ImageList imageList1;
        private DevComponents.DotNetBar.LabelItem lbUserName;
        private DevComponents.DotNetBar.LabelItem labelItem2;
        private DevComponents.DotNetBar.LabelItem lbFullName;
        private DevComponents.DotNetBar.LabelItem lbRole;
        private DevComponents.DotNetBar.Metro.MetroTabPanel metroTabPanel7;
        private DevComponents.DotNetBar.Metro.MetroTabPanel metroTabPanel1;
        private DevComponents.DotNetBar.ButtonX btnLogOut;
        private DevComponents.DotNetBar.ButtonX btnSystemConfig;
        private DevComponents.DotNetBar.ButtonX btnChangePassword;
        private DevComponents.DotNetBar.Metro.MetroAppButton metroAppButton1;
        private DevComponents.DotNetBar.ButtonItem btnHelp;
        private DevComponents.DotNetBar.ButtonItem btnRegister;
        private System.ComponentModel.BackgroundWorker backgroundWorkerRestaurantInfor;

    }
}


namespace RestaurantManagement
{
    partial class ConnectionManagement
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConnectionManagement));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtPortName = new DevComponents.Editors.IntegerInput();
            this.chkIntegratedSecurity = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.chkSa = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.labelX4 = new DevComponents.DotNetBar.LabelX();
            this.labelX5 = new DevComponents.DotNetBar.LabelX();
            this.labelX3 = new DevComponents.DotNetBar.LabelX();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.txtPassword = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.txtUserName = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.txtDatabaseName = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.txtServerName = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.btnAceept = new DevComponents.DotNetBar.ButtonX();
            this.btnExit = new DevComponents.DotNetBar.ButtonX();
            this.btnDefault = new DevComponents.DotNetBar.ButtonX();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtPortName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.White;
            this.groupBox1.Controls.Add(this.txtPortName);
            this.groupBox1.Controls.Add(this.chkIntegratedSecurity);
            this.groupBox1.Controls.Add(this.chkSa);
            this.groupBox1.Controls.Add(this.labelX4);
            this.groupBox1.Controls.Add(this.labelX5);
            this.groupBox1.Controls.Add(this.labelX3);
            this.groupBox1.Controls.Add(this.labelX2);
            this.groupBox1.Controls.Add(this.labelX1);
            this.groupBox1.Controls.Add(this.txtPassword);
            this.groupBox1.Controls.Add(this.txtUserName);
            this.groupBox1.Controls.Add(this.txtDatabaseName);
            this.groupBox1.Controls.Add(this.txtServerName);
            this.groupBox1.Controls.Add(this.pictureBox);
            this.groupBox1.ForeColor = System.Drawing.Color.Black;
            this.groupBox1.Location = new System.Drawing.Point(12, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(437, 205);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông tin kết nối";
            // 
            // txtPortName
            // 
            this.txtPortName.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtPortName.BackgroundStyle.Class = "DateTimeInputBackground";
            this.txtPortName.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtPortName.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.txtPortName.ForeColor = System.Drawing.Color.Black;
            this.txtPortName.Location = new System.Drawing.Point(225, 126);
            this.txtPortName.Name = "txtPortName";
            this.txtPortName.Size = new System.Drawing.Size(80, 20);
            this.txtPortName.TabIndex = 4;
            this.txtPortName.WatermarkText = "Nhập số";
            // 
            // chkIntegratedSecurity
            // 
            this.chkIntegratedSecurity.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.chkIntegratedSecurity.BackgroundStyle.Class = "";
            this.chkIntegratedSecurity.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.chkIntegratedSecurity.ForeColor = System.Drawing.Color.Black;
            this.chkIntegratedSecurity.Location = new System.Drawing.Point(225, 72);
            this.chkIntegratedSecurity.Name = "chkIntegratedSecurity";
            this.chkIntegratedSecurity.Size = new System.Drawing.Size(132, 23);
            this.chkIntegratedSecurity.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.chkIntegratedSecurity.TabIndex = 2;
            this.chkIntegratedSecurity.Text = "Integrated Security ";
            this.chkIntegratedSecurity.CheckedChanged += new System.EventHandler(this.chkSa_CheckedChanged);
            // 
            // chkSa
            // 
            this.chkSa.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.chkSa.BackgroundStyle.Class = "";
            this.chkSa.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.chkSa.ForeColor = System.Drawing.Color.Black;
            this.chkSa.Location = new System.Drawing.Point(225, 100);
            this.chkSa.Name = "chkSa";
            this.chkSa.Size = new System.Drawing.Size(132, 23);
            this.chkSa.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.chkSa.TabIndex = 3;
            this.chkSa.Text = "Kết nối qua mạng";
            this.chkSa.CheckedChanged += new System.EventHandler(this.chkSa_CheckedChanged);
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
            this.labelX4.Location = new System.Drawing.Point(144, 175);
            this.labelX4.Name = "labelX4";
            this.labelX4.Size = new System.Drawing.Size(65, 23);
            this.labelX4.TabIndex = 2;
            this.labelX4.Text = "Mật khẩu";
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
            this.labelX5.Location = new System.Drawing.Point(144, 124);
            this.labelX5.Name = "labelX5";
            this.labelX5.Size = new System.Drawing.Size(65, 23);
            this.labelX5.TabIndex = 2;
            this.labelX5.Text = "Cổng kết nối";
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
            this.labelX3.Location = new System.Drawing.Point(144, 151);
            this.labelX3.Name = "labelX3";
            this.labelX3.Size = new System.Drawing.Size(65, 23);
            this.labelX3.TabIndex = 2;
            this.labelX3.Text = "Tài khoản";
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
            this.labelX2.Location = new System.Drawing.Point(144, 45);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(65, 23);
            this.labelX2.TabIndex = 2;
            this.labelX2.Text = "Database";
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
            this.labelX1.Location = new System.Drawing.Point(144, 19);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(75, 23);
            this.labelX1.TabIndex = 2;
            this.labelX1.Text = "Tên máy chủ";
            // 
            // txtPassword
            // 
            this.txtPassword.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtPassword.Border.Class = "TextBoxBorder";
            this.txtPassword.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtPassword.ForeColor = System.Drawing.Color.Black;
            this.txtPassword.Location = new System.Drawing.Point(225, 178);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '$';
            this.txtPassword.Size = new System.Drawing.Size(206, 20);
            this.txtPassword.TabIndex = 6;
            this.txtPassword.WatermarkText = "Mật khẩu kết nối qua mạng";
            // 
            // txtUserName
            // 
            this.txtUserName.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtUserName.Border.Class = "TextBoxBorder";
            this.txtUserName.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtUserName.ForeColor = System.Drawing.Color.Black;
            this.txtUserName.Location = new System.Drawing.Point(225, 152);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(206, 20);
            this.txtUserName.TabIndex = 5;
            this.txtUserName.WatermarkText = "Tài khoản sa kết nối qua mạng";
            // 
            // txtDatabaseName
            // 
            this.txtDatabaseName.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtDatabaseName.Border.Class = "TextBoxBorder";
            this.txtDatabaseName.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtDatabaseName.ForeColor = System.Drawing.Color.Black;
            this.txtDatabaseName.Location = new System.Drawing.Point(225, 46);
            this.txtDatabaseName.Name = "txtDatabaseName";
            this.txtDatabaseName.Size = new System.Drawing.Size(206, 20);
            this.txtDatabaseName.TabIndex = 1;
            this.txtDatabaseName.WatermarkText = "Tên cơ sở dữ liệu trên máy chủ";
            // 
            // txtServerName
            // 
            this.txtServerName.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtServerName.Border.Class = "TextBoxBorder";
            this.txtServerName.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtServerName.ForeColor = System.Drawing.Color.Black;
            this.txtServerName.Location = new System.Drawing.Point(225, 19);
            this.txtServerName.Name = "txtServerName";
            this.txtServerName.Size = new System.Drawing.Size(206, 20);
            this.txtServerName.TabIndex = 0;
            this.txtServerName.WatermarkText = "Tên máy chủ chứa cơ sở dữ liệu";
            // 
            // pictureBox
            // 
            this.pictureBox.BackColor = System.Drawing.Color.White;
            this.pictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox.ForeColor = System.Drawing.Color.Black;
            this.pictureBox.Image = global::RestaurantManagement.Properties.Resources.update_apple;
            this.pictureBox.Location = new System.Drawing.Point(6, 19);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(132, 127);
            this.pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox.TabIndex = 0;
            this.pictureBox.TabStop = false;
            // 
            // btnAceept
            // 
            this.btnAceept.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnAceept.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAceept.Location = new System.Drawing.Point(193, 214);
            this.btnAceept.Name = "btnAceept";
            this.btnAceept.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.CtrlS);
            this.btnAceept.Size = new System.Drawing.Size(75, 23);
            this.btnAceept.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnAceept.TabIndex = 7;
            this.btnAceept.Text = "Đồng ý";
            this.btnAceept.Click += new System.EventHandler(this.btnAceept_Click);
            // 
            // btnExit
            // 
            this.btnExit.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.Location = new System.Drawing.Point(274, 214);
            this.btnExit.Name = "btnExit";
            this.btnExit.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.CtrlD);
            this.btnExit.Size = new System.Drawing.Size(75, 23);
            this.btnExit.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnExit.TabIndex = 8;
            this.btnExit.Text = "Thoát";
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnDefault
            // 
            this.btnDefault.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnDefault.Location = new System.Drawing.Point(112, 214);
            this.btnDefault.Name = "btnDefault";
            this.btnDefault.Size = new System.Drawing.Size(75, 23);
            this.btnDefault.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnDefault.TabIndex = 9;
            this.btnDefault.Text = "Mặc định";
            this.btnDefault.Click += new System.EventHandler(this.btnDefault_Click);
            // 
            // ConnectionManagement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(461, 243);
            this.Controls.Add(this.btnDefault);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnAceept);
            this.Controls.Add(this.groupBox1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "ConnectionManagement";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Kết nối cơ sở dữ liệu";
            this.Load += new System.EventHandler(this.ConnectionManagement_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtPortName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.GroupBox groupBox1;
        private DevComponents.DotNetBar.ButtonX btnAceept;
        private DevComponents.DotNetBar.ButtonX btnExit;
        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.DotNetBar.Controls.TextBoxX txtServerName;
        private DevComponents.DotNetBar.LabelX labelX4;
        private DevComponents.DotNetBar.LabelX labelX3;
        private DevComponents.DotNetBar.LabelX labelX2;
        private DevComponents.DotNetBar.Controls.TextBoxX txtUserName;
        private DevComponents.DotNetBar.Controls.TextBoxX txtDatabaseName;
        private DevComponents.DotNetBar.Controls.TextBoxX txtPassword;
        private DevComponents.DotNetBar.Controls.CheckBoxX chkSa;
        private DevComponents.DotNetBar.ButtonX btnDefault;
        private DevComponents.Editors.IntegerInput txtPortName;
        private DevComponents.DotNetBar.LabelX labelX5;
        private DevComponents.DotNetBar.Controls.CheckBoxX chkIntegratedSecurity;
    }
}
namespace RestaurantManagement
{
    partial class EditTableName
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditTableName));
            this.btnChangedName = new DevComponents.DotNetBar.ButtonX();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.txtOldTableName = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.txtNewTableName = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.btnExit = new DevComponents.DotNetBar.ButtonX();
            this.labelX3 = new DevComponents.DotNetBar.LabelX();
            this.txtChairNumber = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.SuspendLayout();
            // 
            // btnChangedName
            // 
            this.btnChangedName.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnChangedName.Location = new System.Drawing.Point(56, 90);
            this.btnChangedName.Name = "btnChangedName";
            this.btnChangedName.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.CtrlS);
            this.btnChangedName.Size = new System.Drawing.Size(75, 23);
            this.btnChangedName.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnChangedName.TabIndex = 3;
            this.btnChangedName.Text = "Đổi tên";
            this.btnChangedName.Click += new System.EventHandler(this.btnChangedName_Click);
            // 
            // labelX1
            // 
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.Class = "";
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Location = new System.Drawing.Point(12, 12);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(75, 23);
            this.labelX1.TabIndex = 1;
            this.labelX1.Text = "Tên cũ";
            // 
            // txtOldTableName
            // 
            this.txtOldTableName.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtOldTableName.Border.Class = "TextBoxBorder";
            this.txtOldTableName.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtOldTableName.ForeColor = System.Drawing.Color.Black;
            this.txtOldTableName.Location = new System.Drawing.Point(57, 12);
            this.txtOldTableName.Name = "txtOldTableName";
            this.txtOldTableName.ReadOnly = true;
            this.txtOldTableName.Size = new System.Drawing.Size(202, 20);
            this.txtOldTableName.TabIndex = 0;
            // 
            // labelX2
            // 
            // 
            // 
            // 
            this.labelX2.BackgroundStyle.Class = "";
            this.labelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX2.Location = new System.Drawing.Point(12, 37);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(75, 23);
            this.labelX2.TabIndex = 1;
            this.labelX2.Text = "Tên mới";
            // 
            // txtNewTableName
            // 
            this.txtNewTableName.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtNewTableName.Border.Class = "TextBoxBorder";
            this.txtNewTableName.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtNewTableName.ForeColor = System.Drawing.Color.Black;
            this.txtNewTableName.Location = new System.Drawing.Point(57, 37);
            this.txtNewTableName.Name = "txtNewTableName";
            this.txtNewTableName.Size = new System.Drawing.Size(202, 20);
            this.txtNewTableName.TabIndex = 1;
            // 
            // btnExit
            // 
            this.btnExit.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnExit.Location = new System.Drawing.Point(139, 90);
            this.btnExit.Name = "btnExit";
            this.btnExit.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.CtrlD);
            this.btnExit.Size = new System.Drawing.Size(75, 23);
            this.btnExit.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnExit.TabIndex = 4;
            this.btnExit.Text = "Đóng";
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // labelX3
            // 
            // 
            // 
            // 
            this.labelX3.BackgroundStyle.Class = "";
            this.labelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX3.Location = new System.Drawing.Point(12, 63);
            this.labelX3.Name = "labelX3";
            this.labelX3.Size = new System.Drawing.Size(39, 23);
            this.labelX3.TabIndex = 1;
            this.labelX3.Text = "Số ghế";
            // 
            // txtChairNumber
            // 
            this.txtChairNumber.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtChairNumber.Border.Class = "TextBoxBorder";
            this.txtChairNumber.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtChairNumber.ForeColor = System.Drawing.Color.Black;
            this.txtChairNumber.Location = new System.Drawing.Point(57, 63);
            this.txtChairNumber.Name = "txtChairNumber";
            this.txtChairNumber.Size = new System.Drawing.Size(202, 20);
            this.txtChairNumber.TabIndex = 2;
            // 
            // EditTableName
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(271, 118);
            this.Controls.Add(this.txtChairNumber);
            this.Controls.Add(this.txtNewTableName);
            this.Controls.Add(this.labelX3);
            this.Controls.Add(this.txtOldTableName);
            this.Controls.Add(this.labelX2);
            this.Controls.Add(this.labelX1);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnChangedName);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "EditTableName";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Đổi tên bàn";
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.ButtonX btnChangedName;
        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.DotNetBar.Controls.TextBoxX txtOldTableName;
        private DevComponents.DotNetBar.LabelX labelX2;
        private DevComponents.DotNetBar.Controls.TextBoxX txtNewTableName;
        private DevComponents.DotNetBar.ButtonX btnExit;
        private DevComponents.DotNetBar.LabelX labelX3;
        private DevComponents.DotNetBar.Controls.TextBoxX txtChairNumber;
    }
}
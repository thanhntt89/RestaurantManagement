namespace RestaurantManagement
{
    partial class UpdateMeterial
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UpdateMeterial));
            this.btnClose = new DevComponents.DotNetBar.ButtonX();
            this.btnAddMeterial = new DevComponents.DotNetBar.ButtonX();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnUnit = new DevComponents.DotNetBar.ButtonX();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cboSubMeterialGroup = new DevComponents.DotNetBar.Controls.ComboTree();
            this.cboUnit = new DevComponents.DotNetBar.Controls.ComboTree();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.labelX3 = new DevComponents.DotNetBar.LabelX();
            this.txtNote = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.txtMeterialName = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX5 = new DevComponents.DotNetBar.LabelX();
            this.labelX4 = new DevComponents.DotNetBar.LabelX();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.txtMeterialCode = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(276, 177);
            this.btnClose.Name = "btnClose";
            this.btnClose.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.CtrlD);
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnClose.TabIndex = 9;
            this.btnClose.Text = "Đóng";
            this.btnClose.Tooltip = "Ctrl + D";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnAddMeterial
            // 
            this.btnAddMeterial.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnAddMeterial.Location = new System.Drawing.Point(195, 177);
            this.btnAddMeterial.Name = "btnAddMeterial";
            this.btnAddMeterial.Size = new System.Drawing.Size(75, 23);
            this.btnAddMeterial.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnAddMeterial.TabIndex = 8;
            this.btnAddMeterial.Text = "Cập nhật";
            this.btnAddMeterial.Tooltip = "Enter";
            this.btnAddMeterial.Click += new System.EventHandler(this.btnAddMeterial_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnUnit);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.cboSubMeterialGroup);
            this.groupBox1.Controls.Add(this.cboUnit);
            this.groupBox1.Controls.Add(this.pictureBox1);
            this.groupBox1.Controls.Add(this.labelX3);
            this.groupBox1.Controls.Add(this.txtNote);
            this.groupBox1.Controls.Add(this.txtMeterialName);
            this.groupBox1.Controls.Add(this.labelX5);
            this.groupBox1.Controls.Add(this.labelX4);
            this.groupBox1.Controls.Add(this.labelX2);
            this.groupBox1.Controls.Add(this.txtMeterialCode);
            this.groupBox1.Controls.Add(this.labelX1);
            this.groupBox1.Location = new System.Drawing.Point(12, 1);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(523, 170);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông tin mặt hàng";
            // 
            // btnUnit
            // 
            this.btnUnit.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnUnit.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUnit.Location = new System.Drawing.Point(342, 105);
            this.btnUnit.Name = "btnUnit";
            this.btnUnit.Size = new System.Drawing.Size(20, 23);
            this.btnUnit.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnUnit.TabIndex = 7;
            this.btnUnit.Text = "...";
            this.btnUnit.Click += new System.EventHandler(this.btnUnit_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.Location = new System.Drawing.Point(93, 110);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(11, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "*";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.Red;
            this.label4.Location = new System.Drawing.Point(93, 55);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(11, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "*";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(93, 81);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(11, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "*";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(93, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(11, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "*";
            // 
            // cboSubMeterialGroup
            // 
            this.cboSubMeterialGroup.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.cboSubMeterialGroup.BackgroundStyle.Class = "TextBoxBorder";
            this.cboSubMeterialGroup.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.cboSubMeterialGroup.ButtonDropDown.Visible = true;
            this.cboSubMeterialGroup.ForeColor = System.Drawing.Color.Black;
            this.cboSubMeterialGroup.Location = new System.Drawing.Point(107, 23);
            this.cboSubMeterialGroup.Name = "cboSubMeterialGroup";
            this.cboSubMeterialGroup.Size = new System.Drawing.Size(255, 23);
            this.cboSubMeterialGroup.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2010;
            this.cboSubMeterialGroup.TabIndex = 3;
            this.cboSubMeterialGroup.WatermarkText = "Chọn nhóm cho mặt hàng";
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
            this.cboUnit.Location = new System.Drawing.Point(107, 105);
            this.cboUnit.Name = "cboUnit";
            this.cboUnit.Size = new System.Drawing.Size(232, 23);
            this.cboUnit.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2010;
            this.cboUnit.TabIndex = 3;
            this.cboUnit.WatermarkText = "Chọn đơn vị tính";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Image = global::RestaurantManagement.Properties.Resources._1369914393_Class;
            this.pictureBox1.Location = new System.Drawing.Point(371, 24);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(140, 133);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
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
            this.labelX3.Location = new System.Drawing.Point(19, 23);
            this.labelX3.Name = "labelX3";
            this.labelX3.Size = new System.Drawing.Size(68, 23);
            this.labelX3.TabIndex = 0;
            this.labelX3.Text = "Danh mục";
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
            this.txtNote.Location = new System.Drawing.Point(107, 137);
            this.txtNote.Name = "txtNote";
            this.txtNote.Size = new System.Drawing.Size(255, 20);
            this.txtNote.TabIndex = 4;
            this.txtNote.WatermarkText = "Ghi chú";
            // 
            // txtMeterialName
            // 
            this.txtMeterialName.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtMeterialName.Border.Class = "TextBoxBorder";
            this.txtMeterialName.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtMeterialName.ForeColor = System.Drawing.Color.Black;
            this.txtMeterialName.Location = new System.Drawing.Point(107, 79);
            this.txtMeterialName.Name = "txtMeterialName";
            this.txtMeterialName.Size = new System.Drawing.Size(255, 20);
            this.txtMeterialName.TabIndex = 2;
            this.txtMeterialName.WatermarkText = "Nhập vào tên mặt hàng";
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
            this.labelX5.Location = new System.Drawing.Point(19, 134);
            this.labelX5.Name = "labelX5";
            this.labelX5.Size = new System.Drawing.Size(75, 23);
            this.labelX5.TabIndex = 0;
            this.labelX5.Text = "Ghi chú";
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
            this.labelX4.Location = new System.Drawing.Point(19, 105);
            this.labelX4.Name = "labelX4";
            this.labelX4.Size = new System.Drawing.Size(75, 23);
            this.labelX4.TabIndex = 0;
            this.labelX4.Text = "Đơn vị tính";
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
            this.labelX2.Location = new System.Drawing.Point(19, 76);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(75, 23);
            this.labelX2.TabIndex = 0;
            this.labelX2.Text = "Tên mặt hàng";
            // 
            // txtMeterialCode
            // 
            this.txtMeterialCode.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtMeterialCode.Border.Class = "TextBoxBorder";
            this.txtMeterialCode.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtMeterialCode.ForeColor = System.Drawing.Color.Black;
            this.txtMeterialCode.Location = new System.Drawing.Point(107, 53);
            this.txtMeterialCode.Name = "txtMeterialCode";
            this.txtMeterialCode.ReadOnly = true;
            this.txtMeterialCode.Size = new System.Drawing.Size(255, 20);
            this.txtMeterialCode.TabIndex = 1;
            this.txtMeterialCode.WatermarkText = "Mã mặt hàng để quản lý";
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
            this.labelX1.Location = new System.Drawing.Point(19, 50);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(75, 23);
            this.labelX1.TabIndex = 0;
            this.labelX1.Text = "Mã mặt hàng";
            // 
            // UpdateMeterial
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(546, 208);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnAddMeterial);
            this.Controls.Add(this.groupBox1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "UpdateMeterial";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Cập nhật mặt hàng";
            this.Load += new System.EventHandler(this.UpdateMeterial_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.ButtonX btnClose;
        private DevComponents.DotNetBar.ButtonX btnAddMeterial;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private DevComponents.DotNetBar.Controls.ComboTree cboSubMeterialGroup;
        private DevComponents.DotNetBar.Controls.ComboTree cboUnit;
        private System.Windows.Forms.PictureBox pictureBox1;
        private DevComponents.DotNetBar.LabelX labelX3;
        private DevComponents.DotNetBar.Controls.TextBoxX txtNote;
        private DevComponents.DotNetBar.Controls.TextBoxX txtMeterialName;
        private DevComponents.DotNetBar.LabelX labelX5;
        private DevComponents.DotNetBar.LabelX labelX4;
        private DevComponents.DotNetBar.LabelX labelX2;
        private DevComponents.DotNetBar.Controls.TextBoxX txtMeterialCode;
        private DevComponents.DotNetBar.LabelX labelX1;
        private System.Windows.Forms.Label label4;
        private DevComponents.DotNetBar.ButtonX btnUnit;
    }
}
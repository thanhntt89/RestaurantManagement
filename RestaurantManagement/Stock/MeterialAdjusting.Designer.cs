namespace RestaurantManagement
{
    partial class MeterialAdjusting
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MeterialAdjusting));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtQuantityAdjusting = new DevComponents.Editors.DoubleInput();
            this.txtOldQuantity = new DevComponents.Editors.DoubleInput();
            this.lbItemName = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtOK = new DevComponents.DotNetBar.ButtonX();
            this.btnCancel = new DevComponents.DotNetBar.ButtonX();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtQuantityAdjusting)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtOldQuantity)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtQuantityAdjusting);
            this.groupBox1.Controls.Add(this.txtOldQuantity);
            this.groupBox1.Controls.Add(this.lbItemName);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(24, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(364, 140);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông tin nguyên liệu";
            // 
            // txtQuantityAdjusting
            // 
            this.txtQuantityAdjusting.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtQuantityAdjusting.BackgroundStyle.Class = "DateTimeInputBackground";
            this.txtQuantityAdjusting.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtQuantityAdjusting.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.txtQuantityAdjusting.DisplayFormat = "###,#0";
            this.txtQuantityAdjusting.ForeColor = System.Drawing.Color.Black;
            this.txtQuantityAdjusting.Increment = 1;
            this.txtQuantityAdjusting.Location = new System.Drawing.Point(114, 97);
            this.txtQuantityAdjusting.MinValue = 0;
            this.txtQuantityAdjusting.Name = "txtQuantityAdjusting";
            this.txtQuantityAdjusting.ShowUpDown = true;
            this.txtQuantityAdjusting.Size = new System.Drawing.Size(211, 21);
            this.txtQuantityAdjusting.TabIndex = 2;
            // 
            // txtOldQuantity
            // 
            this.txtOldQuantity.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtOldQuantity.BackgroundStyle.Class = "DateTimeInputBackground";
            this.txtOldQuantity.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtOldQuantity.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.txtOldQuantity.DisplayFormat = "###,#0";
            this.txtOldQuantity.ForeColor = System.Drawing.Color.Black;
            this.txtOldQuantity.Increment = 1;
            this.txtOldQuantity.IsInputReadOnly = true;
            this.txtOldQuantity.Location = new System.Drawing.Point(114, 67);
            this.txtOldQuantity.MinValue = 0;
            this.txtOldQuantity.Name = "txtOldQuantity";
            this.txtOldQuantity.Size = new System.Drawing.Size(211, 21);
            this.txtOldQuantity.TabIndex = 2;
            // 
            // lbItemName
            // 
            this.lbItemName.AutoSize = true;
            this.lbItemName.Location = new System.Drawing.Point(111, 36);
            this.lbItemName.Name = "lbItemName";
            this.lbItemName.Size = new System.Drawing.Size(19, 15);
            this.lbItemName.TabIndex = 1;
            this.lbItemName.Text = "....";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 105);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 15);
            this.label3.TabIndex = 0;
            this.label3.Text = "Điều chỉnh lại";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 15);
            this.label2.TabIndex = 0;
            this.label2.Text = "Lượng tồn";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tên nguyên liệu";
            // 
            // txtOK
            // 
            this.txtOK.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.txtOK.Location = new System.Drawing.Point(122, 147);
            this.txtOK.Name = "txtOK";
            this.txtOK.Size = new System.Drawing.Size(75, 23);
            this.txtOK.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.txtOK.TabIndex = 1;
            this.txtOK.Text = "Đồng ý";
            this.txtOK.Tooltip = "Enter";
            this.txtOK.Click += new System.EventHandler(this.txtOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnCancel.Location = new System.Drawing.Point(205, 147);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.CtrlD);
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Huỷ";
            this.btnCancel.Tooltip = "Ctrl + D";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // MeterialAdjusting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(402, 178);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.txtOK);
            this.Controls.Add(this.groupBox1);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MeterialAdjusting";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Điều chỉnh số lượng tồn kho";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtQuantityAdjusting)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtOldQuantity)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private DevComponents.Editors.DoubleInput txtOldQuantity;
        private System.Windows.Forms.Label lbItemName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private DevComponents.DotNetBar.ButtonX txtOK;
        private DevComponents.Editors.DoubleInput txtQuantityAdjusting;
        private System.Windows.Forms.Label label3;
        private DevComponents.DotNetBar.ButtonX btnCancel;
    }
}
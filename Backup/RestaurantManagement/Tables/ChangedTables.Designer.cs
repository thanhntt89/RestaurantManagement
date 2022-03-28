namespace RestaurantManagement
{
    partial class ChangedTables
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChangedTables));
            this.cboRegional = new DevComponents.DotNetBar.Controls.ComboTree();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lbOldTableName = new System.Windows.Forms.Label();
            this.cboTables = new DevComponents.DotNetBar.Controls.ComboTree();
            this.labelX3 = new DevComponents.DotNetBar.LabelX();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.btnChangedTable = new DevComponents.DotNetBar.ButtonX();
            this.btnClose = new DevComponents.DotNetBar.ButtonX();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cboRegional
            // 
            this.cboRegional.BackColor = System.Drawing.SystemColors.Window;
            // 
            // 
            // 
            this.cboRegional.BackgroundStyle.Class = "TextBoxBorder";
            this.cboRegional.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.cboRegional.ButtonDropDown.Visible = true;
            this.cboRegional.ColumnsVisible = false;
            this.cboRegional.GridColumnLines = false;
            this.cboRegional.Location = new System.Drawing.Point(124, 46);
            this.cboRegional.Name = "cboRegional";
            this.cboRegional.SelectionBoxStyle = DevComponents.AdvTree.eSelectionStyle.FullRowSelect;
            this.cboRegional.Size = new System.Drawing.Size(266, 23);
            this.cboRegional.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cboRegional.TabIndex = 0;
            this.cboRegional.SelectedValueChanged += new System.EventHandler(this.cboRegional_SelectedValueChanged);
            // 
            // labelX1
            // 
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.Class = "";
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Location = new System.Drawing.Point(21, 22);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(46, 23);
            this.labelX1.TabIndex = 1;
            this.labelX1.Text = "Đổi bàn:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cboRegional);
            this.groupBox1.Controls.Add(this.lbOldTableName);
            this.groupBox1.Controls.Add(this.cboTables);
            this.groupBox1.Controls.Add(this.labelX3);
            this.groupBox1.Controls.Add(this.labelX2);
            this.groupBox1.Controls.Add(this.labelX1);
            this.groupBox1.Location = new System.Drawing.Point(12, 1);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(433, 120);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông tin đổi bàn";
            // 
            // lbOldTableName
            // 
            this.lbOldTableName.AutoSize = true;
            this.lbOldTableName.Location = new System.Drawing.Point(121, 27);
            this.lbOldTableName.Name = "lbOldTableName";
            this.lbOldTableName.Size = new System.Drawing.Size(47, 13);
            this.lbOldTableName.TabIndex = 2;
            this.lbOldTableName.Text = "Tên bàn";
            // 
            // cboTables
            // 
            this.cboTables.BackColor = System.Drawing.SystemColors.Window;
            // 
            // 
            // 
            this.cboTables.BackgroundStyle.Class = "TextBoxBorder";
            this.cboTables.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.cboTables.ButtonDropDown.Visible = true;
            this.cboTables.ColumnsVisible = false;
            this.cboTables.GridColumnLines = false;
            this.cboTables.Location = new System.Drawing.Point(124, 77);
            this.cboTables.Name = "cboTables";
            this.cboTables.SelectionBoxStyle = DevComponents.AdvTree.eSelectionStyle.FullRowSelect;
            this.cboTables.Size = new System.Drawing.Size(266, 23);
            this.cboTables.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cboTables.TabIndex = 0;
            // 
            // labelX3
            // 
            // 
            // 
            // 
            this.labelX3.BackgroundStyle.Class = "";
            this.labelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX3.Location = new System.Drawing.Point(21, 77);
            this.labelX3.Name = "labelX3";
            this.labelX3.Size = new System.Drawing.Size(89, 23);
            this.labelX3.TabIndex = 1;
            this.labelX3.Text = "Chuyển sang bàn";
            // 
            // labelX2
            // 
            // 
            // 
            // 
            this.labelX2.BackgroundStyle.Class = "";
            this.labelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX2.Location = new System.Drawing.Point(21, 46);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(74, 23);
            this.labelX2.TabIndex = 1;
            this.labelX2.Text = "Chọn khu vực";
            // 
            // btnChangedTable
            // 
            this.btnChangedTable.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnChangedTable.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnChangedTable.Location = new System.Drawing.Point(149, 128);
            this.btnChangedTable.Name = "btnChangedTable";
            this.btnChangedTable.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.CtrlS);
            this.btnChangedTable.Size = new System.Drawing.Size(75, 23);
            this.btnChangedTable.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnChangedTable.TabIndex = 3;
            this.btnChangedTable.Text = "Đổi bàn";
            this.btnChangedTable.Click += new System.EventHandler(this.btnChangedTable_Click);
            // 
            // btnClose
            // 
            this.btnClose.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnClose.Location = new System.Drawing.Point(232, 128);
            this.btnClose.Name = "btnClose";
            this.btnClose.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.CtrlD);
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnClose.TabIndex = 3;
            this.btnClose.Text = "Đóng";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // ChangedTables
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(457, 159);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnChangedTable);
            this.Controls.Add(this.groupBox1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "ChangedTables";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Đổi bàn cho khách hàng";
            this.Load += new System.EventHandler(this.ChangedTables_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.Controls.ComboTree cboRegional;
        private DevComponents.DotNetBar.LabelX labelX1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lbOldTableName;
        private DevComponents.DotNetBar.Controls.ComboTree cboTables;
        private DevComponents.DotNetBar.LabelX labelX3;
        private DevComponents.DotNetBar.LabelX labelX2;
        private DevComponents.DotNetBar.ButtonX btnChangedTable;
        private DevComponents.DotNetBar.ButtonX btnClose;
    }
}


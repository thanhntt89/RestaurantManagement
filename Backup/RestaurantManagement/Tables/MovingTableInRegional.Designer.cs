namespace RestaurantManagement
{
    partial class MovingTableInRegional
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MovingTableInRegional));
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.btnMovingTable = new DevComponents.DotNetBar.ButtonX();
            this.btnExit = new DevComponents.DotNetBar.ButtonX();
            this.txtTableName = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX3 = new DevComponents.DotNetBar.LabelX();
            this.cboNewRegional = new DevComponents.DotNetBar.Controls.ComboTree();
            this.txtOldRegional = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.SuspendLayout();
            // 
            // labelX1
            // 
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.Class = "";
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Location = new System.Drawing.Point(18, 71);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(92, 23);
            this.labelX1.TabIndex = 0;
            this.labelX1.Text = "Đến khu vực mới";
            // 
            // labelX2
            // 
            // 
            // 
            // 
            this.labelX2.BackgroundStyle.Class = "";
            this.labelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX2.Location = new System.Drawing.Point(19, 12);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(67, 23);
            this.labelX2.TabIndex = 0;
            this.labelX2.Text = "Chuyển bàn";
            // 
            // btnMovingTable
            // 
            this.btnMovingTable.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnMovingTable.Location = new System.Drawing.Point(109, 106);
            this.btnMovingTable.Name = "btnMovingTable";
            this.btnMovingTable.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.CtrlS);
            this.btnMovingTable.Size = new System.Drawing.Size(75, 23);
            this.btnMovingTable.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnMovingTable.TabIndex = 2;
            this.btnMovingTable.Text = "Chuyển bàn";
            this.btnMovingTable.Click += new System.EventHandler(this.btnMovingTable_Click);
            // 
            // btnExit
            // 
            this.btnExit.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnExit.Location = new System.Drawing.Point(192, 106);
            this.btnExit.Name = "btnExit";
            this.btnExit.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.CtrlD);
            this.btnExit.Size = new System.Drawing.Size(75, 23);
            this.btnExit.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnExit.TabIndex = 2;
            this.btnExit.Text = "Đóng";
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // txtTableName
            // 
            this.txtTableName.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtTableName.Border.Class = "TextBoxBorder";
            this.txtTableName.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtTableName.ForeColor = System.Drawing.Color.Black;
            this.txtTableName.Location = new System.Drawing.Point(116, 15);
            this.txtTableName.Name = "txtTableName";
            this.txtTableName.ReadOnly = true;
            this.txtTableName.Size = new System.Drawing.Size(247, 20);
            this.txtTableName.TabIndex = 3;
            // 
            // labelX3
            // 
            // 
            // 
            // 
            this.labelX3.BackgroundStyle.Class = "";
            this.labelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX3.Location = new System.Drawing.Point(19, 41);
            this.labelX3.Name = "labelX3";
            this.labelX3.Size = new System.Drawing.Size(75, 23);
            this.labelX3.TabIndex = 0;
            this.labelX3.Text = "Của khu vực";
            // 
            // cboNewRegional
            // 
            this.cboNewRegional.BackColor = System.Drawing.SystemColors.Window;
            // 
            // 
            // 
            this.cboNewRegional.BackgroundStyle.Class = "TextBoxBorder";
            this.cboNewRegional.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.cboNewRegional.ButtonDropDown.Visible = true;
            this.cboNewRegional.ColumnsVisible = false;
            this.cboNewRegional.GridColumnLines = false;
            this.cboNewRegional.GridLinesColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.cboNewRegional.Location = new System.Drawing.Point(116, 74);
            this.cboNewRegional.Name = "cboNewRegional";
            this.cboNewRegional.SelectionBoxStyle = DevComponents.AdvTree.eSelectionStyle.FullRowSelect;
            this.cboNewRegional.Size = new System.Drawing.Size(247, 20);
            this.cboNewRegional.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cboNewRegional.TabIndex = 4;
            // 
            // txtOldRegional
            // 
            this.txtOldRegional.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtOldRegional.Border.Class = "TextBoxBorder";
            this.txtOldRegional.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtOldRegional.ForeColor = System.Drawing.Color.Black;
            this.txtOldRegional.Location = new System.Drawing.Point(116, 44);
            this.txtOldRegional.Name = "txtOldRegional";
            this.txtOldRegional.ReadOnly = true;
            this.txtOldRegional.Size = new System.Drawing.Size(247, 20);
            this.txtOldRegional.TabIndex = 3;
            // 
            // MovingTableInRegional
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(377, 139);
            this.Controls.Add(this.cboNewRegional);
            this.Controls.Add(this.txtOldRegional);
            this.Controls.Add(this.txtTableName);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnMovingTable);
            this.Controls.Add(this.labelX2);
            this.Controls.Add(this.labelX3);
            this.Controls.Add(this.labelX1);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MovingTableInRegional";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Chuyển bàn";
            this.Load += new System.EventHandler(this.MovingTable_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.DotNetBar.LabelX labelX2;
        private DevComponents.DotNetBar.ButtonX btnMovingTable;
        private DevComponents.DotNetBar.ButtonX btnExit;
        private DevComponents.DotNetBar.Controls.TextBoxX txtTableName;
        private DevComponents.DotNetBar.LabelX labelX3;
        private DevComponents.DotNetBar.Controls.ComboTree cboNewRegional;
        private DevComponents.DotNetBar.Controls.TextBoxX txtOldRegional;
    }
}
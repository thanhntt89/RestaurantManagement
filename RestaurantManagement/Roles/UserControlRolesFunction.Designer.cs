namespace RestaurantManagement
{
    partial class UserControlRolesFunction
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnSave = new DevComponents.DotNetBar.ButtonX();
            this.panel1 = new System.Windows.Forms.Panel();
            this.ckDeleteAll = new System.Windows.Forms.CheckBox();
            this.ckEditAll = new System.Windows.Forms.CheckBox();
            this.clAddAll = new System.Windows.Forms.CheckBox();
            this.ckViewAll = new System.Windows.Forms.CheckBox();
            this.dgvFunctions = new System.Windows.Forms.DataGridView();
            this.STTS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FunctionsName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.View = new DevComponents.DotNetBar.Controls.DataGridViewCheckBoxXColumn();
            this.Add = new DevComponents.DotNetBar.Controls.DataGridViewCheckBoxXColumn();
            this.Edit = new DevComponents.DotNetBar.Controls.DataGridViewCheckBoxXColumn();
            this.Delete = new DevComponents.DotNetBar.Controls.DataGridViewCheckBoxXColumn();
            this.FunctionId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFunctions)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSave.Location = new System.Drawing.Point(615, 514);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnSave.TabIndex = 3;
            this.btnSave.Text = "Lưu quyền";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.panel1.Controls.Add(this.dataGridView1);
            this.panel1.Controls.Add(this.ckDeleteAll);
            this.panel1.Controls.Add(this.ckEditAll);
            this.panel1.Controls.Add(this.clAddAll);
            this.panel1.Controls.Add(this.ckViewAll);
            this.panel1.Controls.Add(this.dgvFunctions);
            this.panel1.Controls.Add(this.btnSave);
            this.panel1.Location = new System.Drawing.Point(12, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(944, 542);
            this.panel1.TabIndex = 4;
            // 
            // ckDeleteAll
            // 
            this.ckDeleteAll.AutoSize = true;
            this.ckDeleteAll.Location = new System.Drawing.Point(886, 1);
            this.ckDeleteAll.Name = "ckDeleteAll";
            this.ckDeleteAll.Size = new System.Drawing.Size(55, 17);
            this.ckDeleteAll.TabIndex = 7;
            this.ckDeleteAll.Text = "Tất cả";
            this.ckDeleteAll.UseVisualStyleBackColor = true;
            this.ckDeleteAll.CheckedChanged += new System.EventHandler(this.ckDeleteAll_CheckedChanged);
            // 
            // ckEditAll
            // 
            this.ckEditAll.AutoSize = true;
            this.ckEditAll.Location = new System.Drawing.Point(817, 1);
            this.ckEditAll.Name = "ckEditAll";
            this.ckEditAll.Size = new System.Drawing.Size(55, 17);
            this.ckEditAll.TabIndex = 7;
            this.ckEditAll.Text = "Tất cả";
            this.ckEditAll.UseVisualStyleBackColor = true;
            this.ckEditAll.CheckedChanged += new System.EventHandler(this.ckEditAll_CheckedChanged);
            // 
            // clAddAll
            // 
            this.clAddAll.AutoSize = true;
            this.clAddAll.Location = new System.Drawing.Point(756, 1);
            this.clAddAll.Name = "clAddAll";
            this.clAddAll.Size = new System.Drawing.Size(55, 17);
            this.clAddAll.TabIndex = 7;
            this.clAddAll.Text = "Tất cả";
            this.clAddAll.UseVisualStyleBackColor = true;
            this.clAddAll.CheckedChanged += new System.EventHandler(this.clAddAll_CheckedChanged);
            // 
            // ckViewAll
            // 
            this.ckViewAll.AutoSize = true;
            this.ckViewAll.Location = new System.Drawing.Point(695, 1);
            this.ckViewAll.Name = "ckViewAll";
            this.ckViewAll.Size = new System.Drawing.Size(55, 17);
            this.ckViewAll.TabIndex = 7;
            this.ckViewAll.Text = "Tất cả";
            this.ckViewAll.UseVisualStyleBackColor = true;
            this.ckViewAll.CheckedChanged += new System.EventHandler(this.ckViewAll_CheckedChanged);
            // 
            // dgvFunctions
            // 
            this.dgvFunctions.AllowUserToAddRows = false;
            this.dgvFunctions.AllowUserToDeleteRows = false;
            this.dgvFunctions.AllowUserToResizeRows = false;
            this.dgvFunctions.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dgvFunctions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFunctions.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.STTS,
            this.FunctionsName,
            this.View,
            this.Add,
            this.Edit,
            this.Delete,
            this.FunctionId});
            this.dgvFunctions.Location = new System.Drawing.Point(439, 19);
            this.dgvFunctions.MultiSelect = false;
            this.dgvFunctions.Name = "dgvFunctions";
            this.dgvFunctions.RowHeadersVisible = false;
            this.dgvFunctions.Size = new System.Drawing.Size(493, 489);
            this.dgvFunctions.TabIndex = 5;
            // 
            // STTS
            // 
            this.STTS.HeaderText = "STT";
            this.STTS.Name = "STTS";
            this.STTS.ReadOnly = true;
            this.STTS.Width = 50;
            // 
            // FunctionsName
            // 
            this.FunctionsName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.FunctionsName.HeaderText = "Chức năng";
            this.FunctionsName.Name = "FunctionsName";
            this.FunctionsName.ReadOnly = true;
            // 
            // View
            // 
            this.View.Checked = true;
            this.View.CheckState = System.Windows.Forms.CheckState.Indeterminate;
            this.View.CheckValue = null;
            this.View.HeaderText = "Xem";
            this.View.Name = "View";
            this.View.Width = 60;
            // 
            // Add
            // 
            this.Add.Checked = true;
            this.Add.CheckState = System.Windows.Forms.CheckState.Indeterminate;
            this.Add.CheckValue = null;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Add.DefaultCellStyle = dataGridViewCellStyle7;
            this.Add.HeaderText = "Thêm";
            this.Add.Name = "Add";
            this.Add.Width = 60;
            // 
            // Edit
            // 
            this.Edit.Checked = true;
            this.Edit.CheckState = System.Windows.Forms.CheckState.Indeterminate;
            this.Edit.CheckValue = null;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Edit.DefaultCellStyle = dataGridViewCellStyle8;
            this.Edit.HeaderText = "Sửa";
            this.Edit.Name = "Edit";
            this.Edit.Width = 60;
            // 
            // Delete
            // 
            this.Delete.Checked = true;
            this.Delete.CheckState = System.Windows.Forms.CheckState.Indeterminate;
            this.Delete.CheckValue = null;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Delete.DefaultCellStyle = dataGridViewCellStyle9;
            this.Delete.HeaderText = "Xóa";
            this.Delete.Name = "Delete";
            this.Delete.Width = 60;
            // 
            // FunctionId
            // 
            this.FunctionId.HeaderText = "FunctionId";
            this.FunctionId.Name = "FunctionId";
            this.FunctionId.Visible = false;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(17, 19);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(240, 150);
            this.dataGridView1.TabIndex = 8;
            // 
            // UserControlRolesFunction
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.Controls.Add(this.panel1);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "UserControlRolesFunction";
            this.Size = new System.Drawing.Size(994, 555);
            this.Load += new System.EventHandler(this.RolesFunction_Load);
            this.SizeChanged += new System.EventHandler(this.RolesFunction_SizeChanged);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFunctions)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.ButtonX btnSave;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dgvFunctions;
        private System.Windows.Forms.CheckBox ckDeleteAll;
        private System.Windows.Forms.CheckBox ckEditAll;
        private System.Windows.Forms.CheckBox clAddAll;
        private System.Windows.Forms.CheckBox ckViewAll;
        private System.Windows.Forms.DataGridViewTextBoxColumn STTS;
        private System.Windows.Forms.DataGridViewTextBoxColumn FunctionsName;
        private DevComponents.DotNetBar.Controls.DataGridViewCheckBoxXColumn View;
        private DevComponents.DotNetBar.Controls.DataGridViewCheckBoxXColumn Add;
        private DevComponents.DotNetBar.Controls.DataGridViewCheckBoxXColumn Edit;
        private DevComponents.DotNetBar.Controls.DataGridViewCheckBoxXColumn Delete;
        private System.Windows.Forms.DataGridViewTextBoxColumn FunctionId;
        private System.Windows.Forms.DataGridView dataGridView1;
    }
}
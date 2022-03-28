namespace RestaurantManagement
{
    partial class UserControlRoleManagement
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dgvStaff = new System.Windows.Forms.DataGridView();
            this.STT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StaffCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StaffName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RoleName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StaffId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RoleId = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            this.btnSave = new DevComponents.DotNetBar.ButtonX();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStaff)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFunctions)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.panel1.Controls.Add(this.dgvStaff);
            this.panel1.Controls.Add(this.ckDeleteAll);
            this.panel1.Controls.Add(this.ckEditAll);
            this.panel1.Controls.Add(this.clAddAll);
            this.panel1.Controls.Add(this.ckViewAll);
            this.panel1.Controls.Add(this.dgvFunctions);
            this.panel1.Controls.Add(this.btnSave);
            this.panel1.Location = new System.Drawing.Point(0, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(908, 583);
            this.panel1.TabIndex = 5;
            // 
            // dgvStaff
            // 
            this.dgvStaff.AllowUserToAddRows = false;
            this.dgvStaff.AllowUserToDeleteRows = false;
            this.dgvStaff.AllowUserToOrderColumns = true;
            this.dgvStaff.AllowUserToResizeColumns = false;
            this.dgvStaff.AllowUserToResizeRows = false;
            this.dgvStaff.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dgvStaff.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvStaff.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.STT,
            this.StaffCode,
            this.StaffName,
            this.RoleName,
            this.StaffId,
            this.RoleId});
            this.dgvStaff.Location = new System.Drawing.Point(9, 27);
            this.dgvStaff.MultiSelect = false;
            this.dgvStaff.Name = "dgvStaff";
            this.dgvStaff.ReadOnly = true;
            this.dgvStaff.RowHeadersVisible = false;
            this.dgvStaff.Size = new System.Drawing.Size(388, 515);
            this.dgvStaff.TabIndex = 8;
            this.dgvStaff.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvStaff_CellClick);
            // 
            // STT
            // 
            this.STT.HeaderText = "STT";
            this.STT.Name = "STT";
            this.STT.ReadOnly = true;
            this.STT.Width = 50;
            // 
            // StaffCode
            // 
            this.StaffCode.HeaderText = "Mã nhân viên";
            this.StaffCode.Name = "StaffCode";
            this.StaffCode.ReadOnly = true;
            // 
            // StaffName
            // 
            this.StaffName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.StaffName.HeaderText = "Tên nhân viên";
            this.StaffName.Name = "StaffName";
            this.StaffName.ReadOnly = true;
            // 
            // RoleName
            // 
            this.RoleName.HeaderText = "Quyền";
            this.RoleName.Name = "RoleName";
            this.RoleName.ReadOnly = true;
            // 
            // StaffId
            // 
            this.StaffId.HeaderText = "StaffId";
            this.StaffId.Name = "StaffId";
            this.StaffId.ReadOnly = true;
            this.StaffId.Visible = false;
            // 
            // RoleId
            // 
            this.RoleId.HeaderText = "RoleId";
            this.RoleId.Name = "RoleId";
            this.RoleId.ReadOnly = true;
            this.RoleId.Visible = false;
            // 
            // ckDeleteAll
            // 
            this.ckDeleteAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ckDeleteAll.AutoSize = true;
            this.ckDeleteAll.Location = new System.Drawing.Point(842, 9);
            this.ckDeleteAll.Name = "ckDeleteAll";
            this.ckDeleteAll.Size = new System.Drawing.Size(57, 17);
            this.ckDeleteAll.TabIndex = 7;
            this.ckDeleteAll.Text = "Tất cả";
            this.ckDeleteAll.UseVisualStyleBackColor = true;
            this.ckDeleteAll.CheckedChanged += new System.EventHandler(this.ckDeleteAll_CheckedChanged);
            // 
            // ckEditAll
            // 
            this.ckEditAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ckEditAll.AutoSize = true;
            this.ckEditAll.Location = new System.Drawing.Point(782, 9);
            this.ckEditAll.Name = "ckEditAll";
            this.ckEditAll.Size = new System.Drawing.Size(57, 17);
            this.ckEditAll.TabIndex = 7;
            this.ckEditAll.Text = "Tất cả";
            this.ckEditAll.UseVisualStyleBackColor = true;
            this.ckEditAll.CheckedChanged += new System.EventHandler(this.ckEditAll_CheckedChanged);
            // 
            // clAddAll
            // 
            this.clAddAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.clAddAll.AutoSize = true;
            this.clAddAll.Location = new System.Drawing.Point(721, 9);
            this.clAddAll.Name = "clAddAll";
            this.clAddAll.Size = new System.Drawing.Size(57, 17);
            this.clAddAll.TabIndex = 7;
            this.clAddAll.Text = "Tất cả";
            this.clAddAll.UseVisualStyleBackColor = true;
            this.clAddAll.CheckedChanged += new System.EventHandler(this.clAddAll_CheckedChanged);
            // 
            // ckViewAll
            // 
            this.ckViewAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ckViewAll.AutoSize = true;
            this.ckViewAll.Location = new System.Drawing.Point(660, 9);
            this.ckViewAll.Name = "ckViewAll";
            this.ckViewAll.Size = new System.Drawing.Size(57, 17);
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
            this.dgvFunctions.Location = new System.Drawing.Point(404, 27);
            this.dgvFunctions.MultiSelect = false;
            this.dgvFunctions.Name = "dgvFunctions";
            this.dgvFunctions.RowHeadersVisible = false;
            this.dgvFunctions.Size = new System.Drawing.Size(493, 515);
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
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Add.DefaultCellStyle = dataGridViewCellStyle1;
            this.Add.HeaderText = "Thêm";
            this.Add.Name = "Add";
            this.Add.Width = 60;
            // 
            // Edit
            // 
            this.Edit.Checked = true;
            this.Edit.CheckState = System.Windows.Forms.CheckState.Indeterminate;
            this.Edit.CheckValue = null;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Edit.DefaultCellStyle = dataGridViewCellStyle2;
            this.Edit.HeaderText = "Sửa";
            this.Edit.Name = "Edit";
            this.Edit.Width = 60;
            // 
            // Delete
            // 
            this.Delete.Checked = true;
            this.Delete.CheckState = System.Windows.Forms.CheckState.Indeterminate;
            this.Delete.CheckValue = null;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Delete.DefaultCellStyle = dataGridViewCellStyle3;
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
            // btnSave
            // 
            this.btnSave.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSave.Location = new System.Drawing.Point(627, 548);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnSave.TabIndex = 3;
            this.btnSave.Text = "Lưu quyền";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // UserControlRoleManagement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.Controls.Add(this.panel1);
            this.Name = "UserControlRoleManagement";
            this.Size = new System.Drawing.Size(928, 600);
            this.Load += new System.EventHandler(this.UserControlRoleManagement_Load);
            this.SizeChanged += new System.EventHandler(this.UserControlRoleManagement_SizeChanged);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStaff)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFunctions)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dgvStaff;
        private System.Windows.Forms.DataGridViewTextBoxColumn STT;
        private System.Windows.Forms.DataGridViewTextBoxColumn StaffCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn StaffName;
        private System.Windows.Forms.DataGridViewTextBoxColumn RoleName;
        private System.Windows.Forms.DataGridViewTextBoxColumn StaffId;
        private System.Windows.Forms.DataGridViewTextBoxColumn RoleId;
        private System.Windows.Forms.CheckBox ckDeleteAll;
        private System.Windows.Forms.CheckBox ckEditAll;
        private System.Windows.Forms.CheckBox clAddAll;
        private System.Windows.Forms.CheckBox ckViewAll;
        private System.Windows.Forms.DataGridView dgvFunctions;
        private System.Windows.Forms.DataGridViewTextBoxColumn STTS;
        private System.Windows.Forms.DataGridViewTextBoxColumn FunctionsName;
        private DevComponents.DotNetBar.Controls.DataGridViewCheckBoxXColumn View;
        private DevComponents.DotNetBar.Controls.DataGridViewCheckBoxXColumn Add;
        private DevComponents.DotNetBar.Controls.DataGridViewCheckBoxXColumn Edit;
        private DevComponents.DotNetBar.Controls.DataGridViewCheckBoxXColumn Delete;
        private System.Windows.Forms.DataGridViewTextBoxColumn FunctionId;
        private DevComponents.DotNetBar.ButtonX btnSave;
    }
}

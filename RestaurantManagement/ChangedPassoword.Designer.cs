namespace RestaurantManagement
{
    partial class ChangedPassoword
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
            this.userControlChangedPassword1 = new RestaurantManagement.UserControlChangedPassword();
            this.SuspendLayout();
            // 
            // userControlChangedPassword1
            // 
            this.userControlChangedPassword1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.userControlChangedPassword1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.userControlChangedPassword1.Location = new System.Drawing.Point(12, 12);
            this.userControlChangedPassword1.Name = "userControlChangedPassword1";
            this.userControlChangedPassword1.Size = new System.Drawing.Size(529, 337);
            this.userControlChangedPassword1.TabIndex = 0;
            // 
            // ChangedPassoword
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(547, 236);
            this.Controls.Add(this.userControlChangedPassword1);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "ChangedPassoword";
            this.Text = "Đổi mật khẩu";
            this.ResumeLayout(false);

        }

        #endregion

        private UserControlChangedPassword userControlChangedPassword1;
    }
}
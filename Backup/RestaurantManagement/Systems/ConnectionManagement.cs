using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using RestaurantDTO;
using System.Configuration;
using System.Data.SqlClient;
using RestaurantController;
using RestaurantCommon;

namespace RestaurantManagement
{
    public partial class ConnectionManagement : DevComponents.DotNetBar.Metro.MetroForm
    {
        public delegate void ChangedDataBase();
        public event ChangedDataBase changedDatabase;
        public bool isOK = false;

        public ConnectionManagement()
        {
            InitializeComponent();
        }

        private void ConnectionManagement_Load(object sender, EventArgs e)
        {
            LoadConnectionString();
        }

        private void SaveConnectionString()
        {
            if (!CheckItem())
                return;

            // Gọi lại phương thức thay đổi database
            if (changedDatabase != null)
                changedDatabase();
            //  Data Source=THANHNT-PC,1433;Initial Catalog=RestaurantManagement;Integrated Security=False;User ID=sa;Password=[Password]
            StringBuilder sqlConnectString = new StringBuilder();
            sqlConnectString.Append("Data Source=");
            sqlConnectString.Append(txtServerName.Text);
            if (txtPortName.Value > 0)
            {
                sqlConnectString.Append(",");
                sqlConnectString.Append(txtPortName.Value);

            }
            sqlConnectString.Append(";Initial Catalog=");
            sqlConnectString.Append(txtDatabaseName.Text);
            sqlConnectString.Append(";Integrated Security =");
            sqlConnectString.Append(chkIntegratedSecurity.Checked);
            if (chkSa.Checked)
            {
                sqlConnectString.Append(";User ID=");
                sqlConnectString.Append(txtUserName.Text);
                sqlConnectString.Append(";Password=");
                sqlConnectString.Append(txtPassword.Text);
            }
            try
            {
                isOK = true;
                SqlConnection sqlConnection = new SqlConnection(sqlConnectString.ToString());
                sqlConnection.Open();
                CheckLogin.SaveConnectionString(sqlConnectString.ToString());
                CheckLogin.SettingConnectionApplication(sqlConnectString.ToString());
                this.Close();
            }
            catch
            {
                isOK = false;
                MessageBox.Show("Không kết nối được đến máy chủ. \n Bạn hãy kiểm tra lại kết nối đến máy chủ", "Lỗi kết nối", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadConnectionString()
        {
            string ConnecString = string.Empty;
            ConnecString = DataBaseConnection.GetConnectString();
        }

        private void btnAceept_Click(object sender, EventArgs e)
        {
            SaveConnectionString();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnDefault_Click(object sender, EventArgs e)
        {
            ConnectionDefault();
        }

        private bool CheckItem()
        {
            if (string.IsNullOrEmpty(txtServerName.Text))
            {
                MessageBox.Show("Tên máy chủ không được để trống", Constants.CaptionInformationMessage, MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtServerName.Focus();

                return false;
            }
            if (string.IsNullOrEmpty(txtDatabaseName.Text))
            {
                MessageBox.Show("Tên cơ sở dữ liệu không được để trống", Constants.CaptionInformationMessage, MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtDatabaseName.Focus();

                return false;
            }
            if (chkSa.Checked)
            {
                if (string.IsNullOrEmpty(txtUserName.Text))
                {
                    MessageBox.Show("Tên tài khoản sa không được để trống", Constants.CaptionInformationMessage, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtUserName.Focus();
                    return false;
                }
                if (string.IsNullOrEmpty(txtPassword.Text))
                {
                    MessageBox.Show("Mật khẩu tài khoản sa không được để trống", Constants.CaptionInformationMessage, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtPassword.Focus();
                    return false;
                }
            }
            return true;
        }

        private void ConnectionDefault()
        {
            txtServerName.Text = Constants.ServerNameDefault;
            txtDatabaseName.Text = Constants.DatabaseDefault;
            txtUserName.Text = "sa";
            txtPortName.Value = 1433;
            txtPassword.Text = Constants.PassWordDefault;
            chkSa.Checked = true;
        }

        private void chkSa_CheckedChanged(object sender, EventArgs e)
        {
            if (chkSa.Checked)
            {
                txtPortName.Enabled = true;
                txtUserName.Enabled = true;
                txtPassword.Enabled = true;
            }
            else
            {
                txtPortName.Value = 0;
                txtUserName.Text = string.Empty;
                txtPassword.Text = string.Empty;
                txtUserName.Enabled = false;
                txtPassword.Enabled = false;
                txtPortName.Enabled = false;

            }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Enter)
            {
                btnAceept_Click(null, null);
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
}

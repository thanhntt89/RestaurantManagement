using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using RestaurantController;
using RestaurantDTO.RestaurantInforDataSetTableAdapters;
using RestaurantDTO;
using RestaurantCommon;

namespace RestaurantManagement
{
    public partial class UserControlRestaurantInfor : UserControl
    {
        private RestaurantInforController restaurantInforController = new RestaurantInforController();
        private RestaurantInforDataSet.RestaurantInforDataTable restaurantInforDataTable = null;
        private UserFunctionList userFunctionList = null;

        public UserControlRestaurantInfor(UserFunctionList userFunctionList)
        {
            InitializeComponent();
            this.userFunctionList = userFunctionList;
            CheckUpdate();
        }

        public UserControlRestaurantInfor()
        {
            InitializeComponent();
        }

        private void CheckUpdate()
        {
            if (userFunctionList.SystemConfig.Count > 0 && (userFunctionList.SystemConfig[0].Add == 1 | userFunctionList.SystemConfig[0].Edit == 1))
                btnSave.Enabled = true;
            else
                btnSave.Enabled = false;
        }

        private void LoadRestaurantInfor()
        {
            restaurantInforDataTable = new RestaurantInforDataSet.RestaurantInforDataTable();
            restaurantInforController.GetAllRestaurantInforByRestaurantInforId(restaurantInforDataTable, 1);
            if (restaurantInforDataTable.Rows.Count == 0)
                return;

            txtRestaurantName.Text = restaurantInforDataTable.First().Field<string>("RestaurantName");
            txtWonerRestaurant.Text = restaurantInforDataTable.First().Field<string>("RestaurantManagement");
            txtTexa.Text = restaurantInforDataTable.First().Field<string>("RestaurantTexNumber");
            txtMobile.Text = restaurantInforDataTable.First().Field<string>("RestaurantMobile");
            txtEmail.Text = restaurantInforDataTable.First().Field<string>("RestaurantEmail");
            txtAddress.Text = restaurantInforDataTable.First().Field<string>("RestaurantAddress");
            ptbLogo.Image = restaurantInforDataTable.First().IsRestaurantLogoNull() ? null : Utilities.ConvertByteToImage(restaurantInforDataTable.First().RestaurantLogo);
        }

        private void UserControlRestaurantInfor_Load(object sender, EventArgs e)
        {
            LoadRestaurantInfor();
            panel1.CenterHorizontally();
            panel1.CenterVertically();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveRestaurantInfor();
        }

        private void SaveRestaurantInfor()
        {
            restaurantInforDataTable = new RestaurantInforDataSet.RestaurantInforDataTable();
            restaurantInforController.GetAllRestaurantInforByRestaurantInforId(restaurantInforDataTable, 1);
            if (restaurantInforDataTable.Rows.Count == 0)
                return;

            restaurantInforDataTable.First().RestaurantLogo = ptbLogo.Image == null ? null : Utilities.ConvertImageToByte(ptbLogo.Image);
            restaurantInforDataTable.First().RestaurantAddress = txtAddress.Text;
            restaurantInforDataTable.First().RestaurantEmail = txtEmail.Text;
            restaurantInforDataTable.First().RestaurantManagement = txtWonerRestaurant.Text;
            restaurantInforDataTable.First().RestaurantName = txtRestaurantName.Text;
            restaurantInforDataTable.First().RestaurantMobile = txtMobile.Text;
            restaurantInforDataTable.First().RestaurantTexNumber = txtTexa.Text;

            try
            {
                restaurantInforController.UpdateRestaurantInfor(restaurantInforDataTable);
                LogHistories.InsertLogHistories("Sửa thông tin đơn vị sử dụng", DateTime.Now, userFunctionList.UserName, "Thành công");
                MessageBox.Show("Lưu thông tin thành công", Constants.CaptionInformationMessage, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch(Exception ex)
            {
                LogHistories.InsertLogHistories("Lỗi: Sửa thông tin đơn vị sử dụng", DateTime.Now, userFunctionList.UserName, ex.Message);
                MessageBox.Show("Có lỗi trong quá trình lưu thông tin", Constants.CaptionErrorMessage, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog openfile = new OpenFileDialog();
            Utilities.ConvertImgeToByte(openfile, ptbLogo);
        }

        private void UserControlRestaurantInfor_SizeChanged(object sender, EventArgs e)
        {
            panel1.CenterHorizontally();
            panel1.CenterVertically();
        }

    }
}

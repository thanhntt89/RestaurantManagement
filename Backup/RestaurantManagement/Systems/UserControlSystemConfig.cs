using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using RestaurantCommon;

namespace RestaurantManagement
{
    public partial class UserControlSystemConfig : UserControl
    {
        private UserFunctionList userFunctionList;

        public UserControlSystemConfig(UserFunctionList userFunctionList)
        {
            InitializeComponent();
            this.userFunctionList = userFunctionList;
            CheckRole(userFunctionList);
        }

        private void CheckRole(UserFunctionList userFunctionList)
        {
            tabLogHistories.Visible = false;
            superTabItemRoleUser.Visible = false;

            if (userFunctionList.RoleId == 2)
            {
                tabLogHistories.Visible = true;
                superTabItemRoleUser.Visible = true;
            }
        }

        private void superTabItemRestaurantInfor_Click(object sender, EventArgs e)
        {
            panelRestaurantInfor.Controls.Clear();
            LogHistories.InsertLogHistories("Xem thông tin đơn vị sử dụng", DateTime.Now, userFunctionList.UserName, "Thành công");
            UserControlRestaurantInfor UserControlRestaurantInfor = new UserControlRestaurantInfor(userFunctionList);
            UserControlRestaurantInfor.Dock = DockStyle.Fill;
            panelRestaurantInfor.Controls.Add(UserControlRestaurantInfor);
        }

        private void superTabItemUnitName_Click(object sender, EventArgs e)
        {
            panelUnitManagement.Controls.Clear();
            LogHistories.InsertLogHistories("Xem thông tin đơn vị tính", DateTime.Now, userFunctionList.UserName, "Thành công");
            UsercontrolUnitManagement UnitManagement = new UsercontrolUnitManagement(userFunctionList);
            UnitManagement.Dock = DockStyle.Fill;
            panelUnitManagement.Controls.Add(UnitManagement);
        }

        private void superTabItemRoleUser_Click(object sender, EventArgs e)
        {
            superPanelRoleUser.Controls.Clear();
            LogHistories.InsertLogHistories("Xem chức năng phân quyền sử dụng", DateTime.Now, userFunctionList.UserName, "Thành công");
            UserControlRoleManagement UserControlRoleManagement = new UserControlRoleManagement(userFunctionList);
            UserControlRoleManagement.Dock = DockStyle.Fill;
            superPanelRoleUser.Controls.Add(UserControlRoleManagement);
        }

        private void tabLogHistories_Click(object sender, EventArgs e)
        {
            panelLogHistories.Controls.Clear();
            LogHistories.InsertLogHistories("Xem chức năng phân quyền sử dụng", DateTime.Now, userFunctionList.UserName, "Thành công");
            UserControlLogHistories UserControlLogHistories = new UserControlLogHistories(userFunctionList);
            UserControlLogHistories.Dock = DockStyle.Fill;
            panelLogHistories.Controls.Add(UserControlLogHistories);
        }

        private void UserControlSystemConfig_Load(object sender, EventArgs e)
        {
            superTabItemRestaurantInfor_Click(null, null);
        }
    }
}

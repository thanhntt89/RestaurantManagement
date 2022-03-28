using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RestaurantDTO;
using RestaurantDTO.MenuDataSetTableAdapters;
using System.Data.SqlClient;

namespace RestaurantController
{
    public class MenuController
    {
        public void UpdateMenu(MenuDataSet.MenuDataTable MenuDataTable)
        {
            try
            {
                MenuTableAdapter MenuTableAdapter = new MenuTableAdapter();
                MenuTableAdapter.Update(MenuDataTable);
            }
            catch { throw; }
        }

        public void GetAllMenu(MenuDataSet.MenuDataTable MenuDataTable)
        {
            using (var menuTableAdapter = new MenuTableAdapter())
            {
                menuTableAdapter.FillAllMenu(MenuDataTable);
            }
        }

        public void GetMaxMenuId(MenuDataSet.MenuDataTable MenuDataTable)
        {
            using (var menuTableAdapter = new MenuTableAdapter())
            {
                menuTableAdapter.FillByMaxMenuId(MenuDataTable);
            }
        }

        public void GetMenuByMenuId(MenuDataSet.MenuDataTable MenuDataTable, int menuId)
        {
            using (var menuTableAdapter = new MenuTableAdapter())
            {
                menuTableAdapter.FillByMenuId(MenuDataTable, menuId);
            }
        }

        public void GetMenuBySubGroupId(MenuDataSet.MenuDataTable MenuDataTable, int subGroupId)
        {
            using (var menuTableAdapter = new MenuTableAdapter())
            {
                menuTableAdapter.FillBySubGroupId(MenuDataTable, subGroupId);
            }
        }

        public void GetAllMenuAndSubGroupMenu(MenuDataSet.MenuAndSubGroupMenuDataTable MenuAndSubGroupMenuDataTable)
        {
            using (var menuAndSubGroupMenuTableAdapter = new MenuAndSubGroupMenuTableAdapter())
            {
                menuAndSubGroupMenuTableAdapter.FillAll(MenuAndSubGroupMenuDataTable);
            }
        }

        public void GetMenuBySubGroupId(MenuDataSet.MenuAndSubGroupMenuDataTable MenuAndSubGroupMenuDataTable, int subGroupId)
        {
            using (var menuAndSubGroupMenuTableAdapter = new MenuAndSubGroupMenuTableAdapter())
            {
                menuAndSubGroupMenuTableAdapter.FillBySubGroupId(MenuAndSubGroupMenuDataTable, subGroupId);
            }
        }


        public void SearchImportBillByBillEntity(MenuDataSet.MenuQuantityByBillDateDataTable menuQuantityByBillDateDataTable, BillEntity billEntity)
        {
            // KHởi tạo connection  
            string ConnectString = DataBaseConnection.GetConnectString();
            SqlConnection sqlConnection = new SqlConnection(ConnectString);
            try
            {
                // Khởi tạo command
                using (SqlCommand command = new SqlCommand(CreateFillQuery(billEntity), sqlConnection))
                {
                    command.Parameters.AddRange(CreateSqlParameters(billEntity));
                    command.Connection.Open();
                    SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();

                    sqlDataAdapter.SelectCommand = command;

                    menuQuantityByBillDateDataTable.Clear();

                    // Fill thông tin người dùng vào View
                    sqlDataAdapter.Fill(menuQuantityByBillDateDataTable);
                }
            }
            finally
            {
                sqlConnection.Close();
            }
        }

        private string CreateFillQuery(BillEntity billEntity)
        {
            StringBuilder query = new StringBuilder();
            query.AppendLine("SELECT     ");
            query.AppendLine("dbo.BillDetail.MenuId, ");
            query.AppendLine("dbo.Menu.ItemName,");
            query.AppendLine(" SUM(dbo.BillDetail.Quatity) AS Quantity,");
            query.AppendLine(" dbo.Unit.UnitName FROM   ");
           query.AppendLine(" dbo.Menu INNER JOIN");
            query.AppendLine(" dbo.Unit ON dbo.Menu.UnitId = dbo.Unit.UnitId RIGHT OUTER JOIN ");
             query.AppendLine(" dbo.BillDetail ON dbo.Menu.MenuId = dbo.BillDetail.MenuId LEFT OUTER JOIN ");
             query.AppendLine(" dbo.Bill ON dbo.BillDetail.BillId = dbo.Bill.BillId ");

            //query.AppendLine("SELECT ");
            //query.AppendLine("BillDetail.MenuId as MenuId,");
            //query.AppendLine("Menu.ItemName as ItemName,");
            //query.AppendLine("BillDetail.UnitName as UnitName,");
            //query.AppendLine("SUM(BillDetail.Quatity) as Quatity ");
            //query.AppendLine("FROM ");
            //query.AppendLine("Bill INNER JOIN ");
            //query.AppendLine("BillDetail ON Bill.BillId = BillDetail.BillId INNER JOIN ");
            //query.AppendLine("Menu ON BillDetail.MenuId = Menu.MenuId ");

            query.AppendLine(CreateWherePhrase(billEntity));
            query.AppendLine("  GROUP BY  dbo.BillDetail.MenuId, dbo.Menu.ItemName,dbo.Unit.UnitName");
            // query.AppendLine("  Group By BillDetail.MenuId ,Menu.ItemName,BillDetail.UnitName");
            return query.ToString();
        }

        private string CreateWherePhrase(BillEntity billEntity)
        {

            StringBuilder sb = new StringBuilder();

            sb.AppendLine(" WHERE 1=1 ");// (1 = 1) 

            if (billEntity.MenuId != 0)
                sb.AppendLine(" AND (BillDetail.MenuId = @MenuId) ");

            if (billEntity.FromMonth != 0)
                sb.AppendLine(" AND (MONTH(Bill.BillDate) >= @FromMonth)");
            if (billEntity.FromYear != 0)
                sb.AppendLine(" AND (YEAR(Bill.BillDate) >=  @FromYear)");

            if (!string.IsNullOrEmpty(billEntity.FromDate))
            {
                sb.AppendLine(" AND (Bill.BillDate >= @FromDate)");
            }

            if (billEntity.ToMonth != 0)
                sb.AppendLine(" AND (MONTH(Bill.BillDate) <= @ToMonth)");

            if (billEntity.ToYear != 0)
                sb.AppendLine(" AND (YEAR(Bill.BillDate) <= @ToYear)");

            if (!string.IsNullOrEmpty(billEntity.ToDate))
            {
                sb.AppendLine(" AND (Bill.BillDate <= @ToDate)");
            }

            return sb.ToString();
        }

        private SqlParameter[] CreateSqlParameters(BillEntity billEntity)
        {
            List<SqlParameter> list = new List<SqlParameter>();

            // Trường hợp có nhập Id vụ khảo nghiệm
            if (billEntity.MenuId != 0)
            {
                list.Add(new SqlParameter("@MenuId", billEntity.MenuId));
            }

            // Trường hợp có nhập Id vụ khảo nghiệm
            if (billEntity.ToDate != null)
            {
                list.Add(new SqlParameter("@ToDate", billEntity.ToDate));
            }

            if (billEntity.FromMonth != 0)
            {
                list.Add(new SqlParameter("@FromMonth", billEntity.FromMonth));
            }

            if (billEntity.FromYear != 0)
            {
                list.Add(new SqlParameter("@FromYear", billEntity.FromYear));
            }

            if (billEntity.ToMonth != 0)
            {
                list.Add(new SqlParameter("@ToMonth", billEntity.ToMonth));
            }

            if (billEntity.ToYear != 0)
            {
                list.Add(new SqlParameter("@ToYear", billEntity.ToYear));
            }

            // Trường hợp chọn năm khảo nghiệm từ năm
            if (billEntity.FromDate != null)
            {
                list.Add(new SqlParameter("@FromDate", billEntity.FromDate));
            }
            return list.ToArray();
        }
    }
}

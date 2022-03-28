using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RestaurantDTO;
using RestaurantDTO.BillsDataSetTableAdapters;
using System.Data.SqlClient;

namespace RestaurantController
{
    public class BillController
    {
        public void UpdateBill(BillsDataSet.BillDataTable BillDataTable)
        {
            try
            {
                BillTableAdapter BillTableAdapter = new BillTableAdapter();
                BillTableAdapter.Update(BillDataTable);
            }
            catch
            {
                throw;
            }
        }

        public void GetBillByBillId(BillsDataSet.BillDataTable BillDataTable, string BillId)
        {
            using (var billAdapter = new BillTableAdapter())
            {
                billAdapter.FillByBillId(BillDataTable, BillId);
            }
        }

        public void GetAllBill(BillsDataSet.BillDataTable BillDataTable)
        {
            using (var billAdapter = new BillTableAdapter())
            {
                billAdapter.Fill(BillDataTable);
            }
        }

        public void GetBillByTableIdAndStatus(BillsDataSet.BillDataTable BillDataTable, int tableId, int status)
        {
            using (var billAdapter = new BillTableAdapter())
            {
                billAdapter.FillByTableIdAndStatus(BillDataTable, tableId, status);
            }
        }

        public void SearchBillByBillEntity(BillsDataSet.ReportBillDataTable reportBillDataTable, BillEntity billEntity)
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

                    reportBillDataTable.Clear();

                    // Fill thông tin người dùng vào View
                    sqlDataAdapter.Fill(reportBillDataTable);
                }
            }
            finally
            {
                sqlConnection.Close();
            }
        }

        private string CreateWherePhrase(BillEntity billEntity)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(" WHERE 1=1 ");
            sb.AppendLine(" AND (Bill.Status = @Status) ");

            if (billEntity.StaffId != 0)
            {
                sb.AppendLine(" AND (Bill.StaffId = @StaffId)");
            }

            if (billEntity.FromMonth != 0)
                sb.AppendLine(" AND (MONTH(Bill.BillDate) >= @FromMonth)");

            if (billEntity.FromYear != 0)
                sb.AppendLine(" AND (YEAR(Bill.BillDate) >=  @FromYear)");

            if (billEntity.ToMonth != 0)
                sb.AppendLine(" AND (MONTH(Bill.BillDate) <= @ToMonth)");

            if (billEntity.ToYear != 0)
                sb.AppendLine(" AND (YEAR(Bill.BillDate) <= @ToYear)");

            if (!string.IsNullOrEmpty(billEntity.FromDate))
            {
                sb.AppendLine(" AND (Bill.BillDate >= @FromDate)");
            }

            if (!string.IsNullOrEmpty(billEntity.ToDate))
            {
                sb.AppendLine(" AND (Bill.BillDate <= @ToDate)");
            }
            return sb.ToString();
        }

        private string CreateFillQuery(BillEntity billEntity)
        {
            StringBuilder query = new StringBuilder();
            query.AppendLine("SELECT");
            query.AppendLine("COUNT(BillId) as CountBill,");
            query.AppendLine("SUM(TotalCost) as TotalMoney");
            query.AppendLine("FROM");
            query.AppendLine("Bill ");

            query.AppendLine(CreateWherePhrase(billEntity));
            return query.ToString();
        }

        private SqlParameter[] CreateSqlParameters(BillEntity billEntity)
        {
            List<SqlParameter> list = new List<SqlParameter>();

            // Trường hợp có chọn Id nhân viên
            if (billEntity.StaffId != 0)
            {
                list.Add(new SqlParameter("@StaffId", billEntity.StaffId));
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

            if (billEntity.FromDate != null)
            {
                list.Add(new SqlParameter("@FromDate", billEntity.FromDate));
            }

            if (billEntity.Status != -1)
            {
                list.Add(new SqlParameter("@Status", billEntity.Status));
            }

            if (!string.IsNullOrEmpty(billEntity.BillCode))
            {
                list.Add(new SqlParameter("@BillCode", billEntity.BillCode));
            }

            if (billEntity.ShiftId != 0)
            {
                list.Add(new SqlParameter("@ShiftId", billEntity.ShiftId));
            }

            return list.ToArray();
        }

        public void SearchBillByBillEntity(BillsDataSet.SearchBillDataTable searchBillDataTable, BillEntity billEntity)
        {
            // KHởi tạo connection 
            string ConnectString = DataBaseConnection.GetConnectString();
            SqlConnection sqlConnection = new SqlConnection(ConnectString);
            try
            {
                // Khởi tạo command
                using (SqlCommand command = new SqlCommand(CreateFillQueryBillSearch(billEntity), sqlConnection))
                {
                    command.Parameters.AddRange(CreateSqlParameters(billEntity));
                    command.Connection.Open();
                    SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();

                    sqlDataAdapter.SelectCommand = command;

                    searchBillDataTable.Clear();

                    // Fill thông tin người dùng vào View
                    sqlDataAdapter.Fill(searchBillDataTable);
                }
            }
            finally
            {
                sqlConnection.Close();
            }
        }

        private string CreateFillQueryBillSearch(BillEntity billEntity)
        {
            StringBuilder query = new StringBuilder();
            query.Append("SELECT ");
            query.Append("Bill.BillId,");
            query.Append("Bill.BillCode,");
            query.Append("Tables.TableName,");
            query.Append("Customers.CustomerName,");
            query.Append("Bill.ShiftId,");
            query.Append("Bill.TotalCost,");
            query.Append("Shifts.ShiftName,");
            query.Append("Staffs.FullName,");
            query.Append("Staffs.UserName,");
            query.Append("Bill.StaffId,");
            query.Append("Bill.BillDate,");
            query.Append("Bill.Status,");
            query.Append("Bill.Note ");
            query.Append("FROM Bill ");
            query.Append("INNER JOIN Staffs ");
            query.Append("ON Bill.StaffId = Staffs.StaffId ");
            query.Append("INNER JOIN Shifts ");
            query.Append("ON Bill.ShiftId = Shifts.ShiftId ");
            query.Append("INNER JOIN Tables ");
            query.Append("ON Bill.TableId = Tables.TableId ");
            query.Append("LEFT OUTER JOIN Customers ");
            query.Append("ON Bill.CustomerId = Customers.CustomerId ");

            query.AppendLine(CreateWherePhraseBillSearch(billEntity));
            return query.ToString();
        }

        private string CreateWherePhraseBillSearch(BillEntity billEntity)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(" WHERE 1=1 ");

            if (billEntity.Status != -1)
            {
                sb.AppendLine(" AND (Bill.Status = @Status) ");
            }
            if (billEntity.StaffId != 0)
            {
                sb.AppendLine(" AND (Bill.StaffId = @StaffId)");
            }

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

            if (!string.IsNullOrEmpty(billEntity.BillCode))
            {
                sb.AppendLine(" AND (Bill.BillCode= @BillCode)");
            }
            if (billEntity.ShiftId != 0)
            {
                sb.AppendLine(" AND (Bill.ShiftId= @ShiftId)");
            }
            return sb.ToString();
        }

        public void GetAllBillByMenuId(BillsDataSet.BillByMenuDataTable billByMenuDataTable, BillEntity billEntity)
        {
            // KHởi tạo connection 
            string ConnectString = DataBaseConnection.GetConnectString();
            SqlConnection sqlConnection = new SqlConnection(ConnectString);
            try
            {
                // Khởi tạo command
                using (SqlCommand command = new SqlCommand(CreateFillQueryBillByMenu(billEntity), sqlConnection))
                {
                    command.Parameters.AddRange(CreateSqlParametersBillByMenu(billEntity));
                    command.Connection.Open();
                    SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();

                    sqlDataAdapter.SelectCommand = command;

                    billByMenuDataTable.Clear();

                    // Fill thông tin người dùng vào View
                    sqlDataAdapter.Fill(billByMenuDataTable);
                }
            }
            finally
            {
                sqlConnection.Close();
            }
        }

        private string CreateFillQueryBillByMenu(BillEntity billEntity)
        {
            StringBuilder query = new StringBuilder();
            query.Append("SELECT ");
            query.Append("dbo.Bill.BillId, ");
            query.Append("dbo.Bill.BillCode, ");
            query.Append("dbo.Bill.BillDate, ");
            query.Append("dbo.BillDetail.Quatity, ");
            query.Append("dbo.BillDetail.UnitName ");
            query.Append("FROM dbo.Bill INNER JOIN ");
            query.Append("dbo.BillDetail  ON dbo.Bill.BillId = dbo.BillDetail.BillId ");
            query.AppendLine(CreateWherePhraseBillByMenu(billEntity));
            return query.ToString();
        }

        private string CreateWherePhraseBillByMenu(BillEntity billEntity)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(" WHERE dbo.BillDetail.MenuId = @MenuId ");

            if (!string.IsNullOrEmpty(billEntity.FromDate))
            {
                sb.AppendLine(" AND (dbo.Bill.BillDate >= @FromDate)");
            }

            if (!string.IsNullOrEmpty(billEntity.ToDate))
            {
                sb.AppendLine(" AND (dbo.Bill.BillDate <= @ToDate)");
            }

            if (billEntity.FromMonth != 0)
                sb.AppendLine(" AND (MONTH(Bill.BillDate) >= @FromMonth)");

            if (billEntity.FromYear != 0)
                sb.AppendLine(" AND (YEAR(Bill.BillDate) >=  @FromYear)");

            if (billEntity.ToMonth != 0)
                sb.AppendLine(" AND (MONTH(Bill.BillDate) <= @ToMonth)");

            if (billEntity.ToYear != 0)
                sb.AppendLine(" AND (YEAR(Bill.BillDate) <= @ToYear)");

            return sb.ToString();
        }

        private SqlParameter[] CreateSqlParametersBillByMenu(BillEntity billEntity)
        {
            List<SqlParameter> list = new List<SqlParameter>();

            // Trường hợp có chọn Id nhân viên
            if (billEntity.MenuId != 0)
            {
                list.Add(new SqlParameter("@MenuId", billEntity.MenuId));
            }

            // Trường hợp có nhập Id vụ khảo nghiệm
            if (billEntity.ToDate != null)
            {
                list.Add(new SqlParameter("@ToDate", billEntity.ToDate));
            }

            if (billEntity.FromDate != null)
            {
                list.Add(new SqlParameter("@FromDate", billEntity.FromDate));
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

            return list.ToArray();
        }

        public void CountMeterialQuantity(BillsDataSet.CountMenuIdDataTable countMenuIdDataTable, BillEntity billEntity)
        {
            // KHởi tạo connection 
            string ConnectString = DataBaseConnection.GetConnectString();
            SqlConnection sqlConnection = new SqlConnection(ConnectString);
            try
            {
                // Khởi tạo command
                using (SqlCommand command = new SqlCommand(CreateFillQueryCountMenuId(billEntity), sqlConnection))
                {
                    command.Parameters.AddRange(CreateSqlParametersCountMenuId(billEntity));
                    command.Connection.Open();
                    SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();

                    sqlDataAdapter.SelectCommand = command;

                    countMenuIdDataTable.Clear();

                    // Fill thông tin người dùng vào View
                    sqlDataAdapter.Fill(countMenuIdDataTable);
                }
            }
            finally
            {
                sqlConnection.Close();
            }
        }

        private SqlParameter[] CreateSqlParametersCountMenuId(BillEntity billEntity)
        {
            List<SqlParameter> list = new List<SqlParameter>();

            // Trường hợp có chọn Id nhân viên
            if (billEntity.MenuId != 0)
            {
                list.Add(new SqlParameter("@MenuId", billEntity.MenuId));
            }

            // Trường hợp có nhập Id vụ khảo nghiệm
            if (billEntity.ToDate != null)
            {
                list.Add(new SqlParameter("@ToDate", billEntity.ToDate));
            }

            if (billEntity.FromDate != null)
            {
                list.Add(new SqlParameter("@FromDate", billEntity.FromDate));
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

            return list.ToArray();
        }

        private string CreateFillQueryCountMenuId(BillEntity billEntity)
        {
            StringBuilder query = new StringBuilder();
            query.AppendLine("SELECT ");
            query.AppendLine("BillDetail.MenuId, SUM(BillDetail.Quatity) AS TotalQuantity ");
            query.AppendLine("FROM  Bill INNER JOIN");
            query.AppendLine("BillDetail ON Bill.BillId = BillDetail.BillId ");
            query.AppendLine(CreateWherePhraseCountMenuId(billEntity));
            query.AppendLine(" GROUP BY BillDetail.MenuId");
            return query.ToString();
        }

        private string CreateWherePhraseCountMenuId(BillEntity billEntity)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(" WHERE dbo.BillDetail.MenuId = @MenuId ");

            if (!string.IsNullOrEmpty(billEntity.FromDate))
            {
                sb.AppendLine(" AND (dbo.Bill.BillDate >= @FromDate)");
            }

            if (!string.IsNullOrEmpty(billEntity.ToDate))
            {
                sb.AppendLine(" AND (dbo.Bill.BillDate <= @ToDate)");
            }

            if (billEntity.FromMonth != 0)
                sb.AppendLine(" AND (MONTH(Bill.BillDate) >= @FromMonth)");

            if (billEntity.FromYear != 0)
                sb.AppendLine(" AND (YEAR(Bill.BillDate) >=  @FromYear)");

            if (billEntity.ToMonth != 0)
                sb.AppendLine(" AND (MONTH(Bill.BillDate) <= @ToMonth)");

            if (billEntity.ToYear != 0)
                sb.AppendLine(" AND (YEAR(Bill.BillDate) <= @ToYear)");

            return sb.ToString();
        }
    }
}

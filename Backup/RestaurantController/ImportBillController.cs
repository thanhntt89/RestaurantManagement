using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RestaurantDTO;
using RestaurantDTO.ImportBillDataSetTableAdapters;
using System.Data.SqlClient;

namespace RestaurantController
{
    public class ImportBillController
    {
        public void UpdateImportBill(ImportBillDataSet.ImportBillDataTable ImportBillDataTable)
        {
            try
            {
                var ImportBillTableAdapter = new ImportBillTableAdapter();
                ImportBillTableAdapter.Update(ImportBillDataTable);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void GetByImportId(ImportBillDataSet.ImportBillDataTable ImportBillDataTable, string ImportId)
        {
            using (var ImportBillTableAdapter = new ImportBillTableAdapter())
            {
                ImportBillTableAdapter.FillByImportId(ImportBillDataTable, ImportId);
            }
        }

        public void GetImportBillByAll(ImportBillDataSet.ImportBillDataTable ImportBillDataTable)
        {
            using (var ImportBillTableAdapter = new ImportBillTableAdapter())
            {
                ImportBillTableAdapter.FillByAll(ImportBillDataTable);
            }
        }

        public void SearchImportBillByBillEntity(ImportBillDataSet.ImportBillReportDataTable importBillReportDataTable, BillEntity billEntity)
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

                    importBillReportDataTable.Clear();

                    // Fill thông tin người dùng vào View
                    sqlDataAdapter.Fill(importBillReportDataTable);
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

            sb.AppendLine(" WHERE (1 = 1) ");//

            // Trường hợp có nhập Id loài
            if (billEntity.StaffId != 0)
            {
                sb.AppendLine(" AND (ImportBill.StaffId = @StaffId)");
            }

            if (!string.IsNullOrEmpty(billEntity.BillCode))
            {
                sb.AppendLine(" AND (ImportBill.BillCode = @BillCode)");
            }

            if (billEntity.FromMonth != 0)
                sb.AppendLine(" AND (MONTH(DateTime) >= @FromMonth)");
            if (billEntity.FromYear != 0)
                sb.AppendLine(" AND (YEAR(DateTime) >=  @FromYear)");

            if (!string.IsNullOrEmpty(billEntity.FromDate))
            {
                sb.AppendLine(" AND (DateTime >= @FromDate)");
            }
            if (billEntity.ToMonth != 0)
                sb.AppendLine(" AND (MONTH(DateTime) <= @ToMonth)");
             if (billEntity.ToYear != 0)
                sb.AppendLine(" AND (YEAR(DateTime) <= @ToYear)");

            if (!string.IsNullOrEmpty(billEntity.ToDate))
            {
                sb.AppendLine(" AND (DateTime <= @ToDate)");
            }

            return sb.ToString();
        }

        private string CreateFillQuery(BillEntity billEntity)
        {
            StringBuilder query = new StringBuilder();
            query.AppendLine("SELECT");
            query.AppendLine("COUNT(ImportId) as CountBill,");
            query.AppendLine("SUM(TotalMoney) as TotalMoney");
            query.AppendLine("FROM");
            query.AppendLine("ImportBill");

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

            // Trường hợp tìm kiếm trong giống điển hình
            if (billEntity.Status != -1)
            {
                list.Add(new SqlParameter("@Status", billEntity.Status));
            }

            if (!string.IsNullOrEmpty(billEntity.BillCode))
            {
                list.Add(new SqlParameter("@BillCode", billEntity.BillCode));
            }

            return list.ToArray();
        }

        public void SearchImportBillByBillEntity(ImportBillDataSet.SearchImportBillsDataTable searchImportBillsDataTable, BillEntity billEntity)
        {
            // KHởi tạo connection  
            string ConnectString = DataBaseConnection.GetConnectString();
            SqlConnection sqlConnection = new SqlConnection(ConnectString);
            try
            {
                // Khởi tạo command
                using (SqlCommand command = new SqlCommand(CreateFillQuerySearchImportBill(billEntity), sqlConnection))
                {
                    command.Parameters.AddRange(CreateSqlParameters(billEntity));
                    command.Connection.Open();
                    SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();

                    sqlDataAdapter.SelectCommand = command;

                    searchImportBillsDataTable.Clear();

                    // Fill thông tin người dùng vào View
                    sqlDataAdapter.Fill(searchImportBillsDataTable);
                }
            }
            finally
            {
                sqlConnection.Close();
            }
        }

        private string CreateFillQuerySearchImportBill(BillEntity billEntity)
        {
            StringBuilder query = new StringBuilder();
            query.AppendLine("SELECT ");
            query.AppendLine("ImportBill.ImportId,");
            query.AppendLine("ImportBill.ImportBillCode,");
            query.AppendLine("ImportBill.DateTime,");
            query.AppendLine("ImportBill.Note,");
            query.AppendLine("ImportBill.TotalMoney,");
            query.AppendLine("ImportBill.StaffId,");
            query.AppendLine("Staffs.FullName ");
            query.AppendLine("FROM ImportBill ");
            query.AppendLine("LEFT OUTER JOIN ");
            query.AppendLine("Staffs ON ImportBill.StaffId = Staffs.StaffId");

            query.AppendLine(CreateWherePhrase(billEntity));
            return query.ToString();
        }

    }
}

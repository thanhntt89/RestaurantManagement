using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RestaurantDTO;
using RestaurantDTO.MeterialDataSetTableAdapters;
using System.Data.SqlClient;

namespace RestaurantController
{
    public class MeterialController
    {
        public void UpdateMeterial(MeterialDataSet.MeterialsDataTable MeterialsDataTable)
        {
            try
            {
                var MeterialsTableAdapter = new MeterialsTableAdapter();
                MeterialsTableAdapter.Update(MeterialsDataTable);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void GetByMerterialId(MeterialDataSet.MeterialsDataTable MeterialsDataTable, int meterialId)
        {
            using (var MeterialsTableAdapter = new MeterialsTableAdapter())
            {
                MeterialsTableAdapter.FillByMeterialId(MeterialsDataTable, meterialId);
            }
        }

        public void GetBySubMeterialGroupId(MeterialDataSet.MeterialsDataTable MeterialsDataTable, int SubMeterialGroupId)
        {
            using (var MeterialsTableAdapter = new MeterialsTableAdapter())
            {
                MeterialsTableAdapter.FillBySubMeterialGroupId(MeterialsDataTable, SubMeterialGroupId);
            }
        }

        public void GetByMerterialId(MeterialDataSet.MeterialUnitAndSubGroupMeterialDataTable MeterialUnitAndSubGroupMeterialDataTable, int meterialId)
        {
            using (var adapter = new MeterialUnitAndSubGroupMeterialTableAdapter())
            {
                adapter.FillMeterialId(MeterialUnitAndSubGroupMeterialDataTable, meterialId);
            }
        }

        public void GetMeterialByAll(MeterialDataSet.MeterialsDataTable MeterialsDataTable)
        {
            using (var MeterialsTableAdapter = new MeterialsTableAdapter())
            {
                MeterialsTableAdapter.FillByAll(MeterialsDataTable);
            }
        }

        public void GetBySubMeterialGroupId(MeterialDataSet.MeterialUnitAndSubGroupMeterialDataTable MeterialUnitAndSubGroupMeterialDataTable, int SubMeterialGroupId)
        {
            using (var MeterialUnitAndSubGroupMeterialTableAdapter = new MeterialUnitAndSubGroupMeterialTableAdapter())
            {
                MeterialUnitAndSubGroupMeterialTableAdapter.FillBySubMeterialGroupId(MeterialUnitAndSubGroupMeterialDataTable, SubMeterialGroupId);
            }
        }

        public void GetMeterialByAll(MeterialDataSet.MeterialUnitAndSubGroupMeterialDataTable meterialUnitAndSubGroupMeterialDataTable)
        {
            using (var meterialUnitAndSubgroupMeterialAdapter = new MeterialUnitAndSubGroupMeterialTableAdapter())
            {
                meterialUnitAndSubgroupMeterialAdapter.FillByAll(meterialUnitAndSubGroupMeterialDataTable);
            }
        }

        public void GetMeterialByMeterialCode(MeterialDataSet.MeterialsDataTable meterialsDataTable, string meterialCode)
        {
            using (var meterialsTableAdapter = new MeterialsTableAdapter())
            {
                meterialsTableAdapter.FillByMeterialCode(meterialsDataTable, meterialCode);
            }
        }


        public void SearchMeterialImportByBillEntity(MeterialDataSet.MeterialImportDataTable meterialImportDataTable, BillEntity billEntity)
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

                    meterialImportDataTable.Clear();

                    // Fill thông tin người dùng vào View
                    sqlDataAdapter.Fill(meterialImportDataTable);
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

            query.AppendLine("SELECT ");
            query.AppendLine(" dbo.Meterials.MeterialCode,");
            query.AppendLine("dbo.Meterials.MeterialName,");
            query.AppendLine("dbo.Unit.UnitName,");
            query.AppendLine("SUM(dbo.ImportBillDetail.Quantity)AS Quantity,");
            query.AppendLine("SUM(dbo.ImportBillDetail.Cost*dbo.ImportBillDetail.Quantity) AS MoneyTotal");
            query.AppendLine("FROM dbo.ImportBillDetail ");
            query.AppendLine("INNER JOIN ");
            query.AppendLine("dbo.Meterials ON ");
            query.AppendLine("dbo.ImportBillDetail.MeterialId = dbo.Meterials.MeterialId ");
            query.AppendLine("INNER JOIN ");
            query.AppendLine(" dbo.Unit ON ");
            query.AppendLine(" dbo.Meterials.UnitId = dbo.Unit.UnitId INNER JOIN");
            query.AppendLine("dbo.ImportBill ON ");
            query.AppendLine("dbo.ImportBillDetail.ImportBillId = dbo.ImportBill.ImportId");

            query.AppendLine(CreateWherePhrase(billEntity));

            query.AppendLine(" GROUP BY dbo.Meterials.MeterialCode, dbo.Meterials.MeterialName,dbo.Unit.UnitName");
            return query.ToString();
        }

        private string CreateWherePhrase(BillEntity billEntity)
        {

            StringBuilder sb = new StringBuilder();

            sb.AppendLine(" WHERE 1=1 ");// (1 = 1) 

            if (billEntity.MeterialId != 0)
                sb.AppendLine(" AND (ImportBillDetail.MeterialId = @MeterialId) ");
            
                //if (billEntity.FromYear != 0 && billEntity.FromMonth != 0)
                //    sb.AppendLine(" AND (MONTH(dbo.ImportBill.DateTime) >= @FromMonth) AND (YEAR(dbo.ImportBill.DateTime) >= @FromYear)");
                //else
            if (billEntity.FromMonth != 0)
                    sb.AppendLine(" AND (MONTH(dbo.ImportBill.DateTime) >= @FromMonth)");
            if (billEntity.FromYear != 0)
                    sb.AppendLine(" AND (YEAR(dbo.ImportBill.DateTime) >=  @FromYear)");

            if (!string.IsNullOrEmpty(billEntity.FromDate))
            {
                sb.AppendLine(" AND (ImportBill.DateTime >= @FromDate)");
            }
            
            //if (billEntity.ToYear != 0 && billEntity.ToMonth != 0)
            //    sb.AppendLine(" AND (MONTH(dbo.ImportBill.DateTime) <= @ToMonth)  AND (YEAR(dbo.ImportBill.DateTime) <= @ToYear)");
            //else 
                if (billEntity.ToMonth != 0)
                sb.AppendLine(" AND (MONTH(dbo.ImportBill.DateTime) <= @ToMonth)");
             if (billEntity.ToYear != 0)
                sb.AppendLine(" AND (YEAR(dbo.ImportBill.DateTime) <= @ToYear)");

            if (!string.IsNullOrEmpty(billEntity.ToDate))
            {
                sb.AppendLine(" AND (ImportBill.DateTime <= @ToDate)");
            }

            return sb.ToString();
        }

        private SqlParameter[] CreateSqlParameters(BillEntity billEntity)
        {
            List<SqlParameter> list = new List<SqlParameter>();

            // Trường hợp có nhập Id vụ khảo nghiệm
            if (billEntity.MeterialId != 0)
            {
                list.Add(new SqlParameter("@MeterialId", billEntity.MeterialId));
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

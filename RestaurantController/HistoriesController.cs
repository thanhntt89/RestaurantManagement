using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RestaurantDTO;
using RestaurantDTO.HistoriesDataSetTableAdapters;

namespace RestaurantController
{
    public class HistoriesController
    {
        public static void UpdateHistories(HistoriesDataSet.LogHistoryDataTable logHistoryDataTable)
        {
            try
            {
                LogHistoryTableAdapter logHistoryTableAdapter = new LogHistoryTableAdapter();
                logHistoryTableAdapter.Update(logHistoryDataTable);
            }
            catch 
            {
                throw;
            }
        }

        public static void GetAllHistories(HistoriesDataSet.LogHistoryDataTable logHistoryDataTable)
        {
            try
            {
                LogHistoryTableAdapter logHistoryTableAdapter = new LogHistoryTableAdapter();
                logHistoryTableAdapter.Fill(logHistoryDataTable);
            }
            catch
            {
                throw;
            }
        }

        public static void GetHistoriesByHistoriesId(HistoriesDataSet.LogHistoryDataTable logHistoryDataTable, Int64 historiesId)
        {
            try
            {
                LogHistoryTableAdapter logHistoryTableAdapter = new LogHistoryTableAdapter();
                logHistoryTableAdapter.FillByHistoryId(logHistoryDataTable, historiesId);
            }
            catch
            {
                throw;
            }
        }
    }
}

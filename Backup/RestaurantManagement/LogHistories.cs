using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RestaurantDTO;
using RestaurantController;

namespace RestaurantManagement
{
    public class LogHistories
    {

        public static void InsertLogHistories(string contenLog, DateTime dateTime, string userName, string note)
        {
            HistoriesDataSet.LogHistoryDataTable logHistoryDataTable = new HistoriesDataSet.LogHistoryDataTable();
            var newRow = logHistoryDataTable.NewLogHistoryRow();
            newRow.ContentsLog = contenLog;
            newRow.DateTime = dateTime;
            newRow.UserName = userName;
            newRow.Note = note;

            logHistoryDataTable.AddLogHistoryRow(newRow);

            try
            {
                HistoriesController.UpdateHistories(logHistoryDataTable);
            }
            catch 
            {
            }
        }
    }
}

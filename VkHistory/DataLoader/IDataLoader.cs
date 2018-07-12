using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VkHistory.HistoryData.SearchHistoryData;

namespace VkHistory.DataLoader
{
    public interface IDataLoader
    {
        ISearchHistoryData loadData(string directoryPath);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VkHistory.HistoryData.SearchHistoryData;
using VK_COM.Enums;

namespace VkHistory.HistoryStorage.SearchHistoryStorage
{
    public interface ISearchHistoryStorage : IHistoryStorage
    {
        void saveSearchHistoryData(ISearchHistoryData hData);
        ISearchHistoryData loadSearchHistoryData(string coreId, SearchType sType);
    }
}

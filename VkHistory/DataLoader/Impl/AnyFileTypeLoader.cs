using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VkHistory.HistoryData.SearchHistoryData;
using VK_COM.Enums;
using VkHistory.HistoryData.SearchHistoryData.Impl;
using VkHistory.Utils;

namespace VkHistory.DataLoader.Impl
{
    public class AnyFileTypeLoader : IDataLoader
    {
        #region IDataLoader Members

        public ISearchHistoryData loadData(string directoryPath)
        {
            ISearchHistoryData data = new PeopleSearchHistoryData();
            data.SearchIds = FileStorageProcessor.getLines(directoryPath);
            return data;
        }

        #endregion

    }
}

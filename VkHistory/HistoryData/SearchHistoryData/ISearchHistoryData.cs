using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VK_COM.Enums;

namespace VkHistory.HistoryData.SearchHistoryData
{
    public abstract class ISearchHistoryData : IHistoryData
    {
        private DateTime searchTimestamp = DateTime.Now;
        private List<string> searchIds = null;
        private SearchType sType = SearchType.Unknown;

        public SearchType SearchDataType { get { return sType; } set { sType = value; } }
        public DateTime SearchTimestamp { get { return searchTimestamp; } set { searchTimestamp = value; } }
        public List<string> SearchIds { get { return searchIds; } set { searchIds = value; } }
    }
}

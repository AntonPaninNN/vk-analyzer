using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VK_COM.Enums;

namespace VkHistory.HistoryData.SearchHistoryData.Impl
{
    class GroupsSearchHistoryData : ISearchHistoryData
    {
        public GroupsSearchHistoryData()
        {
            SearchDataType = SearchType.Groups;
        }
    }
}

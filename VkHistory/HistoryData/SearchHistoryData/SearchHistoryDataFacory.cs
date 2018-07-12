using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VK_COM.Enums;
using VkHistory.HistoryData.SearchHistoryData.Impl;

namespace VkHistory.HistoryData.SearchHistoryData
{
    public class SearchHistoryDataFacory
    {
        public static ISearchHistoryData createSearchHistoryData(SearchType sType)
        {
            if (sType == SearchType.People)
                return new PeopleSearchHistoryData();
            else if (sType == SearchType.Groups)
                return new GroupsSearchHistoryData();
            else if (sType == SearchType.Unknown)
                return null;

            return null;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VkSearch.Factory;
using VK_COM.Enums;
using VkSearch.Profiles;
using VkSearch.Strategy;
using VkCommands.Data;
using VkCommands.Data.Impl;
using VkSearch.Events;

namespace VkSearch.Helpers.Impl
{
    public class SearchHelper : IHelper
    {
        private static ITreeSearchStrategy strategy = null;

        public static List<User> performeTreesSearchForPeople(string coreId, int depth, 
            Dictionary<string, string> criteria, ISearchSubscriber subscriber, bool checkFriends)
        {
            ISearchProfile sProfile = SearchProfileFactory.createSearchProfile(SearchType.People);
            strategy = 
                SearchStrategyFactory.createTreeSearchStrategy(SearchStrategyType.BalancedTrees);

            strategy.CoreId = coreId;
            strategy.OnFirstStep = true;
            strategy.Depth = depth;
            sProfile.Criteria = criteria;
            sProfile.CheckFriends = checkFriends;
            List<IData> targets = strategy.search(sProfile, subscriber);

            return targets.Cast<User>().ToList();
        }

        public static void stopSearch()
        {
            strategy.stopSearch();
        }
    }
}

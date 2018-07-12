using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VkSearch.Strategy;
using VK_COM.Enums;
using VkSearch.Strategy.Impl;

namespace VkSearch.Factory
{
    class SearchStrategyFactory
    {
        public static ITreeSearchStrategy createTreeSearchStrategy(SearchStrategyType sType)
        {
            if (sType == SearchStrategyType.BalancedTrees)
                return new BalancedTreesSearchStrategy();
            else
                return null;
        }
    }
}

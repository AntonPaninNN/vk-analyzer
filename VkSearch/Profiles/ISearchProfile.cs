using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VK_COM.Enums;

namespace VkSearch.Profiles
{
    public abstract class ISearchProfile
    {
        private SearchType target = SearchType.Unknown;
        private int count;
        private List<string> matchedIds; /* not used now */
        private Dictionary<string, string> criteria;
        private bool checkFriends = false;

        public List<string> MatchedIds { get { return matchedIds; } set { matchedIds = value; } }
        public int Count { get { return count; } set { count = value; } }
        public SearchType SearchTarget { get { return target; } set { target = value; } }
        public Dictionary<string, string> Criteria { get { return criteria; } set { criteria = value; } }
        public bool CheckFriends { get { return checkFriends; } set { checkFriends = value; } }
    }
}

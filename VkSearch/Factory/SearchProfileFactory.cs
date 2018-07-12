using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VkSearch.Profiles;
using VK_COM.Enums;
using VkSearch.Profiles.Impl;

namespace VkSearch.Factory
{
    class SearchProfileFactory
    {
        public static ISearchProfile createSearchProfile(SearchType sType)
        {
            if (sType == SearchType.People)
                return new PeopleSearchProfile();
            else if (sType == SearchType.Groups)
                return new GroupSearchProfile();
            else
                return null;
        }
    }
}

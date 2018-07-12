using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VkSearch.Profiles;
using VkCommands.Data;
using VkSearch.Events;

namespace VkSearch.Strategy
{
    public abstract class ISearchStrategy
    {
        protected bool isStopped = false;

        public abstract List<IData> search(ISearchProfile sProfile, ISearchSubscriber subscriber);

        public void stopSearch()
        {
            isStopped = true;
        }
    }
}

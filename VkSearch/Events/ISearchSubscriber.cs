using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VkSearch.Events
{
    public interface ISearchSubscriber
    {
        void onItemFoundEvent(ISearchEvent evt);

        void onSearchStarted();

        void onSearchFinished();
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VkSearch.Events;

namespace VkAnalyzer.Fake
{
    public class FakeSearchSubscriber : ISearchSubscriber
    {
        private FakeSearchSubscriber()
        { }

        private static FakeSearchSubscriber _fake = null;

        public static FakeSearchSubscriber getInstance()
        {
            if (_fake == null)
                _fake = new FakeSearchSubscriber();

            return _fake;
        }

        #region ISearchSubscriber Members

        public void onItemFoundEvent(ISearchEvent evt)
        { }

        public void onSearchStarted()
        { }

        public void onSearchFinished()
        { }

        #endregion


    }
}

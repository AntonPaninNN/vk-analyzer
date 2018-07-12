using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VkSearch.Events.EventsImpl
{
    public abstract class ItemUpdatedAbstractEvent : ISearchEvent
    {
        protected string _item;

        #region ISearchEvent Members

        public string getItem()
        {
            return _item;
        }

        #endregion
    }
}

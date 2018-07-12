using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VkSearch.Events.EventsImpl
{
    public class ItemUpdatedEvent : ItemUpdatedAbstractEvent
    {
        public ItemUpdatedEvent(string item)
        {
            _item = item;
        }
    }
}

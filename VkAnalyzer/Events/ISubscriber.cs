using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VkAnalyzer.Events.Events;

namespace VkAnalyzer.Events
{
    public interface ISubscriber
    {
        void onEvent(IEvent evt);
    }
}

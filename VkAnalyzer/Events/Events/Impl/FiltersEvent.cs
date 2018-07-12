using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VkAnalyzer.Events.Events
{
    class FiltersEvent : IEvent
    {
        public FiltersEvent(Dictionary<string, string> parameters)
        {
            Parameters = parameters;
        }
    }
}

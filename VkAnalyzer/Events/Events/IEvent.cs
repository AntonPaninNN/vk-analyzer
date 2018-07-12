using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VkAnalyzer.Events.Events
{
    public abstract class IEvent
    {
        private Dictionary<string, string> parameters;

        public Dictionary<string, string> Parameters 
        { get { return parameters; } set { parameters = value; } }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VK_COM.Enums;

namespace VkScheduler.ScheduleEvent
{
    abstract class IScheduleEvent
    {
        private ScheduleType sType = ScheduleType.Unknown;
        private DateTime eventTime = DateTime.Now;

        public DateTime EventTime { get { return eventTime; } set { eventTime = value; } }
        public ScheduleType ScheduleType { get { return sType; } set { sType = value; } }
    }
}

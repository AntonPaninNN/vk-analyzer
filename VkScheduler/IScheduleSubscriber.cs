using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VK_COM.Enums;
using VkScheduler.ScheduleEvent;

namespace VkScheduler
{
    abstract class IScheduleSubscriber
    {
        private ScheduleType sType = ScheduleType.Unknown;

        public ScheduleType ScheduleType { get { return sType; } set { sType = value; } }

        public abstract void onScheduleEvent(IScheduleEvent sEvent);
    }
}

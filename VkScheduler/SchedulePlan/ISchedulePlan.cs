using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VK_COM.Enums;

namespace VkScheduler.SchedulePlan
{
    abstract class ISchedulePlan
    {
        private ScheduleType sType = ScheduleType.Unknown;
        private List<IScheduleSubscriber> sSubscribers = null;

        public ScheduleType ScheduleType { get { return sType; } set { sType = value; } }

        public void subscribeToScheduleEvent(IScheduleSubscriber sSubscriber)
        {
            if (sSubscribers == null)
                sSubscribers = new List<IScheduleSubscriber>();

            sSubscribers.Add(sSubscriber);
        }

        public abstract void startSchedule();

        public abstract void stopSchedule();
    }
}

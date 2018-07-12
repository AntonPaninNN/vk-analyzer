using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VkScheduler.SchedulePlan.Impl
{
    class IntervalSchedulePlan : ISchedulePlan
    {
        public IntervalSchedulePlan()
        {
            ScheduleType = VK_COM.Enums.ScheduleType.Interval;
        }

        private DateTime interval = DateTime.Now;

        public DateTime Interval { get { return interval; } set { interval = value; } }

        public override void startSchedule()
        {
            throw new NotImplementedException();
        }

        public override void stopSchedule()
        {
            throw new NotImplementedException();
        }
    }
}

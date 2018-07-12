using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VkScheduler.SchedulePlan.Impl
{
    class EveryDaySchedulePlan : ISchedulePlan
    {
        public EveryDaySchedulePlan()
        {
            ScheduleType = VK_COM.Enums.ScheduleType.EveryDay;
        }

        private List<DateTime> timesWhenFire = null;

        public List<DateTime> TimesWhenFire { get { return timesWhenFire; } set { timesWhenFire = value; } }

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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VK_COM.Enums;
using VkScheduler.SchedulePlan.Impl;

namespace VkScheduler.SchedulePlan
{
    class SchedulePlanFactory
    {
        public static ISchedulePlan createSchedulePlan(ScheduleType sType)
        {
            if (sType == ScheduleType.Interval)
                return new IntervalSchedulePlan();
            else if (sType == ScheduleType.EveryDay)
                return new EveryDaySchedulePlan();
            else if (sType == ScheduleType.Unknown)
                return null;

            return null;
        }
    }
}

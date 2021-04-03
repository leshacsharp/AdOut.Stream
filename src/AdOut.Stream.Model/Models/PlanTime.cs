using System.Collections.Generic;

namespace AdOut.Stream.Model.Models
{
    public class PlanTime
    {
        public IEnumerable<AdPlanTime> Ads { get; set; }

        public IEnumerable<SchedulePeriod> Schedules { get; set; }
    }
}

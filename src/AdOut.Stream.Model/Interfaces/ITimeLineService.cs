using AdOut.Stream.Model.Models;
using System;
using System.Collections.Generic;

namespace AdOut.Stream.Model.Interfaces
{
    public interface ITimeLineService
    {
        List<TimeAdBlock> GenerateTimeLine(List<PlanTime> plans, DateTime start, DateTime end);
        List<TimeAdBlock> GenerateTimeAdBlocks(PlanTime plan, DateTime start, DateTime end);
    }
}

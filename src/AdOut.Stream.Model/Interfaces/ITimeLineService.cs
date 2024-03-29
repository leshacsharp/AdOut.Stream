﻿using AdOut.Stream.Model.Models;
using System;
using System.Collections.Generic;

namespace AdOut.Stream.Model.Interfaces
{
    public interface ITimeLineService
    {
        List<TimeBlock> GenerateTimeLine(List<PlanTime> plans, DateTime forDate, TimeSpan fromTime);
        List<TimeBlock> MergeTimeLine(List<TimeBlock> timeLine, PlanTime newPlan, DateTime forDate, TimeSpan fromTime);
    }
}

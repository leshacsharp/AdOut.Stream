using AdOut.Stream.Model.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdOut.Stream.Model.Interfaces
{
    public interface IPlanService
    {
        Task<List<PlanTime>> GetPlanTimesAsync(DateTime date);
    }
}

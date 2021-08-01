using AdOut.Stream.Model.Events;
using AdOut.Stream.Model.Models;
using AutoMapper;
using System;

namespace AdOut.Stream.Core.Automapper
{
    public class PlanProfile : Profile
    {
        public PlanProfile()
        {
            CreateMap<PlanHandledEvent, PlanTime>();
            CreateMap<Planning.Client.Model.StreamPlanTime, PlanTime>();
            CreateMap<Planning.Client.Model.AdPlanTime, AdPlanTime>();
            CreateMap<Planning.Client.Model.SchedulePeriod, SchedulePeriod>();
            CreateMap<Planning.Client.Model.TimeRange, TimeRange>()
                .ForMember(x => x.Start, x => x.MapFrom(m => TimeSpan.Parse(m.Start)))
                .ForMember(x => x.End, x => x.MapFrom(m => TimeSpan.Parse(m.End)));
        }
    }
}

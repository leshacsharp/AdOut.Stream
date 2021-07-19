using AdOut.Stream.Model.Events;
using AdOut.Stream.Model.Models;
using AdOut.Stream.Planning.Client.Model;
using AutoMapper;

namespace AdOut.Stream.Core.Automapper
{
    public class PlanProfile : Profile
    {
        public PlanProfile()
        {
            CreateMap<PlanHandledEvent, PlanTime>();
            CreateMap<StreamPlanTime, PlanTime>();
        }
    }
}

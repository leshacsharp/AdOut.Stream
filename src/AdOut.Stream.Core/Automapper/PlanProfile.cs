using AdOut.Stream.Model.Events;
using AdOut.Stream.Model.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdOut.Stream.Core.Automapper
{
    public class PlanProfile : Profile
    {
        public PlanProfile()
        {
            CreateMap<PlanHandledEvent, PlanTime>();
        }
    }
}

using AdOut.Stream.Model.Config;
using AdOut.Stream.Model.Interfaces;
using AdOut.Stream.Model.Models;
using AdOut.Stream.Planning.Client.Api;
using AutoMapper;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdOut.Stream.Core.Services
{
    public class PlanService : IPlanService
    {
        private readonly IAuthorizationClientWrapper<IPlanApi> _planApi;
        private readonly IMapper _mapper;
        private readonly AdPointConfig _config;

        public PlanService(
            IAuthorizationClientWrapper<IPlanApi> planApi,
            IMapper mapper,
            IOptions<AdPointConfig> config)
        {
            _planApi = planApi;
            _mapper = mapper;
            _config = config.Value;
        }

        public async Task<List<PlanTime>> GetPlanTimesAsync(DateTime date)
        {
            var client = await _planApi.GetClientAsync();

            //todo: we can't deserialize the api response to the client model. A cause is timespan models. 
            //need to modify the Planning openapi file
            var models = await client.StreamPlansGetAsync(_config.Id, date);
            var planTimes = _mapper.Map<List<PlanTime>>(models);
            return planTimes;
        }
    }
}

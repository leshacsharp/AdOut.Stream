using AdOut.Stream.Model.Interfaces;
using AdOut.Stream.Planning.Client.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdOut.Stream.Core.Services
{
    public class PlanService : IPlanService
    {
        private readonly IAuthorizationClientWrapper<IPlanApi> _planApi;
        public PlanService(IAuthorizationClientWrapper<IPlanApi> planApi)
        {
            _planApi = planApi;
        }

        public Task GetStreamPlansAsync(string adPointId, DateTime date)
        {
            throw new NotImplementedException();
        }
    }
}

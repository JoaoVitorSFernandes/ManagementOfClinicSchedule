using ManagementOfClinicSchedule.Domain.Core.Interfaces.Repositories;
using ManagementOfClinicSchedule.Domain.Core.Interfaces.Services;
using ManagementOfClinicSchedule.Domain.Entities;

namespace ManagementOfClinicSchedule.Domain.Services
{
    public class ServiceServiceRule : ServiceBase<ServiceRule>, IServiceServiceRule
    {
        private readonly IRepositoryServiceRule _repositoryServieRule;

        public ServiceServiceRule(IRepositoryServiceRule repositoryServieRule) 
            : base(repositoryServieRule)
        {
            _repositoryServieRule = repositoryServieRule;
        }

        public async Task<IEnumerable<ServiceRule>> AvailableTimes()
        {
            return await _repositoryServieRule.AvailableTimes();
        }
    }
}

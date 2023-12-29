using ManagementOfClinicSchedule.Domain.Core.Interfaces.Repositories;
using ManagementOfClinicSchedule.Domain.Entities;

namespace ManagementOfClinicSchedule.Infrastructure.Data.Repositories
{
    internal class RepositoryServiceRule : RepositoryBase<ServiceRule>, IRepositoryServiceRule
    {
        public Task<IEnumerable<ServiceRule>> AvailableTimes()
        {
            throw new NotImplementedException();
        }
    }
}

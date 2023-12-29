using ManagementOfClinicSchedule.Domain.Entities;

namespace ManagementOfClinicSchedule.Domain.Core.Interfaces.Repositories
{
    public interface IRepositoryServiceRule : IRepositoryBase<ServiceRule>
    {
        Task<IEnumerable<ServiceRule>> AvailableTimes();
    }
}

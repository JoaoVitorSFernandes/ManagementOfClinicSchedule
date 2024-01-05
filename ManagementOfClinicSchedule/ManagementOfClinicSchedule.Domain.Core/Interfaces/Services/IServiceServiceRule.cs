using ManagementOfClinicSchedule.Domain.Entities;

namespace ManagementOfClinicSchedule.Domain.Core.Interfaces.Services
{
    public interface IServiceServiceRule : IServiceBase<ServiceRule>
    {
        Task<IEnumerable<ServiceRule>> AvailableTimes();
    }
}

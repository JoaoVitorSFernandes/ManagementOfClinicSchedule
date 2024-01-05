using ManagementOfClinicSchedule.Application.DTOs;

namespace ManagementOfClinicSchedule.Application.Interfaces
{
    public interface IApplicationServiceRule
    {
        Task<IEnumerable<ServiceRuleDTO>> GetAll();
        Task Add(ServiceRuleDTO serviceRuleDTO);
        Task AddRange(IEnumerable<ServiceRuleDTO> serviceRuleDTO);
        Task Remove(int id);
        Task RemoveRange(IEnumerable<ServiceRuleDTO> serviceRuleDTO);
        Task<IEnumerable<ServiceRuleDTO>> AvailableTimes();
    }
}

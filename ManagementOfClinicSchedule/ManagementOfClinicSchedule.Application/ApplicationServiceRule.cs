using ManagementOfClinicSchedule.Application.DTOs;
using ManagementOfClinicSchedule.Application.Interfaces;
using ManagementOfClinicSchedule.Application.Interfaces.Mapper;
using ManagementOfClinicSchedule.Domain.Core.Interfaces.Services;

namespace ManagementOfClinicSchedule.Application
{
    public class ApplicationServiceRule : IApplicationServiceRule
    {
        private readonly IMapperServiceRule _mapperServiceRule;
        private readonly IServiceServiceRule _serviceServiceRule;

        public ApplicationServiceRule(IMapperServiceRule mapperServiceRule, IServiceServiceRule serviceServiceRule)
        {
            _mapperServiceRule = mapperServiceRule;
            _serviceServiceRule = serviceServiceRule;
        }

        public async Task Add(ServiceRuleDTO serviceRuleDTO)
        {
            var serviceRule = _mapperServiceRule.MapperDtoToEntity(serviceRuleDTO);
            await _serviceServiceRule.Add(serviceRule);
        }

        public async Task AddRange(IEnumerable<ServiceRuleDTO> serviceRuleDTO)
        {
            var serviceRules = _mapperServiceRule.MapperListDtoToEntity(serviceRuleDTO);
            await _serviceServiceRule.AddRange(serviceRules);
        }

        public async Task<IEnumerable<ServiceRuleDTO>> AvailableTimes()
        {
            var servicesRulesAvailable = await _serviceServiceRule.AvailableTimes();
            return _mapperServiceRule.MapperListServicesDto(servicesRulesAvailable);
        }

        public async Task<IEnumerable<ServiceRuleDTO>> GetAll()
        {
            var serviceRulesDtos = await _serviceServiceRule.GetAll();
            return _mapperServiceRule.MapperListServicesDto(serviceRulesDtos);
        }

        public async Task Remove(int id)
        {
            var serviceRuleDTO  = await _serviceServiceRule.GetById(id);
            await _serviceServiceRule.Remove(serviceRuleDTO);
        }

        public async Task RemoveRange(IEnumerable<ServiceRuleDTO> serviceRuleDTO)
        {
            var serviceRules = _mapperServiceRule.MapperListDtoToEntity(serviceRuleDTO);
            await _serviceServiceRule.RemoveRange(serviceRules);
        }
    }
}

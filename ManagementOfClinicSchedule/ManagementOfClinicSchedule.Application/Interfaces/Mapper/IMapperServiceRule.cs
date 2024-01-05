using ManagementOfClinicSchedule.Application.DTOs;
using ManagementOfClinicSchedule.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementOfClinicSchedule.Application.Interfaces.Mapper
{
    public interface IMapperServiceRule
    {
        ServiceRule MapperDtoToEntity(ServiceRuleDTO serviceRuleDTO);
        ServiceRuleDTO MapperEntityToDto(ServiceRule serviceRule);
        IEnumerable<ServiceRuleDTO> MapperListServicesDto(IEnumerable<ServiceRule> serviceRules);
        IEnumerable<ServiceRule> MapperListDtoToEntity(IEnumerable<ServiceRuleDTO> serviceRulesDtos);
    }
}

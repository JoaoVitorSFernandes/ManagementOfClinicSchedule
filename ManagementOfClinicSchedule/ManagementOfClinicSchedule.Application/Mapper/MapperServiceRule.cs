using ManagementOfClinicSchedule.Application.DTOs;
using ManagementOfClinicSchedule.Application.Interfaces.Mapper;
using ManagementOfClinicSchedule.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace ManagementOfClinicSchedule.Application.Mapper
{
    public class MapperServiceRule : IMapperServiceRule
    {
        public ServiceRule MapperDtoToEntity(ServiceRuleDTO serviceRuleDTO)
        {
            var serviceRule = new ServiceRule();

            serviceRule.Date = serviceRuleDTO.Date;
            
            foreach(var item in serviceRuleDTO.Timesheets)
            {
                serviceRule.Timesheets.Add(new Timesheet(item.StartTime, item.EndTime, item.IsBusy));
            }

            return serviceRule;
        }

        public ServiceRuleDTO MapperEntityToDto(ServiceRule serviceRule)
        {
            var serviceRuleDTO = new ServiceRuleDTO();

            serviceRuleDTO.Date = serviceRule.Date;

            foreach (var item in serviceRule.Timesheets)
            {
                serviceRuleDTO.Timesheets.Add(new TimesheetDTO(item.StartTime, item.EndDate, item.IsBusy));
            }

            return serviceRuleDTO;
        }

        public IEnumerable<ServiceRule> MapperListDtoToEntity(IEnumerable<ServiceRuleDTO> serviceRulesDtos)
        {
            var serviceRules = serviceRulesDtos.Select(s => new ServiceRule
            {
                Date = s.Date,
                Timesheets = s.Timesheets.Select(t => new Timesheet(t.StartTime, t.EndTime, t.IsBusy)).ToList()
            });

            return serviceRules;
        }

        public IEnumerable<ServiceRuleDTO> MapperListServicesDto(IEnumerable<ServiceRule> serviceRules)
        {
            var serviceRuleDTOs = serviceRules.Select(s => new ServiceRuleDTO
            {
                Date = s.Date,
                Timesheets = s.Timesheets.Select(t => new TimesheetDTO(t.StartTime, t.EndDate, t.IsBusy)).ToList()
            });

            return serviceRuleDTOs;
        }
    }
}

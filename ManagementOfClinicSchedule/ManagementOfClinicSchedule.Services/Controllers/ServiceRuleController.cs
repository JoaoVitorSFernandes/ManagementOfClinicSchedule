using ManagementOfClinicSchedule.Application.DTOs;
using ManagementOfClinicSchedule.Application.Interfaces;
using ManagementOfClinicSchedule.Services.VewModels;
using Microsoft.AspNetCore.Mvc;

namespace ManagementOfClinicSchedule.Services.Controllers
{
    [ApiController]
    public class ServiceRuleController : ControllerBase
    {
        private readonly IApplicationServiceRule _applicationServiceRule;

        public ServiceRuleController(IApplicationServiceRule applicationServiceRule)
        {
            _applicationServiceRule = applicationServiceRule;
        }

        [HttpGet("/servicerules")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var serviceRules = await _applicationServiceRule.GetAll();

                if (serviceRules is null)
                    return NotFound();

                return Ok(new ResultViewModel<IEnumerable<ServiceRuleDTO>>(serviceRules));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ResultViewModel<string>(null, $"Internal Server Erro - {ex.Message}"));
            }
        }

        [HttpPost("/servicerules")]
        public async Task<IActionResult> Add(
            [FromBody] ServiceRuleDTO serviceRuleDTO)
        {
            try
            {
                if (serviceRuleDTO == null)
                    return BadRequest();

                return Created("", _applicationServiceRule.Add(serviceRuleDTO));
            }
            catch (Exception)
            {
                return StatusCode(500, new ResultViewModel<string>(null, "Internal Server Erro"));
            }
        }

        [HttpPost("/servicerules/range")]
        public async Task<IActionResult> AddRange(
            [FromBody] IEnumerable<ServiceRuleDTO> serviceRuleDTOs)
        {
            try
            {
                if (serviceRuleDTOs is null)
                    return BadRequest();

                return Created("", _applicationServiceRule.AddRange(serviceRuleDTOs));
            }
            catch (Exception)
            {
                return StatusCode(500, new ResultViewModel<string>(null, "Internal Server Erro"));
            }
        }

        [HttpDelete("/servicerules/{id:int}")]
        public async Task<IActionResult> Remove(
            [FromRoute] int id)
        {
            try
            {
                await _applicationServiceRule.Remove(id);
                return Ok(new ResultViewModel<string>(null, "deu certo"));
            }
            catch (Exception)
            {
                return StatusCode(500, new ResultViewModel<string>(null, "Internal Server Erro"));
            }
        }

        [HttpDelete("/servicerules/range")]
        public async Task<IActionResult> RemoveRange(
            [FromBody] IEnumerable<ServiceRuleDTO> serviceRuleDTOs)
        {
            try
            {
                if (serviceRuleDTOs is null)
                    return BadRequest();

                return Ok(_applicationServiceRule.RemoveRange(serviceRuleDTOs));
            }
            catch (Exception)
            {
                return StatusCode(500, new ResultViewModel<string>(null, "Internal Server Erro"));
            }
        }

        [HttpGet("/servicerules/availabletimes")]
        public async Task<IActionResult> AvailableTimes()
        {
            try
            {
                var serviceRules = await _applicationServiceRule.AvailableTimes();

                if (serviceRules is null)
                    return NotFound();

                return Ok(new ResultViewModel<IEnumerable<ServiceRuleDTO>>(serviceRules));

            }
            catch (Exception)
            {
                return StatusCode(500, new ResultViewModel<string>(null, "Internal Server Erro"));
            }
        }
    }
}

namespace ManagementOfClinicSchedule.Application.DTOs
{
    public class ServiceRuleDTO
    {
        public DateTime Date { get; set; }
        public List<TimesheetDTO> Timesheets { get; set; } = new();

        public ServiceRuleDTO() { }
    }
}

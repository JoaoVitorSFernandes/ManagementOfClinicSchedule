namespace ManagementOfClinicSchedule.Domain.Entities
{
    public class ServiceRule : Base
    {
        public DateTime Date { get; set; }
        public List<Timesheet> Timesheet { get; set; } = new();
    }
}

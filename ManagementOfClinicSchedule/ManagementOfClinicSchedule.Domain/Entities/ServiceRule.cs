namespace ManagementOfClinicSchedule.Domain.Entities
{
    public class ServiceRule : Base
    {
        public DateTime Date { get; set; }
        public IList<Timesheet> Timesheets { get; set; }

        public ServiceRule() { }
    }
}

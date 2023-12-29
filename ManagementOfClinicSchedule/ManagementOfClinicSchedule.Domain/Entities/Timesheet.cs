using ManagementOfClinicSchedule.Domain.Entities.Exceptions;

namespace ManagementOfClinicSchedule.Domain.Entities
{
    public class Timesheet : Base
    {
        public DateTime StartTime { get; set; }
        public DateTime EndDate { get; set; }
        public bool IsBusy { get; set; }

        public int ServiceRuleId { get; set; }
        public ServiceRule ServiceRule { get; set; }

    }
}

using ManagementOfClinicSchedule.Domain.Entities.Exceptions;

namespace ManagementOfClinicSchedule.Domain.Entities
{
    public class Timesheet : Base
    {
        public DateTime StartTime { get; set; }
        public DateTime EndDate { get; set; }
        public bool IsBusy { get; set; }

        public Timesheet(DateTime startTime, DateTime endDate)
        {
            IsBusy = false;
            StartTime = startTime;
            EndDate = endDate;
        }

        private void ValidateDates(DateTime startTime, DateTime endDate)
        {
            if (startTime > endDate)
                throw new DateTimeException("Start time cannot be greater than the end time.");
        }
    }
}

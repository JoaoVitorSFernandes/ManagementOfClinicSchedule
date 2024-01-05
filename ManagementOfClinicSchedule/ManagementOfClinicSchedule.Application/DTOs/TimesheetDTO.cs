namespace ManagementOfClinicSchedule.Application.DTOs
{
    public class TimesheetDTO
    {
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public bool IsBusy { get; set; }

        public TimesheetDTO() { }

        public TimesheetDTO(DateTime starTime, DateTime endTime, bool isBusy)
        {
            StartTime = starTime;
            EndTime = endTime;
            IsBusy = isBusy;
        }
    }
}

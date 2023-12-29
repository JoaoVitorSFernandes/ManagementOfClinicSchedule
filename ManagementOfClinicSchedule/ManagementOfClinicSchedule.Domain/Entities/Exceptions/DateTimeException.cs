namespace ManagementOfClinicSchedule.Domain.Entities.Exceptions
{
    public class DateTimeException : Exception
    {
        public DateTimeException(string message) : base(message) { }
    }
}

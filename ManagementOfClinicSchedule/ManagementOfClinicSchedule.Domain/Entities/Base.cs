namespace ManagementOfClinicSchedule.Domain.Entities
{
    public abstract class Base
    {
        public int Id { get; set; }
        public IList<string> Messages { get; set; }
    }
}

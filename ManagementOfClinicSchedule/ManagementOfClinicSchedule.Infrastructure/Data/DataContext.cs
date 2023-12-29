using ManagementOfClinicSchedule.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ManagementOfClinicSchedule.Infrastructure.Data
{
    public class DataContext : DbContext
    {
        public DbSet<ServiceRule> ServicesRule { get; set; }
        public DbSet<Timesheet> Timesheets { get; set; }

        public DataContext()
        { }

        public DataContext(DbContextOptions<DataContext> options) 
            : base(options)
        { }


    }
}

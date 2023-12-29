using ManagementOfClinicSchedule.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ManagementOfClinicSchedule.Infrastructure.Data.Map
{
    public class TimesheetMap : IEntityTypeConfiguration<Timesheet>
    {
        public void Configure(EntityTypeBuilder<Timesheet> builder)
        {
            builder.ToTable("ServiceRule");

            builder.HasKey(x => x.Id)
                .HasName("PK_ServiceRule");

            builder.Property(x => x.StartTime)
                .IsRequired()
                .HasColumnType("SMALLDATETIME")
                .HasColumnName("StartTime");            
            
            builder.Property(x => x.EndDate)
                .IsRequired()
                .HasColumnType("SMALLDATETIME")
                .HasColumnName("EndDate");

            builder.Property(x => x.IsBusy)
                .HasColumnName("IsBusy")
                .HasColumnType("BIT")
                .HasDefaultValue(false);
        }
    }
}

using ManagementOfClinicSchedule.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ManagementOfClinicSchedule.Infrastructure.Data.Map
{
    public class TimesheetMap : IEntityTypeConfiguration<Timesheet>
    {
        public void Configure(EntityTypeBuilder<Timesheet> builder)
        {
            builder.ToTable("Timesheet");

            builder.HasKey(x => x.Id)
                .HasName("PK_Timesheet");

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

            builder.HasOne(x => x.ServiceRule)
                .WithMany(x => x.Timesheets)
                .HasConstraintName("FK_Timesheet_ServiceRule")
                .OnDelete(DeleteBehavior.ClientSetNull);
        }
    }
}

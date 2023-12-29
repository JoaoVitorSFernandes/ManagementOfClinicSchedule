using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ManagementOfClinicSchedule.Domain.Entities;

namespace ManagementOfClinicSchedule.Infrastructure.Data.Map
{
    public class ServiceRuleMap : IEntityTypeConfiguration<ServiceRule>
    {
        public void Configure(EntityTypeBuilder<ServiceRule> builder)
        {
            builder.ToTable("ServiceRule");

            builder.HasKey(x => x.Id)
                .HasName("PK_ServiceRule");

            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd()
                .UseIdentityColumn();

            builder.Property(x => x.Date)
                .IsRequired()
                .HasColumnType("SMALLDATETIME")
                .HasColumnName("Date");

            builder.HasMany(x => x.Timesheets)
                    .WithOne(x => x.ServiceRule)
                    .HasConstraintName("FK_ServiceRule_Timesheet")
                    .OnDelete(DeleteBehavior.ClientCascade);
        }
    }
}

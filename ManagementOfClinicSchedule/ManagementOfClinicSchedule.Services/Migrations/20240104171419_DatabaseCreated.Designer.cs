﻿// <auto-generated />
using System;
using ManagementOfClinicSchedule.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ManagementOfClinicSchedule.Services.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20240104171419_DatabaseCreated")]
    partial class DatabaseCreated
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ManagementOfClinicSchedule.Domain.Entities.ServiceRule", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Date")
                        .HasColumnType("SMALLDATETIME")
                        .HasColumnName("Date");

                    b.HasKey("Id")
                        .HasName("PK_ServiceRule");

                    b.ToTable("ServiceRule", (string)null);
                });

            modelBuilder.Entity("ManagementOfClinicSchedule.Domain.Entities.Timesheet", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("SMALLDATETIME")
                        .HasColumnName("EndDate");

                    b.Property<bool>("IsBusy")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("BIT")
                        .HasDefaultValue(false)
                        .HasColumnName("IsBusy");

                    b.Property<int>("ServiceRuleId")
                        .HasColumnType("int");

                    b.Property<DateTime>("StartTime")
                        .HasColumnType("SMALLDATETIME")
                        .HasColumnName("StartTime");

                    b.HasKey("Id")
                        .HasName("PK_Timesheet");

                    b.HasIndex("ServiceRuleId");

                    b.ToTable("Timesheet", (string)null);
                });

            modelBuilder.Entity("ManagementOfClinicSchedule.Domain.Entities.Timesheet", b =>
                {
                    b.HasOne("ManagementOfClinicSchedule.Domain.Entities.ServiceRule", "ServiceRule")
                        .WithMany("Timesheets")
                        .HasForeignKey("ServiceRuleId")
                        .IsRequired()
                        .HasConstraintName("FK_Timesheet_ServiceRule");

                    b.Navigation("ServiceRule");
                });

            modelBuilder.Entity("ManagementOfClinicSchedule.Domain.Entities.ServiceRule", b =>
                {
                    b.Navigation("Timesheets");
                });
#pragma warning restore 612, 618
        }
    }
}

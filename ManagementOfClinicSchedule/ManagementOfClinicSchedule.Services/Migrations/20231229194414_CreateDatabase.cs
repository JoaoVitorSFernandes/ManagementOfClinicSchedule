using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ManagementOfClinicSchedule.Services.Migrations
{
    /// <inheritdoc />
    public partial class CreateDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ServiceRule",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "SMALLDATETIME", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceRule", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Timesheet",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StartTime = table.Column<DateTime>(type: "SMALLDATETIME", nullable: false),
                    EndDate = table.Column<DateTime>(type: "SMALLDATETIME", nullable: false),
                    IsBusy = table.Column<bool>(type: "BIT", nullable: false, defaultValue: false),
                    ServiceRuleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Timesheet", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Timesheet_ServiceRule",
                        column: x => x.ServiceRuleId,
                        principalTable: "ServiceRule",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Timesheet_ServiceRuleId",
                table: "Timesheet",
                column: "ServiceRuleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Timesheet");

            migrationBuilder.DropTable(
                name: "ServiceRule");
        }
    }
}

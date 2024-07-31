using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Datapoint.Compass.Migrator.Migrations
{
    /// <inheritdoc />
    public partial class Enrollments : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Enrollments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false),
                    RowVersionId = table.Column<Guid>(type: "char(36)", nullable: false),
                    FacilityId = table.Column<Guid>(type: "char(36)", nullable: false),
                    ServiceId = table.Column<Guid>(type: "char(36)", nullable: false),
                    Number = table.Column<string>(type: "varchar(64)", maxLength: 64, nullable: false),
                    Creation = table.Column<DateTimeOffset>(type: "datetime", nullable: false),
                    Start = table.Column<DateTimeOffset>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enrollments", x => x.Id);
                    table.UniqueConstraint("AK_Enrollments_Number", x => x.Number);
                    table.ForeignKey(
                        name: "FK_Enrollments_Facilities_FacilityId",
                        column: x => x.FacilityId,
                        principalTable: "Facilities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Enrollments_Services_ServiceId",
                        column: x => x.ServiceId,
                        principalTable: "Services",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Enrollments_FacilityId",
                table: "Enrollments",
                column: "FacilityId");

            migrationBuilder.CreateIndex(
                name: "IX_Enrollments_ServiceId",
                table: "Enrollments",
                column: "ServiceId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Enrollments");
        }
    }
}

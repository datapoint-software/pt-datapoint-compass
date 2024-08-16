using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Datapoint.Compass.Migrator.Migrations
{
    /// <inheritdoc />
    public partial class EmployeeSessions : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EmployeeSessions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false),
                    EmployeeId = table.Column<Guid>(type: "char(36)", nullable: false),
                    RemoteAddress = table.Column<string>(type: "varchar(64)", maxLength: 64, nullable: false),
                    UserAgent = table.Column<string>(type: "varchar(4096)", maxLength: 4096, nullable: false),
                    Creation = table.Column<DateTimeOffset>(type: "datetime", nullable: false),
                    Expiration = table.Column<DateTimeOffset>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeSessions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmployeeSessions_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeSessions_EmployeeId",
                table: "EmployeeSessions",
                column: "EmployeeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmployeeSessions");
        }
    }
}

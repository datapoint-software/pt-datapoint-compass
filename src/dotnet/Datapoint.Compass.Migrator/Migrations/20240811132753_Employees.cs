using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Datapoint.Compass.Migrator.Migrations
{
    /// <inheritdoc />
    public partial class Employees : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false),
                    RowVersionId = table.Column<Guid>(type: "char(36)", nullable: false),
                    Name = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: false),
                    EmailAddress = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: false),
                    PasswordHash = table.Column<string>(type: "varchar(64)", maxLength: 64, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_EmailAddress",
                table: "Employees",
                column: "EmailAddress",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employees");
        }
    }
}

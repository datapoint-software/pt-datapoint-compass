using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Datapoint.Compass.Migrator.Migrations
{
    /// <inheritdoc />
    public partial class Services : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Services",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false),
                    RowVersionId = table.Column<Guid>(type: "char(36)", nullable: false),
                    Code = table.Column<string>(type: "varchar(16)", maxLength: 16, nullable: false),
                    Name = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: false),
                    Description = table.Column<string>(type: "varchar(4096)", maxLength: 4096, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Services", x => x.Id);
                    table.UniqueConstraint("AK_Services_Code", x => x.Code);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Services_Name",
                table: "Services",
                column: "Name",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Services");
        }
    }
}

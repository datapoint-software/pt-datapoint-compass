using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Datapoint.Compass.Migrator.Migrations
{
    /// <inheritdoc />
    public partial class Districts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Districts",
                columns: table => new
                {
                    Code = table.Column<string>(type: "varchar(16)", maxLength: 16, nullable: false),
                    CountryCode = table.Column<string>(type: "varchar(2)", maxLength: 2, nullable: false),
                    Name = table.Column<string>(type: "varchar(64)", maxLength: 64, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Districts", x => new { x.Code, x.CountryCode });
                })
                .Annotation("MySQL:Charset", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Districts");
        }
    }
}

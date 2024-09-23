using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Datapoint.Compass.Migrator.Migrations
{
    /// <inheritdoc />
    public partial class Counties : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Counties",
                columns: table => new
                {
                    CountryCode = table.Column<string>(type: "varchar(16)", maxLength: 16, nullable: false),
                    DistrictCode = table.Column<string>(type: "varchar(16)", maxLength: 16, nullable: false),
                    CountyCode = table.Column<string>(type: "varchar(16)", maxLength: 16, nullable: false),
                    Name = table.Column<string>(type: "varchar(64)", maxLength: 64, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Counties", x => new { x.CountryCode, x.DistrictCode, x.CountyCode });
                    table.ForeignKey(
                        name: "FK_Counties_Countries_CountryCode",
                        column: x => x.CountryCode,
                        principalTable: "Countries",
                        principalColumn: "CountryCode",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Counties_Districts_CountryCode_DistrictCode",
                        columns: x => new { x.CountryCode, x.DistrictCode },
                        principalTable: "Districts",
                        principalColumns: new[] { "CountryCode", "DistrictCode" },
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Counties");
        }
    }
}

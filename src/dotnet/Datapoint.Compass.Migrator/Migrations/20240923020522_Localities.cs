using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Datapoint.Compass.Migrator.Migrations
{
    /// <inheritdoc />
    public partial class Localities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Localities",
                columns: table => new
                {
                    CountryCode = table.Column<string>(type: "varchar(16)", maxLength: 16, nullable: false),
                    DistrictCode = table.Column<string>(type: "varchar(16)", maxLength: 16, nullable: false),
                    CountyCode = table.Column<string>(type: "varchar(16)", maxLength: 16, nullable: false),
                    LocalityCode = table.Column<string>(type: "varchar(16)", maxLength: 16, nullable: false),
                    Name = table.Column<string>(type: "varchar(64)", maxLength: 64, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Localities", x => new { x.CountryCode, x.DistrictCode, x.CountyCode, x.LocalityCode });
                    table.ForeignKey(
                        name: "FK_Localities_Counties_CountryCode_DistrictCode_CountyCode",
                        columns: x => new { x.CountryCode, x.DistrictCode, x.CountyCode },
                        principalTable: "Counties",
                        principalColumns: new[] { "CountryCode", "DistrictCode", "CountyCode" },
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Localities_Countries_CountryCode",
                        column: x => x.CountryCode,
                        principalTable: "Countries",
                        principalColumn: "CountryCode",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Localities_Districts_CountryCode_DistrictCode",
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
                name: "Localities");
        }
    }
}

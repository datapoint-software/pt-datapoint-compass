using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Datapoint.Compass.Migrator.Migrations
{
    /// <inheritdoc />
    public partial class Streets : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Streets",
                columns: table => new
                {
                    CountryCode = table.Column<string>(type: "varchar(16)", maxLength: 16, nullable: false),
                    DistrictCode = table.Column<string>(type: "varchar(16)", maxLength: 16, nullable: false),
                    CountyCode = table.Column<string>(type: "varchar(16)", maxLength: 16, nullable: false),
                    LocalityCode = table.Column<string>(type: "varchar(16)", maxLength: 16, nullable: false),
                    PostalCode = table.Column<string>(type: "varchar(16)", maxLength: 16, nullable: false),
                    StreetCode = table.Column<string>(type: "varchar(16)", maxLength: 16, nullable: false),
                    Name = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Streets", x => new { x.CountryCode, x.DistrictCode, x.CountyCode, x.LocalityCode, x.PostalCode, x.StreetCode });
                    table.ForeignKey(
                        name: "FK_Streets_Counties_CountryCode_DistrictCode_CountyCode",
                        columns: x => new { x.CountryCode, x.DistrictCode, x.CountyCode },
                        principalTable: "Counties",
                        principalColumns: new[] { "CountryCode", "DistrictCode", "CountyCode" },
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Streets_Countries_CountryCode",
                        column: x => x.CountryCode,
                        principalTable: "Countries",
                        principalColumn: "CountryCode",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Streets_Districts_CountryCode_DistrictCode",
                        columns: x => new { x.CountryCode, x.DistrictCode },
                        principalTable: "Districts",
                        principalColumns: new[] { "CountryCode", "DistrictCode" },
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Streets_Localities_CountryCode_DistrictCode_CountyCode_Local~",
                        columns: x => new { x.CountryCode, x.DistrictCode, x.CountyCode, x.LocalityCode },
                        principalTable: "Localities",
                        principalColumns: new[] { "CountryCode", "DistrictCode", "CountyCode", "LocalityCode" },
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Streets_Zones_CountryCode_DistrictCode_CountyCode_LocalityCo~",
                        columns: x => new { x.CountryCode, x.DistrictCode, x.CountyCode, x.LocalityCode, x.PostalCode },
                        principalTable: "Zones",
                        principalColumns: new[] { "CountryCode", "DistrictCode", "CountyCode", "LocalityCode", "PostalCode" },
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Streets");
        }
    }
}

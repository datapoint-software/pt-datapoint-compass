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
                    CountryCode = table.Column<string>(type: "varchar(2)", maxLength: 2, nullable: false),
                    Code = table.Column<string>(type: "varchar(16)", maxLength: 16, nullable: false),
                    Name = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Districts", x => new { x.CountryCode, x.Code });
                    table.ForeignKey(
                        name: "FK_Districts_Countries_CountryCode",
                        column: x => x.CountryCode,
                        principalTable: "Countries",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.InsertData("Districts", [ "CountryCode", "Code", "Name" ], [ "PT", "01", "Aveiro"]);
            migrationBuilder.InsertData("Districts", [ "CountryCode", "Code", "Name" ], [ "PT", "02", "Beja"]);
            migrationBuilder.InsertData("Districts", [ "CountryCode", "Code", "Name" ], [ "PT", "03", "Braga"]);
            migrationBuilder.InsertData("Districts", [ "CountryCode", "Code", "Name" ], [ "PT", "04", "Bragança"]);
            migrationBuilder.InsertData("Districts", [ "CountryCode", "Code", "Name" ], [ "PT", "05", "Castelo Branco"]);
            migrationBuilder.InsertData("Districts", [ "CountryCode", "Code", "Name" ], [ "PT", "06", "Coimbra"]);
            migrationBuilder.InsertData("Districts", [ "CountryCode", "Code", "Name" ], [ "PT", "07", "Évora"]);
            migrationBuilder.InsertData("Districts", [ "CountryCode", "Code", "Name" ], [ "PT", "08", "Faro"]);
            migrationBuilder.InsertData("Districts", [ "CountryCode", "Code", "Name" ], [ "PT", "09", "Guarda"]);
            migrationBuilder.InsertData("Districts", [ "CountryCode", "Code", "Name" ], [ "PT", "10", "Leiria"]);
            migrationBuilder.InsertData("Districts", [ "CountryCode", "Code", "Name" ], [ "PT", "11", "Lisboa"]);
            migrationBuilder.InsertData("Districts", [ "CountryCode", "Code", "Name" ], [ "PT", "12", "Portalegre"]);
            migrationBuilder.InsertData("Districts", [ "CountryCode", "Code", "Name" ], [ "PT", "13", "Porto"]);
            migrationBuilder.InsertData("Districts", [ "CountryCode", "Code", "Name" ], [ "PT", "14", "Santarém"]);
            migrationBuilder.InsertData("Districts", [ "CountryCode", "Code", "Name" ], [ "PT", "15", "Setúbal"]);
            migrationBuilder.InsertData("Districts", [ "CountryCode", "Code", "Name" ], [ "PT", "16", "Viana do Castelo"]);
            migrationBuilder.InsertData("Districts", [ "CountryCode", "Code", "Name" ], [ "PT", "17", "Vila Real"]);
            migrationBuilder.InsertData("Districts", [ "CountryCode", "Code", "Name" ], [ "PT", "18", "Viseu"]);
            migrationBuilder.InsertData("Districts", [ "CountryCode", "Code", "Name" ], [ "PT", "31", "Ilha da Madeira"]);
            migrationBuilder.InsertData("Districts", [ "CountryCode", "Code", "Name" ], [ "PT", "32", "Ilha de Porto Santo"]);
            migrationBuilder.InsertData("Districts", [ "CountryCode", "Code", "Name" ], [ "PT", "41", "Ilha de Santa Maria"]);
            migrationBuilder.InsertData("Districts", [ "CountryCode", "Code", "Name" ], [ "PT", "42", "Ilha de São Miguel"]);
            migrationBuilder.InsertData("Districts", [ "CountryCode", "Code", "Name" ], [ "PT", "43", "Ilha Terceira"]);
            migrationBuilder.InsertData("Districts", [ "CountryCode", "Code", "Name" ], [ "PT", "44", "Ilha da Graciosa"]);
            migrationBuilder.InsertData("Districts", [ "CountryCode", "Code", "Name" ], [ "PT", "45", "Ilha de São Jorge"]);
            migrationBuilder.InsertData("Districts", [ "CountryCode", "Code", "Name" ], [ "PT", "46", "Ilha do Pico"]);
            migrationBuilder.InsertData("Districts", [ "CountryCode", "Code", "Name" ], [ "PT", "47", "Ilha do Faial"]);
            migrationBuilder.InsertData("Districts", [ "CountryCode", "Code", "Name" ], [ "PT", "48", "Ilha das Flores"]);
            migrationBuilder.InsertData("Districts", [ "CountryCode", "Code", "Name" ], [ "PT", "49", "Ilha do Corvo"]);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Districts");
        }
    }
}

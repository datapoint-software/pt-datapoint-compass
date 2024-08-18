using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Datapoint.Compass.Migrator.Migrations
{
    /// <inheritdoc />
    public partial class Districts_Portugal : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData("Districts", ["Code", "CountryCode", "Name"], ["01", "PT", "Aveiro"]);
            migrationBuilder.InsertData("Districts", ["Code", "CountryCode", "Name"], ["02", "PT", "Beja"]);
            migrationBuilder.InsertData("Districts", ["Code", "CountryCode", "Name"], ["03", "PT", "Braga"]);
            migrationBuilder.InsertData("Districts", ["Code", "CountryCode", "Name"], ["04", "PT", "Bragança"]);
            migrationBuilder.InsertData("Districts", ["Code", "CountryCode", "Name"], ["05", "PT", "Castelo Branco"]);
            migrationBuilder.InsertData("Districts", ["Code", "CountryCode", "Name"], ["06", "PT", "Coimbra"]);
            migrationBuilder.InsertData("Districts", ["Code", "CountryCode", "Name"], ["07", "PT", "Évora"]);
            migrationBuilder.InsertData("Districts", ["Code", "CountryCode", "Name"], ["08", "PT", "Faro"]);
            migrationBuilder.InsertData("Districts", ["Code", "CountryCode", "Name"], ["09", "PT", "Guarda"]);
            migrationBuilder.InsertData("Districts", ["Code", "CountryCode", "Name"], ["10", "PT", "Leiria"]);
            migrationBuilder.InsertData("Districts", ["Code", "CountryCode", "Name"], ["11", "PT", "Lisboa"]);
            migrationBuilder.InsertData("Districts", ["Code", "CountryCode", "Name"], ["12", "PT", "Portalegre"]);
            migrationBuilder.InsertData("Districts", ["Code", "CountryCode", "Name"], ["13", "PT", "Porto"]);
            migrationBuilder.InsertData("Districts", ["Code", "CountryCode", "Name"], ["14", "PT", "Santarém"]);
            migrationBuilder.InsertData("Districts", ["Code", "CountryCode", "Name"], ["15", "PT", "Setúbal"]);
            migrationBuilder.InsertData("Districts", ["Code", "CountryCode", "Name"], ["16", "PT", "Viana do Castelo"]);
            migrationBuilder.InsertData("Districts", ["Code", "CountryCode", "Name"], ["17", "PT", "Vila Real"]);
            migrationBuilder.InsertData("Districts", ["Code", "CountryCode", "Name"], ["18", "PT", "Viseu"]);
            migrationBuilder.InsertData("Districts", ["Code", "CountryCode", "Name"], ["31", "PT", "Ilha da Madeira"]);
            migrationBuilder.InsertData("Districts", ["Code", "CountryCode", "Name"], ["32", "PT", "Ilha de Porto Santo"]);
            migrationBuilder.InsertData("Districts", ["Code", "CountryCode", "Name"], ["41", "PT", "Ilha de Santa Maria"]);
            migrationBuilder.InsertData("Districts", ["Code", "CountryCode", "Name"], ["42", "PT", "Ilha de São Miguel"]);
            migrationBuilder.InsertData("Districts", ["Code", "CountryCode", "Name"], ["43", "PT", "Ilha Terceira"]);
            migrationBuilder.InsertData("Districts", ["Code", "CountryCode", "Name"], ["44", "PT", "Ilha da Graciosa"]);
            migrationBuilder.InsertData("Districts", ["Code", "CountryCode", "Name"], ["45", "PT", "Ilha de São Jorge"]);
            migrationBuilder.InsertData("Districts", ["Code", "CountryCode", "Name"], ["46", "PT", "Ilha do Pico"]);
            migrationBuilder.InsertData("Districts", ["Code", "CountryCode", "Name"], ["47", "PT", "Ilha do Faial"]);
            migrationBuilder.InsertData("Districts", ["Code", "CountryCode", "Name"], ["48", "PT", "Ilha das Flores"]);
            migrationBuilder.InsertData("Districts", ["Code", "CountryCode", "Name"], ["49", "PT", "Ilha do Corvo"]);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}

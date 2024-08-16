using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Datapoint.Compass.Migrator.Migrations
{
    /// <inheritdoc />
    public partial class Charset : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySQL:Charset", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}

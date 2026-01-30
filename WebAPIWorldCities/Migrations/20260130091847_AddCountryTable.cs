using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WebAPIWorldCities.Migrations
{
    /// <inheritdoc />
    public partial class AddCountryTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Country",
                table: "WorldCities");

            migrationBuilder.AddColumn<int>(
                name: "CountryId",
                table: "WorldCities",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    CountryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CountryName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.CountryId);
                });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "CountryId", "CountryName" },
                values: new object[,]
                {
                    { 1, "" },
                    { 2, "" },
                    { 3, "" },
                    { 4, "" }
                });

            migrationBuilder.UpdateData(
                table: "WorldCities",
                keyColumn: "CityId",
                keyValue: 1,
                columns: new[] { "CityName", "CountryId" },
                values: new object[] { "", 3 });

            migrationBuilder.UpdateData(
                table: "WorldCities",
                keyColumn: "CityId",
                keyValue: 2,
                columns: new[] { "CityName", "CountryId" },
                values: new object[] { "", 1 });

            migrationBuilder.UpdateData(
                table: "WorldCities",
                keyColumn: "CityId",
                keyValue: 3,
                columns: new[] { "CityName", "CountryId" },
                values: new object[] { "", 4 });

            migrationBuilder.CreateIndex(
                name: "IX_WorldCities_CountryId",
                table: "WorldCities",
                column: "CountryId");

            migrationBuilder.AddForeignKey(
                name: "FK_WorldCities_Countries_CountryId",
                table: "WorldCities",
                column: "CountryId",
                principalTable: "Countries",
                principalColumn: "CountryId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WorldCities_Countries_CountryId",
                table: "WorldCities");

            migrationBuilder.DropTable(
                name: "Countries");

            migrationBuilder.DropIndex(
                name: "IX_WorldCities_CountryId",
                table: "WorldCities");

            migrationBuilder.DropColumn(
                name: "CountryId",
                table: "WorldCities");

            migrationBuilder.AddColumn<string>(
                name: "Country",
                table: "WorldCities",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "WorldCities",
                keyColumn: "CityId",
                keyValue: 1,
                columns: new[] { "CityName", "Country" },
                values: new object[] { "Gdansk", "Poland" });

            migrationBuilder.UpdateData(
                table: "WorldCities",
                keyColumn: "CityId",
                keyValue: 2,
                columns: new[] { "CityName", "Country" },
                values: new object[] { "Malmö", "Sweden" });

            migrationBuilder.UpdateData(
                table: "WorldCities",
                keyColumn: "CityId",
                keyValue: 3,
                columns: new[] { "CityName", "Country" },
                values: new object[] { "Bergen", "Norway" });
        }
    }
}

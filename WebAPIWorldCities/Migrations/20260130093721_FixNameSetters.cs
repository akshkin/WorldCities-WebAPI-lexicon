using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebAPIWorldCities.Migrations
{
    /// <inheritdoc />
    public partial class FixNameSetters : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "CountryId",
                keyValue: 1,
                column: "CountryName",
                value: "Sweden");

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "CountryId",
                keyValue: 2,
                column: "CountryName",
                value: "Denmark");

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "CountryId",
                keyValue: 3,
                column: "CountryName",
                value: "Poland");

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "CountryId",
                keyValue: 4,
                column: "CountryName",
                value: "Norway");

            migrationBuilder.UpdateData(
                table: "WorldCities",
                keyColumn: "CityId",
                keyValue: 1,
                column: "CityName",
                value: "Gdansk");

            migrationBuilder.UpdateData(
                table: "WorldCities",
                keyColumn: "CityId",
                keyValue: 2,
                column: "CityName",
                value: "Malmö");

            migrationBuilder.UpdateData(
                table: "WorldCities",
                keyColumn: "CityId",
                keyValue: 3,
                column: "CityName",
                value: "Bergen");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "CountryId",
                keyValue: 1,
                column: "CountryName",
                value: "");

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "CountryId",
                keyValue: 2,
                column: "CountryName",
                value: "");

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "CountryId",
                keyValue: 3,
                column: "CountryName",
                value: "");

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "CountryId",
                keyValue: 4,
                column: "CountryName",
                value: "");

            migrationBuilder.UpdateData(
                table: "WorldCities",
                keyColumn: "CityId",
                keyValue: 1,
                column: "CityName",
                value: "");

            migrationBuilder.UpdateData(
                table: "WorldCities",
                keyColumn: "CityId",
                keyValue: 2,
                column: "CityName",
                value: "");

            migrationBuilder.UpdateData(
                table: "WorldCities",
                keyColumn: "CityId",
                keyValue: 3,
                column: "CityName",
                value: "");
        }
    }
}

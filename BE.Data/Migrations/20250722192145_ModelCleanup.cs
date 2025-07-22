using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BE.Data.Migrations
{
    /// <inheritdoc />
    public partial class ModelCleanup : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "GeographicalData",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "GeographicalData",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "GeographicalData",
                keyColumn: "Id",
                keyValue: 3);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "GeographicalData",
                columns: new[] { "Id", "gemeente", "huisletter", "huisnummer", "huisnummertoevoeging", "lat", "lon", "nevenadres", "nummeraanduiding", "objectid", "objecttype", "openbareruimte", "oppervlakteverblijfsobject", "pandbouwjaar", "pandid", "pandstatus", "postcode", "provincie", "verblijfsobjectgebruiksdoel", "verblijfsobjectstatus", "woonplaats", "x", "y" },
                values: new object[,]
                {
                    { 1, "Amsterdam", null, 1, null, 52.370215999999999, 4.895168, null, "1", "OBJ1", "Pand", "Hoofdstraat", 100, 1990, "PAND1", "Bestaand", "1234AB", "Noord-Holland", "Wonen", "Actief", "Amsterdam", 12345, 67890 },
                    { 2, "Rotterdam", "A", 2, null, 51.922499999999999, 4.4791699999999999, null, "2A", "OBJ2", "Pand", "Dorpsstraat", 80, 1980, "PAND2", "Bestaand", "5678CD", "Zuid-Holland", "Wonen", "Actief", "Rotterdam", 54321, 98765 },
                    { 3, "Utrecht", null, 3, 1, 52.090739999999997, 5.1214199999999996, null, "3-1", "OBJ3", "Pand", "Kerkstraat", 120, 2000, "PAND3", "Bestaand", "9012EF", "Utrecht", "Wonen", "Actief", "Utrecht", 11111, 22222 }
                });
        }
    }
}

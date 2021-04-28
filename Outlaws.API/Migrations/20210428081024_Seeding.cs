using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Outlaws.API.Migrations
{
    public partial class Seeding : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "DeathCauses",
                keyColumn: "DeathCauseId",
                keyValue: new Guid("711a4f01-6df6-46f6-b389-452224ad131d"));

            migrationBuilder.DeleteData(
                table: "Gangs",
                keyColumn: "GangId",
                keyValue: new Guid("b9ee6fc4-99b7-4d7b-80e6-2c1beb0af994"));

            migrationBuilder.InsertData(
                table: "DeathCauses",
                columns: new[] { "DeathCauseId", "DeathUri", "Description" },
                values: new object[] { new Guid("2db1b768-d37e-4c12-bf15-1006df06746f"), "http://dbpedia.org/resource/Gunshot_wounds", "Gunshot wound" });

            migrationBuilder.InsertData(
                table: "Gangs",
                columns: new[] { "GangId", "GangName", "GangUri" },
                values: new object[] { new Guid("911b4ff0-bb44-49dd-b3ad-dd993cf04641"), "Butch Cassidy's Wild Bunch", "http://dbpedia.org/resource/Butch_Cassidy's_Wild_Bunch" });

            migrationBuilder.InsertData(
                table: "Gangs",
                columns: new[] { "GangId", "GangName", "GangUri" },
                values: new object[] { new Guid("fd4eb443-dacb-4c08-9731-b7a10d5d4d35"), "Butch Cassidy's Wild Bunch", "https://dbpedia.org/resource/James-Younger_Gang" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "DeathCauses",
                keyColumn: "DeathCauseId",
                keyValue: new Guid("2db1b768-d37e-4c12-bf15-1006df06746f"));

            migrationBuilder.DeleteData(
                table: "Gangs",
                keyColumn: "GangId",
                keyValue: new Guid("911b4ff0-bb44-49dd-b3ad-dd993cf04641"));

            migrationBuilder.DeleteData(
                table: "Gangs",
                keyColumn: "GangId",
                keyValue: new Guid("fd4eb443-dacb-4c08-9731-b7a10d5d4d35"));

            migrationBuilder.InsertData(
                table: "DeathCauses",
                columns: new[] { "DeathCauseId", "DeathUri", "Description" },
                values: new object[] { new Guid("711a4f01-6df6-46f6-b389-452224ad131d"), "http://dbpedia.org/resource/Gunshot_wounds", "Gunshot wound" });

            migrationBuilder.InsertData(
                table: "Gangs",
                columns: new[] { "GangId", "GangName", "GangUri" },
                values: new object[] { new Guid("b9ee6fc4-99b7-4d7b-80e6-2c1beb0af994"), "Butch Cassidy's Wild Bunch", "http://dbpedia.org/resource/Butch_Cassidy's_Wild_Bunch" });
        }
    }
}

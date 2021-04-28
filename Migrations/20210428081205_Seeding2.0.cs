using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjectBackendDevelopment.Migrations
{
    public partial class Seeding20 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                values: new object[] { new Guid("0536a2ac-0c95-4479-b883-db4bba5bdcff"), "http://dbpedia.org/resource/Gunshot_wounds", "Gunshot wound" });

            migrationBuilder.InsertData(
                table: "Gangs",
                columns: new[] { "GangId", "GangName", "GangUri" },
                values: new object[] { new Guid("1a852173-2a5e-4b58-95a8-e347240a1311"), "Butch Cassidy's Wild Bunch", "http://dbpedia.org/resource/Butch_Cassidy's_Wild_Bunch" });

            migrationBuilder.InsertData(
                table: "Gangs",
                columns: new[] { "GangId", "GangName", "GangUri" },
                values: new object[] { new Guid("bc81b157-618c-4147-b58e-aabc0436e58d"), "James–Younger Gang", "https://dbpedia.org/resource/James-Younger_Gang" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "DeathCauses",
                keyColumn: "DeathCauseId",
                keyValue: new Guid("0536a2ac-0c95-4479-b883-db4bba5bdcff"));

            migrationBuilder.DeleteData(
                table: "Gangs",
                keyColumn: "GangId",
                keyValue: new Guid("1a852173-2a5e-4b58-95a8-e347240a1311"));

            migrationBuilder.DeleteData(
                table: "Gangs",
                keyColumn: "GangId",
                keyValue: new Guid("bc81b157-618c-4147-b58e-aabc0436e58d"));

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
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Outlaws.API.Migrations
{
    public partial class NoCauseAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                values: new object[,]
                {
                    { new Guid("b82f1cde-d0bc-46f8-bf90-f8092349a861"), "http://dbpedia.org/resource/Gunshot_wounds", "Gunshot wound" },
                    { new Guid("0502be48-d9c7-46b2-80bc-726fbc2f0b6c"), null, "None" }
                });

            migrationBuilder.InsertData(
                table: "Gangs",
                columns: new[] { "GangId", "GangName", "GangUri" },
                values: new object[,]
                {
                    { new Guid("48be1c96-ac9e-4dc7-978e-0924c8d92a87"), "Butch Cassidy's Wild Bunch", "http://dbpedia.org/resource/Butch_Cassidy's_Wild_Bunch" },
                    { new Guid("f2a2d10b-dfb3-46c3-95e5-08458ea5114c"), "James–Younger Gang", "https://dbpedia.org/resource/James-Younger_Gang" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "DeathCauses",
                keyColumn: "DeathCauseId",
                keyValue: new Guid("0502be48-d9c7-46b2-80bc-726fbc2f0b6c"));

            migrationBuilder.DeleteData(
                table: "DeathCauses",
                keyColumn: "DeathCauseId",
                keyValue: new Guid("b82f1cde-d0bc-46f8-bf90-f8092349a861"));

            migrationBuilder.DeleteData(
                table: "Gangs",
                keyColumn: "GangId",
                keyValue: new Guid("48be1c96-ac9e-4dc7-978e-0924c8d92a87"));

            migrationBuilder.DeleteData(
                table: "Gangs",
                keyColumn: "GangId",
                keyValue: new Guid("f2a2d10b-dfb3-46c3-95e5-08458ea5114c"));

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
    }
}

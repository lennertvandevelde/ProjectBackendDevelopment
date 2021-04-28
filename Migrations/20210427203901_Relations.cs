using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjectBackendDevelopment.Migrations
{
    public partial class Relations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DeathCauses",
                columns: table => new
                {
                    DeathCauseId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DeathUri = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeathCauses", x => x.DeathCauseId);
                });

            migrationBuilder.CreateTable(
                name: "Gangs",
                columns: table => new
                {
                    GangId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GangName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GangUri = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gangs", x => x.GangId);
                });

            migrationBuilder.CreateTable(
                name: "Outlaws",
                columns: table => new
                {
                    OutlawId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OutlawUri = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BirthDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeathDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeathCauseId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Outlaws", x => x.OutlawId);
                    table.ForeignKey(
                        name: "FK_Outlaws_DeathCauses_DeathCauseId",
                        column: x => x.DeathCauseId,
                        principalTable: "DeathCauses",
                        principalColumn: "DeathCauseId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GangOutlaw",
                columns: table => new
                {
                    GangId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OutlawId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GangOutlaw", x => new { x.GangId, x.OutlawId });
                    table.ForeignKey(
                        name: "FK_GangOutlaw_Gangs_GangId",
                        column: x => x.GangId,
                        principalTable: "Gangs",
                        principalColumn: "GangId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GangOutlaw_Outlaws_OutlawId",
                        column: x => x.OutlawId,
                        principalTable: "Outlaws",
                        principalColumn: "OutlawId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "DeathCauses",
                columns: new[] { "DeathCauseId", "DeathUri", "Description" },
                values: new object[] { new Guid("711a4f01-6df6-46f6-b389-452224ad131d"), "http://dbpedia.org/resource/Gunshot_wounds", "Gunshot wound" });

            migrationBuilder.InsertData(
                table: "Gangs",
                columns: new[] { "GangId", "GangName", "GangUri" },
                values: new object[] { new Guid("b9ee6fc4-99b7-4d7b-80e6-2c1beb0af994"), "Butch Cassidy's Wild Bunch", "http://dbpedia.org/resource/Butch_Cassidy's_Wild_Bunch" });

            migrationBuilder.CreateIndex(
                name: "IX_GangOutlaw_OutlawId",
                table: "GangOutlaw",
                column: "OutlawId");

            migrationBuilder.CreateIndex(
                name: "IX_Outlaws_DeathCauseId",
                table: "Outlaws",
                column: "DeathCauseId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GangOutlaw");

            migrationBuilder.DropTable(
                name: "Gangs");

            migrationBuilder.DropTable(
                name: "Outlaws");

            migrationBuilder.DropTable(
                name: "DeathCauses");
        }
    }
}

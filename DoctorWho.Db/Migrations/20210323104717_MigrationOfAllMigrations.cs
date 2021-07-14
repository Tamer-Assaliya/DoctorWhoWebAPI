using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DoctorWho.Db.Migrations
{
    public partial class MigrationOfAllMigrations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Authors",
                columns: table => new
                {
                    AuthorId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AuthorName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Authors", x => x.AuthorId);
                });

            migrationBuilder.CreateTable(
                name: "Companions",
                columns: table => new
                {
                    CompanionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanionName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WhoPlayed = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companions", x => x.CompanionId);
                });

            migrationBuilder.CreateTable(
                name: "Doctors",
                columns: table => new
                {
                    DoctorId = table.Column<int>(type: "int", nullable: false),
                    DoctorNumber = table.Column<int>(type: "int", nullable: false),
                    DoctorName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FirstEpisodeDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastEpisodeDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Doctors", x => x.DoctorId);
                });

            migrationBuilder.CreateTable(
                name: "Enemys",
                columns: table => new
                {
                    EnemyId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EnemyName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enemys", x => x.EnemyId);
                });

            migrationBuilder.CreateTable(
                name: "Episodes",
                columns: table => new
                {
                    EpisodeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SeriesNumber = table.Column<int>(type: "int", nullable: false),
                    EpisodeNumber = table.Column<int>(type: "int", nullable: false),
                    EpisodeType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EpisodeDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AuthorId = table.Column<int>(type: "int", nullable: true),
                    DoctorId = table.Column<int>(type: "int", nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Episodes", x => x.EpisodeId);
                    table.ForeignKey(
                        name: "FK_Episodes_Authors_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Authors",
                        principalColumn: "AuthorId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Episodes_Doctors_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "Doctors",
                        principalColumn: "DoctorId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EpisodeCompanion",
                columns: table => new
                {
                    EpisodeId = table.Column<int>(type: "int", nullable: false),
                    CompanionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EpisodeCompanion", x => new { x.EpisodeId, x.CompanionId });
                    table.ForeignKey(
                        name: "FK_EpisodeCompanion_Companions_CompanionId",
                        column: x => x.CompanionId,
                        principalTable: "Companions",
                        principalColumn: "CompanionId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EpisodeCompanion_Episodes_EpisodeId",
                        column: x => x.EpisodeId,
                        principalTable: "Episodes",
                        principalColumn: "EpisodeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EpisodeEnemy",
                columns: table => new
                {
                    EpisodeId = table.Column<int>(type: "int", nullable: false),
                    EnemyId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EpisodeEnemy", x => new { x.EpisodeId, x.EnemyId });
                    table.ForeignKey(
                        name: "FK_EpisodeEnemy_Enemys_EnemyId",
                        column: x => x.EnemyId,
                        principalTable: "Enemys",
                        principalColumn: "EnemyId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EpisodeEnemy_Episodes_EpisodeId",
                        column: x => x.EpisodeId,
                        principalTable: "Episodes",
                        principalColumn: "EpisodeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "AuthorId", "AuthorName" },
                values: new object[,]
                {
                    { 1, "tamer" },
                    { 2, "Fadi" },
                    { 3, "Mohannad" },
                    { 4, "Mohammed" },
                    { 5, "Ayman" }
                });

            migrationBuilder.InsertData(
                table: "Companions",
                columns: new[] { "CompanionId", "CompanionName", "WhoPlayed" },
                values: new object[,]
                {
                    { 3, "Leen", "Roa" },
                    { 2, "Sameer", "Ward" },
                    { 4, "Naheel", "Sali" },
                    { 5, "Samer", "Khalid" },
                    { 1, "Emad", "Omar" }
                });

            migrationBuilder.InsertData(
                table: "Doctors",
                columns: new[] { "DoctorId", "BirthDate", "DoctorName", "DoctorNumber", "FirstEpisodeDate", "LastEpisodeDate" },
                values: new object[,]
                {
                    { 1, new DateTime(1998, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "John", 834676823, new DateTime(1998, 6, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2012, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, new DateTime(1898, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Majd", 511385412, new DateTime(1998, 12, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1999, 5, 11, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, new DateTime(2000, 5, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Alaa", 589135733, new DateTime(2007, 7, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2015, 1, 13, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, new DateTime(1990, 7, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nihad", 399178240, new DateTime(1995, 2, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1997, 8, 9, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, new DateTime(1983, 4, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ali", 388528561, new DateTime(1988, 8, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1998, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Enemys",
                columns: new[] { "EnemyId", "Description", "EnemyName" },
                values: new object[,]
                {
                    { 4, "Unexpected one", "Areen" },
                    { 1, "an evil one", "Suha" },
                    { 2, "a cute one", "Jameel" },
                    { 3, "the wildest", "Jamal" },
                    { 5, "As the fire", "Yazan" }
                });

            migrationBuilder.InsertData(
                table: "Episodes",
                columns: new[] { "EpisodeId", "AuthorId", "DoctorId", "EpisodeDate", "EpisodeNumber", "EpisodeType", "Notes", "SeriesNumber", "Title" },
                values: new object[,]
                {
                    { 3, 5, 1, new DateTime(2013, 12, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 629, "Funny", "loved by people", 766, "GOT" },
                    { 1, 2, 2, new DateTime(2021, 4, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 565, "Action", "best car drifting", 432, "Fast & Furios" },
                    { 4, 1, 2, new DateTime(2000, 11, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 257, "Thriller", "An exciting one", 551, "Prison Break" },
                    { 2, 4, 3, new DateTime(2015, 5, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 112, "Fancy", "back to worldwide war 2", 433, "The Game" },
                    { 5, 1, 3, new DateTime(2018, 5, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 391, "Mystrey", "psychopath lover", 984, "You" }
                });

            migrationBuilder.InsertData(
                table: "EpisodeCompanion",
                columns: new[] { "CompanionId", "EpisodeId" },
                values: new object[,]
                {
                    { 1, 3 },
                    { 3, 1 },
                    { 3, 4 },
                    { 5, 2 },
                    { 2, 5 }
                });

            migrationBuilder.InsertData(
                table: "EpisodeEnemy",
                columns: new[] { "EnemyId", "EpisodeId" },
                values: new object[,]
                {
                    { 4, 3 },
                    { 1, 1 },
                    { 3, 1 },
                    { 3, 4 },
                    { 2, 5 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_EpisodeCompanion_CompanionId",
                table: "EpisodeCompanion",
                column: "CompanionId");

            migrationBuilder.CreateIndex(
                name: "IX_EpisodeEnemy_EnemyId",
                table: "EpisodeEnemy",
                column: "EnemyId");

            migrationBuilder.CreateIndex(
                name: "IX_Episodes_AuthorId",
                table: "Episodes",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_Episodes_DoctorId",
                table: "Episodes",
                column: "DoctorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EpisodeCompanion");

            migrationBuilder.DropTable(
                name: "EpisodeEnemy");

            migrationBuilder.DropTable(
                name: "Companions");

            migrationBuilder.DropTable(
                name: "Enemys");

            migrationBuilder.DropTable(
                name: "Episodes");

            migrationBuilder.DropTable(
                name: "Authors");

            migrationBuilder.DropTable(
                name: "Doctors");
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DoctorWho.Db.Migrations
{
    public partial class SeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                    { 1, new DateTime(1, 1, 1, 0, 0, 1, 998, DateTimeKind.Unspecified).AddTicks(601), "John", 834676823, new DateTime(1, 1, 1, 0, 0, 1, 998, DateTimeKind.Unspecified).AddTicks(602), new DateTime(1, 1, 1, 0, 0, 2, 12, DateTimeKind.Unspecified).AddTicks(601) },
                    { 2, new DateTime(1, 1, 1, 0, 0, 1, 898, DateTimeKind.Unspecified).AddTicks(1201), "Majd", 511385412, new DateTime(1, 1, 1, 0, 0, 1, 998, DateTimeKind.Unspecified).AddTicks(1211), new DateTime(1, 1, 1, 0, 0, 1, 999, DateTimeKind.Unspecified).AddTicks(511) },
                    { 3, new DateTime(1, 1, 1, 0, 0, 2, 0, DateTimeKind.Unspecified).AddTicks(506), "Alaa", 589135733, new DateTime(1, 1, 1, 0, 0, 2, 7, DateTimeKind.Unspecified).AddTicks(706), new DateTime(1, 1, 1, 0, 0, 2, 15, DateTimeKind.Unspecified).AddTicks(113) },
                    { 4, new DateTime(1, 1, 1, 0, 0, 1, 990, DateTimeKind.Unspecified).AddTicks(714), "Nihad", 399178240, new DateTime(1, 1, 1, 0, 0, 1, 995, DateTimeKind.Unspecified).AddTicks(216), new DateTime(1, 1, 1, 0, 0, 1, 997, DateTimeKind.Unspecified).AddTicks(809) },
                    { 5, new DateTime(1, 1, 1, 0, 0, 1, 983, DateTimeKind.Unspecified).AddTicks(417), "Ali", 388528561, new DateTime(1, 1, 1, 0, 0, 1, 988, DateTimeKind.Unspecified).AddTicks(815), new DateTime(1, 1, 1, 0, 0, 1, 998, DateTimeKind.Unspecified).AddTicks(205) }
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
                    { 3, 5, 1, new DateTime(1, 1, 1, 0, 0, 2, 13, DateTimeKind.Unspecified).AddTicks(1204), 629, "Funny", "loved by people", 766, "GOT" },
                    { 1, 2, 2, new DateTime(1, 1, 1, 0, 0, 2, 21, DateTimeKind.Unspecified).AddTicks(414), 565, "Action", "best car drifting", 432, "Fast & Furios" },
                    { 4, 1, 2, new DateTime(1, 1, 1, 0, 0, 2, 0, DateTimeKind.Unspecified).AddTicks(1123), 257, "Thriller", "An exciting one", 551, "Prison Break" },
                    { 2, 4, 3, new DateTime(1, 1, 1, 0, 0, 2, 15, DateTimeKind.Unspecified).AddTicks(502), 112, "Fancy", "back to worldwide war 2", 433, "The Game" },
                    { 5, 1, 3, new DateTime(1, 1, 1, 0, 0, 2, 18, DateTimeKind.Unspecified).AddTicks(512), 391, "Mystrey", "psychopath lover", 984, "You" }
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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "AuthorId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Companions",
                keyColumn: "CompanionId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "DoctorId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "DoctorId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Enemys",
                keyColumn: "EnemyId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "EpisodeCompanion",
                keyColumns: new[] { "CompanionId", "EpisodeId" },
                keyValues: new object[] { 3, 1 });

            migrationBuilder.DeleteData(
                table: "EpisodeCompanion",
                keyColumns: new[] { "CompanionId", "EpisodeId" },
                keyValues: new object[] { 5, 2 });

            migrationBuilder.DeleteData(
                table: "EpisodeCompanion",
                keyColumns: new[] { "CompanionId", "EpisodeId" },
                keyValues: new object[] { 1, 3 });

            migrationBuilder.DeleteData(
                table: "EpisodeCompanion",
                keyColumns: new[] { "CompanionId", "EpisodeId" },
                keyValues: new object[] { 3, 4 });

            migrationBuilder.DeleteData(
                table: "EpisodeCompanion",
                keyColumns: new[] { "CompanionId", "EpisodeId" },
                keyValues: new object[] { 2, 5 });

            migrationBuilder.DeleteData(
                table: "EpisodeEnemy",
                keyColumns: new[] { "EnemyId", "EpisodeId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "EpisodeEnemy",
                keyColumns: new[] { "EnemyId", "EpisodeId" },
                keyValues: new object[] { 3, 1 });

            migrationBuilder.DeleteData(
                table: "EpisodeEnemy",
                keyColumns: new[] { "EnemyId", "EpisodeId" },
                keyValues: new object[] { 4, 3 });

            migrationBuilder.DeleteData(
                table: "EpisodeEnemy",
                keyColumns: new[] { "EnemyId", "EpisodeId" },
                keyValues: new object[] { 3, 4 });

            migrationBuilder.DeleteData(
                table: "EpisodeEnemy",
                keyColumns: new[] { "EnemyId", "EpisodeId" },
                keyValues: new object[] { 2, 5 });

            migrationBuilder.DeleteData(
                table: "Companions",
                keyColumn: "CompanionId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Companions",
                keyColumn: "CompanionId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Companions",
                keyColumn: "CompanionId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Companions",
                keyColumn: "CompanionId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Enemys",
                keyColumn: "EnemyId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Enemys",
                keyColumn: "EnemyId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Enemys",
                keyColumn: "EnemyId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Enemys",
                keyColumn: "EnemyId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Episodes",
                keyColumn: "EpisodeId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Episodes",
                keyColumn: "EpisodeId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Episodes",
                keyColumn: "EpisodeId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Episodes",
                keyColumn: "EpisodeId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Episodes",
                keyColumn: "EpisodeId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "AuthorId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "AuthorId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "AuthorId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "AuthorId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "DoctorId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "DoctorId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "DoctorId",
                keyValue: 3);
        }
    }
}

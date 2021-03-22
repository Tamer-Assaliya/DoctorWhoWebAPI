using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DoctorWho.Db.Migrations
{
    public partial class CorrectDates : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "DoctorId",
                keyValue: 1,
                columns: new[] { "BirthDate", "FirstEpisodeDate", "LastEpisodeDate" },
                values: new object[] { new DateTime(1998, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1998, 6, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2012, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "DoctorId",
                keyValue: 2,
                columns: new[] { "BirthDate", "FirstEpisodeDate", "LastEpisodeDate" },
                values: new object[] { new DateTime(1898, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1998, 12, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1999, 5, 11, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "DoctorId",
                keyValue: 3,
                columns: new[] { "BirthDate", "FirstEpisodeDate", "LastEpisodeDate" },
                values: new object[] { new DateTime(2000, 5, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2007, 7, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2015, 1, 13, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "DoctorId",
                keyValue: 4,
                columns: new[] { "BirthDate", "FirstEpisodeDate", "LastEpisodeDate" },
                values: new object[] { new DateTime(1990, 7, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1995, 2, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1997, 8, 9, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "DoctorId",
                keyValue: 5,
                columns: new[] { "BirthDate", "FirstEpisodeDate", "LastEpisodeDate" },
                values: new object[] { new DateTime(1983, 4, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1988, 8, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1998, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Episodes",
                keyColumn: "EpisodeId",
                keyValue: 1,
                column: "EpisodeDate",
                value: new DateTime(2021, 4, 14, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Episodes",
                keyColumn: "EpisodeId",
                keyValue: 2,
                column: "EpisodeDate",
                value: new DateTime(2015, 5, 2, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Episodes",
                keyColumn: "EpisodeId",
                keyValue: 3,
                column: "EpisodeDate",
                value: new DateTime(2013, 12, 4, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Episodes",
                keyColumn: "EpisodeId",
                keyValue: 4,
                column: "EpisodeDate",
                value: new DateTime(2000, 11, 23, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Episodes",
                keyColumn: "EpisodeId",
                keyValue: 5,
                column: "EpisodeDate",
                value: new DateTime(2018, 5, 12, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "DoctorId",
                keyValue: 1,
                columns: new[] { "BirthDate", "FirstEpisodeDate", "LastEpisodeDate" },
                values: new object[] { new DateTime(1, 1, 1, 0, 0, 1, 998, DateTimeKind.Unspecified).AddTicks(601), new DateTime(1, 1, 1, 0, 0, 1, 998, DateTimeKind.Unspecified).AddTicks(602), new DateTime(1, 1, 1, 0, 0, 2, 12, DateTimeKind.Unspecified).AddTicks(601) });

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "DoctorId",
                keyValue: 2,
                columns: new[] { "BirthDate", "FirstEpisodeDate", "LastEpisodeDate" },
                values: new object[] { new DateTime(1, 1, 1, 0, 0, 1, 898, DateTimeKind.Unspecified).AddTicks(1201), new DateTime(1, 1, 1, 0, 0, 1, 998, DateTimeKind.Unspecified).AddTicks(1211), new DateTime(1, 1, 1, 0, 0, 1, 999, DateTimeKind.Unspecified).AddTicks(511) });

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "DoctorId",
                keyValue: 3,
                columns: new[] { "BirthDate", "FirstEpisodeDate", "LastEpisodeDate" },
                values: new object[] { new DateTime(1, 1, 1, 0, 0, 2, 0, DateTimeKind.Unspecified).AddTicks(506), new DateTime(1, 1, 1, 0, 0, 2, 7, DateTimeKind.Unspecified).AddTicks(706), new DateTime(1, 1, 1, 0, 0, 2, 15, DateTimeKind.Unspecified).AddTicks(113) });

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "DoctorId",
                keyValue: 4,
                columns: new[] { "BirthDate", "FirstEpisodeDate", "LastEpisodeDate" },
                values: new object[] { new DateTime(1, 1, 1, 0, 0, 1, 990, DateTimeKind.Unspecified).AddTicks(714), new DateTime(1, 1, 1, 0, 0, 1, 995, DateTimeKind.Unspecified).AddTicks(216), new DateTime(1, 1, 1, 0, 0, 1, 997, DateTimeKind.Unspecified).AddTicks(809) });

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "DoctorId",
                keyValue: 5,
                columns: new[] { "BirthDate", "FirstEpisodeDate", "LastEpisodeDate" },
                values: new object[] { new DateTime(1, 1, 1, 0, 0, 1, 983, DateTimeKind.Unspecified).AddTicks(417), new DateTime(1, 1, 1, 0, 0, 1, 988, DateTimeKind.Unspecified).AddTicks(815), new DateTime(1, 1, 1, 0, 0, 1, 998, DateTimeKind.Unspecified).AddTicks(205) });

            migrationBuilder.UpdateData(
                table: "Episodes",
                keyColumn: "EpisodeId",
                keyValue: 1,
                column: "EpisodeDate",
                value: new DateTime(1, 1, 1, 0, 0, 2, 21, DateTimeKind.Unspecified).AddTicks(414));

            migrationBuilder.UpdateData(
                table: "Episodes",
                keyColumn: "EpisodeId",
                keyValue: 2,
                column: "EpisodeDate",
                value: new DateTime(1, 1, 1, 0, 0, 2, 15, DateTimeKind.Unspecified).AddTicks(502));

            migrationBuilder.UpdateData(
                table: "Episodes",
                keyColumn: "EpisodeId",
                keyValue: 3,
                column: "EpisodeDate",
                value: new DateTime(1, 1, 1, 0, 0, 2, 13, DateTimeKind.Unspecified).AddTicks(1204));

            migrationBuilder.UpdateData(
                table: "Episodes",
                keyColumn: "EpisodeId",
                keyValue: 4,
                column: "EpisodeDate",
                value: new DateTime(1, 1, 1, 0, 0, 2, 0, DateTimeKind.Unspecified).AddTicks(1123));

            migrationBuilder.UpdateData(
                table: "Episodes",
                keyColumn: "EpisodeId",
                keyValue: 5,
                column: "EpisodeDate",
                value: new DateTime(1, 1, 1, 0, 0, 2, 18, DateTimeKind.Unspecified).AddTicks(512));
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

namespace DoctorWho.Db.Migrations
{
    public partial class AddView : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(
                    @"CREATE VIEW viewEpisodes AS
                    SELECT a.AuthorName, d.DoctorName, dbo.fnCompanion(e.EpisodeId) CompanionName, dbo.fnEnimes(e.EpisodeId) EnemyName
                    FROM Episodes e
                    JOIN Authors a ON e.AuthorId=a.AuthorId
                    JOIN Doctors d ON e.DoctorId=d.DoctorId
                    "
            );
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP VIEW IF EXISTS viewEpisodes");
        }
    }
}

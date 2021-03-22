using Microsoft.EntityFrameworkCore.Migrations;

namespace DoctorWho.Db.Migrations
{
    public partial class AddFnSps : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(
                @"CREATE OR ALTER FUNCTION fnCompanion (
                    @EpisodeId INT
                )
                RETURNS VARCHAR(50) AS
                BEGIN
                    Declare @val Varchar(MAX); 
                    SELECT  @val=COALESCE(@val + ', '+ c.CompanionName,c.CompanionName)
                    FROM Companions c
                    JOIN EpisodeCompanion ec
                    ON c.CompanionId=ec.CompanionId AND ec.EpisodeId=@EpisodeId
                   -- PRINT @val;
                    RETURN @val;
                END;
                "
            );
            migrationBuilder.Sql(
                @"CREATE OR ALTER FUNCTION fnEnimes (
                    @EpisodeId INT
                )
                RETURNS VARCHAR(50) AS
                BEGIN
                    Declare @val Varchar(MAX); 
                    SELECT  @val=COALESCE(@val + ', '+ e.EnemyName,e.EnemyName)
                    FROM Enemys e
                    JOIN EpisodeEnemy ee
                    ON e.EnemyId=ee.EnemyId AND ee.EpisodeId=@EpisodeId
                    RETURN @val;
                END; 
                "
            );
            migrationBuilder.Sql(
                @"GO
                CREATE OR ALTER PROCEDURE spSummariseEpisodes
                AS BEGIN
                  SELECT TOP(3) c.CompanionName, COUNT(*) Companion_count
                  FROM EpisodeCompanion ec
                  JOIN Companions c
                  ON ec.CompanionId=c.CompanionId
                  GROUP BY c.CompanionId , c.CompanionName
                  ORDER BY Companion_count DESC 
                  ---
                  SELECT TOP(3) e.EnemyName, COUNT(*) Enemy_count
                  FROM EpisodeEnemy ee
                  JOIN Enemys e
                  ON ee.EnemyId=e.EnemyId
                  GROUP BY e.EnemyId , e.EnemyName
                  ORDER BY Enemy_count DESC 
                END;"
            );
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP FUNCTION IF EXISTS fnCompanion");
            migrationBuilder.Sql("DROP FUNCTION IF EXISTS fnEnimes");
            migrationBuilder.Sql("DROP PROCEDURE IF EXISTS spSummariseEpisodes");
        }
    }
}

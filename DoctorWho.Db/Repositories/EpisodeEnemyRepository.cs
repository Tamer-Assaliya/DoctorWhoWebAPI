using System;

namespace DoctorWho.Db
{
    public class EpisodeEnemyRepository
    {
        private static DoctorWhoCoreDbContext _context = new DoctorWhoCoreDbContext();

        public void AddEnemyToEpisode(int enemyId, int episodeId)
        {
            var episodeEnemy = new EpisodeEnemy() { EnemyId = enemyId, EpisodeId = episodeId };
            _context.Add<EpisodeEnemy>(episodeEnemy);
            _context.SaveChanges();
        }
    }
}

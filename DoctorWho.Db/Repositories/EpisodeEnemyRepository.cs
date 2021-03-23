using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;

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

        public bool EpisodeEnemyExist(int enemyId, int episodeId)
        {
            Episode episodeWithEnemies = _context.Episodes.Where(e => e.EpisodeId == episodeId).Include(e => e.EpisodeEnemyies).FirstOrDefault();
            return episodeWithEnemies.EpisodeEnemyies.Any(ee => ee.EnemyId == enemyId);
        }
    }
}

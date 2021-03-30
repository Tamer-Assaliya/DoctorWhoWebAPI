using System.Collections.Generic;

namespace DoctorWho.Db.Contracts
{
    public interface IEpisodeEnemyRepository
    {
        void AddEnemyToEpisode(int enemyId, int episodeId);

        bool EpisodeEnemyExist(int enemyId, int episodeId);
    }
}
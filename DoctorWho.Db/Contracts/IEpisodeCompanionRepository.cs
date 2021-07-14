using System.Collections.Generic;

namespace DoctorWho.Db.Contracts
{
    public interface IEpisodeCompanionRepository
    {
        void AddCompanionToEpisode(int companionId, int episodeId);

        bool EpisodeCompanionExist(int companionId, int episodeId);
    }
}
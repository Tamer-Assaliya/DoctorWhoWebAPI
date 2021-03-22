using System;

namespace DoctorWho.Db
{
    public class EpisodeCompanionRepository
    {
        private static DoctorWhoCoreDbContext _context = new DoctorWhoCoreDbContext();

        public void AddCompanionToEpisode(int companionId, int episodeId)
        {
            var episodeCompanion = new EpisodeCompanion() { CompanionId = companionId, EpisodeId = episodeId };
            _context.Add<EpisodeCompanion>(episodeCompanion);
            _context.SaveChanges();
        }
    }
}

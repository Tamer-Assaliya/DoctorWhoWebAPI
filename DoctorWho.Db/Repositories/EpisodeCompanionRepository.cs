using System.Security.Cryptography.X509Certificates;
using System.Security.Cryptography;
using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

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

        public bool EpisodeCompanionExist(int companionId, int episodeId)
        {
            Episode episodeWithCompanions = _context.Episodes.Where(e => e.EpisodeId == episodeId).Include(e => e.EpisodeCompanions).FirstOrDefault();
            return episodeWithCompanions.EpisodeCompanions.Any(ec => ec.CompanionId == companionId);
        }
    }
}

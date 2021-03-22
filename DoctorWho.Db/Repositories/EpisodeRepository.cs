using System;

namespace DoctorWho.Db
{
    public class EpisodeRepository
    {
        private static DoctorWhoCoreDbContext _context = new DoctorWhoCoreDbContext();

        public void CreatEpisode(int seriesNumber, int episodeNumber, string episodeType, string title, DateTime episodeDate, int? authorId, int? doctorId, string notes)
        {
            var episode = new Episode()
            {
                AuthorId = authorId,
                DoctorId = doctorId,
                EpisodeDate = episodeDate,
                EpisodeNumber = episodeNumber,
                EpisodeType = episodeType,
                Notes = notes,
                SeriesNumber = seriesNumber,
                Title = title
            };
            _context.Add<Episode>(episode);
            _context.SaveChanges();
        }

        public void UpdateEpisode(int id, int seriesNumber, int episodeNumber, string episodeType, string title, DateTime episodeDate, int? authorId, int? doctorId, string notes)
        {
            var episode = _context.Find<Episode>(id);
            episode.AuthorId = authorId;
            episode.DoctorId = doctorId;
            episode.EpisodeDate = episodeDate;
            episode.EpisodeNumber = episodeNumber;
            episode.EpisodeType = episodeType;
            episode.Notes = notes;
            episode.SeriesNumber = seriesNumber;
            episode.Title = title;
            _context.SaveChanges();
        }

        public void DeleteEpisode(int id)
        {
            var episode = _context.Find<Episode>(id);
            _context.Remove<Episode>(episode);
            _context.SaveChanges();
        }
    }
}

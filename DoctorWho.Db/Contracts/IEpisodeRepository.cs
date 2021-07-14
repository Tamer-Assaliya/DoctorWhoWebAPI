using System;
using System.Collections.Generic;

namespace DoctorWho.Db.Contracts
{
    public interface IEpisodeRepository
    {
        void CreatEpisode(Episode episode);

        void UpdateEpisode(int id, int seriesNumber, int episodeNumber, string episodeType, string title, DateTime episodeDate, int? authorId, int? doctorId, string notes);

        void DeleteEpisode(int id);

        List<Episode> GetAllEpisodes();

        Episode GetEpisode(int id);
    }
}
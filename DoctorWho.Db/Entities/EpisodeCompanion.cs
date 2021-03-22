using System;

namespace DoctorWho.Db
{
    public class EpisodeCompanion
    {
        public int EpisodeId { get; set; }
        public Episode Episode { get; set; }
        public int CompanionId { get; set; }
        public Companion Companion { get; set; }
    }
}

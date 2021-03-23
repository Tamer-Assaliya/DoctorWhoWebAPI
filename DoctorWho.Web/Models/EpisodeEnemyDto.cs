using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DoctorWho.Db;

namespace DoctorWho.Web.Models
{
    public class EpisodeEnemyDto
    {
        public int EpisodeId { get; set; }
        public int EnemyId { get; set; }
    }
}

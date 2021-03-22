using System;
using System.Collections.Generic;

namespace DoctorWho.Db
{
    public class Enemy
    {
        public Enemy()
        {
            EpisodeEnemyies = new List<EpisodeEnemy>();
        }

        public int EnemyId { get; set; }
        public string EnemyName { get; set; }
        public string Description { get; set; }
        public List<EpisodeEnemy> EpisodeEnemyies { get; set; }
    }
}

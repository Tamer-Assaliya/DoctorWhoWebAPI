using System;

namespace DoctorWho.Db
{
    public class EnemyRepository
    {
        private static DoctorWhoCoreDbContext _context = new DoctorWhoCoreDbContext();

        public void CreatEnemy(string name, string description)
        {
            var enemy = new Enemy() { EnemyName = name, Description = description };
            _context.Enemys.Add(enemy);
            _context.SaveChanges();
        }

        public void UpdateEnemy(int id, string name, string description)
        {
            var enemy = _context.Find<Enemy>(id);
            enemy.EnemyName = name;
            enemy.Description = description;
            _context.SaveChanges();
        }

        public void DeleteEnemy(int id)
        {
            var enemy = _context.Find<Enemy>(id);
            _context.Remove<Enemy>(enemy);
            _context.SaveChanges();
        }

        public Enemy GetEnemyById(int id)
        {
            var enemy = _context.Enemys.Find(id);
            return enemy;
        }
    }
}

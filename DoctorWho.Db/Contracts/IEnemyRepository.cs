using System.Collections.Generic;

namespace DoctorWho.Db.Contracts
{
    public interface IEnemyRepository
    {
        void CreatEnemy(string name, string description);

        void UpdateEnemy(int id, string name, string description);

        void DeleteEnemy(int id);

        Enemy GetEnemyById(int id);
    }
}
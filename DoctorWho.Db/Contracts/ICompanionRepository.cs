using System.Collections.Generic;

namespace DoctorWho.Db.Contracts
{
    public interface ICompanionRepository
    {
        void CreatCompanion(string name, string whoPlayed);

        void UpdateCompanion(int id, string name, string whoPlayed);

        void DeleteCompanion(int id);

        Companion GetCompanionById(int id);
    }
}
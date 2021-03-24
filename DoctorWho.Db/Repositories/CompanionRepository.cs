using System;

namespace DoctorWho.Db
{
    public class CompanionRepository
    {
        private static DoctorWhoCoreDbContext _context;

        public CompanionRepository(DoctorWhoCoreDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public void CreatCompanion(string name, string whoPlayed)
        {
            var companion = new Companion() { CompanionName = name, WhoPlayed = whoPlayed };
            _context.Companions.Add(companion);
            _context.SaveChanges();
        }

        public void UpdateCompanion(int id, string name, string whoPlayed)
        {
            var companion = _context.Find<Companion>(id);
            companion.CompanionName = name;
            companion.WhoPlayed = whoPlayed;
            _context.SaveChanges();
        }

        public void DeleteCompanion(int id)
        {
            var companion = _context.Find<Companion>(id);
            _context.Remove<Companion>(companion);
        }

        public Companion GetCompanionById(int id)
        {
            var companion = _context.Companions.Find(id);
            return companion;
        }
    }
}

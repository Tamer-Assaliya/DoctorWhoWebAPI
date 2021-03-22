using System;

namespace DoctorWho.Db
{
    public class AuthorRepository
    {
        private static DoctorWhoCoreDbContext _context = new DoctorWhoCoreDbContext();

        public void CreatAuthor(string name)
        {
            var author = new Author() { AuthorName = name };
            _context.Add<Author>(author);
            _context.SaveChanges();
        }

        public void UpdateAuthor(int id, string name)
        {
            var author = _context.Find<Author>(id);
            author.AuthorName = name;
            _context.SaveChanges();
        }

        public void DeleteAuthor(int id)
        {
            var author = _context.Find<Author>(id);
            _context.Remove<Author>(author);
            _context.SaveChanges();
        }
    }
}

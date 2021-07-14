using System;
using System.Linq;
using System.Collections.Generic;
using DoctorWho.Db.Contracts;

namespace DoctorWho.Db
{
    public class AuthorRepository : IAuthorRepository
    {
        private static DoctorWhoCoreDbContext _context;

        public AuthorRepository(DoctorWhoCoreDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public void CreatAuthor(string name)
        {
            var author = new Author() { AuthorName = name };
            _context.Add<Author>(author);
            _context.SaveChanges();
        }

        public void UpdateAuthor()
        {
            // var author = _context.Find<Author>(id);
            // author.AuthorName = name;
            _context.SaveChanges();
        }

        public void DeleteAuthor(int id)
        {
            var author = _context.Find<Author>(id);
            _context.Remove<Author>(author);
            _context.SaveChanges();
        }

        public Author getAuthor(int id)
        {
            var author = _context.Find<Author>(id);
            return author;
        }

        public List<Author> GetAllAuthors()
        {
            var authors = _context.Authors.Select(a => a).ToList();
            return authors;
        }
    }
}

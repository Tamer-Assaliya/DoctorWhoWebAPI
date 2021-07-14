using System.Collections.Generic;

namespace DoctorWho.Db.Contracts
{
    public interface IAuthorRepository
    {
        void CreatAuthor(string name);

        void UpdateAuthor();

        void DeleteAuthor(int id);

        Author getAuthor(int id);

        List<Author> GetAllAuthors();
    }
}
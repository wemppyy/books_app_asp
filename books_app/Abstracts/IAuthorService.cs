using books_app.DAL;
using books_app.DAL.Abstracts;
using books_app.DAL.Entities;
using books_app.Models;

namespace books_app.Abstracts
{
    public interface IAuthorService
    {
        bool Add(AuthorDTO authorDto);
        bool Update(AuthorDTO authorDto);

        bool Delete(AuthorDTO authorDTO);

        List<Author> GetAll();

        AuthorDTO GetById(int id);
    }
}

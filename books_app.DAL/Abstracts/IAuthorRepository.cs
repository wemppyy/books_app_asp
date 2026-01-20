using books_app.DAL.Entities;

namespace books_app.DAL.Abstracts
{
    public interface IAuthorRepository
    {
        Author GetAuthorById(int authorId);
        bool AddAuthor(Author author);
        bool UpdateAuthor(Author author);
        bool DeleteAuthor(Author author);
        List<Author> GetAllAuthors();
    }
}

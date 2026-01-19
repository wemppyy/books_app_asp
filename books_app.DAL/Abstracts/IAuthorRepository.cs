using books_app.DAL.Entities;

namespace books_app.DAL.Abstracts
{
    public interface IAuthorRepository
    {
        Author GetAuthorById(int authorId);
        void AddAuthor(Author author);
        List<Author> GetAllAuthors();
    }
}

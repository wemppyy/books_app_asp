using books_app.DAL.Entities;

namespace books_app.DAL.Abstracts
{
    public interface IBookRepository
    {
        bool AddBook(Book book);
        bool UpdateBook(Book book);
        Book GetBookById(int bookId);
        List<Book> GetAllBooks();
    }
}

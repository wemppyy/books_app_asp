using books_app.DAL.Entities;
using books_app.DAL.Abstracts;
using System.Linq;

namespace books_app.DAL
{
    public class BookRepository : IBookRepository
    {
        private readonly AppDbContext _db;
        public BookRepository(AppDbContext db)
        {
            _db = db;
        }
        public void AddBook(Book book)
        {
            _db.Books.Add(book);
            _db.SaveChanges();
        }

        public Book GetBookById(int bookId)
        {
            return _db.Books.FirstOrDefault(x => x.Id == bookId);
        }

        public List<Book> GetAllBooks()
        {
            return _db.Books.ToList();
        }
    }
}

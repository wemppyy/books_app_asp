using books_app.DAL.Entities;
using books_app.DAL.Abstracts;
using System.Linq;

namespace books_app.DAL.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly AppDbContext _db;
        public BookRepository(AppDbContext db)
        {
            _db = db;
        }
        public bool AddBook(Book book)
        {
            var res = _db.Books.Add(book) != null;
            _db.SaveChanges();

            return res;
        }

        public Book GetBookById(int bookId)
        {
            return _db.Books.FirstOrDefault(x => x.Id == bookId);
        }

        public List<Book> GetAllBooks()
        {
            return _db.Books.ToList();
        }

        public bool UpdateBook(Book book)
        {
            var existingBook = _db.Books.FirstOrDefault(x => x.Id == book.Id);
            if (existingBook == null)
            {
                return false;
            }
            existingBook.Title = book.Title;
            existingBook.PublishYear = book.PublishYear;
            existingBook.Price = book.Price;
            existingBook.AuthorId = book.AuthorId;
            _db.SaveChanges();
            return true;
        }
    }
}

using books_app.Abstracts;
using books_app.DAL;
using books_app.DAL.Abstracts;
using books_app.DAL.Entities;
using books_app.Models;

namespace books_app.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;

        public BookService(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }
        public bool Add(BookDTO bookDto)
        {
            var book = new Book
            {
                Title = bookDto.Title,
                ISBN = bookDto.ISBN,
                PublishYear = bookDto.PublishYear,
                Price = bookDto.Price,
                AuthorId = bookDto.AuthorId
            };
            return _bookRepository.AddBook(book);
        }

        public List<Book> GetAll()
        {
            return _bookRepository.GetAllBooks();
        }

        public BookDTO GetById(int id) {
            var a = _bookRepository.GetBookById(id);
            if (a == null) return null;
            return new BookDTO
            {
                Id = a.Id,
                Title = a.Title,
                ISBN = a.ISBN,
                PublishYear = a.PublishYear,
                Price = a.Price,
                AuthorId = a.AuthorId
            };
        }

        public bool Update(BookDTO bookDto)
        {
            var book = new Book
            {
                Id = bookDto.Id,
                Title = bookDto.Title,
                ISBN = bookDto.ISBN,
                PublishYear = bookDto.PublishYear,
                Price = bookDto.Price,
                AuthorId = bookDto.AuthorId
            };
            return _bookRepository.UpdateBook(book);
        }
    }
}

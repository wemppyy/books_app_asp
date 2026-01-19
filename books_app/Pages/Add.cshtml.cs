using books_app.DAL.Abstracts;
using books_app.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using books_app.DAL.Entities;
using System.Linq;

namespace books_app.Pages
{
    public class AddModel : PageModel
    {
        [BindProperty]
        public AuthorModel Author { get; set; }
        [BindProperty]
        public BookModel Book { get; set; }
        private readonly IAuthorRepository _authorRepository;
        private readonly IBookRepository _bookRepository;

        public AddModel(IAuthorRepository authorRepository, IBookRepository bookRepository)
        {
            _authorRepository = authorRepository;
            _bookRepository = bookRepository;
        }

        public void OnGet()
        {
            Book = new BookModel();
            Author = new AuthorModel();
        }

        public void OnPostSaveAuthor()
        {
            var author = new Author
            {
                FirstName = Author.FirstName,
                LastName = Author.LastName,
                DateOfBirth = Author.DateOfBirth
            };
            _authorRepository.AddAuthor(author);
        }

        public void OnPostSaveBook()
        {
             var book = new Book
            {
                Title = Book.Title,
                ISBN = Book.ISBN,
                PublishYear = Book.PublishYear,
                Price = Book.Price,
                AuthorId = Book.AuthorId
            };

            _bookRepository.AddBook(book);
        }
    }
}
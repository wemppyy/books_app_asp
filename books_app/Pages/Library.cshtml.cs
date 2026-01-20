using books_app.Abstracts;
using books_app.DAL.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace books_app.Pages
{
    public class LibraryModel : PageModel
    {
        private readonly IAuthorService _authorService;
        private readonly IBookService _bookService;
        public List<Author> Authors { get; set; }
        public List<Book> Books { get; set; }

        public LibraryModel(IAuthorService authorService, IBookService bookService)
        {
            _authorService = authorService;
            _bookService = bookService;
        }

        public void OnGet()
        {
            Authors = _authorService.GetAll();
            Books = _bookService.GetAll();
        }
    }
}

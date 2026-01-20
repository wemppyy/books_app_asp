using books_app.Models;
using books_app.Abstracts;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace books_app.Pages
{
    public class AddBookModel : PageModel
    {
        [BindProperty]
        public BookDTO Book { get; set; }

        private readonly IBookService _bookService;
        private readonly IAuthorService _authorService;
        public string InfoMessage = "";
        public IEnumerable<SelectListItem> Authors { get; set; }

        public AddBookModel(IBookService bookService, IAuthorService authorService)
        {
            _bookService = bookService;
            _authorService = authorService;
            InfoMessage = "";
        }

        public void OnGet()
        {
            Book = new BookDTO();
            Authors = _authorService.GetAll().Select(a => new SelectListItem
            {
                Value = a.Id.ToString(),
                Text = $"{a.FirstName} {a.LastName}"
            });
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                InfoMessage = "Invalid book data.";
                return Page();
            }

            _bookService.Add(Book);
            InfoMessage = "Book saved successfully.";
            return RedirectToPage("/Library");
        }
    }
}

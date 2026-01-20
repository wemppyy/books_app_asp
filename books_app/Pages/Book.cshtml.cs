using books_app.Abstracts;
using books_app.DAL.Entities;
using books_app.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;

namespace books_app.Pages
{
    public class BookModel : PageModel
    {
        [BindProperty]
        public BookDTO Book { get; set; }

        public int? BookId { get; set; }

        private readonly IBookService _bookService;
        private readonly IAuthorService _authorService;
        public string InfoMessage = "";
        public IEnumerable<SelectListItem> Authors { get; set; }

        public BookModel(IBookService bookService, IAuthorService authorService)
        {
            _bookService = bookService;
            _authorService = authorService;
            InfoMessage = "";
        }

        public void OnGet(int? id)
        {
            BookId = id;
            Authors = _authorService.GetAll().Select(a => new SelectListItem
            {
                Value = a.Id.ToString(),
                Text = $"{a.FirstName} {a.LastName}"
            });

            if (id.HasValue)
            {
                var bookDto = _bookService.GetById(id.Value);
                if (bookDto != null)
                {
                    Book = bookDto;
                }
                else
                {
                    Book = new BookDTO();
                    InfoMessage = "Book not found.";
                }
            }
            else
            {
                Book = new BookDTO();
                InfoMessage = "No book ID provided.";
            }
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                InfoMessage = "Invalid book data.";
                Authors = _authorService.GetAll().Select(a => new SelectListItem
                {
                    Value = a.Id.ToString(),
                    Text = $"{a.FirstName} {a.LastName}"
                });
                return Page();
            }

            if (Book.Id == 0)
            {
                InfoMessage = "Cannot update book without ID.";
                Authors = _authorService.GetAll().Select(a => new SelectListItem
                {
                    Value = a.Id.ToString(),
                    Text = $"{a.FirstName} {a.LastName}"
                });
                return Page();
            }

            var ok = _bookService.Update(Book);
            if (!ok)
            {
                InfoMessage = "Update failed.";
                Authors = _authorService.GetAll().Select(a => new SelectListItem
                {
                    Value = a.Id.ToString(),
                    Text = $"{a.FirstName} {a.LastName}"
                });
                return Page();
            }

            InfoMessage = "Book updated successfully.";
            return RedirectToPage("/Library");
        }
    }
}

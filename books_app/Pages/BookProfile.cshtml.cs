using books_app.Abstracts;
using books_app.DAL.Entities;
using books_app.Models;
using books_app.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace books_app.Pages
{
    public class BookProfileModel : PageModel
    {
        public int? BookId { get; set; }
        public string AuthorName { get; set; }
        public BookDTO Book { get; set; }
        private readonly IBookService _bookService;
        private readonly IAuthorService _authorService;

        public string InfoMessage { get; set; } = string.Empty;
        public BookProfileModel(IBookService bookService, IAuthorService authorService)
        {
            _bookService = bookService;
            _authorService = authorService;
        }

        public void OnGet(int? id)
        {
            BookId = id;

            if (id.HasValue)
            {
                var bookDto = _bookService.GetById(id.Value);
                if (bookDto != null)
                {
                    Book = bookDto;
                }
                else
                {
                    return;
                }
            }
            else
            {
                return;
            }

            AuthorName = GetAuthorName(Book.AuthorId);

        }

        private string GetAuthorName(int authorId)
        {
            if (Book.AuthorId > 0)
            {
                var authorDto = _authorService.GetById(Book.AuthorId);
                if (authorDto != null)
                {
                    return authorDto.FirstName + " " + authorDto.LastName;
                }
                else
                {
                    return "Unknown";
                }
            }
            else
            {
                return "Unknown";
            }
        }

        public IActionResult OnPostDelete(int? id)
        {
            if (!id.HasValue || id.Value == 0)
            {
                InfoMessage = "Invalid id.";
                return Page();
            }

            var dto = _bookService.GetById(id.Value);
            if (dto == null)
            {
                InfoMessage = "Book not found.";
                return Page();
            }

            var ok = _bookService.Delete(dto);
            if (!ok)
            {
                InfoMessage = "Delete failed.";
                Book = dto;
                return Page();
            }

            return RedirectToPage("/Library");
        }
    }
}

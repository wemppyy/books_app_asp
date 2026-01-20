using books_app.Abstracts;
using books_app.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace books_app.Pages
{
    public class AuthorProfileModel : PageModel
    {
        public int? AuthorId { get; set; }
        [BindProperty]
        public AuthorDTO Author { get; set; }
        private readonly IAuthorService _authorService;

        public string InfoMessage { get; set; } = string.Empty;

        public AuthorProfileModel(IAuthorService authorService)
        {
            _authorService = authorService;
        }
        public void OnGet(int? id)
        {
            AuthorId = id;
            if (id.HasValue)
            {
                var authorDto = _authorService.GetById(id.Value);
                if (authorDto != null)
                {
                    Author = authorDto;
                }
                else
                {
                    Author = new AuthorDTO();
                }
            }
            else
            {
                Author = new AuthorDTO();
            }
        }


        public IActionResult OnPostDelete(int? id)
        {
            if (!id.HasValue || id.Value == 0)
            {
                InfoMessage = "Invalid id.";
                return Page();
            }

            var dto = _authorService.GetById(id.Value);
            if (dto == null)
            {
                InfoMessage = "Author not found.";
                return Page();
            }

            var ok = _authorService.Delete(dto);
            if (!ok)
            {
                InfoMessage = "Delete failed.";
                Author = dto;
                return Page();
            }

            return RedirectToPage("/Library");
        }
    }
}

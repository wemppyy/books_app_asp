using books_app.Models;
using books_app.Abstracts;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;

namespace books_app.Pages
{
    public class AuthorModel : PageModel
    {
        [BindProperty]
        public AuthorDTO Author { get; set; }
        public int? AuthorId { get; set; }

        private readonly IAuthorService _authorService;
        public string InfoMessage = "";

        public AuthorModel(IAuthorService authorService)
        {
            _authorService = authorService;
            InfoMessage = "";
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
                    InfoMessage = "Author not found.";
                }
            }
            else
            {
                Author = new AuthorDTO();
                InfoMessage = "No author ID provided.";
            }
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                InfoMessage = "Invalid author data.";
                return Page();
            }

            if (Author.Id == 0)
            {
                InfoMessage = "Cannot update author without ID.";
                return Page();
            }

            _authorService.Update(Author);
            InfoMessage = "Author updated successfully.";
            return RedirectToPage("/Library");
        }
    }
}

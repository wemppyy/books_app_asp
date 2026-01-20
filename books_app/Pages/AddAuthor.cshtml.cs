using books_app.Models;
using books_app.Abstracts;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;

namespace books_app.Pages
{
    public class AddAuthorModel : PageModel
    {
        [BindProperty]
        public AuthorDTO Author { get; set; }

        private readonly IAuthorService _authorService;
        public string InfoMessage = "";

        public AddAuthorModel(IAuthorService authorService)
        {
            _authorService = authorService;
            InfoMessage = "";
        }

        public void OnGet()
        {
            Author = new AuthorDTO();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                InfoMessage = "Invalid author data.";
                return Page();
            }

            _authorService.Add(Author);
            InfoMessage = "Author saved successfully.";
            return RedirectToPage("/Library");
        }
    }
}

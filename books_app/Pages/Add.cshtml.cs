using books_app.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace books_app.Pages
{
    public class AddModel : PageModel
    {
        [BindProperty]
        public AuthorModel Author { get; set; }
        public BookModel Book { get; set; }

        // Author
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }

        // Book
        public string Title { get; set; }
        public string ISBN { get; set; }
        public DateTime PublishYear { get; set; }
        public string Price { get; set; }
        public int AuthorId { get; set; }

        public void OnGet()
        {
            // Author
            FirstName = string.Empty;
            LastName = string.Empty;
            BirthDate = DateTime.Now;

            // Book
            Title = string.Empty;
            ISBN = string.Empty;
            PublishYear = DateTime.Now;
            Price = string.Empty;
            AuthorId = 0;
        }

        public void OnPostSaveAuthor()
        {
            if (!ModelState.IsValid)
            {
                return;
            }
            FirstName = Author.FirstName;
            LastName = Author.LastName;
            BirthDate = Author.DateOfBirth;
        }

        public void OnPostSaveBook()
        {
            if (!ModelState.IsValid)
            {
                return;
            }

            Title = Book.Title;
            ISBN = Book.ISBN;
            PublishYear = Book.PublishYear;
            Price = Book.Price;
            AuthorId = Book.AuthorId;
        }
    }
}

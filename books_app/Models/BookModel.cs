using System;
using System.ComponentModel.DataAnnotations;

namespace books_app.Models
{
    public class BookModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MinLength(2)]
        public string Title { get; set; }

        [Required]
        [RegularExpression(@"^978-\d{10}$", ErrorMessage = "ISBN must be in format 978-XXXXXXXXXX (e.g. 978-0123456789).")]
        public string ISBN { get; set; }
        [Required]
        public DateTime PublishYear { get; set; }
        public string Price { get; set; }
        [Required]
        public int AuthorId { get; set; }
    }
}

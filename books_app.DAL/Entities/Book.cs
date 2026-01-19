using System;
using System.Collections.Generic;
using System.Text;

namespace books_app.DAL.Entities
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string ISBN { get; set; }
        public DateTime PublishYear { get; set; }
        public string Price { get; set; }
        public int AuthorId { get; set; }
    }
}

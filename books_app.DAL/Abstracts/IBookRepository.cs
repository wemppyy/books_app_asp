using System;
using System.Collections.Generic;
using System.Text;

namespace books_app.DAL.Abstracts
{
    public interface IBookRepository
    {
        void AddBook(Entities.Book book);
        Entities.Book GetBookById(int bookId);
        List<Entities.Book> GetAllBooks();
    }
}

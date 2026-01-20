using books_app.DAL.Entities;
using books_app.Models;

namespace books_app.Abstracts

{
    public interface IBookService
    {
        bool Add(BookDTO bookDto);
        bool Update(BookDTO bookDto);
        bool Delete(BookDTO bookDto);
        BookDTO GetById(int id);
        List<Book> GetAll();
    }
}

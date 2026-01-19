using books_app.DAL.Abstracts;
using books_app.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace books_app.DAL
{
    public class AuthorRepository : IAuthorRepository
    {
        private readonly AppDbContext _db;
        public AuthorRepository(AppDbContext db)
        {
            _db = db;
        }
        public void AddAuthor(Author author)
        {
            _db.Authors.Add(author);
            _db.SaveChanges();
        }

        public Author GetAuthorById(int authorId)
        {
            return _db.Authors.FirstOrDefault(x => x.Id == authorId);
        }

        public List<Author> GetAllAuthors()
        {
            return _db.Authors.ToList();
        }
    }
}

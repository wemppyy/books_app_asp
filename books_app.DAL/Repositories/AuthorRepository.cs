using books_app.DAL.Abstracts;
using books_app.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace books_app.DAL.Repositories
{
    public class AuthorRepository : IAuthorRepository
    {
        private readonly AppDbContext _db;
        public AuthorRepository(AppDbContext db)
        {
            _db = db;
        }
        public bool AddAuthor(Author author)
        {
            var res = _db.Authors.Add(author) != null;
            _db.SaveChanges();

            return res;
        }

        public bool UpdateAuthor(Author author)
        {
            var existingAuthor = _db.Authors.FirstOrDefault(x => x.Id == author.Id);
            if (existingAuthor == null)
            {
                return false;
            }
            existingAuthor.FirstName = author.FirstName;
            existingAuthor.LastName = author.LastName;
            existingAuthor.DateOfBirth = author.DateOfBirth;
            _db.SaveChanges();
            return true;
        }

        public bool DeleteAuthor(Author author)
        {
            var existingAuthor = _db.Authors.FirstOrDefault(x => x.Id == author.Id);
            if (existingAuthor == null)
            {
                return false;
            }

            try
            {
                _db.Authors.Remove(existingAuthor);
                _db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
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

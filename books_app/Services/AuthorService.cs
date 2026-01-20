using books_app.Abstracts;
using books_app.DAL;
using books_app.DAL.Abstracts;
using books_app.DAL.Entities;
using books_app.Models;
using System;

namespace books_app.Services
{
    public class AuthorService : IAuthorService
    {
        private readonly IAuthorRepository _authorRepository;


        public AuthorService(IAuthorRepository authorRepository)
        {
            _authorRepository = authorRepository;

        }
        public bool Add(AuthorDTO authorDto)
        {
            var author = new Author
            {
                FirstName = authorDto.FirstName,
                LastName = authorDto.LastName,
                DateOfBirth = authorDto.DateOfBirth
            };
            return _authorRepository.AddAuthor(author);

        }
        public bool Delete(AuthorDTO authorDto)
        {
            var author = new Author
            {
                Id = authorDto.Id,
                FirstName = authorDto.FirstName,
                LastName = authorDto.LastName,
                DateOfBirth = authorDto.DateOfBirth
            };

            return _authorRepository.DeleteAuthor(author);
        }

        public bool Update(AuthorDTO authorDto)
        {
            var author = new Author
            {
                Id = authorDto.Id,
                FirstName = authorDto.FirstName,
                LastName = authorDto.LastName,
                DateOfBirth = authorDto.DateOfBirth
            };
            return _authorRepository.UpdateAuthor(author);
        }

        public List<Author> GetAll()
        {
            return _authorRepository.GetAllAuthors();
        }

        public AuthorDTO GetById(int id)
        {
            var a = _authorRepository.GetAuthorById(id);
            if (a == null) return null;
            return new AuthorDTO
            {
                Id = a.Id,
                FirstName = a.FirstName,
                LastName = a.LastName,
                DateOfBirth = a.DateOfBirth
            };
        }

    }
}

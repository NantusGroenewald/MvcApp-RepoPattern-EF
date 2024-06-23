using Book_Store.DAL;
using Book_Store.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Book_Store.Services
{
    public class AuthorService : IAuthorService
    {
        private readonly IRepository<Author> _authorRepository;

        public AuthorService(IRepository<Author> authorRepository)
        {
            _authorRepository = authorRepository;
        }
        public void AddAuthor(Author author)
        {
            _authorRepository.Insert(author);
            _authorRepository.Save(); 
        }

        public IEnumerable<Author> GetAllAuthors()
        {
            return _authorRepository.GetAll(); 
        }

        public Author GetAuthorById(int id)
        {
            return _authorRepository.GetById(id);
        }
    }
}
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
        private readonly IRepository<Book> _bookRepository;

        public AuthorService(IRepository<Author> authorRepository, IRepository<Book> bookRepository)
        {
            _authorRepository = authorRepository;
            _bookRepository = bookRepository;
        }
        public void AddAuthor(Author author)
        {
            _authorRepository.Insert(author);
            _authorRepository.Save();
        }

        public (bool,IEnumerable<string>) DeleteAuthor(int id)
        {
            var authorBooks = GetAllBooksByAuthorId(id);
            if (authorBooks.Count() == 0)
            {
                _authorRepository.Delete(id);
                _authorRepository.Save();
                return (true, null);
            }
            return (false, authorBooks); 
        }

        public IEnumerable<Author> GetAllAuthors()
        {
            return _authorRepository.GetAll();
        }

        public IEnumerable<string> GetAllBooksByAuthorId(int id)
        {
            var relatedBooks = _bookRepository.GetAll().Where(book => book.AuthorId == id);
            return relatedBooks.Select(book => book.Title);
        }

        public Author GetAuthorById(int id)
        {
            return _authorRepository.GetById(id);
        }

        public void UpdateAuthor(Author author)
        {
            _authorRepository.Update(author);
            _authorRepository.Save();
        }
    }
}
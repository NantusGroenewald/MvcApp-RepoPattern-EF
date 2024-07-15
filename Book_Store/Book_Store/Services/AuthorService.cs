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

        public void DeleteAuthor(int id)
        {
            _authorRepository.Delete(id);
            _authorRepository.Save();
        }

        public IEnumerable<Author> GetAllAuthors()
        {
            return _authorRepository.GetAll();
        }

        public List<string> GetAllBooksByAuthorId(int id)
        {
            var relatedBooks = _bookRepository.GetAll().Where(book => book.AuthorId == id);
            List<string> bookTitles = relatedBooks.Select(book => book.Title).ToList();
            return bookTitles;
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
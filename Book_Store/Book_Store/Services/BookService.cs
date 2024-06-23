using Book_Store.DAL;
using Book_Store.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Book_Store.Services
{
    public class BookService : IBookService
    {
        private readonly IRepository<Book> _bookRepository;
        private readonly IRepository<Genre> _genreRepository;
        private readonly IRepository<Author> _authorRepository;
        private readonly IRepository<Publisher> _publisherRepository;

        public BookService(IRepository<Book> bookRepository, IRepository<Genre> genreRepository, IRepository<Author> authorRepository, IRepository<Publisher> publisherRepository)
        {
            _bookRepository = bookRepository;
            _genreRepository = genreRepository;
            _authorRepository = authorRepository;
            _publisherRepository = publisherRepository;
        }


        public void AddBook(Book book)
        {
            _bookRepository.Insert(book);
            _bookRepository.Save(); 
        }

        public IEnumerable<Author> GetAllAuthors()
        {
            return _authorRepository.GetAll(); 
        }

        public IEnumerable<Book> GetAllBooks()
        {
            return _bookRepository.GetAll(); 
        }

        public IEnumerable<Genre> GetAllGenres()
        {
            return _genreRepository.GetAll();
        }

        public IEnumerable<Publisher> GetAllPublishers()
        {
            return _publisherRepository.GetAll();
        }

        public Book GetBookById(int id)
        {
            return _bookRepository.GetById(id);
        }
    }
}
using Book_Store.DAL;
using Book_Store.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Book_Store.Services
{
    public class PublisherService : IPublisherService
    {
        private readonly IRepository<Publisher> _publisherRepository;
        private readonly IRepository<Book> _bookRepository;

        public PublisherService(IRepository<Publisher> publisherRepository, IRepository<Book> bookRepository)
        {
            _publisherRepository = publisherRepository;
            _bookRepository = bookRepository;
        }

        public void AddPublisher(Publisher publisher)
        {
            _publisherRepository.Insert(publisher);
            _publisherRepository.Save();
        }

        public void DeletePublisher(int id)
        {
            _publisherRepository.Delete(id);
            _publisherRepository.Save(); 
        }

        public void EditPublisher(Publisher publisher)
        {
            _publisherRepository.Update(publisher);
            _publisherRepository.Save();
        }

        public IEnumerable<Publisher> GetAllPublishers()
        {
            return _publisherRepository.GetAll();
        }

        public List<string> GetBooksByPublisherId(int id)
        {
            var relatedBooks = _bookRepository.GetAll().Where(book => book.PublisherId == id);
            List<string> bookTitles = relatedBooks.Select(book => book.Title).ToList();
            return bookTitles; 
        }

        public Publisher GetPublisherById(int id)
        {
            return _publisherRepository.GetById(id);
        }
    }
}
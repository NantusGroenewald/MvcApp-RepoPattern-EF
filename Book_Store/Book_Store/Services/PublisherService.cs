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

        public (bool, IEnumerable<string>) DeletePublisher(int id)
        {
            var publisherBooks = GetBooksByPublisherId(id);
            if (publisherBooks.Count() == 0)
            {
                _publisherRepository.Delete(id);
                _publisherRepository.Save();
                return (true, null);
            }
            return (false, publisherBooks);
            
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

        public IEnumerable<string> GetBooksByPublisherId(int id)
        {
            var relatedBooks = _bookRepository.GetAll().Where(book => book.PublisherId == id);
            return relatedBooks.Select(book => book.Title).ToList();
        }

        public Publisher GetPublisherById(int id)
        {
            return _publisherRepository.GetById(id);
        }
    }
}
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

        public PublisherService(IRepository<Publisher> publisherRepository)
        {
            _publisherRepository = publisherRepository;
        }

        public void AddPublisher(Publisher publisher)
        {
            _publisherRepository.Insert(publisher);
            _publisherRepository.Save();
        }

        public IEnumerable<Publisher> GetAllPublishers()
        {
            return _publisherRepository.GetAll();
        }

        public Publisher GetPublisherById(int id)
        {
            return _publisherRepository.GetById(id);
        }
    }
}
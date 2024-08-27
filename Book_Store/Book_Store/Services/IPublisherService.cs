using Book_Store.DAL;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects.DataClasses;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Book_Store.Services
{
    public interface IPublisherService
    {
        IEnumerable<Publisher> GetAllPublishers();
        Publisher GetPublisherById(int id);
        void AddPublisher(Publisher publisher);
        void EditPublisher(Publisher publisher);
        (bool, IEnumerable<string>) DeletePublisher(int id);
        IEnumerable<string> GetBooksByPublisherId(int id);
    }
}

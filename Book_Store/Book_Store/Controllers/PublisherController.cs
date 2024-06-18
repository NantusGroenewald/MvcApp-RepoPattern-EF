using Book_Store.DAL;
using Book_Store.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Book_Store.Controllers
{
    public class PublisherController : Controller
    {
        private readonly IRepository<Publisher> _publisherRepository;

        public PublisherController(IRepository<Publisher> publisherRepository)
        {
            _publisherRepository = publisherRepository; 
        }

        public ActionResult Index()
        {
            var model = _publisherRepository.GetAll();
            return View(model);
        }
    }
}
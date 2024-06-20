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

        [HttpGet]
        public ActionResult Index()
        {
            var model = _publisherRepository.GetAll();
            return View(model);
        }
        [HttpGet]
        public ActionResult AddPublisher()
        {
            return View(new Publisher());
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddPublisher(Publisher publisher)
        {
            if (ModelState.IsValid)
            {
                _publisherRepository.Insert(publisher);
                _publisherRepository.Save();
                return RedirectToAction("Index");
            }
            return AddPublisher();
        }
    }
}
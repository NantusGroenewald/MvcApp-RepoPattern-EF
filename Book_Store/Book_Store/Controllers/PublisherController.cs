using Book_Store.DAL;
using Book_Store.Repositories;
using Book_Store.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Book_Store.Controllers
{
    public class PublisherController : Controller
    {
        private readonly IPublisherService _publisherService;

        public PublisherController(IPublisherService publisherService)
        {
            _publisherService = publisherService;
        }

        [HttpGet]
        public ActionResult Index()
        {
            var model = _publisherService.GetAllPublishers();
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
                _publisherService.AddPublisher(publisher);
                return RedirectToAction("Index");
            }
            return AddPublisher();
        }
    }
}
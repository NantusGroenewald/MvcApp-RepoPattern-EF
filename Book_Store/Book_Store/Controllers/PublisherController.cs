using Book_Store.DAL;
using Book_Store.Repositories;
using Book_Store.Services;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
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

        [HttpGet]
        public ActionResult EditPublisher(int id)
        {
            Publisher publisher = _publisherService.GetPublisherById(id);
            return View(publisher);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditPublisher(Publisher publisher)
        {
            if (ModelState.IsValid)
            {
                _publisherService.EditPublisher(publisher);
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }
        [HttpPost]
        public ActionResult DeletePublisher(int id)
        {
            //try
            //{
            //    _publisherService.DeletePublisher(id);
            //    return Json(new { success = true });
            //}
            //catch (Exception ex)
            //{
            //    if (ex.InnerException != null && ex.InnerException.InnerException is SqlException sqlEx && sqlEx.Number == 547)
            //    {
            //        var relatedBooks = _publisherService.GetBooksByPublisherId(id);
            //        var errorResponse = new { success = false, message = "This publisher cannot be deleted because it is linked to the following books: ", books = relatedBooks };
            //        Response.StatusCode = (int)HttpStatusCode.BadRequest;
            //        return Json(errorResponse);
            //    }
            //    var generalErrorResponse = new { success = false, message = ex.Message };
            //    Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            //    return Json(generalErrorResponse);
            //}
            var deletedAction = _publisherService.DeletePublisher(id);
            if (deletedAction.Item1)
            {
                return Json(new { success = true });
            }
            else
            {
                var errorResponse = new { success = false, message = "This publisher cannot be deleted because it is linked to the following books: ", books = relatedBooks };
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return Json(errorResponse);
            }

        }

    }
}
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
    public class AuthorController : Controller
    {
        private IAuthorService _authorService;

        public AuthorController(IAuthorService authorService)
        {
            _authorService = authorService;
        }

        [HttpGet]
        public ActionResult Index()
        {
            var model = _authorService.GetAllAuthors();
            return View(model);
        }

        [HttpGet]
        public ActionResult AddAuthor()
        {
            return View(new Author()); 
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddAuthor(Author author)
        {
            if (ModelState.IsValid)
            {
                _authorService.AddAuthor(author);
                return RedirectToAction("Index");  
            }
            return AddAuthor();
        }
    }
}
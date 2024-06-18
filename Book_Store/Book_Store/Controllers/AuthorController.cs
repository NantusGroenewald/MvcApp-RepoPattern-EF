using Book_Store.DAL;
using Book_Store.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Book_Store.Controllers
{
    public class AuthorController : Controller
    {
        private IRepository<Author> _authorRepository;

        public AuthorController(IRepository<Author> authorRepository)
        {
            _authorRepository = authorRepository;
        }

        public ActionResult Index()
        {
            var model = _authorRepository.GetAll();
            return View(model);
        }
    }
}
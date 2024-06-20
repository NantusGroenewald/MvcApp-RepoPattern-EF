using Book_Store.DAL;
using Book_Store.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Book_Store.Controllers
{
    public class BookController : Controller
    {
        private IRepository<Book> _bookRepository;
        private IRepository<Genre> _genreRepository;
        private IRepository<Author> _authorRepository;
        private IRepository<Publisher> _publisherRepository;

        public BookController(IRepository<Book> bookRepository, IRepository<Genre> genreRepository, IRepository<Author> authorRepository, IRepository<Publisher> publisherRepository)
        {
            _bookRepository = bookRepository;
            _genreRepository = genreRepository;
            _authorRepository = authorRepository;
            _publisherRepository = publisherRepository;
        }

        [HttpGet]
        public ActionResult Index()
        {
            var model = _bookRepository.GetAll();
            return View(model);
        }

        [HttpGet]
        public ActionResult AddBook()
        {
            ViewBag.Genres = new SelectList(_genreRepository.GetAll(), "GenreId", "GenreName");
            ViewBag.Authors = new SelectList(_authorRepository.GetAll(), "AuthorId", "DisplayName");
            ViewBag.Publishers = new SelectList(_publisherRepository.GetAll(), "PublisherId", "PublisherName"); 
            return View(new Book());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddBook(Book book)
        {
            if (ModelState.IsValid)
            {
                _bookRepository.Insert(book);
                _bookRepository.Save(); 
                return RedirectToAction("Index");
            }
            return AddBook();
        }

    }
}
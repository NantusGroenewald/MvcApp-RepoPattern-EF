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
    public class BookController : Controller
    {
        private readonly IBookService _bookService;
        public BookController(IBookService bookService)
        {
            _bookService = bookService;
            ViewBag.Genres = new SelectList(_bookService.GetAllGenres(), "GenreId", "GenreName");
            ViewBag.Authors = new SelectList(_bookService.GetAllAuthors(), "AuthorId", "DisplayName");
            ViewBag.Publishers = new SelectList(_bookService.GetAllPublishers(), "PublisherId", "PublisherName");
        }

        [HttpGet]
        public ActionResult Index()
        {
            var model = _bookService.GetAllBooks();
            return View(model);
        }

        [HttpGet]
        public ActionResult AddBook()
        {
            
            return View(new Book());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddBook(Book book)
        {
            if (ModelState.IsValid)
            {
                _bookService.AddBook(book);
                return RedirectToAction("Index");
            }
            return AddBook();
        }

        [HttpGet]
        public ActionResult EditBook(int id)
        {
            Book book = _bookService.GetBookById(id);
            return View(book);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditBook(Book book)
        {
            if (ModelState.IsValid)
            {
                _bookService.UpdateBook(book);
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }
    }
}
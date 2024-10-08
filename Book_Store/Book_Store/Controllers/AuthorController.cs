﻿using Book_Store.DAL;
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

        [HttpGet]
        public ActionResult EditAuthor(int id)
        {
            Author author = _authorService.GetAuthorById(id);
            return View(author);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditAuthor(Author author)
        {
            if (ModelState.IsValid)
            {
                _authorService.UpdateAuthor(author);
                return RedirectToAction("Index");
            }
            else
            {
                return View(); 
            }
        }

        [HttpPost]
        public ActionResult DeleteAuthor(int id)
        {
            var deleteAction = _authorService.DeleteAuthor(id);
            if (deleteAction.Item1)
            {
                return Json(new { success = true });
            }
            else
            {
                var errorResponse = new { success = false, message = "This author cannot be deleted because it is linked to the following books: ", books = deleteAction.Item2 };
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return Json(errorResponse);
            }
        }
    }
}
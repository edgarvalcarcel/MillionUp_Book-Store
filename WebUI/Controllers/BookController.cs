using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Application.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace WebUI.Controllers
{
    public class BookController : Controller
    {
        private readonly IBookService _bookService;
        private readonly IPublisherService _publisherService;
        private readonly IAuthorService _authorService;
        public BookController(IBookService bookService, IPublisherService publisherService, IAuthorService authorService)
        {
            _bookService = bookService;
            _publisherService = publisherService;
            _authorService = authorService ;
        }
       
        public IActionResult Index()
        {
            BookViewModel model = _bookService.GetBooks();
            return View(model);
        }

        // GET: Book/Create
        public IActionResult Create()
        { 
            ViewData["PublisherId"] = new SelectList(_publisherService.GetPublishers().Publishers, "Id", "Name");
            ViewData["AuthorId"] = new SelectList(_authorService.GetAuthors().Authors, "Id", "FullName");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,Title,ISBN,Synopsis,Npages,PublisherId,AuthorId")] BookVM book)
        {
            BookVM model = _bookService.Upsert(book);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var book = _bookService.GetBookById((int)id);
            if (book == null)
            {
                return NotFound();
            }
            return View(book);
        }
        
        public IActionResult Edit(int? id)
        {
            ViewData["PublisherId"] = new SelectList(_publisherService.GetPublishers().Publishers, "Id", "Name");
            ViewData["AuthorId"] = new SelectList(_authorService.GetAuthors().Authors, "Id", "FullName");
            if (id == null)
            {
                return NotFound();
            }

            var book = _bookService.GetBookById((int)id);
            if (book == null)
            {
                return NotFound();
            }
            return View(book);
        } 
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Id,Title,ISBN,Synopsis,Npages,PublisherId,AuthorId")] BookVM book)
        {
            if (id != book.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    BookVM model = _bookService.Upsert(book); 
                }
                catch (DbUpdateConcurrencyException)
                { 
                        throw; 
                } 
            }
            return RedirectToAction(nameof(Index));
        }

    }
}

 
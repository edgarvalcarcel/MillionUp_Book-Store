using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Application.ViewModels;
using Microsoft.AspNetCore.Authorization;

namespace WebUI.Controllers
{
    public class AuthorController : Controller
    {
        private readonly IAuthorService _authorService;
        public AuthorController(IAuthorService authorService)
        {
            _authorService = authorService;
        }

        // GET: Author
        public IActionResult Index()
        {
            AuthorsViewModel model = _authorService.GetAuthors();
            return View(model);
        }


        // GET: Authors/Details/5
        public IActionResult Details(int id)
        {
            AuthorViewModel model = _authorService.GetAuthorById(id);
            return View(model);
        }

        // GET: Author/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,Name,SurName")] AuthorViewModel author)
        {
            AuthorViewModel model = _authorService.Upsert(author);
            return View(model);
        }
    }
}

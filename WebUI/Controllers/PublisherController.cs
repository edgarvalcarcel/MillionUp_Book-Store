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
    public class PublisherController : Controller
    {
        private readonly IPublisherService _publisherService;
        public PublisherController(IPublisherService publisherService)
        {
            _publisherService = publisherService;
        }
        public IActionResult Index()
        {
            PublisherListViewModel model = _publisherService.GetPublishers();
            return View(model);
        }

        public IActionResult Details(int id)
        {
            PublisherViewModel model = _publisherService.GetPublisherById(id);
            return View(model);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public  IActionResult Create([Bind("Id,Name")] PublisherViewModel publisher)
        {
            PublisherViewModel model = _publisherService.Upsert(publisher);
            return View(model);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MiniProject.Models;
using MiniProject.ViewModels;

namespace MiniProject.Controllers
{
    public class EventsController : Controller
    {
        EventsService service;
        public EventsController(EventsService service)
        {
            this.service = service;
        }

        [Route("")]
        public async Task<IActionResult> Index()
        {
            var indexVMs = await service.GetEventsAsync();
            return View(indexVMs);
        }

        public async Task<IActionResult> Details(string id)
        {
            var detailVM = await service.GetEventByIdAsync(id);
            return View(detailVM);
        }

        [HttpGet]
        [Route("events/book/{id}/{name}")]
        public async Task<IActionResult> Book(string id, string name)
        {
            var bookVM = await service.GetEventByIdAndNameAsync(id, name);
            return View(bookVM);
        }
    }
}
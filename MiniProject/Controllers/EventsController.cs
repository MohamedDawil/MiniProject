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
        EventsService service = new EventsService();

        [Route("")]
        public IActionResult Index()
        {
            var indexVMs = service.GetEvents();
            return View(indexVMs);
        }

    }
}
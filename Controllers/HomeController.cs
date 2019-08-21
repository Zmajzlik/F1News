using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using F1News.Models;
using F1News.DataAccessLayer;
using Microsoft.Extensions.Options;

namespace F1News.Controllers
{
    public class HomeController : Controller
    {
        private DA _DA { get; set; }

        public HomeController(IOptions<AppSettings> settings)
        {
            _DA = new DA(settings.Value.ConnectionStr);
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult Calendar()
        {
            return View();
        }
        [HttpGet]
        public IActionResult GetCalendarEvents(string start, string end)
        {
            List<Events> events = _DA.GetCalendarEvents(start, end);
            return Json(events);
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

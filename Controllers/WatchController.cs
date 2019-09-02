using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace F1News.Controllers
{
    public class WatchController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult MiniDrivers()
        {
            return View();
        }
        public IActionResult Vlogs()
        {
            return View();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace F1News.Controllers
{
    public class RootController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet("calendar")]
        public IActionResult Calendar()
        {
            return View();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace F1News.Controllers
{
    public class PlayController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Fantasy()
        {
            return View();
        }
        public IActionResult Predictor()
        {
            return View();
        }
    }
}
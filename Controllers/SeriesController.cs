using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace F1News.Controllers
{
    public class SeriesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult WSeries()
        {
            return View();
        }
        public IActionResult FormulaTwo()
        {
            return View();  
        }
        public IActionResult FormulaThree()
        {
            return View();
        }
    }
}
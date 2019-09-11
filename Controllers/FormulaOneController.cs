using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using F1News.Data;
using F1News.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Dynamic;
using Microsoft.AspNetCore.Hosting;
using F1News.ViewModels;

namespace F1News.Controllers
{
    public class FormulaOneController : Controller
    {
        private readonly ApplicationDbContext _context;

        private readonly IHostingEnvironment _env;
        public FormulaOneController(ApplicationDbContext context, IHostingEnvironment env)
        {
            _context = context;
            _env = env;
        }
        public static List<Driver> DriversClassification { get; set; } = new List<Driver>();

        public ActionResult Index()
        {
            var displayDrivers = _context.Drivers.Select(n => new DriversViewModel
            {
                driverName = n.fullName,
                driverTeam = n.Team,
                driverCountry = n.Country,
                driverPoints = n.points.ToString()
                
            });
            return View(displayDrivers);
        }
        public IActionResult Points()
        {
            return View();
        }
        public IActionResult Engines()
        {
            return View();
        }
    }
}
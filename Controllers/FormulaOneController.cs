using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using F1News.Data;
using F1News.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Dynamic;

namespace F1News.Controllers
{
    public class FormulaOneController : Controller
    {
        private ApplicationDbContext _context;
        public FormulaOneController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult LoadData()
        {
            try
            {
                var draw = HttpContext.Request.Form["draw"].FirstOrDefault();
                var start = Request.Form["start"].FirstOrDefault();
               
                var length = Request.Form["length"].FirstOrDefault();
                 
                var sortColumn = Request.Form["columns[" + Request.Form["order[0][column]"].FirstOrDefault() + "][name]"].FirstOrDefault();
                 
                var sortColumnDirection = Request.Form["order[0][dir]"].FirstOrDefault();
             
                var searchValue = Request.Form["search[value]"].FirstOrDefault();
 
                int pageSize = length != null ? Convert.ToInt32(length) : 0;
                int skip = start != null ? Convert.ToInt32(start) : 0;
                int recordsTotal = 0;
                var customerData = (from tempcustomer in _context.Drivers
                                    select tempcustomer);
                if (!(string.IsNullOrEmpty(sortColumn) && string.IsNullOrEmpty(sortColumnDirection)))
                {
                    customerData = customerData.OrderBy(sortColumn + " " + sortColumnDirection);
                }
                if (!string.IsNullOrEmpty(searchValue))
                {
                    customerData = customerData.Where(m => m.fullName == searchValue);
                } 
                recordsTotal = customerData.Count();
              
                var data = customerData.Skip(skip).Take(pageSize).ToList();
 
                return Json(new { draw = draw, recordsFiltered = recordsTotal, recordsTotal = recordsTotal, data = data });

            }
            catch (Exception)
            {
                throw;
            }

        }
        public IActionResult Index()
        {
            return View();
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
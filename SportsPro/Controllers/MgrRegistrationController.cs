using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SportsPro.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;

namespace SportsPro.Controllers
{
    public class MgrRegistrationController : Controller
    {
        private SportsProContext context { get; set; }
        public MgrRegistrationController(SportsProContext ctx)
        {
            context = ctx;
        }

        [Route("getcustomer")]
        [HttpGet]
        public IActionResult GetCustomer()
        {
            ViewBag.Customers = context.Customers.ToList();
            return View();
        }

        [Route("registrations")]
        [HttpGet]
        public IActionResult MgrRegistration(int id)
        {
            List<Product> products = context.Products
                .Where(p => p.ProductID == id)
                .Include(p => p.Name)
                .ToList();
            ViewBag.CustomerName = context.Customers.Find(id).FullName;
            MgrRegisration views = new MgrRegisration();
            views.Products = products;
            return View(views);
        }
    }
}

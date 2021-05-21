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
    public class RegistrationController : Controller
    {
        private SportsProContext context { get; set; }
        public RegistrationController(SportsProContext ctx)
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
        public IActionResult Registration(int id)
        {
            List<Customer> products = context.Customers.Where(p => p.ProductID == id).Include()
        }
    }
}

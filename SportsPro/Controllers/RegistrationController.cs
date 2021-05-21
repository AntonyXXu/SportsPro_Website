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
        public IActionResult MgrRegistration(int CustomerID)
        {
            List<Incident> products= context.Incidents
            .Where(inc => inc.CustomerID == CustomerID)
            .Include(inc => inc.Customer)
            .Include(inc => inc.Product)
            .ToList();
            ViewBag.Customer = context.Customers.Find(CustomerID).FullName;
            //MgrRegisrationModel views = new MgrRegisrationModel();
            //views.Products = products;

            return View(products);
        }
    }
}

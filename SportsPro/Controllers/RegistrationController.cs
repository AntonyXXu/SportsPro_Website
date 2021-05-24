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
        public IActionResult List()
        {
            ViewBag.Customers = context.Customers.ToList();
            return View();
        }

        [Route("registrations")]
        [HttpGet]
        public IActionResult RegProduct(int CustomerID)
        {
            List<CustomerProduct> cust = context.CustomerProducts
                .Where(c => c.CustomerID == CustomerID)
                .Include(c => c.Product)
                .OrderBy(c => c.ProductID)
                .ToList();
            ViewBag.CustomerName = context.Customers.Find(CustomerID).FullName;
            ViewBag.Products = context.Products.ToList();
            MgrRegistrationModel views = new MgrRegistrationModel();
            views.CustomerProducts = cust;

            return View(views);
        }
        [HttpPost]
        public IActionResult RegProduct(MgrRegistrationModel views)
        {
            CustomerProduct cust = views.currentCustomer;
            context.CustomerProducts.Add(cust);
            context.SaveChanges();
            return RedirectToAction("MgrRegistration", views);
        }
    }
}

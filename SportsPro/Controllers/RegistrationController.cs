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
    
    
    [HttpGet]
    public IActionResult RegProduct(int CustomerID)
    {
        List<CustomerProduct> cust = context.CustomerProducts
            .Where(c => c.CustomerID == CustomerID)
            .Include(c => c.Product)
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
            var reg = new CustomerProduct(){ ProductID = views.ProductID, CustomerID = views.CustomerID};
            context.CustomerProducts.Add(reg);
            context.SaveChanges();
            return RedirectToAction("RegProduct", views);
        }

    [HttpGet]
    public IActionResult Delete(int CustomerID, int ProductID)
    {
            return RedirectToAction("List");
        //CustomerProduct cust = views.currentCustomer;
        //context.CustomerProducts.Add(cust);
        //context.SaveChanges();
        //return RedirectToAction("List", views);
    }
    }
}

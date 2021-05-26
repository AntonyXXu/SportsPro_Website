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
        private ISportsUnitWork sportsUnit;
        private IHttpContextAccessor http;
        public RegistrationController(ISportsUnitWork ctx, IHttpContextAccessor httpctx)
        {
            sportsUnit = ctx;
            http = httpctx;
        }

        [Route("getcustomer")]
        [HttpGet]
        public IActionResult List()
        {
            ViewBag.Customers = sportsUnit.Customers.List(new QueryOptions<Customer>());
            return View();
        }
        //[HttpPost]
        //public IActionResult List(MgrRegistrationModel currentCustomer)
        //{
        //    var session = new MySession(HttpContext.Session);
        //    var sessionCust = session.GetCustomer();
        //    sessionCust = sportsUnit.Customers.Get(currentCustomer.Customers.CustomerID);
        //    session.SetCustomer(sessionCust);
        //    return RedirectToAction("RegProduct", "Registration");

        //}
    
    
        [HttpGet]
        public IActionResult RegProduct(int CustomerID)
        {
                QueryOptions<CustomerProduct> query = new QueryOptions<CustomerProduct>
                {
                    Where = inc => inc.CustomerID == CustomerID,
                    Includes = "Customer, Product"
                };
                ViewBag.Products = sportsUnit.Products.List(new QueryOptions<Product>());
                ViewBag.CustomerName = sportsUnit.Customers.Get(CustomerID).FullName;
                MgrRegistrationModel views = new MgrRegistrationModel();
                views.CustomerProducts = sportsUnit.CustomerProducts.List(query);
                http.HttpContext.Session.SetInt32("custID", CustomerID);

            return View(views);
            }

        [HttpPost]
        public IActionResult RegProduct(MgrRegistrationModel views)
        {
            var reg = new CustomerProduct(){ ProductID = views.ProductID, CustomerID = views.CustomerID};
            sportsUnit.CustomerProducts.Insert(reg);
            sportsUnit.save();
            return RedirectToAction("RegProduct", views);
        }

        [HttpPost]
        public IActionResult Delete(int CustomerID, int ProductID, int? dest)
        {
                CustomerProduct cust = new CustomerProduct()
                {
                    CustomerID = CustomerID,
                    ProductID = ProductID
                };
                sportsUnit.CustomerProducts.Delete(cust);
                sportsUnit.save();
                int? custID = http.HttpContext.Session.GetInt32("custID");
                return RedirectToAction("RegProduct", "Registration", new { CustomerID = custID });
        }
        }
}

using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SportsPro.Models;

namespace SportsPro.Controllers
{
    public class CustomerController : Controller
    {
        private ISportsUnitWork sportsUnit { get; set; }
        public CustomerController(ISportsUnitWork sports)
        {
            sportsUnit = sports;
        }

        [Route("customers")]
        public IActionResult List()
        {
            IEnumerable<Customer> cust = sportsUnit.Customers.List(new QueryOptions<Customer>());
            return View(cust);
        }

        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.Country = sportsUnit.Countries.List(new QueryOptions<Country>());
            Customer cust = new Customer();
            return View(cust);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.Country = sportsUnit.Countries.List(new QueryOptions<Country>());
            Customer cust = sportsUnit.Customers.Get(id);
            return View(cust);
        }

        [HttpPost]
        public IActionResult Add(Customer cust)
        {
            try
            {
                sportsUnit.Customers.Insert(cust);
                sportsUnit.Customers.Save();
                return RedirectToAction("List", "Customer");
            }
            catch
            {
                return View();
            }
        }

        [HttpPost]
        public IActionResult Edit(Customer cust)
        {
            try
            {
                sportsUnit.Customers.Update(cust);
                sportsUnit.Customers.Save();
                return RedirectToAction("List", "Customer");
            }
            catch
            {
                ViewBag.Country = sportsUnit.Countries.List(new QueryOptions<Country>());
                return View(cust);
            }
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            try
            {
                Customer cust = sportsUnit.Customers.Get(id);
                sportsUnit.Customers.Delete(cust);
                sportsUnit.Customers.Save();
                return RedirectToAction("List", "Customer");
            }
            catch
            {
                return View("List");
            }
        }
    }
}

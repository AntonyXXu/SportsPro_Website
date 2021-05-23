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
        private Repository<Country> countries { get; set; }
        private Repository<Customer> customers { get; set; }
        public CustomerController(SportsProContext ctx)
        {
            countries = new Repository<Country>(ctx);
            customers = new Repository<Customer>(ctx);
        }

        [Route("customers")]
        public IActionResult List()
        {
            IEnumerable<Customer> cust = customers.List(new QueryOptions<Customer>());
            return View(cust);
        }

        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.Country = countries.List(new QueryOptions<Country>());
            Customer cust = new Customer();
            return View(cust);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.Country = countries.List(new QueryOptions<Country>());
            Customer cust = customers.Get(id);
            return View(cust);
        }

        [HttpPost]
        public IActionResult Add(Customer cust)
        {
            try
            {
                customers.Insert(cust);
                customers.Save();
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
                customers.Update(cust);
                customers.Save();
                return RedirectToAction("List", "Customer");
            }
            catch
            {
                ViewBag.Country = countries.List(new QueryOptions<Country>());
                return View(cust);
            }
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            try
            {
                Customer cust = customers.Get(id);
                customers.Delete(cust);
                customers.Save();
                return RedirectToAction("List", "Customer");
            }
            catch
            {
                return View("List");
            }
        }
    }
}

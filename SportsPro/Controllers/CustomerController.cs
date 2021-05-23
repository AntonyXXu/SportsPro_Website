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
        private SportsProContext context { get; set; }
        private List<Country> oldcountries { get; set; }
        private Repository<Country> countries { get; set; }
        private Repository<Customer> customers { get; set; }
        public CustomerController(SportsProContext ctx)
        {
            context = ctx;
            oldcountries = context.Countries.ToList();
            countries = new Repository<Country>(ctx);
            customers = new Repository<Customer>(ctx);
        }

        [Route("customers")]
        public IActionResult List()
        {
            //List<Customer> oldcustomers = context.Customers.ToList();
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
                customers.Insert(cust);
                customers.Save();
                //context.Customers.Update(cust);
                //context.SaveChanges();
                return RedirectToAction("List", "Customer");
            }
            catch
            {
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
                //Customer cust = context.Customers.Find(id);
                //context.Customers.Remove(cust);
                //context.SaveChanges();
                return RedirectToAction("List", "Customer");
            }
            catch
            {
                return View("List");
            }
        }
    }
}

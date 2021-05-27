using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SportsPro.Models;
using Microsoft.AspNetCore.Authorization;

namespace SportsPro.Controllers
{
    [Authorize(Roles="Admin")]
    public class CustomerController : Controller
    {

        // Initialize sports unit
        private ISportsUnitWork sportsUnit { get; set; }
        public CustomerController(ISportsUnitWork sports)
        {
            sportsUnit = sports;

        }

        [Route("customers")]
        public IActionResult List()
        {

            //if (!User.Identity.IsAuthenticated)
            //{
            //    return RedirectToAction("LogIn", "Account");
            //}
            //else if (!User.IsInRole("Admin"))
            //{
            //    return RedirectToAction("Index", "Home");
            //}
            // Query list of all customers
            IEnumerable<Customer> cust = sportsUnit.Customers.List(new QueryOptions<Customer>());
            return View(cust);
        }

        [HttpGet]
        public IActionResult Add()
        {
            // Query list of all countries and return page with new customer
            ViewBag.Country = sportsUnit.Countries.List(new QueryOptions<Country>());
            Customer cust = new Customer();
            return View(cust);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            // Query list of all countries and return page with selected customer
            ViewBag.Country = sportsUnit.Countries.List(new QueryOptions<Country>());
            Customer cust = sportsUnit.Customers.Get(id);
            return View(cust);
        }

        [HttpPost]
        public IActionResult Add(Customer cust)
        {
            try
            {
                // Save the customer within the context
                sportsUnit.Customers.Insert(cust);
                sportsUnit.Customers.Save();
                TempData["message"] = $"{cust.FullName} was successfully added";
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
                //Update the customer within the context
                sportsUnit.Customers.Update(cust);
                sportsUnit.Customers.Save();
                TempData["message"] = $"{cust.FullName} was successfully updated";
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
                // Remove the customer from the context
                Customer cust = sportsUnit.Customers.Get(id);
                sportsUnit.Customers.Delete(cust);
                sportsUnit.Customers.Save();
                TempData["message"] = $"{cust.FullName} was successfully deleted";
                return RedirectToAction("List", "Customer");
            }
            catch
            {
                return View("List");
            }
        }
    }
}

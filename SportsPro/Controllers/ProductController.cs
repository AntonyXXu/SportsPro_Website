using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SportsPro.Models;
using Microsoft.AspNetCore.Authorization;

namespace SportsPro.Controllers
{
    [Authorize(Roles = "Admin")]
    public class ProductController : Controller
    {

        // Initialize a repository interface of products
        private IRepository<Product> products;
        public ProductController(IRepository<Product> prod)
        {
            products = prod;
        }

        [Route("products")]
        public IActionResult List()
        {
            //Query a list of products

            //if (!User.Identity.IsAuthenticated)
            //{
            //    return RedirectToAction("LogIn", "Account");
            //}
            //else if (!User.IsInRole("Admin"))
            //{
            //    return RedirectToAction("Index", "Home");
            //}
            IEnumerable<Product> prod = products.List(new QueryOptions<Product>());
            return View(prod);
        }

        [HttpGet]
        public IActionResult Add()
        {
            // Create a new product
            return View(new Product());
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            // Update existing product
            Product prod = products.Get(id);
            return View(prod);
        }

        [HttpPost]
        public IActionResult Add(Product prod)
        {
            try
            {
                // Save into database. Send a message to update
                products.Insert(prod);
                products.Save();
                TempData["message"] = $"{prod.Name} was successfully added";
                return RedirectToAction("List", "Product");
            }
            catch
            {
                return View();
            }
        }

        [HttpPost]
        public IActionResult Edit(Product prod)
        {
            try
            {
                // Save into database. send a message to update
                products.Update(prod);
                products.Save();
                TempData["message"] = $"{prod.Name} was successfully updated";
                return RedirectToAction("List", "Product");
            }
            catch
            {
                return View();
            }
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            try
            {
                // delete entry from database. send a message to update
                Product prod = products.Get(id);
                products.Delete(prod);
                products.Save();
                TempData["message"] = $"{prod.Name} was successfully deleted";
                return RedirectToAction("List", "Product");
            }
            catch
            {
                return View("List");
            }
        }
    }
}

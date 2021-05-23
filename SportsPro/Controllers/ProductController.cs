using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SportsPro.Models;

namespace SportsPro.Controllers
{
    public class ProductController : Controller
    {
        private IRepository<Product> products;

        public ProductController(IRepository<Product> prod)
        {
            products = prod;
        }

        [Route("products")]
        public IActionResult List()
        {
            IEnumerable<Product> prod = products.List(new QueryOptions<Product>());
            return View(prod);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View(new Product());
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            Product prod = products.Get(id);
            return View(prod);
        }

        [HttpPost]
        public IActionResult Add(Product prod)
        {
            try
            {
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

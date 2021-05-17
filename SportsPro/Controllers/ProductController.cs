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
        private SportsProContext context { get; set; }
        public ProductController(SportsProContext ctx)
        {
            context = ctx;

        }

        [Route("products")]
        public IActionResult List()
        {
            List<Product> products = context.Products.ToList();
            return View(products);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View(new Product());
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            Product prod = context.Products.Find(id);
            return View(prod);
        }

        [HttpPost]
        public IActionResult Add(Product prod)
        {
            try
            {
                context.Products.Add(prod);
                context.SaveChanges();
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
                context.Products.Update(prod);
                context.SaveChanges();
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
                Product prod = context.Products.Find(id);
                context.Products.Remove(prod);
                context.SaveChanges();
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

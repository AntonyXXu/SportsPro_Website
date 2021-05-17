using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SportsPro.Models;
using Microsoft.EntityFrameworkCore;

namespace SportsPro.Controllers
{
    public class IncidentController : Controller
    {
        private SportsProContext context { get; set; }

        public IncidentController(SportsProContext ctx)
        {
            context = ctx;
        }
        [Route("incidents")]
        public IActionResult List()
        {
            List<Incident> incidents = context.Incidents
                .Include(inc => inc.Customer)
                .Include(inc => inc.Product)
                .OrderBy(inc => inc.DateOpened)
                .ToList();
            return View(incidents);
        }


        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.customers = context.Customers.ToList();
            ViewBag.products = context.Products.ToList();
            ViewBag.technicians = context.Technicians.ToList();
            return View(new Incident());
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            Incident tech = context.Incidents.Find(id);
            ViewBag.customers = context.Customers.ToList();
            ViewBag.products = context.Products.ToList();
            ViewBag.technicians = context.Technicians.ToList();
            return View(tech);
        }

        [HttpPost]
        public IActionResult Add(Incident incident)
        {
            try
            {
                context.Incidents.Add(incident);
                context.SaveChanges();
                return RedirectToAction("List", "Incident");
            }
            catch
            {
                return View();
            }
        }

        [HttpPost]
        public IActionResult Edit(Incident incident)
        {
            try
            {
                context.Incidents.Update(incident);
                context.SaveChanges();
                return RedirectToAction("List", "Incident");
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
                Incident incident = context.Incidents.Find(id);
                context.Incidents.Remove(incident);
                context.SaveChanges();
                return RedirectToAction("List", "Incident");
            }
            catch
            {
                return View("List");
            }
        }

    }
}

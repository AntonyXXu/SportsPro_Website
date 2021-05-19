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
            IncidentViewModel views = new IncidentViewModel();
            views.Incidents = incidents;

            return View(views);
        }


        [HttpGet]
        public IActionResult Add()
        {
            IncidentAddEditViewModel views = new IncidentAddEditViewModel();
            views.customers = context.Customers.ToList();
            views.products = context.Products.ToList();
            views.technicians = context.Technicians.ToList();
            views.operation = "Add";
            views.currentIncident = new Incident();
            return View(views); 
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            Incident tech = context.Incidents.Find(id);
            IncidentAddEditViewModel views = new IncidentAddEditViewModel();
            views.customers = context.Customers.ToList();
            views.products = context.Products.ToList();
            views.technicians = context.Technicians.ToList();
            views.operation = "Edit";
            views.currentIncident = tech;
            return View("Add", views);
        }

        [HttpGet]
        public IActionResult ListByTech()
        {
            ViewBag.Technicians = context.Technicians.ToList();
            Technician tech = new Technician();
            return View(tech);
        }

        [HttpGet]
        public IActionResult TechList(Technician tech)
        {
            List<Incident> incidents = context.Incidents
                .Include(inc => inc.TechnicianID == tech.TechnicianID)
                .Include(inc => inc.Customer)
                .Include(inc => inc.Product)
                .OrderBy(inc => inc.DateOpened)
                .ToList();
            IncidentViewModel views = new IncidentViewModel();
            views.Incidents = incidents;

            return View(views);
        }

        [HttpPost]
        public IActionResult Add(IncidentAddEditViewModel views)
        {
            try
            {
                Incident incident = views.currentIncident;
                context.Incidents.Add(incident);
                context.SaveChanges();
                return RedirectToAction("List", "Incident");
            }
            catch
            {
                return View(views);
            }
        }

        [HttpPost]
        public IActionResult Edit(IncidentAddEditViewModel views)
        {
            try
            {
                Incident incident = views.currentIncident;
                context.Incidents.Update(incident);
                context.SaveChanges();
                return RedirectToAction("List", "Incident");
            }
            catch
            {
                return View("Add", views);
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

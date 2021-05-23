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
    public class IncidentController : Controller
    {
        private SportsProContext context { get; set; }
        private SportsUnitWork sportsUnit;
        public IncidentController(SportsProContext ctx)
        {
            context = ctx;
            sportsUnit = new SportsUnitWork(ctx);
        }

        [Route("incidents")]
        public ViewResult List(string filter = "All")
        {
            List<Incident> incidents;
            IEnumerable<Incident> test;
            if (filter == "All")
            {
                incidents = context.Incidents
                    .Include(inc => inc.Customer)
                    .Include(inc => inc.Product)
                    .OrderBy(inc => inc.DateOpened)
                    .ToList();
            }
            else if (filter == "Unassigned")
            {
                incidents = context.Incidents
                .Where(inc => inc.TechnicianID == null)
                .Include(inc => inc.Customer)
                .Include(inc => inc.Product)
                .OrderBy(inc => inc.DateOpened)
                .ToList();
            }
            else if (filter == "Open")
            {
                incidents = context.Incidents
                .Where(inc => inc.DateClosed == null || inc.DateClosed >= DateTime.Today)
                .Where(inc => inc.TechnicianID != null)
                .Include(inc => inc.Customer)
                .Include(inc => inc.Product)
                .OrderBy(inc => inc.DateOpened)
                .ToList();
            }
            else
            {
                incidents = context.Incidents
                .Where(inc => inc.DateClosed != null && inc.DateClosed < DateTime.Today)
                .Include(inc => inc.Customer)
                .Include(inc => inc.Product)
                .OrderBy(inc => inc.DateOpened)
                .ToList();
            }
            IncidentViewModel views = new IncidentViewModel();
            views.Filter = filter;
            views.Incidents = incidents;

            return View(views);
        }


        [HttpGet]
        public IActionResult Add()
        {
            IncidentAddEditViewModel views = new IncidentAddEditViewModel();
            views.customers = sportsUnit.Customers.List(new QueryOptions<Customer>());
            views.products = sportsUnit.Products.List(new QueryOptions<Product>());
            views.technicians = sportsUnit.Technicians.List(new QueryOptions<Technician>());

            //views.customers = context.Customers.ToList();
            //views.products = context.Products.ToList();
            //views.technicians = context.Technicians.ToList();
            views.operation = "Add";
            views.currentIncident = new Incident();
            return View(views);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            Incident inc = context.Incidents.Find(id);
            IncidentAddEditViewModel views = new IncidentAddEditViewModel();
            views.customers = context.Customers.ToList();
            views.products = context.Products.ToList();
            views.technicians = context.Technicians.ToList();
            views.operation = "Edit";
            views.currentIncident = inc;
            return View("Add", views);
        }

        [HttpGet]
        public IActionResult EditTech(int id)
        {
            Incident inc = context.Incidents.Find(id);
            IncidentAddEditViewModel views = new IncidentAddEditViewModel();
            views.customers = context.Customers.ToList();
            views.products = context.Products.ToList();
            views.technicians = context.Technicians.ToList();
            views.operation = "Edit";
            views.currentIncident = inc;
            ViewBag.technician = inc.TechnicianID;
            return View("Edit", views);
        }

        [HttpGet]
        public IActionResult ListByTech()
        {
            ViewBag.Technicians = context.Technicians.ToList();
            return View();
        }

        [HttpGet]
        public IActionResult TechList(int TechnicianID)
        {
            List<Incident> incidents = context.Incidents
                .Where(inc => inc.TechnicianID == TechnicianID)
                .Include(inc => inc.Customer)
                .Include(inc => inc.Product)
                .OrderBy(inc => inc.DateOpened)
                .ToList();
            ViewBag.TechnicianName = context.Technicians.Find(TechnicianID).Name;
            IncidentViewModel views = new IncidentViewModel();
            views.Incidents = incidents;
            HttpContext.Session.SetInt32("techID", TechnicianID);

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
        public IActionResult Edit(IncidentAddEditViewModel views, int? dest)
        {
            try
            {
                Incident incident = views.currentIncident;
                context.Incidents.Update(incident);
                context.SaveChanges();
                int? techID = HttpContext.Session.GetInt32("techID");
                if (dest != null)
                {
                    return RedirectToAction("TechList", "Incident", new { TechnicianID = techID });
                }
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

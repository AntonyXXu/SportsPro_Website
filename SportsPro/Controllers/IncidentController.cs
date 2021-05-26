using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SportsPro.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using SportsPro.Models.ViewModels;

namespace SportsPro.Controllers
{
    public class IncidentController : Controller
    {
        private ISportsUnitWork sportsUnit;
        private IHttpContextAccessor http;
        public IncidentController(ISportsUnitWork ctx, IHttpContextAccessor httpctx)
        {
            sportsUnit = ctx;
            http = httpctx;
        }

        [Route("incidents")]
        public ViewResult List(string filter = "All")
        {
            QueryOptions<Incident> query = new QueryOptions<Incident>
            {
                Includes = "Customer, Product",
                OrderBy = inc => inc.DateOpened
            };

            if (filter == "Unassigned")
            {
                query.Where = inc => inc.TechnicianID == null;
            }
            else if (filter == "Open")
            {
                query.Where = inc => inc.DateClosed == null || inc.DateClosed >= DateTime.Today;
                query.Where = inc => inc.TechnicianID != null;
            }
            else if (filter == "Closed")
            {
                query.Where = inc => inc.DateClosed != null && inc.DateClosed < DateTime.Today;
            }

            IEnumerable<Incident> incidents = sportsUnit.Incidents.List(query);
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
            views.operation = "Add";
            views.currentIncident = new Incident();
            return View(views);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            Incident inc = sportsUnit.Incidents.Get(id);
            IncidentAddEditViewModel views = new IncidentAddEditViewModel();
            views.customers = sportsUnit.Customers.List(new QueryOptions<Customer>());
            views.products = sportsUnit.Products.List(new QueryOptions<Product>());
            views.technicians = sportsUnit.Technicians.List(new QueryOptions<Technician>());
            views.operation = "Edit";
            views.currentIncident = inc;
            return View("Add", views);
        }

        [HttpGet]
        public IActionResult EditTech(int id)
        {
            Incident inc = sportsUnit.Incidents.Get(id);
            IncidentAddEditViewModel views = new IncidentAddEditViewModel();
            views.customers = sportsUnit.Customers.List(new QueryOptions<Customer>());
            views.products = sportsUnit.Products.List(new QueryOptions<Product>());
            views.technicians = sportsUnit.Technicians.List(new QueryOptions<Technician>());
            views.operation = "Edit";
            views.currentIncident = inc;
            ViewBag.technician = inc.TechnicianID;
            return View("Edit", views);
        }

        [HttpGet]
        public IActionResult ListByTech()
        {
            TechniciansViewModel textvm = new TechniciansViewModel()
            {
                Technicians = sportsUnit.Technicians.List(new QueryOptions<Technician>()).ToList()
            };
            //var technicians = sportsUnit.Technicians.List(new QueryOptions<Technician>());
            return View(textvm);
        }

        [HttpGet]
        public IActionResult TechList(int TechnicianID)
        {
            QueryOptions<Incident> query = new QueryOptions<Incident>
            {
                Where = inc => inc.TechnicianID == TechnicianID,
                Includes = "Customer, Product",
                OrderBy = inc => inc.DateOpened
            };

            ViewBag.TechnicianName = sportsUnit.Technicians.Get(TechnicianID)?.Name?? "You did not select a technician";
            IncidentViewModel views = new IncidentViewModel();
            views.Incidents = sportsUnit.Incidents.List(query);
            http.HttpContext.Session.SetInt32("techID", TechnicianID);

            return View(views);
        }

        [HttpPost]
        public IActionResult Add(IncidentAddEditViewModel views)
        {
            try
            {
                Incident incident = views.currentIncident;
                sportsUnit.Incidents.Insert(incident);
                sportsUnit.save();
                TempData["message"] = $"{incident.Title} was successfully added";
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
                sportsUnit.Incidents.Update(incident);
                sportsUnit.save();
                TempData["message"] = $"{incident.Title} was successfully updated";
                int? techID = http.HttpContext.Session.GetInt32("techID");
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
                Incident incident = sportsUnit.Incidents.Get(id);
                sportsUnit.Incidents.Delete(incident);
                sportsUnit.save();
                TempData["message"] = $"{incident.Title} was successfully deleted";
                return RedirectToAction("List", "Incident");
            }
            catch
            {
                return View("List");
            }
        }

    }
}

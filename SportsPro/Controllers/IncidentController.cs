using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SportsPro.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using SportsPro.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;

namespace SportsPro.Controllers
{
    [Authorize(Roles = "Admin")]
    public class IncidentController : Controller
    {
        // Initialize sportsUnit and the sessions http
        private ISportsUnitWork sportsUnit;
        private IHttpContextAccessor http;
        public IncidentController(ISportsUnitWork ctx, IHttpContextAccessor httpctx)
        {
            sportsUnit = ctx;
            http = httpctx;
        }

        [Route("incidents")]
        public IActionResult List(string filter = "All")
        {

            //if (!User.Identity.IsAuthenticated)
            //{
            //    return RedirectToAction("LogIn", "Account");
            //}
            //else if (!User.IsInRole("Admin"))
            //{
            //    return RedirectToAction("Index", "Home");
            //}
            // Return list of incidents with customer and product data
            QueryOptions<Incident> query = new QueryOptions<Incident>
            {
                Includes = "Customer, Product",
                OrderBy = inc => inc.DateOpened
            };

            if (filter == "Unassigned")
            {
                // Query change where technicianID is not filled
                query.Where = inc => inc.TechnicianID == null;
            }
            else if (filter == "Open")
            {
                // Query change where date is after today
                query.Where = inc => inc.DateClosed == null || inc.DateClosed >= DateTime.Today;
                query.Where = inc => inc.TechnicianID != null;
            }
            else if (filter == "Closed")
            {
                // Query change where date is date is before today
                query.Where = inc => inc.DateClosed != null && inc.DateClosed < DateTime.Today;
            }

            // Get a list of incidents with the query
            IEnumerable<Incident> incidents = sportsUnit.Incidents.List(query);
            
            // Initialize view model
            IncidentViewModel views = new IncidentViewModel();
            views.Filter = filter;
            views.Incidents = incidents;
            return View(views);
        }


        [HttpGet]
        public IActionResult Add()
        {
            // Create a view model for add
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
            // Create a view model for editing
            Incident inc = sportsUnit.Incidents.Get(id);
            IncidentAddEditViewModel views = new IncidentAddEditViewModel();
            views.customers = sportsUnit.Customers.List(new QueryOptions<Customer>());
            views.products = sportsUnit.Products.List(new QueryOptions<Product>());
            views.technicians = sportsUnit.Technicians.List(new QueryOptions<Technician>());
            views.operation = "Edit";
            views.currentIncident = inc;
            return View("Add", views);
        }

        [Authorize(Roles = "Technician")]
        [HttpGet]
        public IActionResult EditTech(int id)
        {
            // Create a view model for editing from a technician
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

        //[HttpGet]
        //public IActionResult ListByTech()
        //{

        //    //if (!User.Identity.IsAuthenticated)
        //    //{
        //    //    return RedirectToAction("LogIn", "Account");
        //    //}
        //    //else if (!User.IsInRole("Admin"))
        //    //{
        //    //    return RedirectToAction("Index", "Home");
        //    //}
        //    //Initialize technician view model
        //    TechniciansViewModel textvm = new TechniciansViewModel()
        //    {
        //        Technicians = sportsUnit.Technicians.List(new QueryOptions<Technician>()).ToList()
        //    };   
        //    return View(textvm);
        //}

        [HttpGet]
        public IActionResult TechList(int TechnicianID)
        {
            // Initialize query for list of the selected and their associated incidents
            QueryOptions<Incident> query = new QueryOptions<Incident>
            {
                Where = inc => inc.TechnicianID == TechnicianID,
                Includes = "Customer, Product",
                OrderBy = inc => inc.DateOpened
            };

            ViewBag.TechnicianName = sportsUnit.Technicians.Get(TechnicianID)?.Name?? "You did not select a technician";
            // initialize incident view model
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
                // update the db context with added model
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
                // update the db context with editted model
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
                // update the db context with deleted model
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

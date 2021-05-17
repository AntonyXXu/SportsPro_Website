using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SportsPro.Models;

namespace SportsPro.Controllers
{
    public class TechnicianController : Controller
    {
        private SportsProContext context { get; set; }
        public TechnicianController(SportsProContext ctx)
        {
            context = ctx;
        }

        [Route("technicians")]
        public IActionResult List()
        {
            List<Technician> technicians = context.Technicians.ToList();
            return View(technicians);
        }


        [HttpGet]
        public IActionResult Add()
        {
            return View(new Technician());
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            Technician tech = context.Technicians.Find(id);
            return View(tech);
        }

        [HttpPost]
        public IActionResult Add(Technician tech)
        {
            try
            {
                context.Technicians.Add(tech);
                context.SaveChanges();
                return RedirectToAction("List", "Technician");
            }
            catch
            {
                return View();
            }
        }

        [HttpPost]
        public IActionResult Edit(Technician tech)
        {
            try
            {
                context.Technicians.Update(tech);
                context.SaveChanges();
                return RedirectToAction("List", "Technician");
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
                Technician tech = context.Technicians.Find(id);
                context.Technicians.Remove(tech);
                context.SaveChanges();
                return RedirectToAction("List", "Technician");
            }
            catch
            {
                return View("List");
            }
        }

    }
}

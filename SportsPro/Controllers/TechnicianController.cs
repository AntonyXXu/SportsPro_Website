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
        private Repository<Technician> technicians;
        public TechnicianController(SportsProContext ctx)
        {
            //context = ctx;
            technicians = new Repository<Technician>(ctx);
        }

        [Route("technicians")]
        public IActionResult List()
        {
            IEnumerable<Technician> techs = technicians.List(new QueryOptions<Technician>());
            return View(techs);
        }


        [HttpGet]
        public IActionResult Add()
        {
            return View(new Technician());
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            Technician tech = technicians.Get(id);
            return View(tech);
        }

        [HttpPost]
        public IActionResult Add(Technician tech)
        {
            try
            {
                technicians.Insert(tech);
                technicians.Save();
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
                technicians.Update(tech);
                technicians.Save();
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
                Technician tech = technicians.Get(id);
                technicians.Delete(tech);
                technicians.Save();
                return RedirectToAction("List", "Technician");
            }
            catch
            {
                return View("List");
            }
        }

    }
}

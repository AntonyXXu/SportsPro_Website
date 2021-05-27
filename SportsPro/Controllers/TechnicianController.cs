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

    public class TechnicianController : Controller
    {
        // Initialize a repository interface of Technicians
        private IRepository<Technician> technicians;
        public TechnicianController(IRepository<Technician> tech)
        {
            technicians = tech;
        }

        [Route("technicians")]
        public IActionResult List()
        {
            //if (!User.Identity.IsAuthenticated)
            //{
            //    return RedirectToAction("LogIn", "Account");
            //}
            //else if (!User.IsInRole("Admin"))
            //{
            //    return RedirectToAction("Index", "Home");
            //}
            //Query a list of Technicians
            IEnumerable<Technician> techs = technicians.List(new QueryOptions<Technician>());
            return View(techs);
        }


        [HttpGet]
        public IActionResult Add()
        {
            // Create a new technician
            return View(new Technician());
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            // update  technician
            Technician tech = technicians.Get(id);
            return View(tech);
        }

        [HttpPost]
        public IActionResult Add(Technician tech)
        {
            try
            {
                // save new tech into db
                technicians.Insert(tech);
                technicians.Save();
                TempData["message"] = $"{tech.Name} was successfully added";
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
                // update tech into db
                technicians.Update(tech);
                technicians.Save();
                TempData["message"] = $"{tech.Name} was successfully updated";
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
                // delete tech from db
                Technician tech = technicians.Get(id);
                technicians.Delete(tech);
                technicians.Save();
                TempData["message"] = $"{tech.Name} was successfully deleted";
                return RedirectToAction("List", "Technician");
            }
            catch
            {
                return View("List");
            }
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SportsPro.Models;

namespace SportsPro.Components
{
    public class TechnicianDropDown : ViewComponent
    {
        private IRepository<Technician> data { get; set; }
        public TechnicianDropDown(IRepository<Technician> rep) => data = rep;
        public IViewComponentResult Invoke(string value, string defaultText, string defaultValue)
        {
            var technicians = data.List(new QueryOptions<Technician>
            {
                OrderBy = t=> t.Name
            });
            var vm = new DropDownOptionsViewModel
            {
                SelectedValue = value,
                DefaultValue = defaultValue,
                DefaultText = defaultText,
                Items = technicians.ToDictionary(
            t => t.TechnicianID.ToString(), t => t.Name)
            };
            return View("~/Views/Shared/Common/DropDownOptions.cshtml", vm);
        }

    }
}

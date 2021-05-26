using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SportsPro.Models;

namespace SportsPro.Components
{
    public class CountryDropDownOptions : ViewComponent
    {
        private IRepository<Country> data { get; set; }
        public CountryDropDownOptions(IRepository<Country> rep) => data = rep;
        public IViewComponentResult Invoke(string value, string defaultText, string defaultValue)
        {
            var countries = data.List(new QueryOptions<Country>
            {
                OrderBy = a => a.Name
            });
            var vm = new DropDownOptionsViewModel
            {
                SelectedValue = value,
                DefaultValue = defaultValue,
                DefaultText = defaultText,
                Items = countries.ToDictionary(
            a => a.CountryID.ToString(), a => a.Name)
            };
            return View("~/Views/Shared/Common/DropDownOptions.cshtml", vm);
        }
    }
}

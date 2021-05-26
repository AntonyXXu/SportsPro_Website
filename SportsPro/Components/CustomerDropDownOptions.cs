using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SportsPro.Models;

namespace SportsPro.Components
{
    public class CustomerDropDownOptions : ViewComponent
    {
        private IRepository<Customer> data { get; set; }
        public CustomerDropDownOptions(IRepository<Customer> rep) => data = rep;
        public IViewComponentResult Invoke(string value, string defaultText, string defaultValue)
        {
            var customers = data.List(new QueryOptions<Customer>
            {
                OrderBy = c => c.LastName
            });
            var vm = new DropDownOptionsViewModel
            {
                SelectedValue = value,
                DefaultValue = defaultValue,
                DefaultText = defaultText,
                Items = customers.ToDictionary(
            c => c.CustomerID.ToString(), c => c.FullName)
            };
            return View("~/Views/Shared/Common/DropDownOptions.cshtml", vm);
        }
    }
}

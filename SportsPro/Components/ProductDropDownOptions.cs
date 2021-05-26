using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SportsPro.Models;

namespace SportsPro.Components
{
    public class ProductDropDownOptions : ViewComponent
    {
        private IRepository<Product> data { get; set; }
        public ProductDropDownOptions(IRepository<Product> rep) => data = rep;
        public IViewComponentResult Invoke(string value, string defaultText, string defaultValue)
        {
            var products = data.List(new QueryOptions<Product>
            {
                OrderBy = p => p.Name
            });
            var vm = new DropDownOptionsViewModel
            {
             
                SelectedValue = value,
                DefaultValue = defaultValue,
                DefaultText = defaultText,
                Items = products.ToDictionary(
            p => p.ProductID.ToString(), p => p.Name)
            };
            return View("~/Views/Shared/Common/DropDownOptions.cshtml", vm);
        }
    }
}

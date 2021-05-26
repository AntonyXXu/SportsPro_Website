using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace SportsPro.Models.TagHelpers
{
    [HtmlTargetElement("a", ParentTag = "div")]
    public class ActiveNavbarTagHelper : TagHelper
    {
        [ViewContext]
        [HtmlAttributeNotBound] public ViewContext ViewCtx { get; set; }
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            string area = ViewCtx.RouteData.Values["action"]?.ToString() ?? "";
            string ctlr = ViewCtx.RouteData.Values["controller"].ToString();
            string aspArea = context.AllAttributes["asp-action"]?.Value?.ToString() ?? "";
            string aspCtlr = context.AllAttributes["asp-controller"]?.Value?.ToString() ?? "";
            if (area == aspArea && ctlr == aspCtlr) output.Attributes.AppendCssClass("active");
        }
    }
}

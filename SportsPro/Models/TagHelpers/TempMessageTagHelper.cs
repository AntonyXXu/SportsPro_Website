using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Microsoft.AspNetCore.Mvc.ViewFeatures;    // [ViewContext] attribute
using Microsoft.AspNetCore.Mvc.Rendering;
using SportsPro.Models;                                           // ViewContext class

namespace SportsPro.Models.TagHelpers
{
    [HtmlTargetElement("my-temp-message")]
    public class TempMessageTagHelper: TagHelper
    {
        [ViewContext]
        [HtmlAttributeNotBound]
        public ViewContext ViewCtx { get; set; }

        public override void Process(TagHelperContext context,
        TagHelperOutput output)
        {
            var td = ViewCtx.TempData;
            if (td.ContainsKey("message"))
            {
                //output.BuildTag("h4", "bg-info text-center text-white p-4");
                output.BuildTag("h4", "tempmsg");

                output.Content.SetContent(td["message"].ToString());
            }
            else
            {
                output.SuppressOutput();
            }
        }
    }
}

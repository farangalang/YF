using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace MyYouthFutures.Helpers
{
    public class EditArea : TagHelper
    {
        public bool IsVisible { get; set; } = true;
        public override Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            if (!IsVisible)
            { 
                output.TagName = "div";
                output.TagMode = TagMode.StartTagAndEndTag;
                output.Attributes.SetAttribute("is-visible", "User.Identity.IsAuthenticated");
            }
            else
            {
                output.TagName = "div";
                output.TagMode = TagMode.StartTagAndEndTag;
                output.Attributes.SetAttribute("is-visible", "User.Identity.IsAuthenticated");
                output.Attributes.SetAttribute("class", "editArea");
            }
            return base.ProcessAsync(context, output);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace MyYouthFutures.Helpers
{
    public class EditAList: TagHelper
    {
        public string Controller { get; set; }
        public string href { get; set; }
        public bool IsVisible { get; set; } = true;

        public override Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            if (!IsVisible)
            {
                output.SuppressOutput();
            }
            else
            {
                href = "/" + Controller + "/Index" ;
                output.TagName = ("a");
                output.TagMode = TagMode.StartTagAndEndTag;
                output.Attributes.SetAttribute("class", "editText");
                output.Attributes.SetAttribute("href", href);
                output.Content.SetContent("Edit");
            }
            return base.ProcessAsync(context, output);
        }
    }
}

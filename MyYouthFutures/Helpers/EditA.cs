﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace MyYouthFutures.Helpers
{
    public class EditA: TagHelper
    {
        public string Controller { get; set; }
        public string RouteID { get; set; }
        public string href { get; set; }


        public override void Process(TagHelperContext context, TagHelperOutput output)
        { 
            href = "/" + Controller + "/Edit/" +RouteID;
            output.TagName = ("a");
            output.TagMode = TagMode.StartTagAndEndTag;
            output.Attributes.SetAttribute("class", "editText");
            output.Attributes.SetAttribute("href", href);
            output.Content.SetContent("Edit");
        }
    }
}
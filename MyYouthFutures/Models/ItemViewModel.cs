using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MyYouthFutures.Data;
using MyYouthFutures.Models;

namespace MyYouthFutures.Models
{
    public class ItemViewModel
    {
        public IEnumerable<introArticle> introArticles { get; set; }
        public IEnumerable<Founder_Message> Founder_Messages { get; set; }
        public IEnumerable<FirstYear_Service_Messages> FirstYear_Service_Messages { get; set; }
        public IEnumerable<Staff_Panel> Staff { get; set; }
        public IEnumerable<List_Item> List_item { get; set; }
        public IEnumerable<Media> Media { get; set; }
        //public IEnumerable<Youth_Story> Youth_Stories { get; set; }
        public IEnumerable<Doners> Doners { get; set; }
        public IEnumerable<Help_Panel> Help_Panel { get; set; }
        public IEnumerable<Services> Services { get; set; }
        public IEnumerable<Services_Message> Services_Message { get; set; }
        public IEnumerable<Purpose> Purpose { get; set; }
        public IEnumerable<HomeTitle> HomeTitle { get; set; }
        public IEnumerable<Link> Link { get; set; }
        public IEnumerable<Events> Events { get; set; }
    }
}

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
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyYouthFutures.Models
{
    public class Youth_Story
    {
        public int id { get; set; }
        public DateTime date { get; set; }
        public string title { get; set; }
        public string image { get; set; }
        public string imageBlurb { get; set; }
        public string articleText { get; set; }
    }
}

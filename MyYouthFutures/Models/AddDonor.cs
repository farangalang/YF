using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyYouthFutures.Models
{
    public class AddDonnor
    {
        public int id { get; set; }
        public char show { get; set; } //show/hide donnors
        public string type { get; set; } //platnum, gold, etc.
        public string name { get; set; }
        public string year { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyYouthFutures.Models
{
    public class Donor
    {
        public int ID { get; set; }
        public string Level { get; set; } //platnum, gold, etc.
        public string Name { get; set; }
        public string Year { get; set; }
    }
}

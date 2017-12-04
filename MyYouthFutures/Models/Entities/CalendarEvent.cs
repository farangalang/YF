using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyYouthFutures.Models
{
    public class CalendarEvent
    {
        public int id { get; set; }
        public string name { get; set; }
        public string eventTitle { get; set; }
        public DateTime datetime { get; set; }
        public string location { get; set; }
        public string info { get; set; }
    }
}

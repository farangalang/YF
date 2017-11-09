using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyYouthFutures.Models
{
    public class AddStaff
    {
        public int id { get; set; }
        public bool current { get; set; } //flag to show/hide staff
        public string name { get; set; }
        public StaffTitle[] titles { get; set; } //title of staff, looks like there could be multiple titles
        public string email { get; set; }
        public string image_path { get; set; }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyYouthFutures.Models
{
    public class Purpose
    {
        public int PurposeID { get; set; }
        public string Title { get; set; }
        public string Message { get; set; }
        public string Content { get; set; }
        public string BackgroundImage { get; set; }
        public string TargetControler { get; set; }
        public string TargetAction { get; set; }
        public string TargetFragment { get; set; }
    }
}

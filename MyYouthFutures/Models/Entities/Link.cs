﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyYouthFutures.Models
{
    public class Link
    {
        public int LinkID { get; set; }
        public string Image { get; set; }
        public string Title { get; set; }
        public string Message { get; set; }
        public string TargetControler { get; set; }
        public string TargetAction { get; set; }
        public string TargetFragment { get; set; }
        public string Hyperlink { get; set; }
    }
}

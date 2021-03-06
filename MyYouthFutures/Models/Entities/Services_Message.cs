﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using MyYouthFutures.Models.Entities;

namespace MyYouthFutures.Models
{
    public class Services_Message
    {
        public int ID { get; set; }
        [Display(Name = "Image Location")]
        public string MessageImage { get; set; }
        [Display(Name = "Service Header")]
        public string MessageHeader { get; set; }
        [Display(Name = "Service Description")]
        [DataType(DataType.MultilineText)]
        public string Message { get; set; }
        [Display(Name = "Link to Page")]
        public string Link { get; set; }
        public string TargetControler { get; set; }
        public string TargetAction { get; set; }
        public string TargetFragment { get; set; }
        public StoreUser User { get; set; }
    }
}

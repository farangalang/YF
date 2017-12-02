using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
/// <summary>
/// this class holds the DB modle for the first year service panels on the history page that is part of the about view.
/// </summary>
namespace MyYouthFutures.Models
{
    public class FirstYear_Service_Messages
    {
        public int ID { get; set; }
        public string firstYearImage { get; set; }
        public string firstYearText { get; set; }
    }
}

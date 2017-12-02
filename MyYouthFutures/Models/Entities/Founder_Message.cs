using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

/// <summary>
/// This class holds the db representation for founder images and subtitles on the history page
/// </summary>
namespace MyYouthFutures.Models
{
    public class Founder_Message
    {
        public int ID { get; set; }
        public string founderImage { get; set; }
        public string founderSubTetxt { get; set; }
    }
}

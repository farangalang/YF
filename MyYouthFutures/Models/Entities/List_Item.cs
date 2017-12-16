using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyYouthFutures.Models
{
    public class List_Item
    {
        public int ID { get; set; }
        public string TypeOfList { get; set; }
        /// <summary>
        /// the group ID property gives a digit for the UI to grab when getting the edit view. This way list items can be edited as logical groups
        /// </summary>
        public int GroupID { get; set; }
        public string LiText { get; set; }
    }
}

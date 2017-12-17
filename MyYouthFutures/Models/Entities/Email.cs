using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyYouthFutures.Models
{
    public class Email
    {
        public int ID { get; set; }
        public string FirstName { get; set; } //show/hide donnors
        public string LastName { get; set; } //platnum, gold, etc.
        public string Phone { get; set; }
        public string EmailAddress { get; set; }
        public string Message { get; set; }
        public string Key { get; set; }
    }
}

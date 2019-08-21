using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace F1News.Models
{
    public class Events
    {
        public int eventID { get; set; }
        public string Subject { get; set; }
        public string Description { get; set; }
        public string Start { get; set; }
        public string End { get; set; }
        public bool IsFullDay { get; set; }
    }
}

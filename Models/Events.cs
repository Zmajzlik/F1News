using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace F1News.Models
{
    public class Events
    {
        public int eventID { get; set; }
        public string title { get; set; }
        public string Description { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public bool IsFullDay { get; set; }
    }
}

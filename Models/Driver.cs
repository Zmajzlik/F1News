using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace F1News.Models
{
    public class Driver
    {
        public int Id { get; set; }
        public string fullName { get; set; }
        public int points { get; set; }
        public string Team { get; set; }
        public string Country { get; set; }
    }
}

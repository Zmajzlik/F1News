using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace F1News.Models
{
    public class GalleryImage
    {
        [Key]
        public int photoID { get; set; }
        public string Caption { get; set; }
        public string URL { get; set; }
        public bool IsMeme { get; set; }
    }
}

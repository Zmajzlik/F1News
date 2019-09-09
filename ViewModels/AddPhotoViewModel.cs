using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace F1News.ViewModels
{
    public class AddPhotoViewModel
    {
        [Required]
        public string Caption { get; set; }
        [Required]
        public List<IFormFile> Photo { get; set; }
    }
}

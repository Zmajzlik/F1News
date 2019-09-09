using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using F1News.Data;
using F1News.Models;
using F1News.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;

namespace F1News.Controllers
{
    public class GalleryController : Controller
    {
        private readonly ApplicationDbContext _context;

        private readonly IHostingEnvironment _env;

        public GalleryController(ApplicationDbContext context, IHostingEnvironment env)
        {
            _context = context;
            _env = env;
        }
        public static List<GalleryImage> PublishedPhotos { get; set; } = new List<GalleryImage>();

        // GET: Post
        public ActionResult Index()
        {

            var displayPostViewModels = _context.GalleryImages.Select(n => new DisplayPostViewModel
            {
                Caption = n.Caption,
                URL = n.URL.Split(',', StringSplitOptions.None).ToList()
            });

            return View(displayPostViewModels);
        }

        // GET: Post/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Post/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AddPhotoViewModel addPhotoViewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    var photoList = new List<string>();
                    foreach (var photo in addPhotoViewModel.Photo)
                    {
                        var uploadFolder = "Upload";

                        var savePhotoPath = Path.Combine(_env.WebRootPath,
                            uploadFolder, photo.FileName);

                        using (var photoSave = new FileStream(savePhotoPath, FileMode.Create))
                        {
                            photo.CopyTo(photoSave);
                        }

                        photoList.Add("/" + uploadFolder + "/" + photo.FileName);
                    }

                    using (var context = new ApplicationDbContext())
                    {
                        context.GalleryImages.Add(new GalleryImage
                        {
                            Caption = addPhotoViewModel.Caption,
                            URL = String.Join(",", photoList),
                            IsMeme = false
                        });

                        var count = context.SaveChanges();

                    }

                    return RedirectToAction(nameof(Index));
                   
                }

                return View(addPhotoViewModel);
            }
            catch

            {
                return View();
            }
        }
    }
}
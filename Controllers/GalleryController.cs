using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using F1News.Data;
using F1News.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;

namespace F1News.Controllers
{
    public class GalleryController : Controller
    {
        static CloudBlobClient blobClient;
        const string BLOB_CONTAINER_NAME = "memes";
        static CloudBlobContainer blobContainer;
        private ApplicationDbContext _context;
        public List<GalleryImage> GalleryImages { get; set; }
        public IConfiguration _configuration;
        [BindProperty]
        public GalleryImage GalleryImage { get; set; }
        public GalleryController(IConfiguration configuration, ApplicationDbContext context)
        {
            _context = context;
            _configuration = configuration;
        }
        public async Task OnGet()
        {
            ViewData["SuccessMessage"] = TempData["SuccessMessage"];
            GalleryImages = await _context.GalleryImages.ToListAsync();
        }
        public async Task OnGetAsync()
        {
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(_configuration.GetConnectionString("AzureStorageConnectionString"));
            blobClient = storageAccount.CreateCloudBlobClient();

            blobContainer = blobClient.GetContainerReference(BLOB_CONTAINER_NAME);

            await blobContainer.CreateIfNotExistsAsync();

            await blobContainer.SetPermissionsAsync(new BlobContainerPermissions { PublicAccess = BlobContainerPublicAccessType.Blob });
        }
        public async Task<IActionResult> OnPost(IFormCollection form)
        {
            try
            {
                var file = form.Files.FirstOrDefault();
                CloudBlockBlob blob = blobContainer.GetBlockBlobReference(file?.FileName);
                blob.Properties.ContentType = file?.ContentType;
                await blob.UploadFromStreamAsync(file?.OpenReadStream());
                GalleryImage.URL = $"{blobContainer.StorageUri.PrimaryUri}/{file?.FileName}";
                _context.GalleryImages.Add(GalleryImage);
                await _context.SaveChangesAsync();
                TempData["SuccessMessage"] = "Image upload success!";
                return RedirectToPage("ImageGallery");
            }
            catch (Exception ex)
            {
                return RedirectToPage("Error");
            }
        }
        public IActionResult UploadPhoto()
        {
            return View();
        }
        public IActionResult ImageGallery()
        {
            return View();
        }
    }
}
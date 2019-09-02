using System;
using System.Collections.Generic;
using System.Text;
using F1News.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace F1News.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<GalleryImage> GalleryImages { get; set; }
        public DbSet<Driver> Drivers { get; set; }
    }
}

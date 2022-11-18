using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;



namespace _Gallery_.Models
{
    public class PictureContext: DbContext
    {
        public PictureContext() : base("DefaultConnection")
        { }

        public DbSet<Picture> Pictures { get; set; }
        public DbSet<Purchase> Purchases { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<Artist> Artists { get; set; }
    }
}
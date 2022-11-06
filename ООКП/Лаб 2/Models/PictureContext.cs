using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;



namespace _Gallery_.Models
{
    public class PictureContext: DbContext
    {
        public DbSet<Picture> Pictures { get; set; }
        public DbSet<Purchase> Purchases { get; set; }
    }
}
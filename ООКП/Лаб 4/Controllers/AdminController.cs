using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using _Gallery_.Models;

namespace _Gallery_.Controllers
{
    public class AdminController : Controller
    {
        PictureContext db = new PictureContext();
        public static int PicId;

        public ActionResult Index()
        {
            IEnumerable<Picture> pictures = db.Pictures;

            ViewBag.Pictures = pictures;

            return View();
        }

        [HttpGet]
        public ActionResult More(int id)
        {
            Picture thisPicture = db.Pictures.Find(id);

            ViewBag.Id = id;
            ViewBag.Name = thisPicture.Name;
            ViewBag.Artist = thisPicture.Artist;
            ViewBag.Genre = thisPicture.Genre;
            ViewBag.Style = thisPicture.Style;
            ViewBag.Materials = thisPicture.Materials;
            ViewBag.Price = thisPicture.Price;
            ViewBag.Link = thisPicture.Link;

            return View();
        }

        public ActionResult Artist(int id)
        {
            IEnumerable<Artist> artists = db.Artists;

            Picture thisPic = db.Pictures.Find(id);

            PicId = id;
            foreach (var a in artists)
            {
                if (thisPic.Artist == a.ArtistsName)
                {
                    ViewBag.Artist = thisPic.Artist;
                    ViewBag.Info = a.Info;
                    ViewBag.Photo = a.Photo;
                    ViewBag.Id = a.Id;
                }
            }

            return View();
        }

        public ActionResult Delete(int id)
        {
            IEnumerable<Picture> pictures = db.Pictures;

            foreach (var pic in pictures)
            {
                if (pic.Id == id)
                {
                    Picture DelRow = db.Pictures.Find(id);
                    if (DelRow != null)
                    {
                        db.Pictures.Remove(DelRow);
                    }
                }
            }
            db.SaveChanges();
            Index();
            return View("~/Views/Admin/Index.cshtml");

        }

        public ActionResult Update(int id, string price)
        {
            Picture updated = db.Pictures.Find(id);

            if (price != null && price != "")
            {
                decimal decPrice = Convert.ToDecimal(price);
                updated.Price = decPrice;
                db.SaveChanges();
            }

            if (updated.Price != Convert.ToDecimal(price))
                return View();
            else
            {
                More(id);
                return View("~/Views/Admin/More.cshtml");
            }
               
        }

        public ActionResult Insert()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Insert(Picture NewPicture, string Price, string Artist, string Link, Artist NewArtist)
        {
            bool flag = false;
            IEnumerable<Artist> artists = db.Artists;

            if (Price != null && Price != "")
            {
                decimal decPrice = Convert.ToDecimal(Price);
                NewPicture.Price = decPrice;
            }

            if (Link == null || Link == "")
                NewPicture.Link = "Пусто";

            foreach (var artist in artists)
            {
                if (Artist == artist.ArtistsName)
                    flag = true;
            }

            if (flag == false)
            {
                NewArtist.ArtistsName = Artist;
                NewArtist.Info = "";
                NewArtist.Photo = "Пусто";
                db.Artists.Add(NewArtist);
                db.SaveChanges();
            }

            db.Pictures.Add(NewPicture);
            db.SaveChanges();

            Index();
            return View("~/Views/Admin/Index.cshtml");
        }

        public ActionResult UpdateArtist(int id, string Info, string Photo)
        {
            bool info = false;
            bool photo = false;

            Artist updated = db.Artists.Find(id);

            if (Photo != null && Photo != "")
            {
                updated.Photo = Photo;
                photo = true;
            }

            if (Info != null && Info != "")
            {
                updated.Info = Info;
                info = true;
            }

            db.SaveChanges();

            if (!photo && !info)
                return View();
            else 
            {
                Artist(PicId);
                return View("~/Views/Admin/Artist.cshtml");
            }
        }
    }
}
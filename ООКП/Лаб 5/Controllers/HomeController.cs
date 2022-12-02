using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using _Gallery_.Models;

namespace _Gallery_.Controllers
{
    public class HomeController : Controller
    {
        PictureContext db = new PictureContext();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ViewPictures(string PictureName, string sort)
        {
            IEnumerable<Picture> pictures = db.Pictures;
            pictures = pictures.Where(x => x.Status == "доступно");

            using (var transaction = db.Database.BeginTransaction())
            {
                try
                {
                    if (PictureName != "" && PictureName != null)
                    {
                        pictures = pictures.Where(x => x.Name == PictureName);
                    }

                    if (sort != null && sort != "")
                    {
                        if (sort == "Name")
                            pictures = pictures.OrderBy(x => x.Name);
                        else if (sort == "Artist")
                            pictures = pictures.OrderBy(x => x.Artist);
                    }

                    ViewBag.Pictures = pictures;
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                }
            }

            return View();
        }

        public ActionResult More(int id)
        {
            Picture thisPicture = db.Pictures.Find(id);

            using (var transaction = db.Database.BeginTransaction())
            {
                try
                {
                    ViewBag.Id = id;
                    ViewBag.Name = thisPicture.Name;
                    ViewBag.Artist = thisPicture.Artist;
                    ViewBag.Genre = thisPicture.Genre;
                    ViewBag.Style = thisPicture.Style;
                    ViewBag.Materials = thisPicture.Materials;
                    ViewBag.Price = thisPicture.Price;
                    ViewBag.Link = thisPicture.Link;

                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                }
            }
            
            return View();
        }

        public ActionResult Artist(int id)
        {
            IEnumerable<Artist> artists = db.Artists;

            Picture thisPic = db.Pictures.Find(id);

            using (var transaction = db.Database.BeginTransaction())
            {
                try
                {
                    foreach (var a in artists)
                    {
                        if (thisPic.Artist == a.ArtistsName)
                        {
                            ViewBag.Artist = thisPic.Artist;
                            ViewBag.Info = a.Info;
                            ViewBag.Photo = a.Photo;
                        }
                    }

                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                }
            }
           
            return View();
        }

        [HttpGet]
        public ActionResult Buy(int id)
        {
            ViewBag.PictureId = id;
            return View();
        }

        [HttpPost]
        public ActionResult Buy(Purchase purchase)
        {
            purchase.Date = DateTime.Now;

            using (var transaction = db.Database.BeginTransaction())
            {
                try
                {
                    foreach (var pic in db.Pictures)
                    {
                        if (pic.Id == purchase.PictureId)
                        {
                            Picture thisPic = db.Pictures.Find(pic.Id);
                            purchase.PicturesName = thisPic.Name;

                            thisPic.Status = "продано";

                        }
                    }

                    db.Purchases.Add(purchase);
                    db.SaveChanges();
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                }
            }
            
            ViewPictures(null, null);
            return View("~/Views/Home/ViewPictures.cshtml");
        }

    }
}
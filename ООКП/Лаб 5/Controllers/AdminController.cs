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
            return View();
        }

        public ActionResult AdminPictures(string status)
        {
            using (var transaction = db.Database.BeginTransaction())
            {
                try
                {
                    IEnumerable<Picture> pictures = db.Pictures;

                    if (status != null && status != "")
                        pictures = pictures.Where(x => x.Status == status);

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

        public ActionResult SoldPictures()
        {
            using (var transaction = db.Database.BeginTransaction())
            {
                try
                {
                    IEnumerable<Purchase> pictures = db.Purchases;

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

        [HttpGet]
        public ActionResult More(int id)
        {
            using (var transaction = db.Database.BeginTransaction())
            {
                try
                {
                    Picture thisPicture = db.Pictures.Find(id);

                    ViewBag.Id = id;
                    ViewBag.Name = thisPicture.Name;
                    ViewBag.Artist = thisPicture.Artist;
                    ViewBag.Genre = thisPicture.Genre;
                    ViewBag.Style = thisPicture.Style;
                    ViewBag.Materials = thisPicture.Materials;
                    ViewBag.Price = thisPicture.Price;
                    ViewBag.Status = thisPicture.Status;
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
            using (var transaction = db.Database.BeginTransaction())
            {
                try
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
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                }
            }

            return View();
        }

        public ActionResult Delete(int id)
        {
            using (var transaction = db.Database.BeginTransaction())
            {
                try
                {
                    IEnumerable<Picture> pictures = db.Pictures;
                    IEnumerable<Artist> artists = db.Artists;

                    bool delete = true;
                    string artist = null;
                    int ArtistID = 0;

                    Picture DelRow = db.Pictures.Find(id);
                    artist = DelRow.Artist;

                    if (DelRow != null)
                        db.Pictures.Remove(DelRow);

                    db.SaveChanges();

                    foreach (var pic in pictures)
                    {
                        if (pic.Artist == artist)
                            delete = false;
                    }

                    foreach (var art in artists)
                    {
                        if (art.ArtistsName == artist)
                            ArtistID = art.Id;
                    }

                    if (delete)
                    {
                        Artist DelArtist = db.Artists.Find(ArtistID);
                        db.Artists.Remove(DelArtist);
                    }
                    db.SaveChanges();
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                }
            }

            AdminPictures(null);
            return View("~/Views/Admin/AdminPictures.cshtml");
        }

        public ActionResult Update(int id, string price)
        {
            Picture updated = db.Pictures.Find(id);

            using (var transaction = db.Database.BeginTransaction())
            {
                try
                {
                    if (price != null && price != "")
                    {
                        decimal decPrice = Convert.ToDecimal(price);
                        updated.Price = decPrice;
                        db.SaveChanges();
                    }

                    db.SaveChanges();
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                }
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
            using (var transaction = db.Database.BeginTransaction())
            {
                try
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

                    NewPicture.Status = "доступно";


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
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                }
            }

            AdminPictures(null);
            return View("~/Views/Admin/AdminPictures.cshtml");
        }

        public ActionResult UpdateArtist(int id, string Info, string Photo)
        {
            bool info = false;
            bool photo = false;

            using (var transaction = db.Database.BeginTransaction())
            {
                try
                {
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
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                }
            }

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
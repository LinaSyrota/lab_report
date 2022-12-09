using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using _Gallery_.Models;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace _Gallery_.Controllers
{
    public class HomeController : Controller
    {
        PictureContext db = new PictureContext();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AddRows(string price)
        {
            using (var transaction = db.Database.BeginTransaction())
            {
                try
                {
                    bool flag = false;
                    IEnumerable<Artist> artists = db.Artists;

                    var rand = new Random();

                    Picture NewPicture = new Picture();
                    Artist NewArtist = new Artist();

                    int i = 0;
                    while (i <= 10000)
                    {
                        NewPicture.Name = rand.Next(-1000, 0).ToString();
                        NewPicture.Artist = "artist1";
                        NewPicture.Genre = "genre";
                        NewPicture.Style = "style";
                        NewPicture.Materials = "materials";
                        NewPicture.Price = Convert.ToDecimal(rand.Next(1000, 100000));
                        NewPicture.Status = "доступно";
                        NewPicture.Link = "Пусто";

                        foreach (var artist in artists)
                        {
                            if (NewPicture.Artist == artist.ArtistsName)
                                flag = true;
                        }

                        if (flag == false)
                        {
                            NewArtist.ArtistsName = NewPicture.Artist;
                            NewArtist.Info = "";
                            NewArtist.Photo = "Пусто";
                            db.Artists.Add(NewArtist);
                            db.SaveChanges();
                        }

                        db.Pictures.Add(NewPicture);
                        db.SaveChanges();

                        i++;
                    }
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                }
            }

            Time(price);
            return View("~/Views/Home/Time.cshtml");
        }

        public ActionResult Time(string price)
        {
            using (var transaction = db.Database.BeginTransaction())
            {
                try
                {
                    IEnumerable<Picture> pictures = db.Pictures;
                    ViewBag.PicturesLin = pictures;
                    ViewBag.PicturesPar = pictures;

                    if (price != null && price != "")
                    {
                        decimal decPrice = Convert.ToDecimal(price);

                        // послідовно
                        Stopwatch durationLin = new Stopwatch();
                        durationLin.Start();

                        pictures = pictures.Where(x => x.Price < decPrice);
                        ViewBag.PicturesLin = pictures;

                        durationLin.Stop();
                        ViewBag.timeLin = durationLin.Elapsed;

                        // паралельно
                        Stopwatch durationPar = new Stopwatch();
                        durationPar.Start();

                        pictures = pictures.AsParallel().Where(x => x.Price < decPrice);
                        ViewBag.PicturesPar = pictures;

                        durationPar.Stop();
                        ViewBag.timePar = durationPar.Elapsed;
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
        public void Part1()
        {
            IEnumerable<Picture> pictures = db.Pictures;
            pictures = pictures.Where(x => x.Price < 2000).Where(x => x.Id <= 5);
        }

        public void Part2()
        {
            IEnumerable<Picture> pictures = db.Pictures;
            pictures = pictures.Where(x => x.Price < 2000).Where(x => x.Id > 5);
        }

        public ActionResult multithreading(string price)
        {
            // створення окремих потоків
            Stopwatch durationThread = new Stopwatch();
            durationThread.Start();

            Thread thr1 = new Thread(Part1);
            Thread thr2 = new Thread(Part2);
            thr1.Start();
            thr2.Start();

            durationThread.Stop();
            ViewBag.timeThread = durationThread.Elapsed;

            // клас Task бібліотеки TPL
            Stopwatch durationTask = new Stopwatch();
            durationTask.Start();

            Task tsk1 = new Task(Part1);
            Task tsk2 = new Task(Part2);
            tsk1.Start();
            tsk2.Start();

            durationTask.Stop();
            ViewBag.timeTask = durationTask.Elapsed;

            // клас Parallel бібліотеки TPL
            Stopwatch durationParallel = new Stopwatch();
            durationParallel.Start();

            Parallel.Invoke(Part1, Part2);

            durationParallel.Stop();
            ViewBag.timeParallel = durationParallel.Elapsed;

            Time(price);
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
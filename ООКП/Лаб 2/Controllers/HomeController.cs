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


        public ActionResult ViewPictures()
        {
            IEnumerable<Picture> pictures = db.Pictures;
            ViewBag.Pictures = pictures;

            return View();
        }


        [HttpGet]
        public ActionResult Buy(int id)
        {
            ViewBag.PictureId = id;
            return View();
        }

        [HttpPost]
        public string Buy(Purchase purchase)
        {
            purchase.Date = DateTime.Now;
            db.Purchases.Add(purchase);
            db.SaveChanges();

            return "Операція виконана успішно!";
        }
    }
}
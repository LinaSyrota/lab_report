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
            // повертаємо подання
            return View();
        }


        public ActionResult ViewPictures()
        {
            // отримуємо з БД всі об'єкти Book
            IEnumerable<Picture> pictures = db.Pictures;
            // передаємо всі об'єкти в динамічну властивість Books в ViewBag
            ViewBag.Pictures = pictures;
            // повертаємо подання
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
            // додаємо інформацію про покупку в базу даних
            db.Purchases.Add(purchase);
            // зберігаємо в БД всі зміни
            db.SaveChanges();
            return "Операція виконана успішно!";
        }
    }
}
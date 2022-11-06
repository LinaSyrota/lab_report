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

        // GET: Admin
        public ActionResult Index()
        {
            // отримуємо з БД всі об'єкти Book
            IEnumerable<Picture> pictures = db.Pictures;
            // передаємо всі об'єкти в динамічну властивість Books в ViewBag
            ViewBag.Pictures = pictures;
            // повертаємо подання
            return View();
        }
    }
}
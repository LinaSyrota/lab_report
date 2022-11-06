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
            IEnumerable<Picture> pictures = db.Pictures;
            ViewBag.Pictures = pictures;

            return View();
        }
    }
}
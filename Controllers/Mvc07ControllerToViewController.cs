using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcEgitimi.Controllers
{
    public class Mvc07ControllerToViewController : Controller
    {
        // GET: Mvc07ControllerToView
        public ActionResult Index()
        {
            ViewBag.KategoriAdi = "Bilgisayar";
            ViewData["UrunAdi"] = "Yenovo Tablet";
            TempData["UrunFiyati"] = 4990;

            return View();
        }
    }
}
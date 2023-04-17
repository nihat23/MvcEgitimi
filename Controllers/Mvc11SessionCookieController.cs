using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcEgitimi.Controllers
{
    public class Mvc11SessionCookieController : Controller
    {
        // GET: Mvc11SessionCookie
        public ActionResult Index()
        {
            if (HttpContext.Request.Cookies["kullanici"] != null)
            {
                ViewBag.Kuki = HttpContext.Request.Cookies["kullanici"].Value;
            }
            return View();
        }
        public ActionResult Sessions()
        {
            if (Session["deger"] != null)
            {
                ViewBag.SessDeger = Session["deger"].ToString();
            }
            else
            {
                ViewBag.SessDeger = "Session değeri boş";
            }
            return View();
        }
        [HttpPost]
        public ActionResult Sessions(string text)
        {
            if (Session["deger"] != null)
            {
                //Session["deger"] = null;
                Session.Remove("deger");
            }
            else
            {
                ViewBag.SessDeger = "Session değeri boş";
            }
            return View();
        }
        [HttpPost]
        public ActionResult Index(string text)
        {
            //Session a değer atama
            Session["deger"] = text;
            //Session.Add("deger", text);

            return View();
        }
        [HttpPost]
        public ActionResult CookieOlustur(string kuki)
        {
            HttpCookie cookie = new HttpCookie("kullanici", "kuki");//Cookie oluşturma
            HttpContext.Response.Cookies.Add(cookie); //Oluşan cookie yi cihaza atma
            ViewBag.Kullanici = HttpContext.Request.Cookies["kullanici"].Value;//Oluşan cookie yi cihazdan okuma
            return RedirectToAction("Index");
        }
        [HttpPost]
        public ActionResult CookieSil()
        {
            if (HttpContext.Request.Cookies["kullanici"] != null)
            {
                HttpContext.Response.Cookies["kullanici"].Expires = DateTime.Now.AddSeconds(-3);
                ViewBag.Kullanici = "Kuki silindi";
            }

            return RedirectToAction("Index"); //View("Index");
        }
    }
}
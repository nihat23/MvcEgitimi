using MvcEgitimi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcEgitimi.Controllers
{
    public class Mvc10ModelValidationController : Controller
    {
        // GET: Mvc10ModelValidation
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult YeniUye()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniUye(Uye uye)
        {
            if (ModelState.IsValid)
            {
                ViewBag.UyeBilgi = $"Üye Adı : {uye.Ad} <hr> Soyadı : {uye.Soyad} <hr> Email : {uye.Email}";
            }
            return View();
        }
        public ActionResult UyeDuzenle(int id)
        {
            Uye uye = new Uye()
            {
                Ad = "Murat",
                Soyad = "Yılmaz",
                Email = "murat@yilmaz.co"
            };
            return View(uye);
        }
        [HttpPost]
        public ActionResult UyeDuzenle(Uye uye)
        {

            return View(uye);
        }
        public ActionResult UyeListesi()
        {
            var uyeListesi = new List<Uye>()
            {
                new Uye(){
                Ad = "Murat",
                Soyad = "Yılmaz",
                Email = "murat@yilmaz.co"
                },
                new Uye(){
                Ad = "Ali",
                Soyad = "Veli",
                Email = "murat@yilmaz.co"
                }
            };
            return View(uyeListesi);
        }

        public ActionResult UyeSil(int id)
        {
            Uye uye = new Uye()
            {
                Id = id,
                Ad = "Murat",
                Soyad = "Yılmaz",
                Email = "murat@yilmaz.co"
            };
            //burada kayıt silinir
            return View(uye);
        }

    }
}
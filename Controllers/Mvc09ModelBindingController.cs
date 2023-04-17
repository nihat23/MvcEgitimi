using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcEgitimi.Models;

namespace MvcEgitimi.Controllers
{
    public class Mvc09ModelBindingController : Controller
    {
        // GET: Mvc09ModelBinding
        public ActionResult Index()
        {
            var sayfaModeli = new AnasayfaViewModel
            {
                AdresNesnesi = new Adres
                {
                    Sehir = "Erzurum",
                    Ilce = "Narman",
                    AcikAdres = "Pınar mah."
                },
                KullaniciNesnesi = new Kullanici
                {
                    Ad = "Murat",
                    Soyad = "Yılmaz",
                    Email = "murat@yilmaz.co"
                }
            };
            return View(sayfaModeli);
        }
        public ActionResult Kullanici()
        {
            Kullanici kullanici = new Kullanici()
            {
                Ad = "Murat",
                Soyad = "Yılmaz",
                Email = "murat@yilmaz.co"
            };
            return View(kullanici);
        }
        [HttpPost]
        public ActionResult Kullanici(Kullanici kullanici)
        {
            ViewBag.Mesaj = "Kullanıcı adı, şifre : " + kullanici.KullaniciAdi + " " + kullanici.Sifre;
            ViewData["Vdata"] = "Kullanıcı adı soyadı " + kullanici.Ad + " " + kullanici.Soyad;
            TempData["Tdata"] = "Email " + kullanici.Email;
            return View();
        }
        public ActionResult Adres()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Adres(Adres adres)
        {
            ViewBag.Mesaj = "Şehir : " + adres.Sehir;
            ViewData["Vdata"] = "İlçe : " + adres.Ilce;
            TempData["Tdata"] = "Açık adres : " + adres.AcikAdres;
            return View();
        }
    }
}
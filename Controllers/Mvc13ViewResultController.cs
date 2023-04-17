using MvcEgitimi.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace MvcEgitimi.Controllers
{
    public class Mvc13ViewResultController : Controller
    {
        // GET: Mvc13ViewResult
        public ActionResult Index()
        {
            return View();
        }
        public RedirectResult Index2()
        {
            //return Redirect("/Home/Index");
            return Redirect("https://www.google.com.tr/");
        }
        public RedirectToRouteResult Index3()
        {
            return RedirectToRoute("Default", new { controller = "Home", action = "Index", id = 5 });
        }
        public PartialViewResult KategorileriPartillaGetir()
        {
            return PartialView("_KategorilerPartial");
        }
        public PartialViewResult KategorileriModelPartillaGetir()
        {
            List<string> kategoriler = new List<string>()
            {
                    "Bilgisayar",
                    "Monitörler",
                    "Klavyeler",
                    "Mouselar",
                    "Laptoplar",
                    "Aksesuarlar"
            };
            return PartialView("_KategorilerPartial2", kategoriler);
        }
        public FileResult PdfDosyaIndir()
        {
            string dosyaYolu = Server.MapPath("/MvcNedir.pdf");

            return new FilePathResult(dosyaYolu, "application/pdf");
        }
        public FileStreamResult MetinDosyasiIndir()
        {
            string metin = "FileStreamResult ile MetinDosyasiIndir";

            MemoryStream memory = new MemoryStream();

            byte[] bytes = Encoding.UTF8.GetBytes(metin);

            memory.Write(bytes, 0, bytes.Length);
            memory.Position = 0;

            FileStreamResult result = new FileStreamResult(memory, "text/plain");
            result.FileDownloadName = "deneme.txt";

            return result;
        }

        public JavaScriptResult JsResult()
        {
            string js = "alert('JsResult çalıştı!')";

            return JavaScript(js);
        }
        public JavaScriptResult JsButtonClick()
        {
            string js = "function button_click(){ alert('JsButtonClick çalıştı!') }";

            return JavaScript(js);
        }
        public JsonResult Index4()
        {
            Kullanici kullanici = new Kullanici()
            {
                Id = 9,
                Ad = "Murat",
                Soyad = "Yılmaz",
                KullaniciAdi = "admin",
                Sifre = "2534"
            };

            /*
             * Örnek Json Çıktısı
                {
                    "Id":9, 
                    "Ad":"Murat", 
                    "Soyad":"Yılmaz", 
                    "Email":null, 
                    "KullaniciAdi":"admin",
                    "Sifre":"2534"
                }
                Örnek Xml Çıktısı
                <kullanici>
                    <Id>9</Id>
                    <Ad>Murat</Ad>
                    <Soyad>Yılmaz</Soyad>
                    <Email>null</Email>
                </kullanici>
            */

            return Json(kullanici, JsonRequestBehavior.AllowGet);
        }

        public ContentResult XmlContentResult()
        {
            var xml = @"
                <kullanicilar>
                    <kullanici>
                        <Id>9</Id>
                        <Ad>Murat</Ad>
                        <Soyad>Yılmaz</Soyad>
                        <Email>null</Email>
                    </kullanici>
                    <kullanici>
                        <Id>10</Id>
                        <Ad>Mesut</Ad>
                        <Soyad>Ilıca</Soyad>
                        <Email>null</Email>
                    </kullanici>
                </kullanicilar>";

            return Content(xml, "application/xml");
        }

    }
}
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcEgitimi.Controllers
{
    public class Mvc12FileUploadController : Controller
    {
        // GET: Mvc12FileUpload
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(HttpPostedFileBase dosya)
        {
            if (dosya != null && dosya.ContentLength > 0)
            {
                var extensions = Path.GetExtension(dosya.FileName);

                if (extensions == ".jpg" || extensions == ".png")
                {
                    //1. yöntem rasgele resim adı oluşturarak yükleme
                    /*var folder = Server.MapPath("/Images");
                    var randomFileName = Path.GetRandomFileName();
                    var fileName = Path.ChangeExtension(randomFileName, ".jpg");

                    var path = Path.Combine(folder, fileName);*/

                    //2. yöntem yüklenen resim adı ile yükleme
                    var fileName = Path.GetFileName(dosya.FileName);
                    var path = Path.Combine(Server.MapPath("/Images"), fileName);

                    dosya.SaveAs(path);
                    ViewBag.ResimAdi = fileName;
                }
                else ViewData["message"] = "Sadece .jpg ve .png resimleri yükleyebilirsiniz!";
            }
            return View();
        }
    }
}
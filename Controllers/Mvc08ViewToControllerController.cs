using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcEgitimi.Controllers
{
    public class Mvc08ViewToControllerController : Controller
    {
        // GET: Mvc08ViewToController
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(string text1, bool cbOnay, string liste)
        {
            /*var txtbox = Request.Form["text1"];
            var ddl = Request.Form["liste"];
            var chb = Request.Form.GetValues("cbOnay")[0];

            ViewBag.Mesaj = "textbox değeri " + txtbox;
            ViewData["Vdata"] = "ddl den gelen değer " + ddl;
            TempData["Tdata"] = "cbOnay ın seçili değeri " + chb;
            */
            ViewBag.Mesaj = "textbox değeri " + text1;
            ViewData["Vdata"] = "ddl den gelen değer " + liste;
            TempData["Tdata"] = "cbOnay ın seçili değeri " + cbOnay;

            return View();
        }
    }
}
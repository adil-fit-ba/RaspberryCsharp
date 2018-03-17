using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FIT_IoT.Server.Web.Areas.WebArea.Helper;
using FIT_IoT.Server.Web.Areas.WebArea.ViewModels;
using FIT_IoT.Server.Web.EF.EntityModel;

namespace FIT_IoT.Server.Web.Areas.WebArea.Controllers
{
    public class StanjeController : BaseWebController
    {
        // GET: WebArea/Stanje
        public ActionResult Index()
        {
            return View(new StanjeIndexVM
            {
                Rows = _db.Komanda.OrderByDescending(x=>x.Id).Take(50)
            });
        }

        public ActionResult Obrisi(int komandaid)
        {
            Komanda x = _db.Komanda.Find(komandaid);

            if (x == null)
            {
                ViewData["Poruka"] = "Greška, nije moguće obrisati";
                return RedirectToAction("Index");
            }
            _db.Komanda.Remove(x);
            _db.SaveChanges();
            ViewData["Poruka"] = "Obrisano";
            return RedirectToAction("Index");
        }
    }
}
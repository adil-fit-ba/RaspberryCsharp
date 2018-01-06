using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FIT_IoT.Server.Shared.EntityModel;
using FIT_IoT.SharedAll;

namespace WebApplication1.Controllers
{
    public class KomandaController : Controller
    {
        // GET: Podaci
        public ActionResult Get()
        {
            MojContext db = new MojContext();

            KomandaGetVM komanda = db.komanda
                .Where(x => !x.JelIzvrsena)
                .OrderBy(x => x.Id)
                .Select(x=>new KomandaGetVM
                {
                    Id = x.Id,
                    VrstaKomande = x.VrstaKomande,
                })
                .FirstOrDefault();


            return Json(komanda, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Index() {
            List<SelectListItem> model = new List<SelectListItem>();

            for (int i = 0; i < VrstaKomandeStrings.VrsteKomande.Length; i++) {
                model.Add(new SelectListItem { Value = i.ToString(), Text = VrstaKomandeStrings.VrsteKomande[i] });
            }

            return View(model);
        }

        [HttpPost]
        public ActionResult Index(int vrstaKomande)
        {
            try
            {
                MojContext db = new MojContext();

                Komanda komanda = new Komanda
                {
                    JelIzvrsena = false,
                    DatumEvidentiranja = DateTime.Now,
                    VrstaKomande = (VrstaKomande)vrstaKomande,
                };

                db.komanda.Add(komanda);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                return Json(new { success = false });
            }

            return RedirectToAction("Index");
        }


        public ActionResult IzvrsiKomandu(int id) {
            try
            {
                MojContext db = new MojContext();

                Komanda komanda = db.komanda.Find(id);

                komanda.JelIzvrsena = true;
                komanda.DatumIzvrsenja = DateTime.Now;

                db.SaveChanges();
            }
            catch (Exception ex) {
                return Json(new { success = false }, JsonRequestBehavior.AllowGet);
            }

            return Json(new { success = true }, JsonRequestBehavior.AllowGet);
        } 
    }
}
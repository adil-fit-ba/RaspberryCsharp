using System;
using System.Linq;
using System.Web.Mvc;
using FIT_IoT.Server.Web.Areas.WebArea.Helper;
using FIT_IoT.Server.Web.Areas.WebArea.ViewModels;
using FIT_IoT.Server.Web.EF.EntityModel;
using FIT_IoT.SharedAll.Enums;
using FIT_IoT.SharedAll.Helper;
using FIT_IoT.SharedAll.ViewModels;

namespace FIT_IoT.Server.Web.Areas.WebArea.Controllers
{
    public class KomandaController : BaseWebController
    {

        public ActionResult Index() {

            KomandaIndexVM model = new KomandaIndexVM
            {
                Rows = Enum.GetValues(typeof(VrstaKomande))
                    .Cast<VrstaKomande>()
                    .Select(n => new KomandaIndexVM.Row() {KomandaValue = n, KomandaText = n.MyDescription()}).ToList()
            };
            return View(model);
        }

        [HttpPost]
        public ActionResult Dodaj(VrstaKomande KomandaValue)
        {
            Komanda komanda = new Komanda
            {
                DatumEvidentiranja = DateTime.Now,
                VrstaKomande = KomandaValue,
            };

            _db.Komanda.Add(komanda);
            _db.SaveChanges();

            return RedirectToAction("Index", "Stanje", new {Area="WebArea"});
        }


       
    }
}
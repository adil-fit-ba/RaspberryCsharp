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
    }
}
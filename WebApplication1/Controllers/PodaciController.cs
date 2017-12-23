using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class PodaciController : Controller
    {
        // GET: Podaci
        public ActionResult Index()
        {
            MojContext db = new MojContext();

            Komanda komanda = db.komanda
                .Where(x => !x.JelIzvrsena)
                .OrderBy(x => x.Id)
                .FirstOrDefault();


            return Json(komanda);
        }
    }
}
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
    public class StateController : BaseWebController
    {
        public ActionResult Index()
        {
            return View(new StateIndexVM
            {
                Rows = _db.Command.OrderByDescending(x=>x.Id).Take(50)
            });
        }

        public ActionResult Delete(int commandId)
        {
            Command x = _db.Command.Find(commandId);

            if (x == null)
            {
                ViewData["Poruka"] = "Greška, nije moguće obrisati";
                return RedirectToAction("Index");
            }
            _db.Command.Remove(x);
            _db.SaveChanges();
            ViewData["Poruka"] = "Obrisano";
            return RedirectToAction("Index");
        }
    }
}
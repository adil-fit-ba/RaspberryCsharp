using System;
using System.Linq;
using System.Web.Mvc;
using FIT_IoT.Core.Helper;
using FIT_IoT.RPI.Core.ViewModels.Enums;
using FIT_IoT.Server.Web.Areas.WebArea.Helper;
using FIT_IoT.Server.Web.Areas.WebArea.ViewModels;
using FIT_IoT.Server.Web.EF.EntityModel;
using FIT_IoT.SharedAll.ViewModels;

namespace FIT_IoT.Server.Web.Areas.WebArea.Controllers
{
    public class MeasurementController : BaseWebController
    {

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult IndexAjax()
        {
            var d = DateTime.Now.AddSeconds(-15);
            var model = new MeasurementIndexVM()
            {
                Rows = _db.SensorMeasurement.OrderByDescending(w => w.id).Where(s => s.Date > d).Take(1).Select(s => new MeasurementIndexVM.Row
                {
                    Value = s.Vrijednost,
                    SensorId = s.SensorId,
                    SensorType = s.SensorType,
                    Date = s.Date
                }).SingleOrDefault(),
                LastFlow = DateTime.Now - _db.SensorMeasurement.OrderByDescending(w => w.id).Where(w => w.Vrijednost > 100).Select(s => s.Date).FirstOrDefault()
            };
            return PartialView("_Index", model);
        }
    }
}
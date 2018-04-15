
using System;
using System.Linq;
using System.Web.Http;
using FIT_IoT.Android.Core.ViewModels;
using FIT_IoT.Core.Helper;
using FIT_IoT.Server.Web.Areas.ApiArea.Helper;
using FIT_IoT.Server.Web.EF.EntityModel;

namespace FIT_IoT.Server.Web.Areas.ApiArea.Controllers
{
    public class AndroidMeasurementController : BaseApiController
    {
        [HttpGet]
        [Route(MeasurementVM.Action_GetLast)]
        public ApiResult<MeasurementVM> GetOne()
        {

            var model = new MeasurementVM()
            {
                Rows = _db.SensorMeasurement.OrderByDescending(w => w.id).Select(s => new MeasurementVM.Row
                {
                    Value = s.Vrijednost,
                    SensorId = s.SensorId,
                    SensorType = s.SensorType.ToString(),
                    Time = s.Date
                }).Take(5).ToList().ToList()
            };

            return ApiResult<MeasurementVM>.OK(model);
        }


       
    }
}
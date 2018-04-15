using FIT_IoT.Server.Web.Areas.ApiArea.Helper;
using FIT_IoT.SharedAll.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;
using System.Web.Http;
using FIT_IoT.Core.Enums;
using FIT_IoT.Core.Helper;
using FIT_IoT.RPI.Core.ViewModels;
using FIT_IoT.Server.Web.EF.EntityModel;

namespace FIT_IoT.Server.Web.Areas.ApiArea.Controllers
{
    public class PiMeasurementController : BaseApiController
    {

        [HttpGet]
        [Route(MeasurementVM.Action_MeasurementSave)]
        public ApiResult<string> Save(int Value,  string SensorId, SensorType? sensorType)
        {
            SensorMeasurement obj = new SensorMeasurement {
                Vrijednost = Value,
                Date = DateTime.Now,
                SensorId = SensorId,
                SensorType = sensorType
            };

            _db.SensorMeasurement.Add(obj);
            _db.SaveChanges();

            return ApiResult<string>.OK(null);
        }
        [HttpGet]

        public ApiResult<int> Test1()
        {
            

            return ApiResult<int>.OK(0);
        }
        [HttpGet]
        public ApiResult<int> Test2(int a)
        {


            return ApiResult<int>.OK(a);
        }
    }
}
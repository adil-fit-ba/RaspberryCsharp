using FIT_IoT.Server.Web.Areas.ApiArea.Helper;
using FIT_IoT.SharedAll.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FIT_IoT.Core.Helper;
using FIT_IoT.RPI.Core.ViewModels;
using FIT_IoT.Server.Web.EF.EntityModel;

namespace FIT_IoT.Server.Web.Areas.ApiArea.Controllers
{
    public class RpiTemperatureController : BaseApiController
    {
        // GET: ApiArea/RPITemperature
        public ApiResult<KomandaGetVM> Get()
        {
            return ApiResult<KomandaGetVM>.OK(null);
        }

        public ApiResult<KomandaGetVM> Update(double trenutnaVrijednost)
        {
                Temperatura obj = new Temperatura {
                    Vrijednost = trenutnaVrijednost,
                    DatumIzvrsenja = DateTime.Now
                };

            _db.Temperatura.Add(obj);
            _db.SaveChanges();

            return ApiResult<KomandaGetVM>.OK(null);
        }
    }
}
using FIT_IoT.Server.Shared.EntityModel;
using FIT_IoT.Server.Web.Areas.ApiArea.Helper;
using FIT_IoT.SharedAll.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FIT_IoT.Server.Web.Areas.ApiArea.Controllers
{
    public class RPITemperatureController : BaseApiController
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
            try
            {

                _db.Temperatura.Add(obj);
                _db.SaveChanges();
            }
            catch (Exception ex)
            {

            }

            return ApiResult<KomandaGetVM>.OK(null);
        }
    }
}
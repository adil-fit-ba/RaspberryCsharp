using System;
using System.Linq;
using System.Web.Http;
using FIT_IoT.Android.Core.ViewModels;
using FIT_IoT.Core.Helper;
using FIT_IoT.RPI.Core.ViewModels.Enums;
using FIT_IoT.Server.Web.Areas.ApiArea.Helper;
using FIT_IoT.Server.Web.Areas.WebArea.ViewModels;
using FIT_IoT.Server.Web.EF.EntityModel;
using FIT_IoT.SharedAll.ViewModels;

namespace FIT_IoT.Server.Web.Areas.ApiArea.Controllers
{
    public class AndroidKomandaController : BaseApiController
    {
        [HttpGet]
        public ApiResult<KomandaNewVM> GetAll()
        {
            //ako ima pravo pristupa
            KomandaNewVM model = new KomandaNewVM
            {
                Rows = Enum.GetValues(typeof(VrstaKomande))
                    .Cast<VrstaKomande>()
                    .Select(n => new KomandaNewVM.Row() { KomandaValue = n, KomandaText = n.MyDescription() }).ToList()
            };

            return ApiResult<KomandaNewVM>.OK(model);
        }


        [HttpGet]
        public ApiResult<string> Dodaj(VrstaKomande KomandaValue)
        {

            Komanda komanda = new Komanda
            {
                DatumEvidentiranja = DateTime.Now,
                VrstaKomande = KomandaValue,
            };

            _db.Komanda.Add(komanda);
            _db.SaveChanges();

            return ApiResult<string>.OK(null);
        }
    }
}
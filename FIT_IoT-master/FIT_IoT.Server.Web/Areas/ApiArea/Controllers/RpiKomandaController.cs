using System;
using System.Linq;
using System.Web.Http;
using FIT_IoT.Core.Helper;
using FIT_IoT.RPI.Core.ViewModels;
using FIT_IoT.Server.Web.Areas.ApiArea.Helper;
using FIT_IoT.Server.Web.EF.EntityModel;

namespace FIT_IoT.Server.Web.Areas.ApiArea.Controllers
{
    public class RpiKomandaController : BaseApiController
    {
        [HttpGet]
        public ApiResult<KomandaGetVM> GetOne()
        {
            //ako ima pravo pristupa
            if (false)
                return ApiResult<KomandaGetVM>.Error(1, "Nema pravo pristupa");

            Komanda k = _db.Komanda
                .Where(x => !x.DatumPreuzimanja.HasValue)
                .OrderBy(x => x.Id)
                .FirstOrDefault();

            if(k==null)
                return ApiResult<KomandaGetVM>.OK(null);

            k.DatumPreuzimanja = DateTime.Now;
            _db.SaveChanges();

            KomandaGetVM model = new KomandaGetVM
            {
                Id = k.Id,
                VrstaKomande =k.VrstaKomande
            };

            return ApiResult<KomandaGetVM>.OK(model);
        }


        [HttpGet]
        public ApiResult<string> IzvrsenaKomanda(int id)
        {

            Komanda komanda = _db.Komanda.Find(id);

            if (komanda == null)
                return ApiResult<string>.Error(1, "Pogrešan ID");

            komanda.DatumIzvrsenja = DateTime.Now;

            _db.SaveChanges();

            return ApiResult<string>.OK(null);
        }
    }
}
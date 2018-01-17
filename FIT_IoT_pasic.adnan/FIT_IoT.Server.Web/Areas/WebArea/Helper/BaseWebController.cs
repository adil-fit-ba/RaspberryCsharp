using System;
using System.Collections.Specialized;
using System.Linq;
using System.Web.Mvc;
using FIT_IoT.Server.Web.EF;
using FIT_IoT.Server.Web.EF.EntityModel;

namespace FIT_IoT.Server.Web.Areas.WebArea.Helper
{
    public class BaseWebController: Controller, IDisposable
    {
         protected MojContext _db = new MojContext();
        protected static string GetAuthToken()
        {
            string authToken = null;
            NameValueCollection headers = System.Web.HttpContext.Current.Request.Headers;
            if (headers["authToken"] != null)
            {
                authToken = headers["authToken"];
            }
            return authToken;
        }

        protected Korisnik GetKorisnikOfAuthToken()
        {
            return GetKorisnikOfAuthToken(_db);
        }

        public static Korisnik GetKorisnikOfAuthToken(MojContext _db)
        {
            string t = GetAuthToken();
            AuthentificationToken aAutentifikacijaToken = _db.AuthentificationToken.SingleOrDefault(x => x.authToken == t && !x.IsDeleted);
            return aAutentifikacijaToken?.Korisnik;
        }


        public new void Dispose()
        {
            _db?.Dispose();
        }
    }
}
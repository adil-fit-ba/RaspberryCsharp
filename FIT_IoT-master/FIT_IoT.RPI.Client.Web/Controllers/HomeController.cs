using System.Web.Mvc;
using FIT_IoT.RPI.Client.Komande;

namespace FIT_IoT.RPI.Client.Web.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public string Index()
        {
            return "Index - ok";
        }
        public string Pokreni()
        {
            GlavniProgram.Run();
            return "Pokreni - ok";
        }
    }
}
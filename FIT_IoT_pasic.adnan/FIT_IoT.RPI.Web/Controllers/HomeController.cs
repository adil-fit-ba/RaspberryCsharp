using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FIT_IoT.RPI.Shared.Komande;

namespace FIT_IoT.RPI.Web.Controllers
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
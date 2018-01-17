using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;
using System.Web.Http;
using FIT_IoT.RPI.Shared.Komande;

namespace FIT_IoT.RPI.Web
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            System.Console.WriteLine("Web aplikacija thread starting");
         
           Thread t = new Thread(
               () =>{
                   GlavniProgram.Run();
               }
               );
            t.Start();
            System.Console.WriteLine("Web aplikacija thread started");
        }
    }
}
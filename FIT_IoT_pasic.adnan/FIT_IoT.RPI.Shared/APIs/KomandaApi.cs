using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using FIT_IoT.SharedAll;
using FIT_IoT.SharedAll.Helper;
using FIT_IoT.SharedAll.ViewModels;

namespace FIT_IoT.RPI.Shared.APIs
{
    public class KomandaApi
    {
       
        public static readonly string ControllerName = "RpiKomanda";

        public static ApiResult<KomandaGetVM> GetOne()
        {
            return MyApiRequests.Get<KomandaGetVM>(ControllerName, "GetOne");
            
        }

        public static void IzvrsenaKomanda(int valueId)
        {
             MyApiRequests.Get<KomandaGetVM>(ControllerName, "IzvrsenaKomanda", new MyApiRequests.P("id", valueId));
        }
    }

   
}

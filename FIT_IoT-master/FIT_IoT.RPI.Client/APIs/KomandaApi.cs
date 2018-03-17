using FIT_IoT.Client.Helper;
using FIT_IoT.Core.Helper;
using FIT_IoT.RPI.Core.ViewModels;

namespace FIT_IoT.RPI.Client.APIs
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

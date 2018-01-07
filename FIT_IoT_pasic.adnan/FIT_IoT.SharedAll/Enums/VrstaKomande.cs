using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FIT_IoT.Server.Shared.EntityModel
{
    public enum VrstaKomande
    {
        SVJETLO_UPALI = 0,
        SVJETLO_UGASI,
        OTVORI_VRATA,
    }

    public class VrstaKomandeStrings {
        public static string[] VrsteKomande = new string[] {
           "Upali svjetlo",
           "Ugasi svjetlo",
           "Otvori vrata"
        };
    }
}

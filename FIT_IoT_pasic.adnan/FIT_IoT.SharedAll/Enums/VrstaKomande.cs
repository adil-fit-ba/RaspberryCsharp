using System.ComponentModel;

namespace FIT_IoT.SharedAll.Enums
{
    public enum VrstaKomande
    {
        [Description("Upali svjetlo")]
        SVJETLO_UPALI = 0,

        [Description("Ugasi svjetlo")]
        SVJETLO_UGASI,

        [Description("Otvori vrata")]
        OTVORI_VRATA,
    }

}

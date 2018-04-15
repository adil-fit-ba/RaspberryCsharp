using System.ComponentModel;

namespace FIT_IoT.RPI.Core.ViewModels.Enums
{
    public enum CommandType
    {
        [Description("Upali svjetlo")]
        LIGHT_ON = 0,

        [Description("Ugasi svjetlo")]
        LIGHT_OF,

        [Description("Otvori vrata")]
        DOOR_OPEN,
    }

}

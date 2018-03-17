using System.Collections.Generic;
using FIT_IoT.RPI.Core.ViewModels.Enums;

namespace FIT_IoT.Android.Core.ViewModels
{
    public class KomandaNewVM
    {
        public IList<Row> Rows { get; set; }


        public class Row
        {
            public VrstaKomande KomandaValue { get; set; }
            public string KomandaText { get; set; }
        }
    }
}

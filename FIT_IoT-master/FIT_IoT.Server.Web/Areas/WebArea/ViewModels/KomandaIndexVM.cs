using System.Collections.Generic;
using FIT_IoT.RPI.Core.ViewModels.Enums;

namespace FIT_IoT.SharedAll.ViewModels
{
    public class KomandaIndexVM
    {
        public IList<Row> Rows { get; set; }

        public VrstaKomande VrstaKomandeValue { get; set; }

        public class Row
        {
            public VrstaKomande KomandaValue { get; set; }
            public string KomandaText { get; set; }
        }
    }
}
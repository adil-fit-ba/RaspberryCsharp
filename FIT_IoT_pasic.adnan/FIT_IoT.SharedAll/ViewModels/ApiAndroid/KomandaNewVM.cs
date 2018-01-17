using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FIT_IoT.SharedAll.Enums;

namespace FIT_IoT.SharedAll.ViewModels.ApiAndroid
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

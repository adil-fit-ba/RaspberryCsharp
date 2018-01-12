using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FIT_IoT.SharedAll.Enums;

namespace FIT_IoT.Server.Web.Areas.WebArea.ViewModels
{
    public class KomandaIndexVM
    {
        public IEnumerable<Row> Rows { get; set; }

        public VrstaKomande VrstaKomandeValue { get; set; }

        public class Row
        {
            public VrstaKomande KomandaValue { get; set; }
            public string KomandaText { get; set; }
        }
    }
}
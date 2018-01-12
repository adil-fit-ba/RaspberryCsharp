using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FIT_IoT.Server.Shared.EntityModel;

namespace FIT_IoT.Server.Web.Areas.WebArea.ViewModels
{
    public class StanjeIndexVM
    {
        public IEnumerable<Komanda> Rows { get; set; }
    }
}
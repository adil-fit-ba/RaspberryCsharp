using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FIT_IoT.Server.Web.EF.EntityModel;

namespace FIT_IoT.Server.Web.Areas.WebArea.ViewModels
{
    public class StateIndexVM
    {
        public IEnumerable<Command> Rows { get; set; }
    }
}
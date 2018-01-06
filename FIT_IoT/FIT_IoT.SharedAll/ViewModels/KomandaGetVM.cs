using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FIT_IoT.Server.Shared.EntityModel;

namespace FIT_IoT.SharedAll
{
    public class KomandaGetVM
    {
        public int Id { get; set; }

        public VrstaKomande VrstaKomande { get; set; }
    }
}

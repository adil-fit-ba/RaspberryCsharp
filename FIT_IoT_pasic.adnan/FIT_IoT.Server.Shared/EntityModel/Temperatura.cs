using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FIT_IoT.Server.Shared.EntityModel
{
    public class Temperatura
    {
        public int id { get; set; }

        public double Vrijednost { get; set; }

        public DateTime? DatumIzvrsenja { get; set; }
    }
}

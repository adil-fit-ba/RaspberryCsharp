using System;

namespace FIT_IoT.Server.Web.EF.EntityModel
{
    public class Temperatura
    {
        public int id { get; set; }

        public double Vrijednost { get; set; }

        public DateTime? DatumIzvrsenja { get; set; }
    }
}

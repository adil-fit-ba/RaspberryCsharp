using System;

namespace FIT_IoT.Server.Shared.EntityModel
{


   

    public class Komanda
    {
        public int Id { get; set; }

        public DateTime DatumEvidentiranja { get; set; }
        public DateTime? DatumIzvrsenja { get; set; }
        public bool JelIzvrsena { get; set; }
        public VrstaKomande VrstaKomande { get; set; }
    }
}
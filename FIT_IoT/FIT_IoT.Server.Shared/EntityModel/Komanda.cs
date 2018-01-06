namespace FIT_IoT.Server.Shared.EntityModel
{


   

    public class Komanda
    {
        public int Id { get; set; }

        public bool DatumEvidentiranja { get; set; }
        public bool DatumIzvrsenja { get; set; }
        public bool JelIzvrsena { get; set; }
        public VrstaKomande VrstaKomande { get; set; }
    }
}
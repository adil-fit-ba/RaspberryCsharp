using System;
using System.ComponentModel.DataAnnotations.Schema;
using FIT_IoT.RPI.Core.ViewModels.Enums;

namespace FIT_IoT.Server.Web.EF.EntityModel
{


   

    public class Komanda
    {
        public int Id { get; set; }

        public DateTime DatumEvidentiranja { get; set; }
        public DateTime? DatumPreuzimanja { get; set; }
        public DateTime? DatumIzvrsenja { get; set; }
        public bool JelPreuzeta => DatumIzvrsenja.HasValue;
        public bool JelIzvrsena => DatumIzvrsenja.HasValue;
        public VrstaKomande VrstaKomande { get; set; }
        public string GreskaOpis { get; set; }

        [ForeignKey(nameof(AuthentificationToken))]
        public int? AuthentificationTokenID { get; set; }
        public AuthentificationToken AuthentificationToken { get; set; }
    }
}
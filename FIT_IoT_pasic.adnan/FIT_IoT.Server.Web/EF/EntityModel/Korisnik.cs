namespace FIT_IoT.Server.Web.EF.EntityModel
{
    public class Korisnik
    {
       
        public int Id { get; set; }

        public string KorisnickoIme { get; set; }
        public string Prezime { get; set; }
        public string Ime { get; set; }
        public string Lozinka { get; set; }
        public KorisnickaUloga Uloga { get; set; }
    }

   
}
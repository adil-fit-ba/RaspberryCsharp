using System.Data.Entity;
using FIT_IoT.Server.Shared.EntityModel;

namespace FIT_IoT.Server.Shared.EF
{
    public class MojContext:DbContext
    {
        public MojContext():base("Server=app.fit.ba,1432;Database=pasica_raspberry;Trusted_Connection=false;MultipleActiveResultSets=true;User ID=pasica_raspberry;Password=Testiranje123")
        {
            
        }
        public DbSet<Komanda> Komanda { get; set; }
        public DbSet<Temperatura> Temperatura { get; set; }
        public DbSet<AuthentificationToken> AuthentificationToken { get; set; }
    }
}
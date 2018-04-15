using System.Data.Entity;
using FIT_IoT.Server.Web.EF.EntityModel;

namespace FIT_IoT.Server.Web.EF
{
    public class MojContext:DbContext
    {
        public MojContext():base("name=CS")
        {
            
        }
        public DbSet<Command> Command { get; set; }
        public DbSet<SensorMeasurement> SensorMeasurement { get; set; }
        public DbSet<AuthentificationToken> AuthentificationToken { get; set; }
    }
}
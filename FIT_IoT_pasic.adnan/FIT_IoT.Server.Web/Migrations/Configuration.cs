using System.Data.Entity.Migrations;
using FIT_IoT.Server.Web.EF;

namespace FIT_IoT.Server.Web.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<MojContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(MojContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}

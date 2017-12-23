using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplicationSaCore
{
    public class MojContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseSqlServer("Server=app.fit.ba,1432;Database=iot2;Trusted_Connection=false;MultipleActiveResultSets=true;User ID=iot2;Password=Ghin135^");
        }

        public DbSet<Komanda> komanda { get; set; }
    }
}
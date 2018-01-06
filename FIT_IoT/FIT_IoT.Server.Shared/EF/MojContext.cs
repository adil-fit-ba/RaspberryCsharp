using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using FIT_IoT.Server.Shared.EntityModel;

namespace WebApplication1
{
    public class MojContext:DbContext
    {
        public MojContext():base("Server=app.fit.ba,1432;Database=pasica_raspberry;Trusted_Connection=false;MultipleActiveResultSets=true;User ID=pasica_raspberry;Password=Testiranje123")
        {
            
        }
        public DbSet<Komanda> komanda { get; set; }
    }
}
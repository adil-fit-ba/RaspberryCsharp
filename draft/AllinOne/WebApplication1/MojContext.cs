using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebApplication1.Models;

namespace WebApplication1
{
    public class MojContext:DbContext
    {
        public MojContext():base("Server=app.fit.ba,1432;Database=iot1;Trusted_Connection=false;MultipleActiveResultSets=true;User ID=iot1;Password=Ghin135^")
        {
            
        }
        public DbSet<Komanda> komanda { get; set; }
    }
}
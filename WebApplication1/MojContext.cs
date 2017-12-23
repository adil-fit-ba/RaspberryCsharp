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
        public MojContext():base("Server=app.fit.ba,1433;Database=RS1_online1;Trusted_Connection=false;MultipleActiveResultSets=true;User ID=nekiUser;Password=nekiPass")
        {
            
        }
        public DbSet<Komanda> komanda { get; set; }
    }
}
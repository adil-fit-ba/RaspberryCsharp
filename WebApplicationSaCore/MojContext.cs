using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1
{
    public class MojContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseSqlServer("Server=app.fit.ba,1433;Database=RS1_online1;Trusted_Connection=false;MultipleActiveResultSets=true;User ID=nekiUser;Password=nekiPass");
        }

        public DbSet<Komanda> komanda { get; set; }
    }
}
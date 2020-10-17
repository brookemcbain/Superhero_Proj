using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Superhero.Models; 

namespace Superhero.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<SuperHero> Superheroes { get; set;  }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
      
        
    }
}

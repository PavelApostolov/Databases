using EfCodeFirst.Data.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfCodeFirst.Data
{
    class SuperheroesDbContext : DbContext
    {
        public SuperheroesDbContext()
            :base("SuperHeroesDbConnection")
        {

        }

        public DbSet<Power> Powers { get; set; }
        public DbSet<Superhero> Superheroes { get; set; }
    }
}

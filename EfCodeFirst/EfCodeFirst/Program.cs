using EfCodeFirst.Data;
using EfCodeFirst.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfCodeFirst
{
    public class Program
    {
        static void Main()
        {
            var batman = new Superhero()
            {
                Name = "Batman",
                SecretIdentity = "Bruce Wayne",
                Powers = new List<Power>()
                {
                    new Power {Name = "Utility belt" }
                }
            };

            var dbContext = new SuperheroesDbContext();
            dbContext.Superheroes.Add(batman);
            dbContext.SaveChanges();
        }
    }
}

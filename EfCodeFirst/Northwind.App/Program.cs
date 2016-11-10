using NorthWind.Data;
using NorthWind.Data.Migrations;
using NorthWind.Data.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.App
{
    class Program
    {
        static void Main(string[] args)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<NorthwindDbContext, Configuration>());

            using (var context = new NorthwindDbContext())
            {

               //context.Database.CreateIfNotExists();
                var newCountry = new Country()
                {
                    Name = "Bulgaria"
                };

                context.Countries.Add(newCountry);
                context.SaveChanges();
            }

        }
    }
}

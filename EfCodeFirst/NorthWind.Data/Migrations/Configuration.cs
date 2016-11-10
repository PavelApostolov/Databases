namespace NorthWind.Data.Migrations
{
    using Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    public sealed class Configuration : DbMigrationsConfiguration<NorthWind.Data.NorthwindDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = false;
            ContextKey = "NorthWind.Data.NorthwindDbContext";
        }

        protected override void Seed(NorthWind.Data.NorthwindDbContext context)
        {
            var alb = context.Countries.FirstOrDefault(c => c.Name == "Albania");
            var city = new City()
            {
                Name = "Tirana",
                CountryId = 1
                //Country = alb
            };
            context.Cities.AddOrUpdate(a => a.Name, city);
        }
    }
}

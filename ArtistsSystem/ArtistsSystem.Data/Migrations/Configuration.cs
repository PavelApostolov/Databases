namespace ArtistsSystem.Data.Migrations
{
    using Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    public sealed class Configuration : DbMigrationsConfiguration<ArtistsDbContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = false;
            this.ContextKey = "ArtistsSystem.Data.ArtistsDbContext";
        }

        protected override void Seed(ArtistsDbContext context)
        {
            context.Artists.AddOrUpdate(a => a.Name, 
                new Artist
            {
                Name = "Seeded artist"
            });
        }
    }
}

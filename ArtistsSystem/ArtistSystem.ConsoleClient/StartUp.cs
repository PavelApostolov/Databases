using ArtistsSystem.Data;
using ArtistsSystem.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArtistsSystem.Data.Migrations;

namespace ArtistSystem.ConsoleClient
{
    public class StartUp
    {
        public static void Main()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<ArtistsDbContext, Configuration>());

            var db = new ArtistsDbContext();
            var artist = new Artist
            {
                Name = "Some random artist",
                Gender = GenderType.Female
            };
            db.Artists.Add(artist);
            db.SaveChanges();
        }
    }
}

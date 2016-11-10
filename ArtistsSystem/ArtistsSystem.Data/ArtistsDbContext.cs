using ArtistsSystem.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtistsSystem.Data
{
    public class ArtistsDbContext : DbContext
    {
        public ArtistsDbContext() : base("ArtistsDatabase")
        {

        }

        public virtual IDbSet<Album> Albums { get; set; }
        public virtual IDbSet<Artist> Artists { get; set; }
        public virtual IDbSet<Song> Songs { get; set; }
        public virtual IDbSet<Image> Images { get; set; }
    }
}

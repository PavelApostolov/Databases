using NorthWind.Data.Migrations;
using NorthWind.Data.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthWind.Data
{
    public class NorthwindDbContext : DbContext
    {
        public NorthwindDbContext() : base("NorthwindDb")
        {
            
        }

        public virtual IDbSet<Teacher> Teachers { get; set; }
        public virtual IDbSet<City> Cities { get; set; }
        public virtual IDbSet<Country> Countries { get; set; }
    }
}

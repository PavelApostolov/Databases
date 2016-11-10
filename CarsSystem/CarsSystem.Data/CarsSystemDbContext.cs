using CarsSystem.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarsSystem.Data
{
    public class CarsSystemDbContext : DbContext
    {
        public CarsSystemDbContext()
            :base("CarsSystem")
        {

        }

        public virtual IDbSet<Car> Cars { get; set; }
        public virtual IDbSet<Dealer> Dealers { get; set; }
        public virtual IDbSet<Manufacturer> Manufacturers { get; set; }
        public virtual IDbSet<City> Cities { get; set; }
    }
}

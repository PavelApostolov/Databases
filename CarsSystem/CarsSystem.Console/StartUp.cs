using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using CarsSystem.Data;
using CarsSystem.Data.Migrations;

namespace CarsSystem.Console
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<CarsSystemDbContext, Configuration>());

            JsonCarsImporter.Import();
            
        }
    }
}

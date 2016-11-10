using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToysStore.Data;

namespace ToysStore.SampleDataGenerator
{
    class Program
    {
        static void Main()
        {
            var random = RandomDataGenerator.Instance;
            var db = new ToysStoreEntities();
            

            var listOfGenerators = new List<IDataGenerator>
            {
                new CategoryDataGenerator(random, db, 100),
                new ManufacturerDataGenerator(random, db, 50),
                new AgeRangeDataGenerator(random, db, 100),
                new ToyDataGenerator(random, db, 20000)
            };

            foreach (var generator in listOfGenerators)
            {
                generator.Generate();
                db.SaveChanges();
            }

            db.Configuration.AutoDetectChangesEnabled = true;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToysStore.Data;

namespace ToysStore.SampleDataGenerator
{
    public class ManufacturerDataGenerator : DataGenerator, IDataGenerator
    {
        public ManufacturerDataGenerator(IRandomDataGenerator randomDataGenerator, ToysStoreEntities toyStoreEntities, int countOfGeneratedObjects)
            : base (randomDataGenerator, toyStoreEntities, countOfGeneratedObjects)
        {

        }

        public override void Generate()
        {
            var manufacturersToBeAdded = new HashSet<string>();

            while (manufacturersToBeAdded.Count != this.Count)
            {
                manufacturersToBeAdded.Add(this.Random.GetRandomStringWithRandomLength(5, 50));
            }

            int index = 0;
            Console.Write("Adding Manufacturers");
            foreach (var manufacturerName in manufacturersToBeAdded)
            {
                var manufacturer = new Manufacturer
                {
                    Name = manufacturerName,
                    Country = this.Random.GetRandomStringWithRandomLength(2, 50)

                };

                

                if (index % 100 == 0)
                {
                    Console.Write(".");
                    this.Database.SaveChanges();
                }

                this.Database.Manufacturers.Add(manufacturer);
                index++;
            }
            Console.WriteLine("Manufacturers added");
        }

    }
}

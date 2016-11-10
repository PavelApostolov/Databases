using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToysStore.Data;

namespace ToysStore.SampleDataGenerator
{
    public class AgeRangeDataGenerator : DataGenerator, IDataGenerator
    {
        public AgeRangeDataGenerator(IRandomDataGenerator randomDataGenerator, ToysStoreEntities toyStoreEntities, int countOfGeneratedObjects) 
            : base(randomDataGenerator, toyStoreEntities, countOfGeneratedObjects)
        {
        }

        public override void Generate()
        {
            Console.WriteLine("Adding age ranges");
            int count = 0;

            for (int i = 0; i < this.Count / 5; i++)
            {
                for (int j = i + 1; j <= i + 5; j++)
                {
                    var ageRange = new AgeRanx
                    {
                        MinimumAge = i,
                        MaximumAge = j
                    };

                    this.Database.AgeRanges.Add(ageRange);

                    count++;

                    if (count % 100 == 0)
                    {
                        Console.Write(".");
                        this.Database.SaveChanges();
                    }

                    if (count == this.Count)
                    {
                        Console.WriteLine("Age ranges added");
                        return;
                    }
                }
            }
        }
    }
}

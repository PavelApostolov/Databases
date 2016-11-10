using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanySampleDataImporter.Importer
{
    class Program
    {
        static void Main()
        {
            SampleDataImporter.Create(Console.Out).Import();
        }
    }
}

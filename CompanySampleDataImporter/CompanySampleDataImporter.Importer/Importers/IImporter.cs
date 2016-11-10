using CompanySampleDataImporter.Data;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanySampleDataImporter.Importer.Importers
{
    public interface IImporter
    {
        string Message { get; }

        int Order { get; }

        Action<CompanyEntities, TextWriter> Get { get; }

        //In the SqlServer studio after every importer:
        //USE Company;
        //DELETE FROM[Company].[dbo].[Departments]
        //DELETE FROM[Company].[dbo].[Employees]
    }
}

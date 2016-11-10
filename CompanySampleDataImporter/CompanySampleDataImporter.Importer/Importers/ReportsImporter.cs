using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CompanySampleDataImporter.Data;

namespace CompanySampleDataImporter.Importer.Importers
{
    public class ReportsImporter : IImporter
    {
        public Action<CompanyEntities, TextWriter> Get
        {
            get
            {
                return (db, tr) =>
                {
                    var employeeIds = db.Employees
                    .Select(e => e.Id)
                    .ToList();

                    for (int i = 0; i < employeeIds.Count; i++)
                    {
                        var numberOfReports = RandomGeneerator.GetRandomNumber(25, 75);

                        for (int j = 0; j < numberOfReports; j++)
                        {
                            db.Reports.Add(new Report
                            {
                                EmployeeId = employeeIds[i],
                                Time = RandomGeneerator.GetRandomDate(before: DateTime.Now)
                            });

                            tr.Write(".");

                            db.SaveChanges();
                            db.Dispose();
                            db = new CompanyEntities();
                        }
                    }
                };

            }
        }

        public string Message
        {
            get
            {
                return "Importing reports";
            }
        }

        public int Order
        {
            get
            {
                return 5;
            }
        }
    }
}

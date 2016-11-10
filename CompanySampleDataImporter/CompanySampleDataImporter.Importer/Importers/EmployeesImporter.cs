using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CompanySampleDataImporter.Data;

namespace CompanySampleDataImporter.Importer.Importers
{
    public class EmployeesImporter : IImporter
    {
        private const int NumberOfEmployees = 5000;

        public Action<CompanyEntities, TextWriter> Get
        {
            get
            {
                return (db, tr) =>
                {
                    var deparmentIds = db.Departments
                    .Select(d => d.Id)
                    .ToList();

                    for (int i = 0; i < NumberOfEmployees; i++)
                    {
                        var randomDepartmentIndex = RandomGeneerator.GetRandomNumber(0, deparmentIds.Count -1);
                        var randomDepartmentId = deparmentIds[randomDepartmentIndex];

                        db.Employees.Add(new Employee
                        {
                            FirstName = RandomGeneerator.GetRandomString(5, 20),
                            LastName = RandomGeneerator.GetRandomString(5, 20),
                            YearSalary = RandomGeneerator.GetRandomNumber(50000, 200000),
                            DepartmentId = randomDepartmentId
                        });
                        //Console progress
                        if (i % 10 == 0)
                        {
                            tr.Write(".");
                        }

                        if (i % 100 == 0)
                        {
                            db.SaveChanges();
                            db.Dispose();
                            db = new CompanyEntities();
                        }
                    }

                    db.SaveChanges();
                };
            }
        }

        public string Message
        {
            get
            {
                return "Importing employees";
            }
        }

        public int Order
        {
            get
            {
                return 2;
            }

        }
    }
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CompanySampleDataImporter.Data;

namespace CompanySampleDataImporter.Importer.Importers
{
    public class ProjectsImporter : IImporter
    {
        private const int NumberOfProjects = 1000;

        public Action<CompanyEntities, TextWriter> Get
        {
            get
            {
                return (db, tr) =>
                {
                    var allEmployeesId = db.Employees
                    .OrderBy(e => Guid.NewGuid())
                    .Select(e => e.Id)
                    .ToList();

                    var currentEmployeeIndex = 0;
                    for (int i = 0; i < NumberOfProjects; i++)
                    {
                        var currentProject = new Project
                        {
                            Name = RandomGeneerator.GetRandomString(5, 50)
                        };

                        var numberOfEmployeesPerProject = RandomGeneerator.GetRandomNumber(2, 8);

                        for (int j = 0; j < numberOfEmployeesPerProject; j++)
                        {
                            if (j + currentEmployeeIndex >= allEmployeesId.Count)
                            {
                                break;
                            }

                            var currentEmployeeId = allEmployeesId[currentEmployeeIndex];
                            var startDate = RandomGeneerator.GetRandomDate(before: DateTime.Now.AddDays(-100));

                            currentProject.ProjectsEmployees.Add(new ProjectsEmployee
                            {
                                EmployeeId = currentEmployeeId,
                                StartDate = startDate,
                                EndDate = RandomGeneerator.GetRandomDate(after: startDate)
                            });

                            currentEmployeeIndex++;
                        }

                        db.Projects.Add(currentProject);
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
                return "Importing projects";
            }
        }

        public int Order
        {
            get
            {
                return 4;
            }
        }
    }
}

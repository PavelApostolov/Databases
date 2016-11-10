using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework
{
    public class Program
    {
        static void Main()
        {
            using (var db = new TelerikAcademyEntities())
            {
                //Find by Id and then delete or smth else
                var proj = db.Projects.Find(1);
                db.Projects.Remove(proj);
                db.SaveChanges();

                //db.Database.SqlQuery<Project>("SELECT * FROM Projects");

                var project = db.Projects
                    .FirstOrDefault(pr => pr.ProjectID == 1);

                var project2 = db.Projects
                    .ToList();

                var empls = db.Employees
                    .Where(e => e.Department.Name == "Sales")
                    .Select(e => new
                    {
                        Id = e.EmployeeID,
                        Name = e.FirstName + " " + e.LastName,
                        DepartmentName = e.Department.Name
                    })
                    .GroupBy(e => e.DepartmentName)
                    .ToList(); // FirstOrDefault(); //.All(pr => true); 

                //Add entry
                var town = new Town
                {
                    Name = "Sofia from console"
                };

                var address = new Address
                {
                    AddressText = "Mladost",
                    Town = town
                };

                //db.Towns.Add(town);
                db.Addresses.Add(address);
                db.SaveChanges();

                var towns = db.Towns
                    .Where(t => t.Addresses.Any())
                    .Select(t => new
                    {
                        t.Name,
                        Addresses = t.Addresses.Select(a => a.AddressText)
                    })
                    .ToList();

                var result = db.Towns
                    .Join(db.Addresses,
                    t => t.TownID, a => a.TownID,
                    (t, a) => new
                    {
                        TownName = t.Name,
                        AddressTexts = a.AddressText
                    })
                    .ToList();

                var empl = db.Employees
                    .Select(e => new
                    {
                        FullName = e.FirstName + " " + e.LastName,
                        Town = e.Address.Town.Name,
                        Address = e.Address.AddressText,
                        Projects = e.Projects.Select(pr => pr.Name).FirstOrDefault(),
                        Departments = e.Department.Name
                    })
                    .FirstOrDefault();

                var emplGroups = db.Employees
                    .GroupBy(e => e.Department.Name)
                    .ToList();

                foreach (var emplGr in emplGroups)
                {
                    Console.WriteLine(emplGr.Key);

                    foreach (var employe in emplGr)
                    {
                        Console.WriteLine(employe.FirstName);
                    }
                }

                var employeeGroups = db.Employees
                    .GroupBy(e => new { e.Department.Name, TownName = e.Address.Town.Name })
                    .ToList();

                //Update
                var employee = db.Employees.FirstOrDefault();
                employee.FirstName = "Ivan";
                db.SaveChanges();

                //
                db.Employees
                    .Where(e => e.DepartmentID == 1 || e.DepartmentID == 2)
                    .GroupBy(e => e.Department.Name)
                    .Select(e => new
                    {
                        DepartmentName = e.Key,
                        EmployeesInGroup = e.Count()
                    });

                ////Delete category in Northwind
                //var cat = db.Categories.Find(11);
                //foreach (var product in cat.Products.ToList())
                //{
                //    db.Products.Rempve(product);
                //}
                //db.Categories.Remove(product);   

                //Add IsDeleted (data type - bit) +allow nulls to Products and Categories
                //Update models from database --> refresh tables and save
                //var cat = db.Categories.Find(11);
                //foreach (var product in cat.Products.ToList())
                //{
                //    product.IsDeleted = true;
                //} 
                //cat.IsDeleted = true;
                //db.SaveChanges();

                //db.Products.Where(pr => !pr.IsDeleted.HasValue || !pr.IsDeleted.Value)
                // .Select(pr => pr.CategoryName)
                // .ToList()
                // .ForEach(Console.WriteLine);

                ////Stored Procedures
                //var min = db.Orders.Min(o => o.ShippedDate);
                //var max = db.Orders.Max(o => o.ShippedDate);
                //min = min.Value.AddDays(100);
                //var result = db.Sales_by_Year(min, max);
                //Console.WriteLine(result.Count());

                Console.WriteLine(project2.Count);
            }
        }
    }
}

////Attach and Detach
//var product = GetProductById(6);
//var entry = dbContext.Entry(product);
//entry.State = EntityFramework.State.Modified;
//    product.ProductName += " Updated";
// dbContext.SaveChanges();
// Console.WriteLine(product.ProductName);

    //private static Product GetProductById(int id)
    //{
    //  var dbContext = new NorthWindEntities();
    //  using(dbContext)
    //  {
    //      return dbContext.Products.Find(id);
    //  }
    //}
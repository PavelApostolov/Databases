using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;
using CarsSystem.Console.Models;
using CarsSystem.Models;
using CarsSystem.Data;

namespace CarsSystem.Console
{
    public static class JsonCarsImporter
    {
        private const string JsonFilePathFormat = "/Data.Json.Files/data.{0}.json";

        public static void Import()
        {
            var carsToAdd = Directory.GetFiles(Directory.GetCurrentDirectory() + "/Data.Json.Files/")
                .Where(f => f.EndsWith(".json"))
                .Select(f => File.ReadAllText(f))
                .SelectMany(str => JsonConvert.DeserializeObject<IEnumerable<JsonCarModel>>(str))
                .ToList();

            var addedCities = new HashSet<string>();
            var addedManufacturers = new HashSet<string>();

            System.Console.WriteLine("Adding cars");
            var addedCars = 0;
            var db = new CarsSystemDbContext();
            db.Configuration.AutoDetectChangesEnabled = false;
            foreach (var car in carsToAdd)
            {
                var cityName = car.Dealer.City;
                if (!addedCities.Contains(cityName))
                {
                    var city = new City
                    {
                        Name = cityName
                    };

                    db.Cities.Add(city);
                    db.SaveChanges();

                    addedCities.Add(cityName);
                }

                var manufacturer = car.Manufacturer;
                if (!addedManufacturers.Contains(manufacturer))
                {
                    var newManufacturer = new Manufacturer
                    {
                        Name = manufacturer
                    };

                    addedManufacturers.Add(manufacturer);

                    db.Manufacturers.Add(newManufacturer);
                    db.SaveChanges();
                }

                var dealerToAdd = new Dealer
                {
                    Name = car.Dealer.Name
                };

                var dbCity = db.Cities.FirstOrDefault(c => c.Name == cityName);

                dealerToAdd.Cities.Add(dbCity);

                var dbManufacturer = db.Manufacturers
                    .FirstOrDefault(m => m.Name == car.Manufacturer);

                var carToAdd = new Car
                {
                    Manufacturer = dbManufacturer,
                    Dealer = dealerToAdd,
                    Model = car.Model,
                    Price = car.Price,
                    Transmission = (TransmissionType)car.TransmissionType,
                    Year = car.Year
                };

                db.Cars.Add(carToAdd);

                if (addedCars % 100 == 0)
                {
                    System.Console.Write(".");
                    db.SaveChanges();
                    db.Dispose();
                    db = new CarsSystemDbContext();
                    db.Configuration.AutoDetectChangesEnabled = false;
                }

                addedCars++;           
            }

            db.SaveChanges();
            db.Configuration.AutoDetectChangesEnabled = true;
        }
    }
}

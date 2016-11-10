using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarsSystem.Console.Models
{
    public class JsonCarModel
    {
        public ushort Year { get; set; }
        public int TransmissionType { get; set; }
        public string Manufacturer { get; set; }
        public string Model { get; set; }
        public decimal Price { get; set; }
        public JsonDealerModel Dealer { get; set; }
    }
}

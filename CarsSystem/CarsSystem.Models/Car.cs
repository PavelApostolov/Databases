using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarsSystem.Models
{
    public class Car
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(25)]
        public string Model { get; set; }

        public TransmissionType Transmission { get; set; }

        public ushort Year { get; set; }

        public decimal Price { get; set; }

        public int DealerId { get; set; }

        public virtual Dealer Dealer { get; set; }

        public int MaufacturerId { get; set; }

        public virtual Manufacturer Manufacturer { get; set; }
    }
}

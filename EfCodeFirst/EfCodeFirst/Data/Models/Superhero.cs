using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfCodeFirst.Data.Models
{
    class Superhero
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string SecretIdentity { get; set; }

        public virtual ICollection<Power> Powers { get; set; }
    }
}

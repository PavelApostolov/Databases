using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ArtistsSystem.Models
{
    public class Artist
    {
        private ICollection<Album> albums;

        public Artist()
        {
            this.Members = 1;
            this.albums = new HashSet<Album>();
        }

        public int Id { get; set; }

        [Required(ErrorMessage = "Artist must have a name")]
        [MaxLength(50)]
        [MinLength(2)]
        public string Name { get; set; }

        [Range(0, 100)]
        public int Age { get; set; }

        public GenderType Gender { get; set; }

        public int Members { get; set; }

        public virtual ICollection<Album> Albums
        {
            get { return this.albums; }
            set { this.albums = value; }
        }
    }
}

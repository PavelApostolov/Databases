using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Models
{
    public class Book
    {
        private ICollection<Review> reviews;
        private ICollection<Author> authors;
        //private ICollection<BookAuthors> authors;

        public Book()
        {
            this.reviews = new HashSet<Review>();
            //this.authors = new HashSet<BookAuthors>();
            this.authors = new HashSet<Author>();
        }

        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Index(IsUnique = true)]
        [MinLength(13)]
        [MaxLength(13)]
        public string ISBN { get; set; }

        public decimal? Price { get; set; }

        public string WebSite { get; set; }

        public virtual ICollection<Review> Reviews
        {
            get { return this.reviews; }
            set { this.reviews = value; }
        }

        public virtual ICollection<Author> Authors
        {
            get { return this.authors; }
            set { this.authors = value; }
        }
    }
}

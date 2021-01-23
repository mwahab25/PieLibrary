using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoffeeWeb.Models
{
    public class Book
    {
        public int BookId { get; set; }
        public string BookName { get; set; }
        public virtual Author Author { get; set; }
        public virtual Publisher Publisher { get; set; }
        public virtual Shelf Shelf { get; set; }
    }
}

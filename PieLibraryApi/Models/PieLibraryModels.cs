using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PieLibraryApi.Models
{
    public interface IAuditableEntity
    {
        DateTime CreatedDate { get; set; }
    }
    public abstract class AuditableEntity : IAuditableEntity
    {
        [Required, DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [DataType(DataType.Date)]   
        public DateTime CreatedDate { get; set; }

    }

    public class Author : AuditableEntity
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AuthorId { get; set; }
        public string AuthorName { get; set; }
        public virtual ICollection<Book> Books { get; set; }
    }
    public class Publisher : AuditableEntity
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PublisherId { get; set; }
        public string PublisherName { get; set; }
        public virtual ICollection<Book> Books { get; set; }
    }
    public class Shelf : AuditableEntity
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ShelfId { get; set; }
        public string ShelfName { get; set; }
        public virtual ICollection<Book> Books { get; set; }
    }
    public class Book : AuditableEntity
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BookId { get; set; }
        public string BookName { get; set; }
        public int AuthorId { get; set; }
        public int PublisherId { get; set; }
        public int ShelfId { get; set; }

        [ForeignKey("AuthorId")]
        public virtual Author Author { get; set; }

        [ForeignKey("PublisherId")]
        public virtual Publisher Publisher { get; set; }

        [ForeignKey("ShelfId")]
        public virtual Shelf Shelf { get; set; }
    }
}

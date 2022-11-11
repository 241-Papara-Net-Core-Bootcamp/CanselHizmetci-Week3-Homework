using System.ComponentModel.DataAnnotations.Schema;

namespace RepositoryPattern.Domain.Entities
{
    [Table("Books")]
    public class Book:BaseEntity
    {
        public string Name { get; set; }
        public string Genre { get; set; }
        public DateTime PublishDate { get; set; }
        public int PageCount { get; set; }
        public Author Author { get; set; }
        public int AuthorId { get; set; }
    }
}

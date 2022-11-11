using System.ComponentModel.DataAnnotations.Schema;

namespace RepositoryPattern.Domain.Entities
{
    [Table("Authors")]
    public class Author:BaseEntity
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime BirthDate { get; set; }
        public string Bio { get; set; }
        public ICollection<Book> Books { get; set; }
    }
}

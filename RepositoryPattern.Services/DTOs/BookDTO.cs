namespace RepositoryPattern.Services.DTOs
{
    public class BookDTO
    {
        public string Name { get; set; }
        public string Genre { get; set; }
        public DateTime PublishDate { get; set; }
        public int PageCount { get; set; }
        public int AuthorId { get; set; }
    }
}

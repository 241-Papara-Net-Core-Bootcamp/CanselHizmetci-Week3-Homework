using RepositoryPattern.Data.Abstracts;
using RepositoryPattern.Domain.Entities;
using RepositoryPattern.Services.Abstracts;
using RepositoryPattern.Services.DTOs;

namespace RepositoryPattern.Services.Concretes
{
    public class BookService : IBookService
    {
        private readonly IRepository<Book> _repository;

        public BookService(IRepository<Book> repository)
        {
            _repository = repository;
        }

        public BookDTO? Get(int id)
        {
            return _repository.Get().Where(c => c.Id == id).Select(c=>new BookDTO
            {
                AuthorId = c.AuthorId,
                Genre = c.Genre,
                Name = c.Name,
                PageCount = c.PageCount,
                PublishDate = c.PublishDate
            }).FirstOrDefault();
        }

        public IEnumerable<BookDTO> GetAll()
        {
            return _repository.Get().Select(c => new BookDTO
            {
                AuthorId = c.AuthorId,
                Genre = c.Genre,
                Name = c.Name,
                PageCount = c.PageCount,
                PublishDate = c.PublishDate
            }).ToList();
        }

        public void Add(BookDTO dto)
        {
            _repository.Add(new Book
            {
                IsDeleted = false,
                AuthorId = dto.AuthorId,
                Genre = dto.Genre,
                Name = dto.Name,
                PageCount = dto.PageCount,
                PublishDate = dto.PublishDate,
                CreateDate = DateTime.Now
            });
        }

        public void Delete(int id)
        {
            _repository.Remove(id);
        }

        public void Update(int id, BookDTO dto)
        {
            _repository.Update(new Book()
            {
                Id = id,
                AuthorId = dto.AuthorId,
                Genre = dto.Genre,
                Name = dto.Name,
                PageCount = dto.PageCount,
                PublishDate = dto.PublishDate,
                LastUpdateDate = DateTime.Now
            });
        }
    }
}

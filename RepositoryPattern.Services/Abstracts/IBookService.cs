using RepositoryPattern.Services.DTOs;

namespace RepositoryPattern.Services.Abstracts
{
    public interface IBookService
    {
        BookDTO? Get(int id);
        IEnumerable<BookDTO> GetAll();
        void Add(BookDTO dto);
        void Delete(int id);
        void Update(int id, BookDTO dto);
    }
}

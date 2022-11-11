using RepositoryPattern.Services.DTOs;

namespace RepositoryPattern.Services.Abstracts
{
    public interface IAuthorService
    {
        AuthorDTO? Get(int id);
        IEnumerable<AuthorDTO> GetAll();
        void Add(AuthorDTO dto);
        void Delete(int id);
        void Update(int id, AuthorDTO dto);
    }
}
